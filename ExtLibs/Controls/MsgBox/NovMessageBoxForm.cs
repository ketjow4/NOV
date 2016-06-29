using MissionPlanner.Controls.Modification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
	public partial class NovMessageBoxForm : Form
	{
		private MessageBoxButton.ButtonClickEventHandler buttonClickHandler;
		private static int _width = 0;
		Color borderColor = Color.FromArgb(100, Color.White);

		public NovMessageBoxForm(MessageBoxType type, MessageBoxButtons buttons, string content, string title, string details)
		{
			InitializeComponent();
			if(_width != 0)
			{
				Size = new Size(_width, Size.Height);
			}
			InfoLabel.Text = title;
			ContentLabel.Text = content;
			if (!string.IsNullOrEmpty(details))
			{
				DetailsLabel.Text = details;
			}
			else
			{
				detailsSwitchPanel.Visible = false;
				detailsPanel.Visible = false;
			}
			Icon icon;
			buttonClickHandler = new MessageBoxButton.ButtonClickEventHandler(buttonClick);
			switch (type)
			{
				case MessageBoxType.INFO:
					icon = SystemIcons.Information;
					break;
				case MessageBoxType.ERROR:
					icon = SystemIcons.Error;
					break;
				case MessageBoxType.WARNING:
				default:
					icon = SystemIcons.Warning;
					break;
			}
			pictureBox1.Image = icon.ToBitmap();

			switch (buttons)
			{
				case MessageBoxButtons.OK:
					buttonInfo.Where(b => b.Caption == "OK").ToList()
						.ForEach(but => flowLayoutPanel1.Controls.Add(new MessageBoxButton(but.Caption, but.Result, buttonClickHandler)));
					break;
				case MessageBoxButtons.OKCancel:
					buttonInfo.Where(b => b.Caption == "OK" || b.Caption == "Cancel").ToList()
						.ForEach(but => flowLayoutPanel1.Controls.Add(new MessageBoxButton(but.Caption, but.Result, buttonClickHandler)));
					break;
				case MessageBoxButtons.AbortRetryIgnore:
					buttonInfo.Where(b => b.Caption == "Abort" || b.Caption == "Retry" || b.Caption == "Ignore").ToList()
						.ForEach(but => flowLayoutPanel1.Controls.Add(new MessageBoxButton(but.Caption, but.Result, buttonClickHandler)));
					break;
				case MessageBoxButtons.YesNoCancel:
					buttonInfo.Where(b => b.Caption == "Yes" || b.Caption == "No" || b.Caption == "Cancel").ToList()
						.ForEach(but => flowLayoutPanel1.Controls.Add(new MessageBoxButton(but.Caption, but.Result, buttonClickHandler)));
					break;
				case MessageBoxButtons.YesNo:
					buttonInfo.Where(b => b.Caption == "Yes" || b.Caption == "No").ToList()
						.ForEach(but => flowLayoutPanel1.Controls.Add(new MessageBoxButton(but.Caption, but.Result, buttonClickHandler)));
					break;
				case MessageBoxButtons.RetryCancel:
					buttonInfo.Where(b => b.Caption == "Retry" || b.Caption == "Cancel").ToList()
						.ForEach(but => flowLayoutPanel1.Controls.Add(new MessageBoxButton(but.Caption, but.Result, buttonClickHandler)));
					break;
				default:
					break;
			}
			
			
			List<Control> controls = new List<Control>() { InfoLabel, tableLayoutPanel2, tableLayoutPanel5, detailsPanel };
			foreach (Control child in flowLayoutPanel1.Controls)
			{
				controls.Insert(0, child);
			}
			controls.ForEach(c => c.Paint += Control_Paint);
			SetFonts();
		}

		public void SetFonts()
		{
			InfoLabel.Font = new Font("Century Gothic", ResolutionManager.InputInfoFontSize, FontStyle.Regular);
			label2.Font = new Font("Century Gothic", ResolutionManager.InputButtonsFontSize, FontStyle.Regular);
			ContentLabel.Font = DetailsLabel.Font
				= new Font("Century Gothic", ResolutionManager.InputSmallTextFontSize, FontStyle.Regular);
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
		
		public static void setWidth(int width)
		{
			_width = width;
		} 

		private void buttonClick(object sender, ButtonClickEventArgs args)
		{
			DialogResult = args.Result;
			Close();
		}

		private ButtonInfo[] buttonInfo = {
			new ButtonInfo() { Caption = "OK", Result = DialogResult.OK },
			new ButtonInfo() { Caption = "Cancel", Result = DialogResult.Cancel },
			new ButtonInfo() { Caption = "Yes", Result = DialogResult.Yes },
			new ButtonInfo() { Caption = "No", Result = DialogResult.No },
			new ButtonInfo() { Caption = "Abort", Result = DialogResult.Abort },
			new ButtonInfo() { Caption = "Retry", Result = DialogResult.Retry },
			new ButtonInfo() { Caption = "Ignore", Result = DialogResult.Ignore }
		};
		
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			var chbox = sender as CheckBox;
			if (chbox.Checked)
			{
				detailsPanel.Visible = true;
			}
			else
			{
				detailsPanel.Visible = false;
			}
		}
	}
}
