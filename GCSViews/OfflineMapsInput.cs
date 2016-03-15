using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public OfflineMapsInput(List<int> tilesOnZoomLevel_)
        {
            InitializeComponent();
            tilesOnZoomLevel = tilesOnZoomLevel_;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            canceled = true;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
			if(OkClicked != null)
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
            for(int i = MinZoomTrackBar.Value; i <= MaxZoomTrackBar.Value; i++)
            {
                sum += tilesOnZoomLevel[i-1];  //because zoom levels starts from 1 and list start index is 0
            }
            TilesCountLabel.Text = sum.ToString();
            EstimatedSizeMBLabel.Text = (sum * sizeOfTile).ToString("#.0");
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
