using System;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
	public class ButtonClickEventArgs: EventArgs
	{
		public DialogResult Result;

		public ButtonClickEventArgs(DialogResult result)
		{
			Result = result;
		}
	}
}
