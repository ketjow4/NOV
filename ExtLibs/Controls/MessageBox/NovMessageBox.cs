using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.Controls.MessageBox
{
	public static class NovMessageBox
	{
		public static DialogResult ShowDialog(MessageBoxType type, MessageBoxButtons buttons, string content, string title, string details = "")
		{
			NovMessageBoxForm form = new NovMessageBoxForm(type, buttons, content, title, details);
			return form.ShowDialog();
		}

		public static void Show(MessageBoxType type, MessageBoxButtons buttons, string content, string title, string details = "")
		{
			NovMessageBoxForm form = new NovMessageBoxForm(type, buttons, content, title, details);
			form.Show();
		}
	}
}
