using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using System.ComponentModel;


namespace MissionPlanner
{
    public class GridPlugin : MissionPlanner.Plugin.Plugin
    {
        

        ToolStripMenuItem but;
        GridUI gridui;

        public override string Name
        {
            get { return "Grid"; }
        }

        public override string Version
        {
            get { return "0.1"; }
        }

        public override string Author
        {
            get { return "Michael Oborne"; }
        }

        public override bool Init()
        {
            return true;
        }

        public override bool Loaded()
        {
            Grid.Host2 = Host;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridUI));
            var temp = (string)(resources.GetObject("$this.Text"));

            but = new ToolStripMenuItem(temp);
            but.Click += but_Click;

            bool hit = false;
            ToolStripItemCollection col = Host.FPMenuMap.Items;
            int index = col.Count;
            foreach (ToolStripItem item in col)
            {
                if (item.Text.Equals(Strings.AutoWP))
                {
                    index = col.IndexOf(item);
                    ((ToolStripMenuItem)item).DropDownItems.Add(but);
                    hit = true;
                    break;
                }
            }

            if (hit == false)
                col.Add(but);

            return true;
        }

        void but_Click(object sender, EventArgs e)
        {
            gridui = new GridUI(this);
            //MissionPlanner.Utilities.ThemeManager.ApplyThemeTo(gridui);

            if (Host.FPDrawnPolygon != null && Host.FPDrawnPolygon.Points.Count > 2)
            {
                GCSViews.Tiles.PathAcceptButtonVisible = true;
				GCSViews.Tiles.pathAcceptedEvent += pathAcceptedEventHandler;       
            }
            else
            {
                if (CustomMessageBox.Show("No polygon defined. Load a file?", "Load File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gridui.LoadGrid();
                    gridui.BUT_Accept_Click(sender, e);
                    GCSViews.Tiles.PathAcceptButtonVisible = true;
                }
                else
                {
                    CustomMessageBox.Show("Please define a polygon.", "Error");
                }
            }
        }

        private void pathAcceptedEventHandler(
            object sender,
            EventArgs e)
        {
            gridui.BUT_Accept_Click(sender, e);
        }

        public override bool Exit()
        {
            return true;
        }
    }
}
