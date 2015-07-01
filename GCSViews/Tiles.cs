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
        public static string camName = "DEFAULT";


        public static Boolean PathAcceptButtonVisible { get { return accept.Visible; } set { accept.Visible = value; } }
        public static double GroundRes { set { groundRes = value; groundResInfo.Value = value.ToString(); } }
        public static int AngleVal { get { return Convert.ToInt32(angleInfo.Value); } } // duup so ugly!
        public static int AltitudeVal { get { return Convert.ToInt32(altInfo.Value); } } // duup so ugly!
        public static int FlyingSpeed { get { return Convert.ToInt32(flyingSpeed.Value); } }
        public static String Distance { set { distanceTile.Value = value; } get { return distanceTile.Value; } }
        public static String DistanceUnit { set { distanceTile.UnitLabel.Text = value; } }
        public static String EstimatedFlightTime { set { flightTime.Value = value; } get { return flightTime.Value; } }

        public static EventHandler calcGrid = null;

        private static TileData flyingSpeed = null;
        private static TileData altInfo = null;
        private static TileData angleInfo = null;
        private static TileData groundResInfo = null;
        private static TileData flightTime = null;          //estimated flight time
        private static TileData distanceTile = null;
        private static TileButton accept = null;



        private static TileData windSpeed = null;

        private static int altMin = 30;
        private static int altMax = 30000;

        private static int fsMin = 3;
        private static int fsMax = 8;

        private static double groundRes;



        public static void ChangeAlt(int v)
        {
            int val = Convert.ToInt32(altInfo.Value) + v;
            if (val < altMin) val = altMin;
            else if (val > altMax) val = altMax;
            FlightPlanner.instance.TXT_DefaultAlt.Text = altInfo.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        public static void ChangeAngle(int v)
        {
            int val = Convert.ToInt32(angleInfo.Value) + v;
            if (val < 0) val = 360;
            else if (val > 360) val = 0;
            angleInfo.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        public static void ChangeSpeed(int v)
        {
            int val = Convert.ToInt32(flyingSpeed.Value) + v;
            if (val < fsMin) val = fsMin;
            else if (val > fsMax) val = fsMax;
            flyingSpeed.Value = val.ToString();
            if (calcGrid != null)
                calcGrid(null, null);
        }

        internal static List<TileInfo> commonTiles = null;
        private static List<Panel> common = new List<Panel>();

        public static void SetCommonTiles()
        {
            commonTiles = new List<TileInfo>();

            //commonTiles.Add(groundResInfo);
            commonTiles.Add(new TileButton("AUTO", 1, 7, (sender, e) =>
            {
                try
                {
                    MainV2.comPort.setMode("FBWB");
                }
                catch
                {
                    CustomMessageBox.Show("The Command failed to execute", "Error");
                }
            }, Color.FromArgb(255, 255, 51, 0)));
            commonTiles.Add(new TileButton("RESTART", 2, 7, (sender, args) =>
            {
                try
                {
                    MainV2.comPort.setWPCurrent(0);
                }
                catch
                {
                    CustomMessageBox.Show("The command failed to execute", "Error");
                }
            }));
            commonTiles.Add(new TileButton("RETURN", 2, 8, (sender, args) =>
            {
                try
                {
                    MainV2.comPort.setMode("RTL");
                }
                catch
                {
                    CustomMessageBox.Show("The Command failed to execute", "Error");
                }
            }));
            commonTiles.Add(new TileButton("LAND", 1, 8, (sender, args) =>                  //index value start from 0
            {
                int wpCount = MainV2.comPort.getWPCount();
                int index = 0;
                for (int i = 0; i < wpCount; i++)
                {
                    if (MainV2.comPort.getWP((ushort)i).id == (byte)MAVLink.MAV_CMD.RETURN_TO_LAUNCH)
                    {
                        index = i;
                        break;
                    }
                }
                MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_CAM_TRIGG_DIST, 0, 0, 0, 0, 0, 0, 0);
                MainV2.comPort.setWPCurrent((ushort)index);
            }));

            TileButton ArmButton = null;
            ArmButton = new TileButton("ARM", 0, 8,
                (sender, args) =>
                {
                    if (!armed)         //jeśli rozbrajamy to nie robimy preflightcheck
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
                    if (armed)
                        ArmButton.Label.Text = "DISARM";
                    else
                        ArmButton.Label.Text = "ARM";
                });

            commonTiles.Add(ArmButton);

            commonTiles.Add(new TileButton("CONNECT", 0, 7, (sender, args) =>
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
                    if (armed)
                        ArmButton.ClickMethod(ArmButton, null);     //disarm before disconnect
                    FlightData.instance.hud1.warning = "";
                    MainV2.instance.MenuConnect_Click(null, null);
                    windSpeed.Visible = true;
                    FlightData.instance.windDir1.Visible = true;
                } 
            }));

            foreach (var tile in commonTiles)
            {
                //TODO: transparent
                var panel = new Panel
                {
                    //Size = new Size(168, 64),
                    //Location = new Point(tile.Column * 170, tile.Row * 66),
                    //Size = new Size((int)(MainV2.View.Width * 0.105), (int)(MainV2.View.Height * 0.072)),
                    //Location = new Point(tile.Column * (int)(MainV2.View.Width * 0.105) + 2, tile.Row * (int)(MainV2.View.Height * 0.072) + 2),
                    Size = new Size(130, 55),
                    Location = new Point(tile.Column * 132, tile.Row * 57),
                    BackColor = Color.FromArgb(220, 0, 0, 0),
                };
                panel.Controls.Add(tile.Label);
                common.Add(panel);
                panel.BringToFront();
            }

            Thread thread = new Thread(new ThreadStart(RefreshTransparentLabel));
            thread.Start();

        }

        public static void RefreshTransparentLabel()
        {
            try
            {
                while(!MissionPlanner.GCSViews.FlightData.instance.IsHandleCreated)
                    System.Threading.Thread.Sleep(1000);
                string text = "";
                while (true)
                {
                    FlightData.instance.hud1.Invoke(new MethodInvoker(delegate { text = FlightData.instance.hud1.warning; }));
                    FlightData.instance.transparent.Invoke(new MethodInvoker(delegate { FlightData.instance.transparent.Text = text; }));
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
            List<TileButton> cameras_buttons = new List<TileButton>();

            var angleBtnUp = new TileButton("+5", 2, 4, (sender, args) => { ChangeAngle(5); });
            var angleBtnDown = new TileButton("-5", 3, 4, (sender, args) => { ChangeAngle(-5); });
            var angleBtnUp1 = new TileButton("+1", 4, 4, (sender, args) => { ChangeAngle(1); });
            var angleBtnDown1 = new TileButton("-1", 5, 4, (sender, args) => { ChangeAngle(-1); });
            TileButton angleBtnOk = null;
            angleBtnOk = new TileButton("OK", 6, 4, (sender, args) => angleBtnUp.Visible = angleBtnDown.Visible = angleBtnUp1.Visible = angleBtnDown1.Visible = angleBtnOk.Visible = false);
            var altBtnUp = new TileButton("+5", 2, 5, (sender, args) => ChangeAlt(5));
            var altBtnDown = new TileButton("-5", 3, 5, (sender, args) => ChangeAlt(-5));
            TileButton altBtnOk = null;
            altBtnOk = new TileButton("OK", 4, 5, (sender, args) => altBtnDown.Visible = altBtnUp.Visible = altBtnOk.Visible = false);


            var fsBtnUp = new TileButton("+1", 2, 6, (sender, args) => ChangeSpeed(1));
            var fsBtnDown = new TileButton("-1", 3, 6, (sender, args) => ChangeSpeed(-1));
            TileButton fsBtnOk = null;
            fsBtnOk = new TileButton("OK", 4, 6, (sender, args) => fsBtnDown.Visible = fsBtnUp.Visible = fsBtnOk.Visible = false);


            flyingSpeed = new TileData("FLYING SPEED", 1, 6, "m/s", (sender, args) =>
            {
                var x = !fsBtnUp.Visible;
                fsBtnUp.Visible = fsBtnDown.Visible = fsBtnOk.Visible = x;
                altBtnUp.Visible = altBtnDown.Visible = altBtnOk.Visible = false;
                angleBtnUp.Visible = angleBtnDown.Visible = angleBtnUp1.Visible = angleBtnDown1.Visible = angleBtnOk.Visible = false;
                cameras_buttons.ForEach(cam => cam.Visible = false);
            });
            flyingSpeed.Value = "3";
            altInfo = new TileData("ALTITUDE ", 1, 5, "m", (sender, args) =>
            {
                var x = !altBtnUp.Visible;
                altBtnUp.Visible = altBtnDown.Visible = altBtnOk.Visible = x;
                angleBtnUp.Visible = angleBtnDown.Visible = angleBtnUp1.Visible = angleBtnDown1.Visible = angleBtnOk.Visible = false;
                fsBtnUp.Visible = fsBtnDown.Visible = fsBtnOk.Visible = false;
                cameras_buttons.ForEach(cam => cam.Visible = false);
            });
            if (!isFlightMode && MainV2.config.ContainsKey("TXT_DefaultAlt"))
                altInfo.Value = FlightPlanner.instance.TXT_DefaultAlt.Text = MainV2.config["TXT_DefaultAlt"].ToString();

            windSpeed = new TileData("WIND SPEED", 9, 0, "m/s");
            TileData mode;

            //------------------------------------------------------------Flight Mode tiles
            var tilesFlightMode = new List<TileInfo>(new TileInfo[]
            {
               new TileButton("FLIGHT\nINFO", 0, 0, (sender, e) => {MainV2.View.ShowScreen("FlightData"); foreach(var pan in common) {pan.Parent = FlightData.instance.splitContainer1.Panel2; FlightData.instance.splitContainer1.Panel2.Controls.Add(pan); pan.BringToFront();}},
                    Color.FromArgb(255, 255, 51, 0)),
                new TileData("GROUND SPEED", 0, 1, "km/h"),
                new TileData("ALTITUDE", 0, 2, "m"),
                new TileData("TIME IN THE AIR", 0, 3, "h:m:s"),   
                new TileData("BATTERY REMAINING", 0, 4, "%"),
               
                new TileButton("DISARM", 0, 7),
                new TileButton("FLIGHT\nPLANNING", 1, 0, (sender, e) =>{ MainV2.View.ShowScreen("FlightPlanner"); foreach(var pan in common) {pan.Parent = FlightPlanner.instance.panelBASE; FlightPlanner.instance.panelBASE.Controls.Add(pan); pan.BringToFront();}}),
                new TileData("AIR SPEED", 1, 1, "km/h"),
                new TileData("DISTANCE TO HOME", 1, 2, "km"),
                new TileData("BATTERY VOLTAGE", 1, 3, "V"),
                new TileData("CURRENT", 1, 4, "A"),
                new TileData("GPSHDOP", 1, 5, ""),              
                new TileData("GPS SAT COUNT", 1, 6, ""),          
                new TileData("RADIO SIGNAL", 0, 5, "%"),
                new TileButton("EXIT",2,0, (sender,e) => { MainV2.instance.Close();}),
                mode = new TileData("MODE",0,6,""),
                windSpeed,
            });
            mode.ValueLabel.Width = 120;

            XmlHelper.ReadCameraName("noveltyCam.xml");

            TileData obsHeadBtn = null;




            int i = 0;
            foreach (var camera in XmlHelper.cameras)
            {
                cameras_buttons.Add(new TileButton(XmlHelper.cameras.ElementAt(i).Value.name.upper(), i + 2, 3, (sender, args) => { cameras_buttons.ForEach(cam => cam.Visible = false); /*cam1Head.Visible = cam2Head.Visible = defaultHead.Visible = false;*/  camName = (sender as Label).Text; if (!pathAccepted) calcGrid(null, null); obsHeadBtn.Value = camName; }));
                i++;
            }



            obsHeadBtn = new TileData("OBSERVATION HEAD", 1, 3, "", (sender, args) =>
            {
                var x = !cameras_buttons.ElementAt(0).Visible;
                cameras_buttons.ForEach(cam => cam.Visible = x);
                altBtnUp.Visible = altBtnDown.Visible = altBtnOk.Visible = false;
                angleBtnUp.Visible = angleBtnDown.Visible = angleBtnUp1.Visible = angleBtnDown1.Visible = angleBtnOk.Visible = false;
                fsBtnUp.Visible = fsBtnDown.Visible = fsBtnOk.Visible = false;
            });

            obsHeadBtn.ValueLabel.Width = 120;
            obsHeadBtn.Value = "DEFAULT";

            accept = new TileButton("ACCEPT\nPATH", 2, 1, (sender, e) => { pathAccepted = true; accept.Visible = false; calcGrid = null; });

            var list = (TileInfo[])cameras_buttons.ToArray();

            List<TileInfo> hidelist2 = new List<TileInfo>();


            var hideList = new TileInfo[] { altBtnUp, altBtnDown, altBtnOk, angleBtnDown, angleBtnUp, angleBtnUp1, angleBtnDown1, angleBtnOk, accept, fsBtnUp, fsBtnOk, fsBtnDown };

            hidelist2.AddRange(hideList);
            hidelist2.AddRange(list);

            obsHeadBtn.ClickMethod(null, null);


            angleInfo = new TileData("ANGLE", 1, 4, "deg", (sender, args) =>
            {
                var x = !angleBtnUp.Visible;
                angleBtnUp.Visible = angleBtnDown.Visible = angleBtnUp1.Visible = angleBtnDown1.Visible = angleBtnOk.Visible = x;
                altBtnUp.Visible = altBtnDown.Visible = altBtnOk.Visible = false;
                fsBtnUp.Visible = fsBtnDown.Visible = fsBtnOk.Visible = false;
                cameras_buttons.ForEach(cam => cam.Visible = false);
            });

            const string polygonmodestring = "POLYGON\nMODE";

            // todo copy paste code ;/
            var tilesFlightPlanning = new List<TileInfo>(new TileInfo[]
            {
                obsHeadBtn,
                altBtnUp, altBtnDown, altBtnOk, angleBtnDown, angleBtnUp, angleBtnOk, angleBtnUp1, angleBtnDown1, 
                accept,
                fsBtnDown,fsBtnOk,fsBtnUp,flyingSpeed,

                groundResInfo = new TileData("GROUND RESOLUTION", 0, 5, "cm/p"),
                new TileButton("FLIGHT\nINFO", 0, 0, (sender, e) => {MainV2.View.ShowScreen("FlightData"); foreach(var pan in common) {pan.Parent = FlightData.instance.splitContainer1.Panel2; FlightData.instance.splitContainer1.Panel2.Controls.Add(pan); pan.BringToFront();}}),
                new TileButton(polygonmodestring, 0, 1, (sender, e) =>
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
                }),
               new TileButton("ADD START\nPOINT", 0, 2,
                    (sender, args) => FlightPlanner.instance.takeoffToolStripMenuItem_Click(null, null)),
                new TileButton("CLEAR", 0, 3, (sender, args) =>
                {
                    FlightPlanner.instance.clearMissionToolStripMenuItem_Click(null, null);
                    FlightPlanner.instance.clearPolygonToolStripMenuItem_Click(null, null);
                }), 
                flightTime = new TileData("FLIGHT TIME", 0, 4, "h:m:s"),
                new TileButton("WRITE WAYPOINTS", 2, 0, (sender, args) => FlightPlanner.instance.BUT_write_Click(sender, args)), 
                new TileButton("FLIGHT\nPLANNING", 1, 0, (sender, e) => MainV2.View.ShowScreen("FlightPlanner"),
                    Color.FromArgb(255, 255, 51, 0)),
                    
                new TileButton("PATH\nGENERATION", 1, 1, (sender, e)  =>
            {
                {
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
                    }
                }
            }
            ),
                new TileButton("ADD LANDING POINT", 1, 2,
                    (sender, args) => FlightPlanner.instance.landToolStripMenuItem_Click(null, null)),
               angleInfo,
               altInfo,

               new TileButton("SAVE WP FILE", 3,7, (sender, args) => FlightPlanner.instance.BUT_saveWPFile_Click(null, null)),
               new TileButton("LOAD WP FILE", 3,8, (sender, args) => FlightPlanner.instance.BUT_loadwpfile_Click(null, null)),
               new TileButton("LOAD WP PLATFORM",4,8,(sender, args) => FlightPlanner.instance.BUT_read_Click(null,null)),

               new TileButton("SHOW WP",3,0,(sender,args) => 
               {
                   FlightPlannerWaypointsForm.Show();
               }),

               distanceTile = new TileData("Distance",0,6,"km"),


            });
            tilesFlightPlanning.AddRange(cameras_buttons);

            var tilesArray = (isFlightMode) ? tilesFlightMode : tilesFlightPlanning;

            foreach (var pan in common) { pan.Parent = FlightData.instance.splitContainer1.Panel2; FlightData.instance.splitContainer1.Panel2.Controls.Add(pan); pan.BringToFront(); }

            // (sender, args) => FlightPlanner.instance.landToolStripMenuItem_Click(null, null)));     

            foreach (var tile in tilesArray)
            {
                //TODO: transparent
                var panel = new Panel
                {
                    //Size = new Size(168, 64),
                    //Location = new Point(tile.Column * 170, tile.Row * 66),
                    //Size = new Size((int)(MainV2.View.Width * 0.105), (int)(MainV2.View.Height * 0.072)),
                    //Location = new Point(tile.Column * (int)(MainV2.View.Width * 0.105) + 2, tile.Row * (int)(MainV2.View.Height * 0.072) + 2),
                    Size = new Size(130, 55),
                    Location = new Point(tile.Column * 132, tile.Row * 57),
                    BackColor = Color.FromArgb(220, 0, 0, 0),
                    Parent = p
                };

                panel.Controls.Add(tile.Label);

                p.Controls.Add(panel);
                panel.BringToFront();
                if (hidelist2.Contains(tile) && tile is TileButton)
                    (tile as TileButton).Visible = false;
            }
        }
    }


}
