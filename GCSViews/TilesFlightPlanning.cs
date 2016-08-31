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
using MissionPlanner.Controls.Modification;
using MissionPlanner.GCSViews.Modification; //classes for tiles
using MissionPlanner.Utilities;
using MissionPlanner.Validators;
using MessageBox = System.CustomMessageBox;
using MissionPlanner.Comms;
using GMap.NET;
using MissionPlanner;

namespace MissionPlanner.GCSViews
{
    public class TilesFlightPlanning : Tiles
    {
        public static event EventHandler pathAcceptedEvent;

        private static List<TileButton> cameras_buttons;
        private static List<TileButton> startFromButtons;

        private static TileData flyingSpeed = null;
        private static TileData altInfo = null;
        private static TileData angleInfo = null;
        private static TileData groundResInfo = null;
        private static TileData flightTime = null;          //estimated flight time
        private static TileData distanceTile = null;
        private static TileButton accept = null;
        private static TileButton SaveWPFile = null;
        private static TileButton LoadWPFile = null;
        private static TileButton LoadWPPlatform = null;
        public static TileButton offlineMaps = null;
        public static TileButton cancelOfflineMaps = null;
        private static TileData sideLap = null;
        private static TileData overLap = null;
        private static TileData Images = null;
        private static TileButton writeWaypoints = null;
        private static TileData obsHeadBtn = null;
        private static TileData area = null;
        private static TileData distanceBetweenLines = null;
        private static TileData numberofStripes = null;
        private static TileData startFromBut = null;
        private static TileButton pathGenerationButton = null;
        private static TileButton Footprint = null;
        private static TileButton Camforward = null;
        private static TileButton ntripbutton = null;
        private static TileData DistanceToPlatform = null;
        private static TileButton Circle = null;
        private static TileButton PointPhoto = null;
        private static TileButton PolygonMode = null;
        private static TileData estimatedDistance = null;
        private static TileData estimatedTime = null;
        private static TileButton RoadModeButton = null;

        private static string polygonmodestring = "POLYGON\nMODE";
        public static EventHandler calcGrid = null;
        private static double groundRes;

        public static int AltitudeVal { get { return Convert.ToInt32(altInfo.Value); } set { altInfo.Value = value.ToString(); } } // duup so ugly!
        public static double GroundRes { set { groundRes = value; groundResInfo.Value = value.ToString(); } }
        public static int AngleVal { get { return Convert.ToInt32(angleInfo.Value); } set { angleInfo.Value = value.ToString(); } } // duup so ugly!
        public static int FlyingSpeed { get { return Convert.ToInt32(flyingSpeed.Value); } set { flyingSpeed.Value = value.ToString(); } }
        public static String Distance { set { distanceTile.Value = value; } get { return distanceTile.Value; } }
        public static String DistanceUnit { set { distanceTile.UnitLabel.Text = value; } }
        public static String EstimatedFlightTime { set { flightTime.Value = value; } get { return flightTime.Value; } }

        public static String Area { set { area.Value = value; } get { return area.Value; } }
        public static String DistanceBeteweenLines { set { distanceBetweenLines.Value = value; } get { return distanceBetweenLines.Value; } }
        public static String NumberOfStripes { set { numberofStripes.Value = value; } get { return numberofStripes.Value; } }

        public static int SideLap { get { return Convert.ToInt32(sideLap.Value); } set { sideLap.Value = value.ToString(); } }
        public static int OverLap { get { return Convert.ToInt32(overLap.Value); } set { overLap.Value = value.ToString(); } }
        public static int ImagesCount { set { Images.Value = value.ToString(); } }

        internal static ICommsSerial comPort = new SerialPort();
        private static System.Windows.Forms.ComboBox CMB_baudrate;
        private static System.Threading.Thread t12;


        #region ChangeFunctions

        public static void ChangeAlt(int v)
        {
            int val = v;
            if (val < altMin) val = altMin;
            else if (val > altMax) val = altMax;
            AltitudeVal = val;
            FlightPlanner.instance.TXT_DefaultAlt.Text = val.ToString();
            calcGrid?.Invoke(null, null);
        }

        public static void ChangeAlt(object sender, ChangeValueEventArgs<int> e)
        {
            ChangeAlt(e.Value);
        }

