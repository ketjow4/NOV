using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using IronPython.Runtime.Operations;
using System.Threading;

using MissionPlanner.GCSViews.Modification; //classes for tiles

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

        public static event EventHandler pathAcceptedEvent;

        public static Boolean PathAcceptButtonVisible { get { return accept.Visible; } set { accept.Visible = value; } }
        public static double GroundRes { set { groundRes = value; groundResInfo.Value = value.ToString(); } }
        public static int AngleVal { get { return Convert.ToInt32(angleInfo.Value); } } // duup so ugly!
        public static int AltitudeVal { get { return Convert.ToInt32(altInfo.Value); } set { altInfo.Value = value.ToString(); } } // duup so ugly!
        public static int FlyingSpeed { get { return Convert.ToInt32(flyingSpeed.Value); } }
        public static String Distance { set { distanceTile.Value = value; } get { return distanceTile.Value; } }
        public static String DistanceUnit { set { distanceTile.UnitLabel.Text = value; } }
        public static String EstimatedFlightTime { set { flightTime.Value = value; } get { return flightTime.Value; } }

        public static String Area { set { area.Value = value; } get { return area.Value; } }
        public static String DistanceBeteweenLines { set { distanceBetweenLines.Value = value; } get { return distanceBetweenLines.Value; } }
        public static String NumberOfStripes { set { numberofStripes.Value = value; } get { return numberofStripes.Value; } }

        public static int SideLap { get { return Convert.ToInt32(sideLap.Value); } }
        public static int OverLap { get { return Convert.ToInt32(overLap.Value); } }
        public static int ImagesCount { set { Images.Value = value.ToString(); } }

        public static EventHandler calcGrid = null;

        private static TileData flyingSpeed = null;
        private static TileData altInfo = null;
        private static TileData angleInfo = null;
        private static TileData groundResInfo = null;
        private static TileData flightTime = null;          //estimated flight time
        private static TileData distanceTile = null;
        private static TileButton accept = null;
        private static TileButton ArmButton = null;
        private static TileButton SaveWPFile = null;
        private static TileButton LoadWPFile = null;
        private static TileButton LoadWPPlatform = null;
        private static TileButton panicButton = null;
        private static TileButton abortLandButton = null;
        public static TileButton offlineMaps = null;
        public static TileButton cancelOfflineMaps = null;
        private static TileButton guidedModeButton = null;

        private static TileData sideLap = null;
        private static TileData overLap = null;
        private static TileData Images = null;
        private static TileButton writeWaypoints = null;
        private static TileData obsHeadBtn = null;
        private static TileData area = null;
        private static TileData distanceBetweenLines = null;
        private static TileData numberofStripes = null;
        private static TileData startFromBut = null;

        private static TileData windSpeed = null;

        private static int altMin = 50;
        private static int altMax = 500;

        private static int fsMin = 3;
        private static int fsMax = 8;

        private static double groundRes;

        private static string polygonmodestring = "POLYGON\nMODE";

        private static List<TileButton> cameras_buttons;
        private static List<TileButton> startFromButtons;

        public static void ChangeAlt(int v)
        {
            int val = v;
            if (val < altMin) val = altMin;
            else if (val > altMax) val = altMax;
            FlightPlanner.instance.TXT_DefaultAlt.Text = altInfo.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        public static void ChangeAngle(int v)
        {
            int val = v;
            if (val < 0) val = 360;
            else if (val > 360) val = 0;
            angleInfo.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        public static void ChangeSpeed(int v)
        {
            int val = v;
            if (val < fsMin) val = fsMin;
            else if (val > fsMax) val = fsMax;
            flyingSpeed.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        public static void ChangeSideLap(int v)
        {
            int val = v;
            if (val > 100) val = 100;
            if (val < 0) val = 0;
            sideLap.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        public static void ChangeOverLap(int v)
        {
            int val = v;
            if (val > 100) val = 100;
            if (val < 0) val = 0;
            overLap.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        internal static List<TileInfo> commonTiles = null;
        public static TileButton ConnectButton;

        public static void SetCommonTiles()
        {
            ConnectButton = new TileButton("CONNECT", 0, 7, ConnectEvent);
            ArmButton = new TileButton("ARM", 0, 8, ArmDisarmEvent);
            Thread thread = new Thread(new ThreadStart(RefreshTransparentLabel));
            thread.Start();
        }

        private static volatile bool firstTime = true;


        private static void ThreadSafeMapZoomToHome()
        {
            if (MainV2.comPort.MAV.cs.HomeLocation.Lat != 0)
            {
                if (MainV2.comPort.MAV.cs.gpsstatus != 0 && MainV2.comPort.MAV.cs.gpsstatus != 1)
                {
                    FlightData.instance.gMapControl1.Invoke(new MethodInvoker(delegate
                    {
                        FlightData.instance.gMapControl1.Position = MainV2.comPort.MAV.cs.HomeLocation;
                        FlightData.instance.gMapControl1.Zoom = 16;
                    }));
                    if (FlightPlanner.instance.IsHandleCreated)
                    {
                        FlightPlanner.instance.MainMap.Invoke(new MethodInvoker(delegate
                        {
                            FlightPlanner.instance.MainMap.Position = MainV2.comPort.MAV.cs.HomeLocation;
                            FlightPlanner.instance.MainMap.Zoom = 16;
                        }));
                    }
                }
            }
        }

        //this refresh transparent label and ARM/DISARM button when it's armed through RC 
        public static void RefreshTransparentLabel()
        {
            try
            {
                while (!MissionPlanner.GCSViews.FlightData.instance.IsHandleCreated)
                    System.Threading.Thread.Sleep(1000);

                string text = "";
                while (true)
                {
                    FlightData.instance.hud1.Invoke(new MethodInvoker(delegate { text = FlightData.instance.hud1.warning; }));
                    FlightData.instance.transparent.Invoke(new MethodInvoker(delegate
                    {
                        if (text == "")
                            FlightData.instance.transparent.Visible = false;
                        else
                        {
                            FlightData.instance.transparent.Visible = true;
                            FlightData.instance.transparent.Text = text;
                        }
                    }));

                    ArmButton.Label.Invoke(new MethodInvoker(delegate
                    {
                        if (MainV2.comPort.MAV.cs.armed)
                            ArmButton.Label.Text = "DISARM";
                        else
                            ArmButton.Label.Text = "ARM";
                    }));


                    var homeLoc = MainV2.comPort.MAV.cs.HomeLocation;

                    if (homeLoc.Lat != 0)
                    {
                        if (MainV2.comPort.MAV.cs.gpsstatus != 0 && MainV2.comPort.MAV.cs.gpsstatus != 1 && firstTime)
                        {
                            //System.Threading.Thread.Sleep(1000);
                            FlightData.instance.gMapControl1.Invoke(new MethodInvoker(delegate
                                {
                                    FlightData.instance.gMapControl1.Position = MainV2.comPort.MAV.cs.HomeLocation;
                                    FlightData.instance.gMapControl1.Zoom = 16;
                                }));
                            if (FlightPlanner.instance.IsHandleCreated)
                            {
                                FlightPlanner.instance.MainMap.Invoke(new MethodInvoker(delegate
                                    {
                                        FlightPlanner.instance.MainMap.Position = MainV2.comPort.MAV.cs.HomeLocation;
                                        FlightPlanner.instance.MainMap.Zoom = 16;
                                    }));
                            }
                            firstTime = false;
                        }
                    }
                    System.Threading.Thread.Sleep(500);
                    if (!MissionPlanner.GCSViews.FlightData.instance.IsHandleCreated)
                        return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Transparent Label error" + ex.Message);
                //Thread thread = new Thread(new ThreadStart(RefreshTransparentLabel));
                //thread.Start();
                // log errors
            }
        }



        public static void SetTiles(Panel p, bool isFlightMode)
        {
            //------------------------------------------------------------Flight Mode tiles---------------------------------------------------------------//
            if (!isFlightMode && MainV2.config.ContainsKey("TXT_DefaultAlt"))
                altInfo.Value = FlightPlanner.instance.TXT_DefaultAlt.Text = MainV2.config["TXT_DefaultAlt"].ToString();

            windSpeed = new TileData("WIND SPEED", ResolutionManager.WindSpeedLocation.Y, ResolutionManager.WindSpeedLocation.X, "m/s");
            TileData mode;

            var tilesFlightMode = new List<TileInfo>(new TileInfo[]
            {
                new TileButton("FLIGHT\nINFO", 0, 0, (sender, e) => {}, Color.FromArgb(255, 255, 51, 0)),
                new TileData("GROUND SPEED", 0, 1, "km/h"),
                new TileData("ALTITUDE", 0, 2, "m"),
                new TileData("TIME IN THE AIR", 0, 3, "h:m:s"),
                new TileData("BATTERY REMAINING", 0, 4, "%"),
                new TileButton("FLIGHT\nPLANNING", 1, 0, FlighPlanningShowEvent),
                new TileData("AIR SPEED", 1, 1, "km/h"),
                new TileData("DISTANCE TO HOME", 1, 2, "m"),
                new TileData("BATTERY VOLTAGE", 1, 3, "V"),
                new TileData("CURRENT", 1, 4, "A"),
                new TileData("GPSHDOP", 1, 5, ""),
                new TileData("GPS SAT COUNT", 1, 6, ""),
                new TileData("RADIO SIGNAL", 0, 5, "%"),
                new TileButton("EXIT",2,0, ExitEvent),
                new TileButton("START\nMISSION",2,6,StartMissionEvent),
                guidedModeButton = new TileButton("GUIDED\nMODE",3,8,GuidedModeEvent),
                new TileButton("TAKE OFF",4,8,TakeOffEvent),
                mode = new TileData("MODE",0,6,""),
                panicButton = new TileButton("BRAKE",ResolutionManager.PanicButtonLocation.Y,ResolutionManager.PanicButtonLocation.X, PanicButtonEvent),
                abortLandButton = new TileButton("ABORT\nLANDING",ResolutionManager.AbortLandLocation.Y,ResolutionManager.AbortLandLocation.X, AbortLandEvent),
                windSpeed,
                new TileButton("AUTO", 1, 7, AutoModeEvent),
                new TileButton("RESTART", 2, 7, RestartMissionEvent),
                new TileButton("RETURN", 2, 8, ReturnToLaunchEvent),
                new TileButton("LAND", 1, 8, LandEvent),
                ArmButton,
                ConnectButton,
            });
            commonTiles = tilesFlightMode;      //bad hax
            mode.ValueLabel.Width = ResolutionManager.MagicWidth;    //ugly !!!

            obsHeadBtn = new TileData("OBSERVATION HEAD", 1, 3, "", ObservationHeadEvent);
            obsHeadBtn.ValueLabel.Width = ResolutionManager.MagicWidth;          //ugly !!!
            obsHeadBtn.Value = camName;


            startFromBut = new TileData("START FROM", 1, 7, "", StartFromHeadEvent);
            startFromBut.ValueLabel.Width = ResolutionManager.MagicWidth;   //ugly !!!
            startFromBut.Value = startFrom;



            //-------------------------------------------------------FLIGHT PLANNER----------------------------------------------//
            cameras_buttons = new List<TileButton>();

            sideLap = new TileData("SIDELAP", 0, 7, "%", SidelapSettingEvent);
            overLap = new TileData("OVERLAP", 0, 8, "%", OverlapSettingEvent);
            flyingSpeed = new TileData("FLYING SPEED", 1, 6, "m/s", FlyingSettingEvent);
            flyingSpeed.Value = "3";


            XmlHelper.ReadCameraName("noveltyCam.xml");

            int i = 0;
            foreach (var camera in XmlHelper.cameras)
            {
                cameras_buttons.Add(new TileButton(XmlHelper.cameras.ElementAt(i).Value.name.upper(), i + 2, 3, CameraButtonListEvent));
                i++;
            }
            


            startFromButtons = new List<TileButton>();
            var names = Enum.GetNames(typeof(StartPosition));
            i = 0;
            foreach (var name in names)
            {
                startFromButtons.Add(new TileButton(name.ToUpper(), i + 2, 7, StartFromButtonListEvent));
                i++;
            }
           

            accept = new TileButton("ACCEPT\nPATH", 2, 1, AcceptPathEvent);
            Images = new TileData("IMAGES NUBMER", ResolutionManager.BottomOfScreenRow, 7, "");
            Images.Value = "0";

            var hideList = new TileInfo[] { accept, sideLap, overLap };

            List<TileInfo> hidelist2 = new List<TileInfo>();
            hidelist2.AddRange(hideList);
            hidelist2.AddRange(cameras_buttons.ToArray());
            hidelist2.AddRange(startFromButtons.ToArray());
            obsHeadBtn.ClickMethod(null, null);

            // todo copy paste code ;/
            var tilesFlightPlanning = new List<TileInfo>(new TileInfo[]
            {
                obsHeadBtn,
                accept,
                flyingSpeed,
                sideLap,overLap,Images,startFromBut,

                new TileButton("COMPASS\nCALIBRATION",ResolutionManager.BottomOfScreenRow,0, CompassCalibrationEvent),
                area = new TileData("AREA",ResolutionManager.BottomOfScreenRow,8,"km\u00B2"),
                distanceBetweenLines = new TileData("DIST BETWEEN IMAGES",ResolutionManager.BottomOfScreenRow - 1,7,"m"),
                numberofStripes = new TileData("NUMBER OF STRIPS",ResolutionManager.BottomOfScreenRow - 1,8,""),
                new TileButton("FLIGHT\nINFO", 0, 0, FlightInfoEvent),
                new TileButton("POLYGON\nMODE", 0, 1, PolygonModeEvent),
                new TileButton("ADD START\nPOINT", 0, 2, AddStartPointEvent),
                new TileButton("CLEAR", 0, 3, ClearEvent),
                new TileButton("FLIGHT\nPLANNING", 1, 0, (sender, e) => { }, Color.FromArgb(255, 255, 51, 0)),
                new TileButton("PATH\nGENERATION", 1, 1, PathGenerationEvent),
                new TileButton("ADD LANDING POINT", 1, 2, AddLandingPointEvent),
                new TileButton("SHOW WP",ResolutionManager.BottomOfScreenRow - 1,0,ShowWPEvent),
                new TileButton("\u2610 FOOTPRINT",0,4, FootprintEvent),
                new TileButton("\u2610   CAM\nFORWARD",0,5, CameraFacingForwardEvent),
                new TileButton("LOAD\nPOLYGON",0,6,LoadPolygonFileEvent),
                new TileButton("SAVE\nPOLYGON",ResolutionManager.BottomOfScreenRow - 3,0,SavePolygonEvent),
                offlineMaps = new TileButton("OFFLINE\nMAPS",ResolutionManager.BottomOfScreenRow - 2,0,OfflineMapsEvent),
                cancelOfflineMaps = new TileButton("CANCEL",ResolutionManager.BottomOfScreenRow - 2,1,CancelOfflineMapsEvent),

                writeWaypoints = new TileButton("SAVE WP PLATFORM", 1, 7, SaveWPPlatformEvent),
                angleInfo = new TileData("ANGLE", 1, 4, "deg", AngelSettingEvent),
                altInfo = new TileData("ALTITUDE ", 1, 5, "m", AltitudeSettingEvent),
                groundResInfo = new TileData("GROUND RESOLUTION", ResolutionManager.BottomOfScreenRow, 5, "cm/p"),
                flightTime = new TileData("FLIGHT TIME", ResolutionManager.BottomOfScreenRow - 1, 6, "h:m:s"),
                SaveWPFile = new TileButton("SAVE WP FILE", 0,7, SaveWPFileEvent),
                LoadWPFile = new TileButton("LOAD WP FILE", 0,8, LoadWPFileEvent),
                LoadWPPlatform = new TileButton("LOAD WP PLATFORM",1,8,LoadWPPlatformEvent),
                distanceTile = new TileData("DISTANCE",ResolutionManager.BottomOfScreenRow,6,"km"),
            });
            tilesFlightPlanning.AddRange(cameras_buttons);
            tilesFlightPlanning.AddRange(startFromButtons);

            var tilesArray = (isFlightMode) ? tilesFlightMode : tilesFlightPlanning;

            var sideValue = MainV2.config["grid_sidelap"];
            var overValue = MainV2.config["grid_overlap"];

            ChangeSideLap(Convert.ToInt32(sideValue));
            ChangeOverLap(Convert.ToInt32(overValue));
            AltitudeVal = altMin;

            foreach (var tile in tilesArray)
            {
                var panel = new Panel
                {
                    Size = new Size(ResolutionManager.TileWidth,  ResolutionManager.TileHeight),
                    Location = new Point((int)(tile.Column * (ResolutionManager.TileWidth + ResolutionManager.MarginSize)), 
                                         (int)(tile.Row * (ResolutionManager.TileHeight + ResolutionManager.MarginSize))),
                    Parent = p,
                    Name = tile.Label.Text,
                };

                panel.Controls.Add(tile.Label);

                p.Controls.Add(panel);
                panel.BringToFront();
                if (hidelist2.Contains(tile) && tile is TileButton)
                    (tile as TileButton).Visible = false;
            }
            sideLap.Visible = false;
            overLap.Visible = false;
            abortLandButton.Visible = false;
            cancelOfflineMaps.Visible = false;
        }

        private static void TakeOffEvent(object sender, EventArgs e)
        {
            FlightData.instance.takeOffToolStripMenuItem_Click(null, null);
        }

        private static void GuidedModeEvent(object sender, EventArgs e)
        {

            if (guidedMode)
            {
                guidedModeButton.SetToOriginal();
                (sender as Label).BackColor = Color.FromArgb(22, 23, 24);
                guidedMode = false;
            }
            else
            {
                (sender as Label).BackColor = Color.FromArgb(0, 120, 60);
                guidedMode = true;
            }
        }


        #region EventsFlightPlanner

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
                else
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
            if (calcGrid != null)
                calcGrid(null, null);
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
            if (calcGrid != null)
                calcGrid(null, null);

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
            SaveWPFile.Visible = false;
            LoadWPFile.Visible = false;
            LoadWPPlatform.Visible = false;
            writeWaypoints.Visible = false;
            sideLap.Visible = true;
            overLap.Visible = true;
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
            if (s.Text == polygonmodestring)
            {
                s.Text = "WAYPOINT\nMODE";
                FlightPlanner.instance.PolygonGridMode = false;
            }
            else
            {
                s.Text = polygonmodestring;
                FlightPlanner.instance.PolygonGridMode = true;
            }
        }


        public static void AcceptPathEvent(object sender, EventArgs args)
        {
            pathAccepted = true; accept.Visible = false; calcGrid = null;
            SaveWPFile.Visible = true;
            LoadWPFile.Visible = true;
            LoadWPPlatform.Visible = true;
            writeWaypoints.Visible = true;
            sideLap.Visible = false;
            overLap.Visible = false;
            if (pathAcceptedEvent != null)
            {
                pathAcceptedEvent(null, null);
                pathAcceptedEvent = null;

            }
            FlightPlanner.instance.pathGenerationMode = false;
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

        private static void AngelSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            InputFlightPlanning inputWindow = new InputFlightPlanning("ANGLE", false, AngleVal.ToString(), 0, 360, ResolutionManager.InputPanelSize);
            inputWindow.ShowDialog();
            ChangeAngle(inputWindow.Result);
        }

        private static void AltitudeSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            InputFlightPlanning inputWindow = new InputFlightPlanning("ALTITUDE", false, AltitudeVal.ToString(), altMin, altMax, ResolutionManager.InputPanelSize);
            inputWindow.ShowDialog();
            ChangeAlt(inputWindow.Result);
        }

        private static void FlyingSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            InputFlightPlanning inputWindow = new InputFlightPlanning("FLYING SPEED", false, FlyingSpeed.ToString(), fsMin, fsMax, ResolutionManager.InputPanelSize);
            inputWindow.ShowDialog();
            ChangeSpeed(inputWindow.Result);
        }

        private static void SidelapSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            InputFlightPlanning inputWindow = new InputFlightPlanning("SIDELAP", false, SideLap.ToString(), 0, 99, ResolutionManager.InputPanelSize);
            inputWindow.ShowDialog();
            ChangeSideLap(inputWindow.Result);
        }

        private static void OverlapSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            InputFlightPlanning inputWindow = new InputFlightPlanning("OVERLAP", false, OverLap.ToString(), 0, 99, ResolutionManager.InputPanelSize);
            inputWindow.ShowDialog();
            ChangeOverLap(inputWindow.Result);
        }
        #endregion


        #region EventsFlightData


        private static void StartMissionEvent(object sender, EventArgs e)
        {
            try
            {
                int param1 = 0;
                int param3 = 1;
                MainV2.comPort.doCommand((MAVLink.MAV_CMD)Enum.Parse(typeof(MAVLink.MAV_CMD), "MISSION_START"),
                           param1, 0, param3, 0, 0, 0, 0);
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            }
        }

        private static void PanicButtonEvent(object sender, EventArgs args)
        {
            try
            {
                MainV2.comPort.setMode("BRAKE");
            }
            catch
            {
                CustomMessageBox.Show("The Command failed to execute", "Error");
            }
        }

        private static void AbortLandEvent(object sender, EventArgs args)
        {
            try
            {
                MainV2.comPort.doAbortLand();
            }
            catch
            {
                CustomMessageBox.Show("The Command failed to execute", "Error");
            }
        }

        private static void ExitEvent(object sender, EventArgs args)
        {
            MissionPlanner.LogReporter.LogReporter.stopThread = true;
            MainV2.config["grid_sidelap"] = SideLap.ToString();
            MainV2.config["grid_overlap"] = OverLap.ToString();
            MainV2.instance.Close();
        }

        private static void FlighPlanningShowEvent(object sender, EventArgs args)
        {
            MainV2.View.ShowScreen("FlightPlanner");
			MainV2.instance.syncMapPositions(MainV2.instance.FlightData.gMapControl1.Position);
			MainV2.instance.syncMapZooms(MainV2.instance.FlightData.gMapControl1.Zoom);
        }


        private static void ConnectEvent(object sender, EventArgs args)
        {
            var conBut = sender as Label;
            if (connected == false)  //connect
            {
                MainV2.instance.MenuConnect_Click(null, null);
                armed = MainV2.comPort.MAV.cs.armed;
                if (armed)
                    commonTiles.Where(x => x.Label.Text == "ARM").First().Label.Text = "DISARM";
                if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2)
                {
                    windSpeed.Visible = false;
                    FlightData.instance.windDir1.Visible = false;
                }
                else if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane)
                {
                    abortLandButton.Visible = true;
                }
				
            }
            else                    //disconnect
            {
                if (MainV2.comPort.MAV.cs.armed)
                    ArmButton.ClickMethod(ArmButton, null);     //disarm before disconnect
                FlightData.instance.hud1.warning = "";
                MainV2.instance.MenuConnect_Click(null, null);
                windSpeed.Visible = true;
                FlightData.instance.windDir1.Visible = true;
                abortLandButton.Visible = false;
            }
        }


        private static void ArmDisarmEvent(object sender, EventArgs args)
        {
            if (!MainV2.comPort.MAV.cs.armed)         //jeśli rozbrajamy to nie robimy preflightcheck
            {
                if (!connected)
                {
                    CustomMessageBox.Show("First connect GCS to UAV", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                PreFlightCheck window = new PreFlightCheck();

                if (window.ShowDialog() == DialogResult.OK)
                {
                    //zapis do logów jest w środku klasy PreFlightCheck
                }
                else
                    return;     //jeśli nie zaakceptowano to powrót i brak arm
            }

            //MainV2.comPort.setMode("Loiter");         //TODO do usunięcia na potem !!!!

            FlightData.instance.BUT_ARM_Click(sender, args);
            if (armed && connected)
            {
                ArmButton.Label.Text = "DISARM";
                ThreadSafeMapZoomToHome();
            }
            else
                ArmButton.Label.Text = "ARM";
        }

        private static void AutoModeEvent(object sender, EventArgs args)
        {
            try
            {
                MainV2.comPort.setMode("AUTO");
            }
            catch
            {
                CustomMessageBox.Show("The Command failed to execute", "Error");
            }
        }

        private static void ReturnToLaunchEvent(object sender, EventArgs args)
        {
            try
            {
                MainV2.comPort.setMode("RTL");
            }
            catch
            {
                CustomMessageBox.Show("The Command failed to execute", "Error");
            }
        }

        private static void RestartMissionEvent(object sender, EventArgs args)
        {
            try
            {
                MainV2.comPort.setWPCurrent(0);
            }
            catch
            {
                CustomMessageBox.Show("The command failed to execute", "Error");
            }
        }

        private static void LandEvent(object sender, EventArgs args)
        {
            try
            {
                MainV2.comPort.setMode("LAND");
            }
            catch
            {
                CustomMessageBox.Show("The Command failed to execute", "Error");
            }
        }
        #endregion
    }
}
