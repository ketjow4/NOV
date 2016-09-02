using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using MissionPlanner.Controls.Modification;

namespace MissionPlanner.GCSViews
{
    public partial class VideoPlayer : UserControl
    {
        #region DLL Imports

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int command);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);

        private const int SWP_NOOWNERZORDER = 0x200;
        private const int SWP_NOREDRAW = 0x8;
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_EX_MDICHILD = 0x40;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int SWP_NOACTIVATE = 0x10;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        private const int SWP_NOMOVE = 0x2;
        private const int SWP_NOSIZE = 0x1;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;
        private const int WS_CHILD = 0x40000000;

        #endregion

        private Process p = null;
        private IntPtr appWin;


        private bool IsDocked = false;
        private bool IsRunning = false;
        private bool IsHidden = false;

        public VideoPlayer()
        {
            InitializeComponent();
            ChangeTaskBarVisibility(false);
            Thread t = new Thread(() => 
            {
                while (!this.IsHandleCreated) Thread.Sleep(20);
                this.BeginInvoke(new MethodInvoker(delegate { HideVideoPlayer(); }));
            } );
            t.Start();
        }

        public static void ChangeTaskBarVisibility(bool show)
        {
            IntPtr hWnd = FindWindow("Shell_TrayWnd", "");
            if (show == true)
            { 
                ShowWindow(hWnd, 1);
            }
            else
            {  
                ShowWindow(hWnd, 0);
            }
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            if(IsHidden)
            { 
                ShowVideoPlayer();
            }
            else
            {
                HideVideoPlayer();
            }

        }

        private void HideVideoPlayer()
        {
            splitContainer1.Panel2Collapsed = true;
            this.Location = ResolutionManager.VideoPlayerLocationHidden;
            this.Size = ResolutionManager.VideoPlayerHidden;
            HideButton.Text = "SHOW";
            IsHidden = true;
        }

        private void ShowVideoPlayer()
        {
            splitContainer1.Panel2Collapsed = false;
            this.Location = ResolutionManager.VideoPlayerLocationVisible;
            this.Size = ResolutionManager.VideoPlayerVisible;
            HideButton.Text = "HIDE";
            IsHidden = false;
        }

        private void DockButton_Click(object sender, EventArgs e)
        {
            if(IsRunning)
            { 
            if (IsDocked == true)
            {
                HideVideoPlayer();
                DockButton.Text = "DOCK";
                SetParent(appWin, new IntPtr(0));
                if (Screen.PrimaryScreen == Screen.AllScreens[1])
                    MoveWindow(appWin, Screen.AllScreens[0].Bounds.X, Screen.AllScreens[0].Bounds.Y, 
                        Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height, true);
                else
                    MoveWindow(appWin, Screen.AllScreens[1].Bounds.X, Screen.AllScreens[1].Bounds.Y, 
                        Screen.AllScreens[1].Bounds.Width, Screen.AllScreens[1].Bounds.Height, true);
            }
            else
            {
                ShowVideoPlayer();
                DockButton.Text = "UNDOCK";
                SetParent(appWin, splitContainer1.Panel2.Handle);
                // Move the window to overlay it on this window
                Thread.Sleep(100);
                MoveWindow(appWin, 0, 0, splitContainer1.Panel2.Width, splitContainer1.Panel2.Height, true);
            }
            IsDocked = !IsDocked;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(IsRunning)
            {
                if (appWin != IntPtr.Zero)
                {
                    // Post a colse message
                    p.CloseMainWindow();
                    // Clear internal handle
                    appWin = IntPtr.Zero;
                }
                StartButton.Text = "START";
                IsRunning = !IsRunning;
            }
            else
            { 
                try
                {
                    var Player = new ProcessStartInfo();
                    Player.FileName = @".\VideoPlayer\GStreamerReceiverWPF.exe";
                    Player.CreateNoWindow = false;
                    Player.ErrorDialog = false;
                    Player.UseShellExecute = false;
                    Player.Arguments = "title_bar off dragging off";
                    Player.WindowStyle = ProcessWindowStyle.Normal;

                    p = System.Diagnostics.Process.Start(Player);

                    // Wait for process to be created and enter idle condition
                    p.WaitForInputIdle();
                    Thread.Sleep(1000);
                    // Get the main handle
                    appWin = p.MainWindowHandle;

                    if (IsHidden)
                        ShowVideoPlayer();

                    // Put it into this form
                    SetParent(appWin, this.splitContainer1.Panel2.Handle);

                    // Move the window to overlay it on this window
                    MoveWindow(appWin, 0, 0, splitContainer1.Panel2.Width, splitContainer1.Panel2.Height, true);
                    IsRunning = !IsRunning;
                    IsDocked = true;
                    StartButton.Text = "STOP";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PhotoButton_Click(object sender, EventArgs e)
        {
            if(GCSViews.Tiles.connected)
                MainV2.comPort.setDigicamControl(true);     //NEED TESTING
            else
                CustomMessageBox.Show("First connect GCS to UAV", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