        public static void ChangeAngle(int v)
        {
            int val = v;
            if (val < 0) val = 360;
            else if (val > 360) val = 0;
            AngleVal = val;
            calcGrid?.Invoke(null, null);
        }

        public static void ChangeAngle(object sender, ChangeValueEventArgs<int> e)
        {
            ChangeAngle(e.Value);
        }

        public static void ChangeSpeed(int v)
        {
            int val = v;
            if (val < fsMinOgar) val = fsMinOgar;
            else if (val > fsMaxOgar) val = fsMaxOgar;
            FlyingSpeed = val;
            calcGrid?.Invoke(null, null);
        }

        public static void ChangeSpeed(object sender, ChangeValueEventArgs<int> e)
        {
            ChangeSpeed(e.Value);
        }

        public static void ChangeSideLap(int v)
        {
            int val = v;
            if (val > 100) val = 100;
            if (val < 0) val = 0;
            SideLap = val;
            calcGrid?.Invoke(null, null);
        }

        public static void ChangeSideLap(object sender, ChangeValueEventArgs<int> e)
        {
            ChangeSideLap(e.Value);
        }

        public static void ChangeOverLap(int v)
        {
            int val = v;
            if (val > 100) val = 100;
            if (val < 0) val = 0;
            OverLap = val;
            calcGrid?.Invoke(null, null);
        }

        public static void ChangeOverLap(object sender, ChangeValueEventArgs<int> e)
        {
            ChangeOverLap(e.Value);
        }

        #endregion


