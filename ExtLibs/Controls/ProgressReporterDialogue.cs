using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using System.Reflection;
using System.Threading;
using MissionPlanner.Controls.Modification;

namespace MissionPlanner.Controls
{
	public partial class ProgressReporterDialogue : Form
	{
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private MessageBoxButton.ButtonClickEventHandler buttonCloseHandler;
		private MessageBoxButton.ButtonClickEventHandler buttonCancelHandler;
		private Exception workerException;

		public ProgressWorkerEventArgs doWorkArgs;
		public delegate void DoWorkEventHandler(object sender, ProgressWorkerEventArgs e, object passdata = null);
		public event DoWorkEventHandler DoWork;

		internal object locker = new object();
		internal int _progress = -1;
		internal string _status = "";
		public bool Running = false;
		private bool errorVisible = false;

		private string text;
		Color borderColor;

		MessageBoxButton buttonClose, buttonCancel;

		public ProgressReporterDialogue()
		{
			InitializeComponent();
			borderColor = ResolutionManager.InputWindowElementBorderColor;
			doWorkArgs = new ProgressWorkerEventArgs();
			Text = text;

			detailsButtonPanel.Visible = false;
			errorPanel.Visible = false;
			pictureBox1.Visible = false;
			pictureBox1.Image = SystemIcons.Warning.ToBitmap();

			buttonCloseHandler = new MessageBoxButton.ButtonClickEventHandler(btn_Close_Click);
			buttonCancelHandler = new MessageBoxButton.ButtonClickEventHandler(btnCancel_Click);
			
			buttonClose = new MessageBoxButton("Close", DialogResult.OK, buttonCloseHandler);
			buttonCancel = new MessageBoxButton("Cancel", DialogResult.Abort, buttonCancelHandler);

			flowLayoutPanel1.Controls.Add(buttonClose);
			flowLayoutPanel1.Controls.Add(buttonCancel);
			buttonClose.Visible = false;

			List<Control> controls = new List<Control>() { Title, tableLayoutPanel2, showErrorDetailsButton, errorPanel, progressBar1 };
			foreach (Control child in flowLayoutPanel1.Controls)
			{
				controls.Insert(0, child);
			}
			controls.ForEach(c => c.Paint += Control_Paint);
			SetFonts();
		}

		public void SetFonts()
		{
			Title.Font = new Font("Century Gothic", ResolutionManager.InputInfoFontSize, FontStyle.Regular);
			showErrorDetailsButton.Font = new Font("Century Gothic", ResolutionManager.InputButtonsFontSize, FontStyle.Regular);
			ContentLabel.Font = DetailsLabel.Font
				= new Font("Century Gothic", ResolutionManager.InputSmallTextFontSize , FontStyle.Regular);
			IEnumerable<Control> buttons = ControlHelpers.GetAll(flowLayoutPanel1, typeof(Button));
			List<Control> buttonsList = new List<Control>(buttons);
			buttonsList.ForEach(b =>
				b.Font = new Font("Century Gothic", ResolutionManager.InputButtonsFontSize, FontStyle.Regular));
		}

