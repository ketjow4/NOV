using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using MissionPlanner.Controls;
using System.Threading;
using MissionPlanner.Controls.MessageBox;

namespace System
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(string text, string details = "")
        {
			return NovMessageBox.ShowDialog(MessageBoxType.WARNING, MessageBoxButtons.OK, text, "WARNING", details);
        }

        public static DialogResult Show(string text, string caption, string details = "")
        {
			return NovMessageBox.ShowDialog(MessageBoxType.WARNING, MessageBoxButtons.OK, text, caption, details);
		}

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, string details = "")
        {
			return NovMessageBox.ShowDialog(MessageBoxType.WARNING, buttons, text, caption, details);
		}

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, string details = "")
        {
			MessageBoxType type;
			switch (icon)
			{
				case MessageBoxIcon.Information:
				case MessageBoxIcon.Question:
				case MessageBoxIcon.None:
					type = MessageBoxType.INFO;
					break;
				case MessageBoxIcon.Error:
					type = MessageBoxType.ERROR;
					break;
				case MessageBoxIcon.Warning:
				default:
					type = MessageBoxType.WARNING;
					break;
			}
			return NovMessageBox.ShowDialog(type, buttons, text, caption, details);
		}
    }
}