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

namespace MissionPlanner.GCSViews
{
    public class TilesFlightData : Tiles
    {

        internal static List<TileInfo> commonTiles = null;

        private static TileButton ArmButton = null;
        private static TileButton panicButton = null;
        private static TileButton abortLandButton = null;
        private static TileButton guidedModeButton = null;
        private static TileButton exitButton = null;
        private static TileButton takeOff;
        private static TileData windSpeed = null;

        public static TileButton ConnectButton;
        private static TileData GPSfixing;

        public static TileData DistToMovingBase { get; private set; }
        public static TileData DistToHome { get; private set; }

        public static void BindingsForTransparentLabel()
        {
            Binding b = new Binding("Visible", FlightData.instance.hud1.data, "warning", true);
            b.Format += (obj, args) => { if ((obj as Binding).Control.Text == "") args.Value = false; else args.Value = true; };
            FlightData.instance.transparent.DataBindings.Add(b);
            FlightData.instance.transparent.DataBindings.Add(new Binding("Text", FlightData.instance.hud1.data, "warning", true));
        }

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


        public static void SetTilesFlightData(Panel p)
        {
            GpsLocator.GpsInfoEvent += GpsLocator_GpsInfoEvent;

            CurrentState.ArmedStatusChanged += Cs_ArmedSet;
            CurrentState.LandedChanged += CurrentState_LandedChanged;

            //------------------------------------------------------------Flight Mode tiles---------------------------------------------------------------//
            windSpeed = new TileData("WIND SPEED", ResolutionManager.WindSpeedLocation.Y, ResolutionManager.WindSpeedLocation.X, "m/s");
            TileData mode;

            DistToMovingBase = new TileData("DISTANCE TO BASE", 1, 2, "m", DistToBaseEventClc);
            DistToHome = new TileData("DISTANCE TO HOME", 1, 2, "m", DistToHomeEventClc);
            
            var tilesFlightMode = new List<TileInfo>(new TileInfo[]
            {
                new TileButton("FLIGHT\nINFO", 0, 0, (sender, e) => {}, Color.FromArgb(255, 255, 51, 0)),
                new TileData("GROUND SPEED", 0, 1, "m/s"),
                new TileData("ALTITUDE", 0, 2, "m"),
                new TileData("TIME IN THE AIR", 0, 3, "h:m:s"),
                new TileData("BATTERY REMAINING", 0, 4, "%"),
                new TileButton("FLIGHT\nPLANNING", 1, 0, FlighPlanningShowEvent),
                new TileData("AIR SPEED", 1, 1, "m/s"),
                DistToHome,
                DistToMovingBase,
                new TileData("BATTERY VOLTAGE", 1, 3, "V"),
                new TileData("CURRENT", 1, 4, "A"),
                new TileData("GPSHDOP", 1, 5, ""),
                new TileData("GPS SAT COUNT", 1, 6, ""),
                new TileData("RADIO SIGNAL", 0, 5, "%"),
                new TileButton("START\nMISSION",2,6,StartMissionEvent),                
                guidedModeButton = new TileButton("GUIDED\nMODE",3,8,GuidedModeEvent),
                mode = new TileData("MODE",0,6,""),
                panicButton = new TileButton("BRAKE",ResolutionManager.PanicButtonLocation.Y,ResolutionManager.PanicButtonLocation.X, PanicButtonEvent),
                abortLandButton = new TileButton("ABORT\nLANDING",ResolutionManager.AbortLandLocation.Y,ResolutionManager.AbortLandLocation.X, AbortLandEvent),
                windSpeed,
                new TileButton("AUTO", 1, 7, AutoModeEvent),
                new TileButton("RESTART", 2, 7, RestartMissionEvent),
                new TileButton("RETURN", 2, 8, ReturnToLaunchEvent),
                new TileButton("LAND", 1, 8, LandEvent),
                ConnectButton = new TileButton("CONNECT", 0, 7, ConnectEvent),
            ArmButton = new TileButton("ARM", 0, 8, ArmDisarmEvent),
            exitButton = new TileButton("EXIT", 2, 0, ExitEvent),
            takeOff = new TileButton("TAKEOFF", 4, 8, TakeOffEvent),
            GPSfixing = new TileData("GPS CONNECTED",7,0,""),
            });
            commonTiles = tilesFlightMode;      //bad hax
            mode.ValueLabel.Width = ResolutionManager.MagicWidth;    //ugly !!!

            SetToView(tilesFlightMode, p);
            abortLandButton.Visible = false;

            GPSfixing.Visible = false;
            DistToHome.Visible = true;
            DistToMovingBase.Visible = false;
            
        }

        private static void DistToBaseEventClc(object sender, EventArgs e)
        {
            DistToHome.Visible = true;
            DistToMovingBase.Visible = false;
        }

