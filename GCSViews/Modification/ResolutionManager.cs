using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MissionPlanner.GCSViews.Modification
{
    class ResolutionManager
    {
        public enum Resolutions
        {
            r1280x800 = 0,
            r1366x768,
            r1600x900,
            r1920x1080,
        };

        public static int TileWidth;
        public static int TileHeight;
        public static int MarginSize;

        public static Size HUDSize;
        public static Point HUDLocation;

        public static Point WindDirLocation;     
        public static Size WindDirSize;

        public static PointF WindSpeedLocation;

        public static PointF PanicButtonLocation;
        public static PointF AbortLandLocation;

        public static Point DistBarLocation;    
        public static Size DistBarSize;

        public static float BottomOfScreenRow;


        public static float TileButtonFontSize;

        #region TileInfoValues

        public static float HeadLabelFontSize;
        public static int HeadLabelTop;
        public static int HeadLabelLeft;
        public static int HeadLabelWidth;

        public static float UnitLabelFontSize;
        public static int UnitLabelLeft;
        public static int UnitLabelTop;

        public static int ValueLabelLeft;
        public static int ValueLabelHeight;
        public static int ValueLabelTop;
        public static int ValueLabelWidth;

        public static float ValueLabelFontSize;


        public static Size PanelSize;

        public static int MagicWidth;

        public static Resolutions CurrentRes;

        private static int ScreenWidth;
        private static int ScreenHeight;

        #endregion

        public static void Initialize()                     //TODO include size of InputDialog, WaypointsForm, check if there should be any other things to change
        {
            BottomOfScreenRow = 13.1f;

            if (CurrentRes == Resolutions.r1280x800)
            { 
                HUDSize = new Size(320, 240);
                TileWidth = 134;
                TileHeight = 55;
                MarginSize = 2;
                DistBarSize = new Size(675, 35);

                MagicWidth = 120;

                TileButtonFontSize = 11f;


                HeadLabelFontSize = 8f;
                HeadLabelTop = 7;
                HeadLabelLeft = 2;
                HeadLabelWidth = TileWidth - 2*MarginSize;  //130

                UnitLabelFontSize = 10f;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100;   //130 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 20;
                ValueLabelTop = TileHeight - 20 - 8;
                ValueLabelWidth = 80;
                ValueLabelFontSize = 15f;

            }
            if (CurrentRes == Resolutions.r1600x900)
            {
                HUDSize = new Size(360, 260);
                TileWidth = 169;
                TileHeight = 62;
                MarginSize = 2;
                DistBarSize = new Size(675, 35);

                MagicWidth = 150;

                TileButtonFontSize = 13f;


                HeadLabelFontSize = 12f;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 13f;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100; //165 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 30;
                ValueLabelTop = TileHeight - 30 - 8;
                ValueLabelWidth = 100;
                ValueLabelFontSize = 20f;
            }

            PanicButtonLocation = new PointF(4, BottomOfScreenRow - 0.1f);
            AbortLandLocation = new PointF(5, BottomOfScreenRow - 0.1f);

            PanelSize = new Size(TileWidth, TileHeight);
            HUDLocation = new Point(0, ScreenHeight - HUDSize.Height);
            WindSpeedLocation = new PointF(0, (float)(ScreenHeight - HUDSize.Height - TileHeight - MarginSize) / (float)(TileHeight + MarginSize));
            WindDirLocation = new Point(TileWidth, (int)((TileHeight + MarginSize) * WindSpeedLocation.Y));
            WindDirSize = new Size(TileHeight, TileHeight);
            DistBarLocation = new Point(TileWidth + 3 * MarginSize, 2 * (TileHeight + MarginSize));
        }


        /// <summary>
        /// Must be called before initialize
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        public static void ParseResolution(int width, int height)
        {
            ScreenHeight = height;
            ScreenWidth = width;
            if (width == 1280 && height == 800)
                CurrentRes = Resolutions.r1280x800;
            if (width == 1366 && height == 768)
                CurrentRes = Resolutions.r1366x768;
            if (width == 1600 && height == 900)
                CurrentRes = Resolutions.r1600x900;
            if (width == 1920 && height == 1080)
                CurrentRes = Resolutions.r1920x1080;
        }
    }
}
