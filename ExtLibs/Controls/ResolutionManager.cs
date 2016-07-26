using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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

        public static Size WaypointFormSize;

        public static Resolutions CurrentRes;

        private static int ScreenWidth;
        private static int ScreenHeight;

        public static void Initialize()                     //TODO check if there should be any other things to change
        {
            BottomOfScreenRow = 13.1f;

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
                
                TransparentLabelFont = new Font("Century Gothic", 40);

                TileButtonFontSize = 13f;

                InputInfoFontSize = 23.25f;
                InputTextBoxFontSize = 27.0f;
                InputButtonsFontSize = 18.75f;
                InputSmallTextFontSize = 10.00f;

				FlightDataZoomTrackBarWidth = 52;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                HeadLabelFontSize = 12f;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 13f;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 95; //165 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 30;
                ValueLabelTop = TileHeight - 30 - 8;
                ValueLabelWidth = 110;
                ValueLabelFontSize = 20f;
                PreFlightCheckSize = new Size(500, 600);
                PreFlightCheckFontButton = TileButtonFontSize; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize;//21.75f;

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

                TransparentLabelFont = new Font("Century Gothic", 36);

                TileButtonFontSize = 11f;

                InputInfoFontSize = 20.25f;
                InputTextBoxFontSize = 24.0f;
                InputButtonsFontSize = 15.75f;
				InputSmallTextFontSize = 9.00f;

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

                HeadLabelFontSize = 8f;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 10f;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100; //165 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 20;
                ValueLabelTop = TileHeight - 20 - 8;
                ValueLabelWidth = 90;
                ValueLabelFontSize = 15f;

                PreFlightCheckSize = new Size(500, 515);
                PreFlightCheckFontButton = TileButtonFontSize; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize;//21.75f;

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

                TransparentLabelFont = new Font("Century Gothic", 48);

                FlightDataZoomTrackBarWidth = 48;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                TileButtonFontSize = 17f;

                InputInfoFontSize = 32.25f;
                InputTextBoxFontSize = 42.0f;
                InputButtonsFontSize = 26.75f;
				InputSmallTextFontSize = 14.00f;


				HeadLabelFontSize = 14f;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 15f;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100; //165 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 35;
                ValueLabelTop = TileHeight - 35 - 8;
                ValueLabelWidth = 135;
                ValueLabelFontSize = 22f;

                PreFlightCheckSize = new Size(550, 630);
                PreFlightCheckFontButton = TileButtonFontSize - 0.5f; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize;//21.75f;

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

                TransparentLabelFont = new Font("Century Gothic", 48);

                TileButtonFontSize = 18f;

                FlightDataZoomTrackBarWidth = 48;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                InputInfoFontSize = 32.25f;
                InputTextBoxFontSize = 42.0f;
                InputButtonsFontSize = 26.75f;
				InputSmallTextFontSize = 14.00f;

				HeadLabelFontSize = 15f;
                HeadLabelTop = 7;
                HeadLabelLeft = 4;
                HeadLabelWidth = TileWidth - 2 * MarginSize;    //165

                UnitLabelFontSize = 16f;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100; //165 - 100
                UnitLabelTop = TileHeight - 27 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 39;
                ValueLabelTop = TileHeight - 39 - 8;
                ValueLabelWidth = 130;
                ValueLabelFontSize = 24f;

                PreFlightCheckSize = new Size(550, 630);
                PreFlightCheckFontButton = TileButtonFontSize - 0.5f; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize;//21.75f;

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

                TransparentLabelFont = new Font("Century Gothic", 36);

                InputInfoFontSize = 20.25f;
                InputTextBoxFontSize = 24.0f;
                InputButtonsFontSize = 15.75f;
				InputSmallTextFontSize = 8.00f;

				TileButtonFontSize = 11f;

                FlightDataZoomTrackBarWidth = 48;
                FlightPlanningZoomTrackBarWidth = FlightDataZoomTrackBarWidth + 8;

                HeadLabelFontSize = 8f;
                HeadLabelTop = 7;
                HeadLabelLeft = 2;
                HeadLabelWidth = TileWidth - 2 * MarginSize;  //130

                UnitLabelFontSize = 10f;
                UnitLabelLeft = TileWidth - 2 * MarginSize - 100;   //130 - 100
                UnitLabelTop = TileHeight - 23 - 8;

                ValueLabelLeft = 4;
                ValueLabelHeight = 20;
                ValueLabelTop = TileHeight - 20 - 8;
                ValueLabelWidth = 80;
                ValueLabelFontSize = 15f;

                PreFlightCheckSize = new Size(415, 515);
                PreFlightCheckFontButton = TileButtonFontSize; // 11.25f;
                PreFlightCheckFontCheckBox = ValueLabelFontSize;//15.0f;
                PreFlightCheckFontWarning = InputInfoFontSize;//21.75f;

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