        private static void DistToHomeEventClc(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.MovingBase.Lat != 0 && MainV2.comPort.MAV.cs.MovingBase.Lng != 0)
            {
                DistToHome.Visible = false;
                DistToMovingBase.Visible = true;
            }
        }

        private static void GpsLocator_GpsInfoEvent(object sender, PortFoundEventArgs args)
        {
            try
            {
                GPSfixing.Label.BeginInvoke(new MethodInvoker(delegate
                {
                    GPSfixing.Value = args.Message;
                    if (args.Message == "FIX OK")
                    {
                        GPSfixing.Visible = false;
                    }
                    else
                        GPSfixing.Visible = true;
                }));
            }
            catch
            {
            }
        }


        #region EventsFlightData

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

        private static void StartMissionEvent(object sender, EventArgs e)
        {
            if (CheckMissionSpeed())
            {
                CustomMessageBox.Show("Speed is out of range for this platform.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2)
                    MainV2.comPort.setMode("BRAKE");
                else if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane)
                    MainV2.comPort.setMode("CIRCLE");
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
            if (!MainV2.comPort.MAV.cs.Landed && MainV2.comPort.MAV.cs.Armed)       //Can't exit when armed and not landed
                return;
            if (CustomMessageBox.Show("Exit application?", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            MainV2.config["grid_sidelap"] = TilesFlightPlanning.SideLap.ToString();
            MainV2.config["grid_overlap"] = TilesFlightPlanning.OverLap.ToString();
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
                armed = MainV2.comPort.MAV.cs.Armed;
                if (armed)
                    commonTiles.Where(x => x.Label.Text == "ARM").First().Label.Text = "DISARM";
                if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2)
                {
                    fsMin = fsMinOgar;
                    fsMax = fsMaxOgar;
                    windSpeed.Visible = false;
                    FlightData.instance.windDir1.Visible = false;
                }
                else if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane)
                {
                    fsMin = fsMinAlbatros;
                    fsMax = fsMaxAlbatros;
                    abortLandButton.Visible = true;
                }

            }
            else                    //disconnect
            {

                if (MainV2.comPort.MAV.cs.Armed)
                {
                    CustomMessageBox.Show("Cannot disconnect when armed. Disarm first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FlightData.instance.hud1.warning = "";
                MainV2.instance.MenuConnect_Click(null, null);
                windSpeed.Visible = true;
                FlightData.instance.windDir1.Visible = true;
                abortLandButton.Visible = false;
            }
        }


        private static void ArmDisarmEvent(object sender, EventArgs args)
        {
            if (!MainV2.comPort.MAV.cs.Armed)         //if we disarm then don't do preflightcheck
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

        private static bool CheckMissionSpeed()
        {
            var Commands = GetWP();

            if (Commands.Any(c => (c.id == (byte)MAVLink.MAV_CMD.DO_CHANGE_SPEED && (c.p2 > fsMax || c.p2 < fsMin))))
                return true;

            return false;
        }

        private static List<Locationwp> GetWP()
        {
            List<Locationwp> cmds = new List<Locationwp>();

            try
            {
                MAVLinkInterface port = MainV2.comPort;
                MainV2.comPort.giveComport = true;

                int cmdcount = port.getWPCount();

                for (ushort a = 0; a < cmdcount; a++)
                {
                    cmds.Add(port.getWP(a));
                }

                port.setWPACK();
                return cmds;
            }
            catch
            {
                throw;
            }
        }

        private static void Cs_ArmedSet(object sender, EventArgs e)
        {
            try
            {
                ArmButton.Label.BeginInvoke(new MethodInvoker(delegate
                {
                    if (MainV2.comPort.MAV.cs.Armed)
                        ArmButton.Label.Text = "DISARM";
                    else
                        ArmButton.Label.Text = "ARM";
                }));

                exitButton.Label.BeginInvoke(new MethodInvoker(delegate
                {
                    if (MainV2.comPort.MAV.cs.Armed)
                    {
                        exitButton.UnsetHoverEvent();
                        exitButton.PanelColor = TileButton.HoverColor;
                        exitButton.Label.ForeColor = Color.FromArgb(178, 178, 178);
                    }
                    else
                    {
                        exitButton.SetHoverEvents();
                        exitButton.PanelColor = TileButton.StandardColor;
                        exitButton.Label.ForeColor = Color.White;
                    }
                }));
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message);
            }
        }

        private static void CurrentState_LandedChanged(object sender, EventArgs e)
        {
            takeOff.Label.BeginInvoke(new MethodInvoker(delegate
            {
                if (MainV2.comPort.MAV.cs.Landed)
                    takeOff.Label.Text = "TAKEOFF";
                else
                    takeOff.Label.Text = "CHANGE ALT";
            }));
        }

    }
}