        public static void SetTilesFlightPlanning(Panel p)
        {
            altInfo = new TileData("ALTITUDE ", 0, 4, "m", AltitudeSettingEvent);
            if (MainV2.config.ContainsKey("TXT_DefaultAlt"))
                altInfo.Value = FlightPlanner.instance.TXT_DefaultAlt.Text = MainV2.config["TXT_DefaultAlt"].ToString();

            cameras_buttons = CreateCameraButtons();
            startFromButtons = CreateStartFromButtons();

            accept = new TileButton("ACCEPT\nPATH", 1, 1, AcceptPathEvent);
            Images = new TileData("IMAGES NUMBER", ResolutionManager.BottomOfScreenRow, 6, "");
            Images.Value = "0";

            var hideList = new TileInfo[] { accept, sideLap, overLap, Footprint, angleInfo, Camforward, flyingSpeed, startFromBut };

            List<TileInfo> hidelist2 = new List<TileInfo>();
            hidelist2.AddRange(hideList);
            hidelist2.AddRange(cameras_buttons.ToArray());
            hidelist2.AddRange(startFromButtons.ToArray());

            obsHeadBtn.ClickMethod(null, null);

            sideLap = new TileData("SIDELAP", 8, 8, "%", SidelapSettingEvent);
            overLap = new TileData("OVERLAP", 7, 8, "%", OverlapSettingEvent);
            flyingSpeed = new TileData("FLYING SPEED", 1, 4, "m/s", FlyingSettingEvent);
            flyingSpeed.Value = "3";
            Footprint = new TileButton("\u2610 FOOTPRINT", 4, 8, FootprintEvent);
            Camforward = new TileButton("\u2610   CAM\nFORWARD", 5, 8, CameraFacingForwardEvent);
            angleInfo = new TileData("ANGLE", 6, 8, "deg", AngleSettingEvent);

            var tilesFlightPlanning = new List<TileInfo>(new TileInfo[]
            {
                obsHeadBtn,
                accept,
                flyingSpeed,
                Footprint,
                angleInfo,
                Camforward,
                sideLap,overLap,startFromBut,

                ntripbutton = new TileButton("NTRIP", 0, 7,NTRIPevent),
                new TileButton("COMPASS\nCALIBRATION",ResolutionManager.BottomOfScreenRow,0, CompassCalibrationEvent),
                new TileButton("FLIGHT\nINFO", 0, 0, FlightInfoEvent),
                PolygonMode = new TileButton("POLYGON\nMODE", 0, 1, PolygonModeEvent),
                new TileButton("ADD START\nPOINT", 0, 2, AddStartPointEvent),
                new TileButton("CLEAR", 0, 3, ClearEvent),
                new TileButton("FLIGHT\nPLANNING", 1, 0, (sender, e) => { }, Color.FromArgb(255, 255, 51, 0)),
                pathGenerationButton = new TileButton("PATH\nGENERATION", 1, 1, PathGenerationEvent),
                new TileButton("ADD LANDING POINT", 1, 2, AddLandingPointEvent),
                new TileButton("SHOW WP",ResolutionManager.BottomOfScreenRow - 1,0,ShowWPEvent),
                new TileButton("LOAD\nPOLYGON",ResolutionManager.BottomOfScreenRow - 4,0,LoadPolygonFileEvent),
                new TileButton("SAVE\nPOLYGON",ResolutionManager.BottomOfScreenRow - 3,0,SavePolygonEvent),
                offlineMaps = new TileButton("OFFLINE\nMAPS",ResolutionManager.BottomOfScreenRow - 2,0,OfflineMapsEvent),
                cancelOfflineMaps = new TileButton("CANCEL",ResolutionManager.BottomOfScreenRow - 2,1,CancelOfflineMapsEvent),
                writeWaypoints = new TileButton("UPLOAD TO PLATFORM", 1, 6, SaveWPPlatformEvent),
                altInfo,
                SaveWPFile = new TileButton("SAVE WP FILE", 0,6, SaveWPFileEvent),
                Circle = new TileButton("\u2610 CIRCLE",4,8,CircleClicked),
                PointPhoto = new TileButton("\u2610 PHOTO",5,8,PointPhotoClicked),
                //RoadModeButton = new TileButton("ROAD MODE",6,8,RoadModeClicked),   //this feature is not finished yet 
                LoadWPFile = new TileButton("LOAD WP FILE", 0,5, LoadWPFileEvent),
                LoadWPPlatform = new TileButton("LOAD FROM PLATFORM",1,5,LoadWPPlatformEvent),

                Images,
                area = new TileData("AREA",ResolutionManager.BottomOfScreenRow,7,"km\u00B2"),
                distanceBetweenLines = new TileData("DIST BETWEEN IMAGES",ResolutionManager.BottomOfScreenRow - 1,7,"m"),
                numberofStripes = new TileData("NUMBER OF STRIPS",ResolutionManager.BottomOfScreenRow - 1,6,""),
                groundResInfo = new TileData("GROUND RES", ResolutionManager.BottomOfScreenRow, 5, "cm/p"),
                flightTime = new TileData("FLIGHT TIME", ResolutionManager.BottomOfScreenRow - 1, 8, "h:m:s"),
                distanceTile = new TileData("DISTANCE",ResolutionManager.BottomOfScreenRow,8,"km"),
                estimatedTime = new TileData("FLIGHT TIME", ResolutionManager.BottomOfScreenRow - 1, 8, "h:m:s"),
                estimatedDistance = new TileData("DISTANCE",ResolutionManager.BottomOfScreenRow,8,"km"),
            });
            tilesFlightPlanning.AddRange(cameras_buttons);
            tilesFlightPlanning.AddRange(startFromButtons);

            var sideValue = MainV2.config["grid_sidelap"];
            var overValue = MainV2.config["grid_overlap"];

            ChangeSideLap(Convert.ToInt32(sideValue));
            ChangeOverLap(Convert.ToInt32(overValue));
            AltitudeVal = altMin;

            SetToView(tilesFlightPlanning, p);

            tilesFlightPlanning.Where(tile => hidelist2.Contains(tile) && tile is TileButton)
                               .ForEach(tile => (tile as TileButton).Visible = false);

            PathPlanningTilesAreVisible(false);
            Circle.Visible = false;
            PointPhoto.Visible = false;


            cancelOfflineMaps.Visible = false;
            estimatedTime.Value = "0:00:00";
        }

        private static void PathPlanningTilesAreVisible(bool visibility)
        {
            sideLap.Visible = visibility;
            overLap.Visible = visibility;
            Footprint.Visible = visibility;
            Camforward.Visible = visibility;
            angleInfo.Visible = visibility;
            startFromBut.Visible = visibility;

            Images.Visible = visibility;
            area.Visible = visibility;
            distanceBetweenLines.Visible = visibility;
            numberofStripes.Visible = visibility;
            groundResInfo.Visible = visibility;
            flightTime.Visible = visibility;
            distanceTile.Visible = visibility;
        }

