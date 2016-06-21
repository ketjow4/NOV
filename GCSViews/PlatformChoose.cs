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
    public partial class PlatformChoose : Form
    {
        public enum Platform
        {
            Albatros,
            Ogar ,
            Error = 100 
        }

        public Platform Result;

        public PlatformChoose()
        {
            InitializeComponent();
            this.Size = new Size(Modification.ResolutionManager.InputPanelSize.Width,Modification.ResolutionManager.ValueLabelWidth);
            foreach(var b in  Grid.Controls)
            {
                if(b is Button)
                    (b as Button).Font = new Font("Century Gothic", Modification.ResolutionManager.InputInfoFontSize, FontStyle.Regular);
            }
        }

        private void OgarButton_Click(object sender, EventArgs e)
        {
            Result = Platform.Ogar;
            Close();
        }

        private void AlbatrosButton_Click(object sender, EventArgs e)
        {
            Result = Platform.Albatros;
            Close();
        }

        private void PlatformChoose_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Result != Platform.Ogar && Result != Platform.Albatros)
                Result = Platform.Error;
        }
    }
}
