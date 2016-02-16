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
    public class Tiles
    {
        public static bool armed = false;
        public static bool connected = false;
        public static bool pathAccepted = true;
        public static string camName = "GEOSCANNER";


        public static Boolean PathAcceptButtonVisible { get { return accept.Visible; } set { accept.Visible = value; } }
        public static double GroundRes { set { groundRes = value; groundResInfo.Value = value.ToString(); } }
        public static int AngleVal { get { return Convert.ToInt32(angleInfo.Value); } } // duup so ugly!
        public static int AltitudeVal { get { return Convert.ToInt32(altInfo.Value); } } // duup so ugly!
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

        private static TileData sideLap = null;
        private static TileData overLap = null;
        private static TileData Images = null;
        private static TileButton writeWaypoints = null;
        private static TileData obsHeadBtn = null;
        private static TileData area = null;
        private static TileData distanceBetweenLines = null;
        private static TileData  numberofStripes = null;

        private static TileData windSpeed = null;

        private static int altMin = 50;
        private static int altMax = 500;

        private static int fsMin = 3;
        private static int fsMax = 8;

        private static double groundRes;

        private static string polygonmodestring = "POLYGON\nMODE";

        private static List<TileButton> cameras_buttons;

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
        private static List<Panel> common = new List<Panel>();

        public static void SetCommonTiles()
        {
            commonTiles = new List<TileInfo>();
            commonTiles.Add(new TileButton("AUTO", 1, 7, AutoModeEvent, Color.FromArgb(255, 255, 51, 0)));
            commonTiles.Add(new TileButton("RESTART", 2, 7, RestartMissionEvent));
            commonTiles.Add(new TileButton("RETURN", 2, 8, ReturnToLaunchEvent));
            commonTiles.Add(new TileButton("LAND", 1, 8, LandEvent));
            ArmButton = new TileButton("ARM", 0, 8, ArmDisarmEvent);
            commonTiles.Add(ArmButton);
            commonTiles.Add(new TileButton("CONNECT", 0, 7, ConnectEvent));

            foreach (var tile in commonTiles)
            {
                //TODO: transparent
                var panel = new Panel
                {
                    Size = new Size(130, 55),
                    Location = new Point((int)tile.Column * 132, (int)tile.Row * 57),
                    BackColor = Color.FromArgb(220, 0, 0, 0),
                };
                panel.Controls.Add(tile.Label);
                common.Add(panel);
                panel.BringToFront();
            }

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
                // log errors
            }
        }



        public static void SetTiles(Panel p, bool isFlightMode)
        {
            //------------------------------------------------------------Flight Mode tiles---------------------------------------------------------------//
            if (!isFlightMode && MainV2.config.ContainsKey("TXT_DefaultAlt"))
                altInfo.Value = FlightPlanner.instance.TXT_DefaultAlt.Text = MainV2.config["TXT_DefaultAlt"].ToString();

            windSpeed = new TileData("WIND SPEED", 9, 0, "m/s");
            TileData mode;

            var tilesFlightMode = new List<TileInfo>(new TileInfo[]
            {
                new TileButton("FLIGHT\nINFO", 0, 0, (sender, e) => {}, Color.FromArgb(255, 255, 51, 0)),
                new TileData("GROUND SPEED", 0, 1, "km/h"),
                new TileData("ALTITUDE", 0, 2, "m"),
                new TileData("TIME IN THE AIR", 0, 3, "h:m:s"),
                new TileData("BATTERY REMAINING", 0, 4, "%"),
                new TileButton("DISARM", 0, 7),
                new TileButton("FLIGHT\nPLANNING", 1, 0, FlighPlanningShowEvent),
                new TileData("AIR SPEED", 1, 1, "km/h"),
                new TileData("DISTANCE TO HOME", 1, 2, "m"),
                new TileData("BATTERY VOLTAGE", 1, 3, "V"),
                new TileData("CURRENT", 1, 4, "A"),
                new TileData("GPSHDOP", 1, 5, ""),
                new TileData("GPS SAT COUNT", 1, 6, ""),
                new TileData("RADIO SIGNAL", 0, 5, "%"),
                new TileButton("EXIT",2,0, ExitEvent),
                mode = new TileData("MODE",0,6,""),
                windSpeed,
            });
            mode.ValueLabel.Width = 120;








            //-------------------------------------------------------FLIGHT PLANNER----------------------------------------------//
            cameras_buttons = new List<TileButton>();

            sideLap = new TileData("SIDELAP", 1, 7, "%", SidelapSettingEvent);
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

            obsHeadBtn = new TileData("OBSERVATION HEAD", 1, 3, "", ObservationHeadEvent);
            obsHeadBtn.ValueLabel.Width = 120;          //ugly !!!
            obsHeadBtn.Value = "GEOSCANNER";

            accept = new TileButton("ACCEPT\nPATH", 2, 1, AcceptPathEvent);
            Images = new TileData("IMAGES NUBMER", 12.4, 7, "");
            Images.Value = "0";



            var hideList = new TileInfo[] { accept, sideLap, overLap };
            var list = (TileInfo[])cameras_buttons.ToArray();

            List<TileInfo> hidelist2 = new List<TileInfo>();
            hidelist2.AddRange(hideList);
            hidelist2.AddRange(list);
            obsHeadBtn.ClickMethod(null, null);

            // todo copy paste code ;/
            var tilesFlightPlanning = new List<TileInfo>(new TileInfo[]
            {
                obsHeadBtn,
                accept,
                flyingSpeed,
                sideLap,overLap,Images,

                new TileButton("COMPASS\nCALIBRATION",12.4,0, CompassCalibrationEvent),
                area = new TileData("AREA",12.4,8,"km^2"),             
                distanceBetweenLines = new TileData("DIST BETWEEN IMAGES",11.4,7,"m"), 
                numberofStripes = new TileData("NUMBER OF STRIPS",11.4,8,""),   
                new TileButton("FLIGHT\nINFO", 0, 0, FlightInfoEvent),
                new TileButton("POLYGON\nMODE", 0, 1, PolygonModeEvent),
                new TileButton("ADD START\nPOINT", 0, 2, AddStartPointEvent),
                new TileButton("CLEAR", 0, 3, ClearEvent),
                new TileButton("FLIGHT\nPLANNING", 1, 0, (sender, e) => { }, Color.FromArgb(255, 255, 51, 0)),
                new TileButton("PATH\nGENERATION", 1, 1, PathGenerationEvent),
                new TileButton("ADD LANDING POINT", 1, 2, AddLandingPointEvent),
                new TileButton("SHOW WP",11.4,0,ShowWPEvent),
                new TileButton("FOOTPRINT",0,4),        //TODO implement event
                new TileButton("CAMERA FACING FORWARD",0,5), //TODO implement event
                new TileData("SPLIT INTO SEGMENTS",0,6), //TODO implement event
                new TileData("START FROM",2,4), //TODO implement event

                writeWaypoints = new TileButton("SAVE WP PLATFORM", 1, 7, SaveWPPlatformEvent),
                angleInfo = new TileData("ANGLE", 1, 4, "deg", AngelSettingEvent),
                altInfo = new TileData("ALTITUDE ", 1, 5, "m", AltitudeSettingEvent),
                groundResInfo = new TileData("GROUND RESOLUTION", 12.4, 5, "cm/p"),
                flightTime = new TileData("FLIGHT TIME", 11.4, 6, "h:m:s"),
                SaveWPFile = new TileButton("SAVE WP FILE", 0,7, SaveWPFileEvent),
                LoadWPFile = new TileButton("LOAD WP FILE", 0,8, LoadWPFileEvent),
                LoadWPPlatform = new TileButton("LOAD WP PLATFORM",1,8,LoadWPPlatformEvent),
                distanceTile = new TileData("Distance",12.4,6,"km"),
            });
            tilesFlightPlanning.AddRange(cameras_buttons);

            var tilesArray = (isFlightMode) ? tilesFlightMode : tilesFlightPlanning;

            foreach (var pan in common)
            {
                pan.Parent = FlightData.instance.splitContainer1.Panel2;
                FlightData.instance.splitContainer1.Panel2.Controls.Add(pan);
                pan.BringToFront();
            }

            var sideValue = MainV2.config["grid_sidelap"];
            var overValue = MainV2.config["grid_overlap"];

            ChangeSideLap(Convert.ToInt32(sideValue));
            ChangeOverLap(Convert.ToInt32(overValue));


            foreach (var tile in tilesArray)
            {
                //TODO: transparent
                var panel = new Panel
                {
                    Size = new Size(130, 55),
                    Location = new Point((int)(tile.Column * 132), (int)(tile.Row * 57)),
                    BackColor = Color.FromArgb(220, 0, 0, 0),
                    Parent = p
                };

                panel.Controls.Add(tile.Label);

                p.Controls.Add(panel);
                panel.BringToFront();
                if (hidelist2.Contains(tile) && tile is TileButton)
                    (tile as TileButton).Visible = false;

                sideLap.Visible = false;
                overLap.Visible = false;
            }
        }



        #region EventsFlightPlanner


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

        private static void CameraButtonListEvent(object sender, EventArgs e)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            /*cam1Head.Visible = cam2Head.Visible = defaultHead.Visible = false;*/
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
			if(FlightPlanner.missionWaypointCount() > 0)
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


        private static void AcceptPathEvent(object sender, EventArgs args)
        {
            pathAccepted = true; accept.Visible = false; calcGrid = null;
            SaveWPFile.Visible = true;
            LoadWPFile.Visible = true;
            LoadWPPlatform.Visible = true;
            writeWaypoints.Visible = true;
            sideLap.Visible = false;
            overLap.Visible = false;
            Images.Visible = false;
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
			MainV2.onMapPositionChanged(MainV2.instance.FlightPlanner.MainMap.Id, MainV2.instance.FlightPlanner.MainMap.Position);
			MainV2.onMapZoomChanged(MainV2.instance.FlightPlanner.MainMap.Id, MainV2.instance.FlightPlanner.MainMap.Zoom);
			foreach (var pan in common)
            {
                pan.Parent = FlightData.instance.splitContainer1.Panel2;
                FlightData.instance.splitContainer1.Panel2.Controls.Add(pan);
                pan.BringToFront();
            }
        }

        private static void AngelSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            InputFlightPlanning inputWindow = new InputFlightPlanning();
            inputWindow.ShowDialog();

            ChangeAngle(60);
            //throw new NotImplementedException();
        }

        private static void AltitudeSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            throw new NotImplementedException();

        }

        private static void FlyingSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            throw new NotImplementedException();
        }

        private static void SidelapSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            throw new NotImplementedException();
        }

        private static void OverlapSettingEvent(object sender, EventArgs args)
        {
            cameras_buttons.ForEach(cam => cam.Visible = false);
            throw new NotImplementedException();
        }
        #endregion


        #region EventsFlightData

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
			MainV2.onMapPositionChanged(MainV2.instance.FlightData.gMapControl1.Id, MainV2.instance.FlightData.gMapControl1.Position);
			MainV2.onMapZoomChanged(MainV2.instance.FlightData.gMapControl1.Id, MainV2.instance.FlightData.gMapControl1.Zoom);
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
            }
            else                    //disconnect
            {
                if (MainV2.comPort.MAV.cs.armed)
                    ArmButton.ClickMethod(ArmButton, null);     //disarm before disconnect
                FlightData.instance.hud1.warning = "";
                MainV2.instance.MenuConnect_Click(null, null);
                windSpeed.Visible = true;
                FlightData.instance.windDir1.Visible = true;
            }
        }


        private static void ArmDisarmEvent(object sender, EventArgs args)
        {
            if (!MainV2.comPort.MAV.cs.armed)         //jeśli rozbrajamy to nie robimy preflightcheck
            {
                if (!connected)
                {
                    CustomMessageBox.Show("Fisrt connect GCS to UAV", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
