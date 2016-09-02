using System;
using System.Threading;

namespace MissionPlanner.Controls
{
	public static class ProgressReporterDialogueTest
	{
		/*
		 *	This class shows the proper way to use ProgressReporterDialogue
		 */
		public static int WindowWidth = 500;

		public static void Test()
		{
			ProgressReporterDialogue prd = new ProgressReporterDialogue()
			{
				Text = "Test progress window",
				Width = WindowWidth
			};
			
			prd.DoWork += Prd_DoWork;
			prd.RunBackgroundOperationAsync();
		}

		private static void Prd_DoWork(object sender, ProgressWorkerEventArgs e, object passdata = null)
		{
			ProgressReporterDialogue prd = sender as ProgressReporterDialogue;
			for (int i = 0; i <= 100; i++)
			{
				if (e.CancelRequested)
				{
					e.CancelAcknowledged = true;
					break;
				}
				else
				{
					string message = string.Empty;
					if (i < 30)
					{
						message = "Preparation...";
					}
					else if (i < 66)
					{
						message = "Performing actions...";
					}
					else
					{
						message = "Finalizing...";
					}
					if (i == 80)
					{
						e.ErrorMessage = "These are some horrible details...";
						throw new Exception("Failed to complete operation");
					}
					prd.UpdateProgressAndStatus(i, message);
					Thread.Sleep(50);
				}
			}
			prd.UpdateProgressAndStatus(100, "Ready!");
			Thread.Sleep(1000);
		}
	}
}
