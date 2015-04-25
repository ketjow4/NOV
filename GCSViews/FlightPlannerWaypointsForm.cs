using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MissionPlanner.GCSViews
{
    class FlightPlannerWaypointsForm
    {
        public delegate void ThemeManager(Control ctl);

        public static event ThemeManager ApplyTheme;

        public static void Show()
        {
            Form wp = new Form();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightPlanner));
            wp.SuspendLayout();
            Panel panelBASE = new Panel();
            panelBASE.SuspendLayout();
            //panel.Dock = DockStyle.Fill;

            resources.ApplyResources(panelBASE, "panelBASE");
            panelBASE.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);

            wp.Size = new Size(850, 400);
            wp.FormBorderStyle = FormBorderStyle.FixedSingle;
            wp.StartPosition = FormStartPosition.CenterScreen;
            FlightPlanner.instance.panelWaypoints.SuspendLayout();
            FlightPlanner.instance.panelWaypoints.Visible = true;
            FlightPlanner.instance.panelWaypoints.Dock = DockStyle.Fill;
           

            panelBASE.Controls.Add(FlightPlanner.instance.panelWaypoints);
            
            wp.Controls.Add(panelBASE);

            wp.FormClosing += (sender3, args3) => { FlightPlanner.instance.panelWaypoints.Visible = false; };
            wp.FormClosed += (sender2, args2) => { FlightPlanner.instance.panelWaypoints.Visible = false; };
            FlightPlanner.instance.panelWaypoints.ResumeLayout();
            panelBASE.ResumeLayout();
            wp.ResumeLayout();


            wp.ShowDialog();
        }

    }
}
