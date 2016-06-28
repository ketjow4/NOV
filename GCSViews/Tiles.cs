using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using IronPython.Runtime.Operations;
using System.Threading;
using Slider = MissionPlanner.GCSViews.ValueSlider.ValueSlider;

using MissionPlanner.Mavlink;
using MissionPlanner.GCSViews.Modification; //classes for tiles
using MissionPlanner.Utilities;
using MissionPlanner.Validators;
using MessageBox = System.CustomMessageBox;

namespace MissionPlanner.GCSViews
{
    //ugly copy-paste from GridUI
    public enum StartPosition
    {
        HOME = 0,
        BOTLEFT = 1,
        TOPLEFT = 2,
        BOTRIGHT = 3,
        TOPRIGHT = 4
    }


    public class Tiles
    {
        public static bool armed = false;
        public static bool connected = false;
        public static bool pathAccepted = true;
        public static string camName = "GEOSCANNER";
        public static string startFrom = "HOME";
        public static StartPosition begin = 0;
        public static bool showFootprint = false;
        public static bool cameraFacingForward = false;
        public static bool guidedMode = false;


        public static int altMin = 25;
        public static int altMax = 500;

        //Ogar speed
        public static int fsMinOgar = 1;
        public static int fsMaxOgar = 10;

        //Albatros speed 
        public static int fsMinAlbatros = 17;
        public static int fsMaxAlbatros = 21;

        //Current speed limits
        public static int fsMin = 0;
        public static int fsMax = 0;

        public static void SetToView(List<TileInfo> list, Panel p)
        {
            foreach (var tile in list)
            {
                var panel = new Panel
                {
                    Size = new Size(ResolutionManager.TileWidth, ResolutionManager.TileHeight),
                    Location = new Point((int)(tile.Column * (ResolutionManager.TileWidth + ResolutionManager.MarginSize)),
                                         (int)(tile.Row * (ResolutionManager.TileHeight + ResolutionManager.MarginSize))),
                    Parent = p,
                    Name = tile.Label.Text,
                };

                panel.Controls.Add(tile.Label);

                p.Controls.Add(panel);
                panel.BringToFront();
            }
        }

    }
}