		private void Control_Paint(object sender, PaintEventArgs e)
		{
			Control ctl = sender as Control;
			ControlPaint.DrawBorder(e.Graphics, ctl.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
		}

		private void showErrorDetailsButton_Click(object sender, EventArgs e)
		{
			errorVisible = !errorVisible;
			if (errorVisible)
			{
				errorPanel.Visible = true;
				showErrorDetailsButton.Text = "Hide error details.";
			}
			else
			{
				errorPanel.Visible = false;
				showErrorDetailsButton.Text = "Show error details.";
			}
		}

		public void RunBackgroundOperationAsync()
		{
			ThreadPool.QueueUserWorkItem(RunBackgroundOperation);
			ShowDialog();
		}

		private void RunBackgroundOperation(object o)
		{
			Running = true;
			log.Info("RunBackgroundOperation");

			try
			{
				Thread.CurrentThread.Name = "ProgressReporterDialogue Background thread";
			}
			catch { } // ok on windows - fails on mono
			// mono fix - ensure the dialog is running
			while (!IsHandleCreated)
			{
				Thread.Sleep(100);
			}
			try
			{
				Invoke((MethodInvoker)delegate
				{
					// make sure its drawn
					Refresh();
				});
			}
			catch { Running = false; return; }
			log.Info("Focus ctl ");
			try
			{
				Invoke((MethodInvoker)delegate
				{
					log.Info("in focus invoke");
					// if this windows isnt the current active windows, popups inherit the wrong parent.
					if (!Focused)
					{
						Focus();
						Application.DoEvents();
					}
				});
			}
			catch { Running = false; return; }

			try
			{
				log.Info("DoWork");
				DoWork?.Invoke(this, doWorkArgs);
				log.Info("DoWork Done");
			}
			catch (Exception e)
			{
				// The background operation thew an exception.
				// Examine the work args, if there is an error, then display that and the exception details
				// Otherwise display 'Unexpected error' and exception details
				timer1.Stop();
				ShowDoneWithError(e, doWorkArgs.ErrorMessage);
				Running = false;
				return;
			}

			// stop the timer
			timer1.Stop();

			// run once more to do final message and progressbar
			if (IsDisposed || Disposing || !IsHandleCreated)
			{
				return;
			}

			try
			{
				Invoke((MethodInvoker)delegate
				{
					timer1_Tick(null, null);
				});
			}
			catch
			{
				Running = false;
				return;
			}

			if (doWorkArgs.CancelRequested && doWorkArgs.CancelAcknowledged)
			{
				//ShowDoneCancelled();
				Content = "Cancelled.";
				Thread.Sleep(500);
				Running = false;
				BeginInvoke((MethodInvoker)Close);
				return;
			}

			if (!string.IsNullOrEmpty(doWorkArgs.ErrorMessage))
			{
				ShowDoneWithError(null, doWorkArgs.ErrorMessage);
				Running = false;
				return;
			}

			if (doWorkArgs.CancelRequested)
			{
				ShowDoneWithError(null, "Operation could not cancel");
				Running = false;
				return;
			}

			ShowDone();
			Running = false;
		}

		// Called as a possible last operation of the bg thread that was cancelled
		// - Hide progress bar 
		// - Set label text
		private void ShowDoneCancelled()
		{
			Invoke((MethodInvoker)delegate
			{
				progressPanel.Visible = false;
				Content = "Cancelled";
				buttonClose.Visible = true;
			});
		}

		// Called as a possible last operation of the bg thread
		// - Set progress bar to 100%
		// - Wait a little bit to allow the Aero progress animatiom to catch up
		// - Signal that we can close
		private void ShowDone()
		{
			if (!IsHandleCreated)
				return;

			Invoke((MethodInvoker)delegate
			{
				progressBar1.Style = ProgressBarStyle.Continuous;
				progressBar1.Value = 100;
				buttonCancel.Visible = false;
				buttonClose.Visible = false;
			});

			Thread.Sleep(1000);
			BeginInvoke((MethodInvoker)Close);
		}

		// Called as a possible last operation of the bg thread
		// There was an exception on the worker event, so:
		// - Show the error message supplied by the worker, or a default message
		// - Make visible the error icon
		// - Make the progress bar invisible to make room for:
		// - Add the exception details and stack trace in an expansion panel
		// - Change the Cancel button to 'Close', so that the user can look at the exception message a bit
		private void ShowDoneWithError(Exception exception, string doWorkArgs)
		{
			var errMessage = doWorkArgs ?? "There was an unexpected error";

			if (Disposing || IsDisposed)
				return;

			if (InvokeRequired)
			{
				try
				{
					Invoke((MethodInvoker)delegate
					{
						Text = "Error";
						Content = exception.Message;
						pictureBox1.Visible = true;
						progressPanel.Visible = false;
						buttonCancel.Visible = false;
						buttonClose.Visible = true;
						if(exception != null)
						{
							detailsButtonPanel.Visible = true;
							DetailsLabel.Text = errMessage;
						}
						workerException = exception;
					});
				}
				catch { } // disposing
			}

		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			// User wants to cancel - 
			// * Set the text of the Cancel button to 'Close'
			// * Set the cancel button to disabled, will enable it and let the user dismiss the dialogue
			//      when the async operation is complete
			// * Set the status text to 'Cancelling...'
			// * Set the progress bar to marquee, we don't know how long the worker will take to cancel
			// * Signal the worker.

			//this.btnCancel.Visible = false;
			Content = "Cancelling...";
			progressBar1.Style = ProgressBarStyle.Marquee;
			doWorkArgs.CancelRequested = true;
		}


		private void btn_Close_Click(object sender, EventArgs e)
		{
			// we have already cancelled, and this now a 'close' button
			Close();
		}

		/// <summary>
		/// Called from the BG thread
		/// </summary>
		/// <param name="progress">progress in %, -1 means inderteminate</param>
		/// <param name="status"></param>
		public void UpdateProgressAndStatus(int progress, string status)
		{
			// we don't let the worker update progress when  a cancel has been
			// requested, unless the cancel has been acknowleged, so we know that
			// this progress update pertains to the cancellation cleanup
			if (doWorkArgs.CancelRequested && !doWorkArgs.CancelAcknowledged)
				return;

			lock (locker)
			{
				_progress = progress;
				_status = status;
			}

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var message = this.workerException.Message
						  + Environment.NewLine + Environment.NewLine;
			//+ this.workerException.StackTrace;

			CustomMessageBox.Show(message, "Exception Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// prevent using invokes on main update status call "UpdateProgressAndStatus", as this is slow on mono
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (Disposing || IsDisposed)
				return;

			int pgv = -1;
			lock (locker)
			{
				pgv = _progress;
				Content = _status;
			}
			if (pgv == -1)
			{
				progressBar1.Style = ProgressBarStyle.Marquee;
			}
			else
			{
				progressBar1.Style = ProgressBarStyle.Continuous;
				try
				{
					progressBar1.Value = pgv;
				} // Exception System.ArgumentOutOfRangeException: Value of '-12959800' is not valid for 'Value'. 'Value' should be between 'minimum' and 'maximum'.
				catch { } // clean fail. and ignore, chances are we will hit this again in the next 100 ms
			}
		}

		private void ProgressReporterDialogue_Load(object sender, EventArgs e)
		{
			Focus();
		}

		private string Content
		{
			get
			{
				return ContentLabel.Text;
			}
			set
			{
				ContentLabel.Text = value;
			}
		}

		public override string Text
		{
			get
			{
				return text;
			}
			set
			{
				text = value;
			}
		}
	}

	public class ProgressWorkerEventArgs : EventArgs
	{
		public string ErrorMessage;
		public volatile bool CancelRequested;
		public volatile bool CancelAcknowledged;
	}
}
