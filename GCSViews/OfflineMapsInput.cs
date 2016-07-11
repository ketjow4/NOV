using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews
{
    public partial class OfflineMapsInput : Form
    {
        //private int tilesCount;
        //private double estimatedSizeMB;
        public event EventHandler OkClicked;
        private readonly double sizeOfTile = 0.054255525;

        public bool canceled = false;
        public List<int> tilesOnZoomLevel;

        private Thread downloadThread;


        public OfflineMapsInput(List<int> tilesOnZoomLevel_)
        {
            InitializeComponent();
            tilesOnZoomLevel = tilesOnZoomLevel_;
            downloadProgressBar.Value = 0;
            downloadProgressBar.Minimum = 0;
            downloadProgressBar.Maximum = 100;
            downloadProgressBar.Step = 1;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            downloadThread.Abort();
            canceled = true;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (OkClicked != null)
            {
                OkClicked(null, null);
            }
            this.Close();
        }

        private void MaxZoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (MaxZoomTrackBar.Value < MinZoomTrackBar.Value)
                MaxZoomTrackBar.Value = MinZoomTrackBar.Value;
            ChangeInfo();
        }

        private void MinZoomTrackBar_ValueChanged(object sender, EventArgs e)
        {

            if (MinZoomTrackBar.Value > MaxZoomTrackBar.Value)
                MinZoomTrackBar.Value = MaxZoomTrackBar.Value;
            ChangeInfo();
        }

        private void ChangeInfo()
        {
            int sum = 0;

            if (MaxZoomTrackBar.Value <= tilesOnZoomLevel.Count)
            {
                for (int i = MinZoomTrackBar.Value; i <= MaxZoomTrackBar.Value; i++)
                {
                    sum += tilesOnZoomLevel[i - 1];  //because zoom levels starts from 1 and list start index is 0
                }
                TilesCountLabel.Text = sum.ToString();
                EstimatedSizeMBLabel.Text = (sum * sizeOfTile).ToString("#.0");
            }
            else
            {
                TilesCountLabel.Text = "-";
                EstimatedSizeMBLabel.Text = "-";
            }

        }

        delegate void SetTilesCountLabelTextCallback(string text);
        delegate void SetEstimatedSizeMBLabelTextCallback(string text);

        private void SetTilesCountLabelText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.TilesCountLabel.InvokeRequired)
            {
                SetTilesCountLabelTextCallback d = new SetTilesCountLabelTextCallback(SetTilesCountLabelText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.TilesCountLabel.Text = text;
            }
        }

        private void SetEstimatedSizeMBLabelText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.EstimatedSizeMBLabel.InvokeRequired)
            {
                SetEstimatedSizeMBLabelTextCallback d = new SetEstimatedSizeMBLabelTextCallback(SetEstimatedSizeMBLabelText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.EstimatedSizeMBLabel.Text = text;
            }
        }

        public void refreshInfo()
        {
            int sum = 0;

            if (MaxZoomTrackBar.Value <= tilesOnZoomLevel.Count)
            {
                for (int i = MinZoomTrackBar.Value; i <= MaxZoomTrackBar.Value; i++)
                {
                    sum += tilesOnZoomLevel[i - 1];  //because zoom levels starts from 1 and list start index is 0
                }

                // TilesCountLabel.Text = sum.ToString();
                // EstimatedSizeMBLabel.Text = sum.ToString();
                SetTilesCountLabelText(sum.ToString());
                SetEstimatedSizeMBLabelText((sum * sizeOfTile).ToString("#.0"));
            }
            else
            {
                // TilesCountLabel.Text = "-";
                // EstimatedSizeMBLabel.Text = "-";
                SetTilesCountLabelText("-");
                SetEstimatedSizeMBLabelText("-");
            }
        }

        public void setDownloadThread(Thread downloadThr)
        {
            downloadThread = downloadThr;
        }


        public int MinZoom
        {
            get
            {
                return MinZoomTrackBar.Value;
            }
        }

        public int MaxZoom
        {
            get
            {
                return MaxZoomTrackBar.Value;
            }
        }

    }
}
