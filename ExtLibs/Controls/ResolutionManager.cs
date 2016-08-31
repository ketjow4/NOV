using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MissionPlanner.Controls.Modification
{
    public static class ResolutionManager
    {
        public enum Resolutions
        {
            r1280x800 = 0,
            r1366x768,      //1360x768 treated as 1366x768 
            r1600x900,
            r1920x1080,
            r1920x1200,
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

        public static float sizefactor = 1;

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
       
        #endregion

        public static Size InputPanelSize;
        public static Size SliderPanelSize;
		public static float InputInfoFontSize;
        public static float InputTextBoxFontSize;
        public static float InputButtonsFontSize;
        public static float InputSmallTextFontSize;
		public static Color InputWindowElementBorderColor = Color.FromArgb(100, Color.White);

		public static Size TransparentLabelSize;
        public static Point TransparentLabelLocation;
        public static Font TransparentLabelFont;

        public static Size PreFlightCheckSize;
        public static float PreFlightCheckFontButton;
        public static float PreFlightCheckFontCheckBox;
        public static float PreFlightCheckFontWarning;

        public static int FlightDataZoomTrackBarWidth;
        public static int FlightPlanningZoomTrackBarWidth;

        public static int MagicWidth;

        public static Size VideoPlayerHidden;
        public static Size VideoPlayerVisible;
        public static Point VideoPlayerLocationVisible;
        public static Point VideoPlayerLocationHidden;

        public static Size WaypointFormSize;

        public static Resolutions CurrentRes;

        private static int ScreenWidth;
        private static int ScreenHeight;


        public static void Initialize(int dpivalue)                     //TODO check if there should be any other things to change
        {
            BottomOfScreenRow = 13.1f;
            
            if (dpivalue == 120) sizefactor = 0.8f;
            if (dpivalue == 144) sizefactor = 0.66f;
            if (dpivalue == 192) sizefactor = 0.5f;
            if (dpivalue == 240) sizefactor = 0.41f;

            if (CurrentRes == Resolutions.r1600x900)
            {
                HUDSize = new Size(360, 270);
                TileWidth = 169;
                TileHeight = 62;
                MarginSize = 2;
                DistBarSize = new Size((TileWidth + MarginSize) * 5 - 3 * MarginSize, 35);        //TODO change this
                InputPanelSize = new Size(520, 470);
                SliderPanelSize = new Size(520, 240);

				MagicWidth = 150;
                
                TransparentLabelFont = new Font("Century Gothic", 40 * sizefactor);

                TileButtonFontSize = 13f * sizefactor;

                InputInfoFontSize = 25.25f * sizefactor;
                InputTextBoxFontSize = 27.0f * sizefactor;
                InputButtonsFontSize = 18.75f * sizefactor;
                InputSmallTextFontSize = 10.00f * sizefactor;

				FlightDataZoomTrackBarWidth = 52;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                HeadLabelFontSize = 12f * sizefactor;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 13f * sizefactor;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 95; //165 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 30;
                ValueLabelTop = TileHeight - 30 - 8;
                ValueLabelWidth = 110;
                ValueLabelFontSize = 20f * sizefactor;
                PreFlightCheckSize = new Size(500, 600);
                PreFlightCheckFontButton = TileButtonFontSize * sizefactor; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize * sizefactor;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize * sizefactor;//21.75f;

                WaypointFormSize = new Size(1000, 400);
            }
            else if (CurrentRes == Resolutions.r1366x768)
            {
                HUDSize = new Size(350, 260);
                if(ScreenWidth == 1360)
                    TileWidth = 143;
                else
                    TileWidth = 144;
                TileHeight = 53;
                MarginSize = 2;
                DistBarSize = new Size( (TileWidth+MarginSize)*5 - 3*MarginSize, 35);
                InputPanelSize = new Size(400, 370);
				SliderPanelSize = new Size(400, 185);

				MagicWidth = 120;

                TransparentLabelFont = new Font("Century Gothic", 36 * sizefactor);

                TileButtonFontSize = 11f * sizefactor;

                InputInfoFontSize = 20.25f * sizefactor;
                InputTextBoxFontSize = 24.0f * sizefactor;
                InputButtonsFontSize = 15.75f * sizefactor;
				InputSmallTextFontSize = 9.00f * sizefactor;

				if (ScreenWidth == 1360)
                {
                    FlightDataZoomTrackBarWidth = 46;
                    FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;
                }
                else
                {
                    FlightDataZoomTrackBarWidth = 43;
                    FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;
                }

                HeadLabelFontSize = 8f * sizefactor;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 10f * sizefactor;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100; //165 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 20;
                ValueLabelTop = TileHeight - 20 - 8;
                ValueLabelWidth = 90;
                ValueLabelFontSize = 15f * sizefactor;

                PreFlightCheckSize = new Size(500, 515);
                PreFlightCheckFontButton = TileButtonFontSize * sizefactor; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize * sizefactor;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize * sizefactor;//21.75f;

                WaypointFormSize = new Size(850, 341);
            }
            else if(CurrentRes == Resolutions.r1920x1080)
            {

                HUDSize = new Size(480, 360);
                TileWidth = 205;
                TileHeight = 75;
                MarginSize = 2;
                DistBarSize = new Size((TileWidth + MarginSize) * 5 - 3 * MarginSize, 35);
                InputPanelSize = new Size(700, 670);
				SliderPanelSize = new Size(700, 324);

				MagicWidth = 190;

                TransparentLabelFont = new Font("Century Gothic", 48 * sizefactor);

                FlightDataZoomTrackBarWidth = 48;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                TileButtonFontSize = 17f * sizefactor;

                InputInfoFontSize = 25.6f * sizefactor;
                InputTextBoxFontSize = 42.0f * sizefactor;
                InputButtonsFontSize = 20f * sizefactor;
				InputSmallTextFontSize = 14.00f * sizefactor;

				HeadLabelFontSize = 14f * sizefactor;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 15f * sizefactor;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100; //165 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 35;
                ValueLabelTop = TileHeight - 35 - 8;
                ValueLabelWidth = 135;
                ValueLabelFontSize = 22f * sizefactor;

                PreFlightCheckSize = new Size(550, 630);
                PreFlightCheckFontButton = (TileButtonFontSize - 0.5f) * sizefactor; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize * sizefactor;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize * sizefactor;//21.75f;

                WaypointFormSize = new Size(1000, 480);
            }
            else if(CurrentRes == Resolutions.r1920x1200)
            {
                BottomOfScreenRow = 13.15f;
                HUDSize = new Size(500, 380);
                TileWidth = 205;
                TileHeight = 83;
                MarginSize = 2;
                DistBarSize = new Size((TileWidth + MarginSize) * 5 - 3 * MarginSize, 35);
                InputPanelSize = new Size(700, 670);
				SliderPanelSize = new Size(700, 324);

				MagicWidth = 190;

                TransparentLabelFont = new Font("Century Gothic", 48 * sizefactor);

                TileButtonFontSize = 18f * sizefactor;

                FlightDataZoomTrackBarWidth = 48;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                InputInfoFontSize = 32.25f * sizefactor;
                InputTextBoxFontSize = 42.0f * sizefactor;
                InputButtonsFontSize = 26.75f * sizefactor;
				InputSmallTextFontSize = 14.00f * sizefactor;

				HeadLabelFontSize = 15f * sizefactor;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 16f * sizefactor;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100; //165 - 100
                UnitLabelTop = TileHeight - 27 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 39;
                ValueLabelTop = TileHeight - 39 - 8;
                ValueLabelWidth = 130;
                ValueLabelFontSize = 24f * sizefactor;

                PreFlightCheckSize = new Size(550, 630);
                PreFlightCheckFontButton = (TileButtonFontSize - 0.5f) * sizefactor; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize * sizefactor;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize * sizefactor;//21.75f;

                WaypointFormSize = new Size(1000, 533);
            }
            else //(CurrentRes == Resolutions.r1280x800)
            {
                HUDSize = new Size(320, 240);
                TileWidth = 134;
                TileHeight = 55;
                MarginSize = 2;
                DistBarSize = new Size((TileWidth + MarginSize) * 5 - 3 * MarginSize, 35);
                InputPanelSize = new Size(400, 370);
				SliderPanelSize = new Size(400, 185);

				MagicWidth = 120;

                TransparentLabelFont = new Font("Century Gothic", 36 * sizefactor);

                InputInfoFontSize = 22.25f * sizefactor;
                InputTextBoxFontSize = 24.0f * sizefactor;
                InputButtonsFontSize = 15.75f * sizefactor;
				InputSmallTextFontSize = 8.00f * sizefactor;

				TileButtonFontSize = 11f * sizefactor;

                FlightDataZoomTrackBarWidth = 48;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                HeadLabelFontSize = 8f * sizefactor;
                HeadLabelTop = 7;
                HeadLabelLeft = 2;
                HeadLabelWidth = TileWidth - 2 * MarginSize;  //130

                UnitLabelFontSize = 10f * sizefactor;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100;   //130 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 20;
                ValueLabelTop = TileHeight - 20 - 8;
                ValueLabelWidth = 80;
                ValueLabelFontSize = 15f * sizefactor;

                PreFlightCheckSize = new Size(415, 515);
                PreFlightCheckFontButton = TileButtonFontSize * sizefactor; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize * sizefactor;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize * sizefactor;//21.75f;

                WaypointFormSize = new Size(850, 400);
            }

            PanicButtonLocation = new PointF(4, BottomOfScreenRow - 0.1f);
            AbortLandLocation = new PointF(3, BottomOfScreenRow - 0.1f);

            TransparentLabelSize = new System.Drawing.Size((7 * ScreenWidth) / 16, (3 * ScreenHeight) / 9);
            TransparentLabelLocation = new Point((ScreenWidth - TransparentLabelSize.Width) / 2, (ScreenHeight - TransparentLabelSize.Height) / 2);
            PanelSize = new Size(TileWidth, TileHeight);
            HUDLocation = new Point(1, ScreenHeight - HUDSize.Height - 1);  //1 is because of some margin on flight info screen
            WindSpeedLocation = new PointF(0, (float)(ScreenHeight - HUDSize.Height - TileHeight - MarginSize) / (float)(TileHeight + MarginSize));
            WindDirLocation = new Point(TileWidth, (int)((TileHeight + MarginSize) * WindSpeedLocation.Y));
            WindDirSize = new Size(TileHeight, TileHeight);
            DistBarLocation = new Point(TileWidth + 3 * MarginSize, 2 * (TileHeight + MarginSize));

            VideoPlayerHidden = new Size(4 * (TileWidth + MarginSize) - MarginSize, 50);
            VideoPlayerVisible = new Size(4 * (TileWidth + MarginSize) - MarginSize, HUDSize.Height + TileHeight + 5);
            VideoPlayerLocationVisible = new Point(ScreenWidth - VideoPlayerVisible.Width - FlightDataZoomTrackBarWidth - 11, ScreenHeight - VideoPlayerVisible.Height - 5);
            VideoPlayerLocationHidden = new Point(ScreenWidth - VideoPlayerHidden.Width - FlightDataZoomTrackBarWidth - 11, ScreenHeight - VideoPlayerHidden.Height - 5);
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
            if ((width == 1366 || width == 1360) && height == 768)      //1366x768 or 1360x768 are treated the same
                CurrentRes = Resolutions.r1366x768;
            if (width == 1600 && height == 900)
                CurrentRes = Resolutions.r1600x900;
            if (width == 1920 && height == 1080)
                CurrentRes = Resolutions.r1920x1080;
            if (width == 1920 && height == 1200)
                CurrentRes = Resolutions.r1920x1200;
        }
    }
}
