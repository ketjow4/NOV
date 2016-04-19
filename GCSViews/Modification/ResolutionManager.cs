using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MissionPlanner.GCSViews.Modification
{
    class ResolutionManager
    {
        enum Resolutions
        {
            r1280x800,
            r1366x768,
            r1600x900,
            r1920x1080,
        };

        public static int TileWidth = 134;
        public static int TileHeight = 55;

        public static Size HUDSize = new Size(319, 240);
        public static Point HUDLocation = new Point(0, 555);

        public static Point WindDirLocation = new Point(132, 498);      //Y should be tileheight * windspeedlocationY;
        public static Size WindDirSize = new Size(55, 55);

        public static PointF WindSpeedLocation = new PointF(0, 8.725f);

        public static PointF PanicButtonLocation = new PointF(4, 12.9f);
        public static PointF AbortLandLocation = new PointF(5, 12.9f);

        public static Point DistBarLocation = new Point(140, 115);    
        public static Size DistBarSize = new Size(675, 35);

        public static int MarginSize = 2;

        public static float BottomOfScreenRow = 13.0f;

    }
}
