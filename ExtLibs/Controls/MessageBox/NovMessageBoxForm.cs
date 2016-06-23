using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.Controls.MessageBox
{
	public partial class NovMessageBoxForm : Form
	{
		private MessageBoxButton.ButtonClickEventHandler buttonClickHandler;

		public NovMessageBoxForm(MessageBoxType type, MessageBoxButtons buttons, string content, string title, string details)
		{
			InitializeComponent();
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