        #region EventsFlightPlanner

        private static void NTRIPevent(object sender, EventArgs args)
        {            
            comPort = new CommsNTRIP();
            try
            {
                comPort.Open();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error Connecting\nif using com0com please rename the ports to COM??\n" +
                                      ex.ToString());
                return;
            }
            SerialInjectGPS inject = new SerialInjectGPS();
            t12 = new System.Threading.Thread(new System.Threading.ThreadStart(inject.mainloop))
            {
                IsBackground = true,
                Name = "injectgps"
            };
            t12.Start();

        }

        private static void LoadPolygonFileEvent(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "All supported (*.kml *.kmz *.poly *.shp)| *.kml;*.kmz;*.poly;*.shp; |Google Earth KML| *.kml;*.kmz; |Polygon|*.poly; |Shape file|*.shp;";
                fd.Multiselect = false;
                DialogResult result = fd.ShowDialog();
                string file = fd.FileName;

                string ext = System.IO.Path.GetExtension(fd.FileName);
                if (ext == ".kml" || ext == ".kmz")
                    FlightPlanner.instance.loadKMLFileToolStripMenuItem_Click(file, e);
                else if (ext == ".poly")
                    FlightPlanner.instance.loadPolygonToolStripMenuItem_Click(file, e);
                else if (ext == ".shp")
                    FlightPlanner.instance.fromSHPToolStripMenuItem_Click(file, e); //NOT TESTED!!!
            }
        }

        private static void SavePolygonEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.savePolygonToolStripMenuItem_Click(null, null);
        }

        private static bool firstClick = true;


        private static void OfflineMapsEvent(object sender, EventArgs e)
        {
            //first click action
            if (firstClick)
            {
                FlightPlanner.instance.prefetchToolStripMenuItem_Click(sender, e);
                offlineMaps.Label.Text = "DOWNLOAD";
                cancelOfflineMaps.Visible = true;
                firstClick = false;
            }
            else
            {
                //second click action
                FlightPlanner.instance.DownloadOfflineMap();
                offlineMaps.Label.Text = "OFFLINE\nMAPS";
                firstClick = true;
            }
        }

        private static void CancelOfflineMapsEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.RestoreMainMapSettings();
            cancelOfflineMaps.Visible = false;
            offlineMaps.Label.Text = "OFFLINE\nMAPS";
            firstClick = true;
        }

        private static void ShowWPEvent(object sender, EventArgs e)
        {
            FlightPlannerWaypointsForm.Show();
        }

        private static void LoadWPPlatformEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.BUT_read_Click(null, null);
        }

        private static void SaveWPPlatformEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.BUT_write_Click(sender, e);
        }

        private static void LoadWPFileEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.BUT_loadwpfile_Click(null, null);
        }

        private static void SaveWPFileEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.BUT_saveWPFile_Click(null, null);
        }


        private static void AddStartPointEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.takeoffToolStripMenuItem_Click(null, null);
        }

        private static void AddLandingPointEvent(object sender, EventArgs e)
        {
            FlightPlanner.instance.landToolStripMenuItem_Click(null, null);
        }


        private static void FootprintEvent(object sender, EventArgs e)
        {
            if (showFootprint)
            {
                (sender as Label).Text = "\u2610 FOOTPRINT";       //unchecked
                showFootprint = !showFootprint;
            }
            else
            {
                (sender as Label).Text = "\u2612 FOOTPRINT";       //checked
                showFootprint = !showFootprint;
            }
            calcGrid?.Invoke(null, null);
        }

        private static void CameraFacingForwardEvent(object sender, EventArgs e)
        {
            if (cameraFacingForward)
            {
                (sender as Label).Text = "\u2610   CAM\nFORWARD";       //unchecked
                cameraFacingForward = !cameraFacingForward;
            }
            else
            {
                (sender as Label).Text = "\u2612   CAM\nFORWARD";       //checked
                cameraFacingForward = !cameraFacingForward;
            }
            calcGrid?.Invoke(null, null);

        }

        private static void StartFromButtonListEvent(object sender, EventArgs e)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            startFromButtons.ForEach(cam => cam.Visible = false);
            startFrom = (sender as Label).Text;
            startFromBut.Value = startFrom;
            StartPosition temp = (StartPosition)Enum.Parse(typeof(StartPosition), startFrom);
            begin = temp;
            if (!pathAccepted)
                calcGrid(null, null);
        }

        private static void StartFromHeadEvent(object sender, EventArgs e)
        {
            var x = !startFromButtons.ElementAt(0).Visible;
            startFromButtons.ForEach(but => but.Visible = x);
        }

        private static void CameraButtonListEvent(object sender, EventArgs e)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            startFromButtons.ForEach(cam => cam.Visible = false);
            camName = (sender as Label).Text;
            if (!pathAccepted)
                calcGrid(null, null);
            obsHeadBtn.Value = camName;
        }

        private static void ObservationHeadEvent(object sender, EventArgs e)
        {
            var x = !cameras_buttons.ElementAt(0).Visible;
            cameras_buttons.ForEach(cam => cam.Visible = x);
        }

        private static void PathGenerationEvent(object sender, EventArgs args)
        {
            if (!pathAccepted)          //cannot generate many paths at once
                return;
            SaveWPFile.Visible = false;
            LoadWPFile.Visible = false;
            LoadWPPlatform.Visible = false;
            writeWaypoints.Visible = false;
            accept.Visible = true;
            pathGenerationButton.Visible = false;
            ntripbutton.Visible = false;
            estimatedDistance.Visible = false;
            estimatedTime.Visible = false;

            PathPlanningTilesAreVisible(true);

            PolygonMode.Label.Text = polygonmodestring;
            FlightPlanner.instance.PolygonGridMode = true;
            Circle.Visible = false;
            PointPhoto.Visible = false;


            FlightPlanner.instance.pathGenerationMode = true;
            FlightPlanner.instance.MainMap.ZoomAndCenterMarkers("drawnpolygons");
            pathAccepted = false;

            var Host = new Plugin.PluginHost();
            ToolStripItemCollection col = Host.FPMenuMap.Items;
            int index = col.Count;
            foreach (
                var toolStripItem in
                    col.Cast<ToolStripItem>()
                        .Where(item => item.Text.Equals("Survey (Grid)"))
                        .OfType<ToolStripMenuItem>())
            {
                toolStripItem.PerformClick();
                break;
            }
        }

        private static void ClearEvent(object sender, EventArgs args)
        {
            GroundRes = 0.0;

            if (FlightPlanner.missionWaypointCount() > 0)
            {
                FlightPlanner.instance.clearMissionToolStripMenuItem_Click(null, null);
            }
            else
            {
                FlightPlanner.instance.clearPolygonToolStripMenuItem_Click(null, null);
            }
        }

        private static void PolygonModeEvent(object sender, EventArgs args)
        {
            var s = sender as Label;
            // todo YEAH HACKING EVERYWHERE!
            if (!FlightPlanner.instance.pathGenerationMode)
            {
                if (s.Text == polygonmodestring)
                {
                    s.Text = "WAYPOINT\nMODE";
                    FlightPlanner.instance.PolygonGridMode = false;

                    Circle.Visible = true;
                    PointPhoto.Visible = true;

                }
                else
                {
                    s.Text = polygonmodestring;
                    FlightPlanner.instance.PolygonGridMode = true;

                    Circle.Visible = false;
                    PointPhoto.Visible = false;
                }
            }
        }


        public static void AcceptPathEvent(object sender, EventArgs args)
        {
            FlightPlanner.instance.takeoffToolStripMenuItem_Click(null, null);     //always add takeoff at mission height
            pathAccepted = true;
            pathGenerationButton.Visible = true;
            accept.Visible = false; calcGrid = null;
            SaveWPFile.Visible = true;
            LoadWPFile.Visible = true;
            LoadWPPlatform.Visible = true;
            writeWaypoints.Visible = true;
            ntripbutton.Visible = true;

            PathPlanningTilesAreVisible(false);

            estimatedDistance.Visible = true;
            estimatedTime.Visible = true;



            if (pathAcceptedEvent != null)
            {
                pathAcceptedEvent(null, null);
                pathAcceptedEvent = null;

            }
            FlightPlanner.instance.pathGenerationMode = false;
            FlightPlanner.instance.calculateWaypointDistance();
        }

        

        private static void CompassCalibrationEvent(object sender, EventArgs args)
        {
            if (CustomMessageBox.Show("Do you want to do compass calibration", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MagCalib.DoGUIMagCalib();
            }
        }

        private static void FlightInfoEvent(object sender, EventArgs args)
        {
            MainV2.View.ShowScreen("FlightData");
            MainV2.instance.syncMapPositions(MainV2.instance.FlightPlanner.MainMap.Position);
            MainV2.instance.syncMapZooms(MainV2.instance.FlightPlanner.MainMap.Zoom);
        }

        private static void AngleSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            var intValidator = new NumericValidator<int>(0, 360);
            Slider slider = new Slider(intValidator, "ANGLE", AngleVal.ToString());
            slider.OnValidValueSet += ChangeAngle;
            if (slider.ShowDialog() == DialogResult.OK)
            {
                ChangeAngle(slider.Result);
            }
        }

        private static void AltitudeSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            var intValidator = new NumericValidator<int>(altMin, altMax);
            InputFlightPlanning<int> inputWindow = new InputFlightPlanning<int>(intValidator, "ALTITUDE", false, AltitudeVal.ToString());
            inputWindow.OnValidValueSet += ChangeAlt;
            if (inputWindow.ShowDialog() == DialogResult.OK)
            {
                ChangeAlt(inputWindow.Result);
            }
        }

        private static void FlyingSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            IValidator<int> intValidator;
            InputFlightPlanning<int> inputWindow;
            PlatformChoose.Platform platform = PlatformChoose.Platform.Error;

            if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2 && connected)
            {
                platform = PlatformChoose.Platform.Ogar;
            }
            else if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane && connected)
            {
                platform = PlatformChoose.Platform.Albatros;
            }
            else
            {
                PlatformChoose chooseWindow = new PlatformChoose();
                chooseWindow.ShowDialog();
                platform = chooseWindow.Result;
            }

            switch (platform)
            {
                case PlatformChoose.Platform.Albatros:
                    intValidator = new NumericValidator<int>(fsMinAlbatros, fsMaxAlbatros);
                    inputWindow = new InputFlightPlanning<int>(intValidator, "FLYING SPEED - ALBATROS", false, FlyingSpeed.ToString());
                    break;
                case PlatformChoose.Platform.Ogar:
                    intValidator = new NumericValidator<int>(fsMinOgar, fsMaxOgar);
                    inputWindow = new InputFlightPlanning<int>(intValidator, "FLYING SPEED - OGAR", false, FlyingSpeed.ToString());
                    break;
                case PlatformChoose.Platform.Error:
                default:
                    CustomMessageBox.Show("Error, operation is not valid");
                    return;
            }
            inputWindow.OnValidValueSet += ChangeSpeed;
            if (inputWindow.ShowDialog() == DialogResult.OK)
            {
                ChangeSpeed(inputWindow.Result);
                FlightPlanner.instance.addSpeedWaypoint(inputWindow.Result);
                FlightPlanner.instance.calculateWaypointDistance(); //updates time
            }
        }

        private static void SidelapSettingEvent(object sender, EventArgs args)
        {
            var intValidator = new NumericValidator<int>(0, 99);
            InputFlightPlanning<int> inputWindow = new InputFlightPlanning<int>(intValidator, "SIDELAP", false, SideLap.ToString());
            inputWindow.OnValidValueSet += ChangeSideLap;
            if (inputWindow.ShowDialog() == DialogResult.OK)
            {
                ChangeSideLap(inputWindow.Result);
            }
        }

        private static void OverlapSettingEvent(object sender, EventArgs args)
        {
            var intValidator = new NumericValidator<int>(0, 99);
            InputFlightPlanning<int> inputWindow = new InputFlightPlanning<int>(intValidator, "OVERLAP", false, OverLap.ToString());
            inputWindow.OnValidValueSet += ChangeOverLap;
            if (inputWindow.ShowDialog() == DialogResult.OK)
            {
                ChangeOverLap(inputWindow.Result);
            }
        }

        public static bool circleSet { get; set; } = false;

        private static void CircleClicked(object sender, EventArgs args)
        {
            if (!circleSet)
            {
                if (!pointPhotoSet)
                {
                    //Circle.ChangeButtonColor(Color.FromArgb(86, 87, 89));
                    (sender as Label).Text = "\u2612 CIRCLE";       //checked
                    circleSet = true;
                }
            }
            else
            {
                // Circle.ChangeButtonColor(Color.FromArgb(22, 23, 24));
                (sender as Label).Text = "\u2610 CIRCLE";       //unchecked
                circleSet = false;
            }



        }

        public static bool pointPhotoSet { get; set; } = false;

        private static void PointPhotoClicked(object sender, EventArgs args)
        {
            if (!pointPhotoSet)
            {
                if (!circleSet)
                {
                    // PointPhoto.ChangeButtonColor(Color.FromArgb(86, 87, 89));
                    (sender as Label).Text = "\u2612 PHOTO";       //checked
                    pointPhotoSet = true;
                }
            }
            else
            {
                //PointPhoto.ChangeButtonColor(Color.FromArgb(22, 23, 24));
                (sender as Label).Text = "\u2610 PHOTO";       //unchecked
                pointPhotoSet = false;
            }
        }

        public static bool roadModeSet { get; set; } = false;

        private static void RoadModeClicked(object sender, EventArgs args)
        {
            List<PointLatLng> list = FlightPlanner.instance.getWPList();

            RoadMode roadObj = new RoadMode(list);

            roadObj.work(30);

            list = roadObj.getWPs();

            for(int i =0;i<list.Count;i++)
            {
                FlightPlanner.instance.AddCommand(MAVLink.MAV_CMD.WAYPOINT, 0, 0, 0, 0, list[i].Lng, list[i].Lat, AltitudeVal);
            }

            //if (!roadModeSet)
            //{
            //    if (!circleSet)
            //    {
            //        // PointPhoto.ChangeButtonColor(Color.FromArgb(86, 87, 89));
            //        (sender as Label).Text = "\u2612 ROAD MODE";       //checked
            //        roadModeSet = true;
            //    }
            //}
            //else
            //{
            //    //PointPhoto.ChangeButtonColor(Color.FromArgb(22, 23, 24));
            //    (sender as Label).Text = "\u2610 ROAD MODE";       //unchecked
            //    roadModeSet = false;
            //}
        }

        #endregion

        private static List<TileButton> CreateCameraButtons()
        {
            obsHeadBtn = new TileData("PAYLOAD", 1, 3, "", ObservationHeadEvent);
            obsHeadBtn.ValueLabel.Width = ResolutionManager.MagicWidth;          //ugly !!!
            obsHeadBtn.Value = camName;

            cameras_buttons = new List<TileButton>();
            XmlHelper.ReadCameraName("noveltyCam.xml");

            int i = 0;
            foreach (var camera in XmlHelper.cameras)
            {
                cameras_buttons.Add(new TileButton(XmlHelper.cameras.ElementAt(i).Value.name.upper(), i + 2, 3, CameraButtonListEvent));
                i++;
            }
            return cameras_buttons;
        }

        private static List<TileButton> CreateStartFromButtons()
        {
            startFromBut = new TileData("START FROM", 9, 8, "", StartFromHeadEvent);
            startFromBut.ValueLabel.Width = ResolutionManager.MagicWidth;   //ugly !!!
            startFromBut.Value = startFrom;

            startFromButtons = new List<TileButton>();
            var names = Enum.GetNames(typeof(StartPosition));
            int i = 0;
            foreach (var name in names)
            {
                startFromButtons.Add(new TileButton(name.ToUpper(), 9, 7 - i, StartFromButtonListEvent));
                i++;
            }
            return startFromButtons;
        }


        public static void UpdateEstimatedDistance(double distance)
        {
            estimatedDistance.Value = distance.ToString();
        }

        public static void UpdateEstimatedDistance(object sender, ChangeValueEventArgs<int> e)
        {
            UpdateEstimatedDistance(e.Value);
        }

        public static void UpdateEstimatedTime(int time)
        {
            int t = time;
            string h, m, s;

            s = (t % 60).ToString("D2");
            t /= 60;
            m = (t % 60).ToString("D2");
            t /= 60;
            h = (t % 60).ToString("D1");

            estimatedTime.Value = h+':'+m+':'+s;
        }

        public static void UpdateEstimatedTime(object sender, ChangeValueEventArgs<int> e)
        {
            UpdateEstimatedTime(e.Value);
        }
    }
}
