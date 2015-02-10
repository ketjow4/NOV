﻿using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using IronPython.Runtime.Operations;

namespace MissionPlanner.GCSViews
{
    public class Tiles
    {
        static TileData altInfo = null;
        static TileData angleInfo = null;

        private static bool connected = false;

        private static int altMin = 75;
        private static int altMax = 450;

        public static int AngleVal { get { return Convert.ToInt32(angleInfo.Value); } } // duup so ugly!
        public static int AltitudeVal { get { return Convert.ToInt32(altInfo.Value); } } // duup so ugly!

        public static void ChangeAlt(int v)
        {
            int val = Convert.ToInt32(altInfo.Value) + v;
            if (val < altMin) val = altMin;
            else if (val > altMax) val = altMax;
            FlightPlanner.instance.TXT_DefaultAlt.Text = altInfo.Value = val.ToString();
        }

        public static void SetTiles(Panel p, bool isFlightMode)
        {
            var angleBtnUp = new TileButton("+5", 2, 4, (sender, args) => angleInfo.Value = (Convert.ToInt32(angleInfo.Value) + 5).ToString());
            var angleBtnDown = new TileButton("-5", 3, 4, (sender, args) => angleInfo.Value = (Convert.ToInt32(angleInfo.Value) - 5).ToString());
            TileButton angleBtnOk = null;
            angleBtnOk = new TileButton("OK", 4, 4, (sender, args) => angleBtnUp.Visible = angleBtnDown.Visible = angleBtnOk.Visible = false);
            var altBtnUp = new TileButton("+10", 2, 5, (sender, args) => ChangeAlt(10));
            var altBtnDown = new TileButton("-10", 3, 5, (sender, args) => ChangeAlt(-10));
            TileButton altBtnOk = null;
            altBtnOk = new TileButton("OK", 4, 5, (sender, args) => altBtnDown.Visible = altBtnUp.Visible = altBtnOk.Visible = false);


            altInfo = new TileData("ALTITUDE ", 1, 5, "m", (sender, args) =>
            {
                var x = !altBtnUp.Visible;
                altBtnUp.Visible = altBtnDown.Visible = altBtnOk.Visible = x;
            });
            if (!isFlightMode && MainV2.config.ContainsKey("TXT_DefaultAlt"))
                altInfo.Value = FlightPlanner.instance.TXT_DefaultAlt.Text = MainV2.config["TXT_DefaultAlt"].ToString();
            

           
           

            var tilesFlightMode = new List<TileInfo>(new TileInfo[]
            {
               new TileButton("FLIGHT\nINFO", 0, 0, (sender, e) => MainV2.View.ShowScreen("FlightData"),
                    Color.FromArgb(255, 255, 51, 0)),
                new TileData("GROUND SPEED", 0, 1, "km/h"),
                new TileData("ALTITUDE", 0, 2, "m"),
                new TileData("TIME IN THE AIR", 0, 3),   
                new TileData("BATTERY REMAINING", 0, 4, "%"),
                new TileData("GROUND RESOLUTION", 0, 5, "cm"),  //TODO implement
               
                new TileButton("DISARM", 0, 7),
                new TileButton("FLIGHT\nPLANNING", 1, 0, (sender, e) => MainV2.View.ShowScreen("FlightPlanner")),
                new TileData("AIR SPEED", 1, 1, "km/h"),
                new TileData("DISTANCE TO HOME", 1, 2, "km"),
                new TileData("BATTERY VOLTAGE", 1, 3, "V"),
                new TileData("CURRENT", 1, 4, "A"),
                new TileData("GPS SIGNAL", 1, 5, "%"),
            });


            TileButton defaultHead, cam1Head, cam2Head;
            defaultHead = cam1Head = cam2Head = null;
            defaultHead = new TileButton("DEFAULT", 2, 3,(sender, args) => { cam1Head.Visible = cam2Head.Visible = defaultHead.Visible = false; });
            cam1Head = new TileButton("CAMERA 1", 3, 3, (sender, args) => { cam1Head.Visible = cam2Head.Visible = defaultHead.Visible = false; });
            cam2Head = new TileButton("CAMERA 2", 4, 3, (sender, args) => { cam1Head.Visible = cam2Head.Visible = defaultHead.Visible = false; });

            TileData obsHeadBtn = null;
            obsHeadBtn = new TileData("OBSERVATION HEAD", 1, 3, "",(sender, args) =>
            {
                var x = !defaultHead.Visible;
                defaultHead.Visible = cam1Head.Visible = cam2Head.Visible = x;
                obsHeadBtn.Value = "Default";
            });

            var hideList = new TileInfo[] { altBtnUp, altBtnDown, altBtnOk, angleBtnDown, angleBtnUp, angleBtnOk,defaultHead,cam1Head,cam2Head };
            obsHeadBtn.ClickMethod(null,null);


            angleInfo = new TileData("ANGLE", 1, 4, "deg", (sender, args) =>
            {
                var x = !angleBtnUp.Visible;
                angleBtnUp.Visible = angleBtnDown.Visible = angleBtnOk.Visible = x;
            });

            const string polygonmodestring = "POLYGON\nMODE";

            // todo copy paste code ;/
            var tilesFlightPlanning = new List<TileInfo>(new TileInfo[]
            {
                obsHeadBtn,
                cam2Head,defaultHead,cam1Head,                                            
                altBtnUp, altBtnDown, altBtnOk, angleBtnDown, angleBtnUp, angleBtnOk,
                new TileButton("FLIGHT\nINFO", 0, 0, (sender, e) => MainV2.View.ShowScreen("FlightData")),
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
                new TileData("DISTANCE", 0, 4, "km"),
                new TileData("GROUND RESOLUTION", 0, 5, "cm"),
                new TileButton("WRITE WAYPOINTS", 2, 8, (sender, args) => FlightPlanner.instance.BUT_write_Click(sender, args)), 
                new TileButton("FLIGHT\nPLANNING", 1, 0, (sender, e) => MainV2.View.ShowScreen("FlightPlanner"),
                    Color.FromArgb(255, 255, 51, 0)),
                    
                new TileButton("PATH\nGENERATION", 1, 1, (sender, e)  =>
            {
                {
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

               new TileButton("SAVE WP FILE", 0,8, (sender, args) => FlightPlanner.instance.BUT_saveWPFile_Click(null, null)),
               new TileButton("LOAD WP FILE", 1,8, (sender, args) => FlightPlanner.instance.BUT_loadwpfile_Click(null, null)),
               
            });

            var tilesArray = (isFlightMode) ? tilesFlightMode : tilesFlightPlanning;
            tilesArray.Add(new TileButton("AUTO", 1, 6, (sender, e) =>
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
            tilesArray.Add(new TileButton("RESTART", 2, 6, (sender, args) =>
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
            tilesArray.Add(new TileButton("RETURN", 2, 7, (sender, args) =>
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
            tilesArray.Add(new TileButton("LAND", 1, 7, (sender, args) =>
            {
                int wpCount = MainV2.comPort.getWPCount();
                List<Utilities.Locationwp> wpList = new List<Utilities.Locationwp>;
                for (int i = 0; i < wpCount; i++)
                {
                    wpList.Add(MainV2.comPort.getWP((ushort)i));
                }
                
                foreach( var wp in wpList)
                {
                    //if(wp.id == MAVLink.MAV_CMD.LAND)
                    //{

                    //}
                }
                                                                            
                
                //FlightData.instance.BUT_loadtelem_Click(null, null);
                //FlightData.instance.BUT_playlog_Click(null, null);
                //try
                //{
                //    FlightData.instance.BUT_clear_track_Click(sender, null);

                //    MainV2.comPort.lastlogread = DateTime.MinValue;
                //    MainV2.comPort.MAV.cs.ResetInternals();

                //    if (MainV2.comPort.logplaybackfile != null)
                //        MainV2.comPort.logplaybackfile.BaseStream.Position =
                //            (long)(MainV2.comPort.logplaybackfile.BaseStream.Length * (40 / 100.0));

                //    FlightData.instance.updateLogPlayPosition();
                //}
                //catch
                //{
                //}
            })); // todo not implemented
            // (sender, args) => FlightPlanner.instance.landToolStripMenuItem_Click(null, null)));     
            tilesArray.Add(new TileButton("ARM/DISARM", 0, 7,
                (sender, args) => FlightData.instance.BUT_ARM_Click(sender, args)));       
            tilesArray.Add(new TileData("WIND SPEED", 9, 0, "m/s"));


            tilesArray.Add(new TileButton("CONNECT", 0, 6, (sender, args) =>            //todo change here that in flight planning name is the same as in flight data
               {
                   var conBut = sender as Label;
                   if (connected == false)  //connect
                   {
                       conBut.Text = "DISCONNECT";
                       MainV2.instance.MenuConnect_Click(null, null);
                       connected = true;
                   }
                   else                    //disconnect
                   {
                       conBut.Text = "CONNECT";
                       MainV2.instance.MenuConnect_Click(null, null);
                       connected = false;
                   }
               }));

            foreach (var tile in tilesArray)
            {
                //TODO: transparent
                var panel = new Panel
                {
                    Size = new Size(168, 64),
                    Location = new Point(tile.Column * 170, tile.Row * 66),
                    BackColor = Color.FromArgb(220, 0, 0, 0),
                    Parent = p
                };

                panel.Controls.Add(tile.Label);

                p.Controls.Add(panel);
                panel.BringToFront();
                if (hideList.Contains(tile) && tile is TileButton)
                    (tile as TileButton).Visible = false;
            }
        }
    }




    internal abstract class TileInfo
    {
        protected readonly string text;

        public int Row { get; private set; }
        public int Column { get; private set; }

        protected TileInfo(string text, int row, int column)
        {
            this.text = text;
            Row = row;
            Column = column;
        }

        public string Text
        {
            get { return text; }
        }

        public abstract Control Label { get; }
    }

    internal class TileData : TileInfo
    {
        private readonly string unit;
        private readonly Panel panel;
        private readonly Label valueLabel;
        public TileData(string text, int row, int column, string unit = "", EventHandler handler = null)
            : base(text, row, column)
        {
            this.unit = unit;
            ClickMethod = handler;
            panel = new Panel { Size = new Size(163, 64) };
            // panel.Dock = DockStyle.Fill;
            ;
            var headLabel = new Label()
            {
                Text = text,
                ForeColor = Color.FromArgb(255, 41, 171, 226),
                Font = new Font("Century Gothic", 10, FontStyle.Italic),
                Top = 10,
                Left = 10,
                Width = 165,
                TextAlign = ContentAlignment.TopLeft

            };
            var unitLabel = new Label()
            {
                Text = unit,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.BottomRight,
            };
            unitLabel.Top = 64 - unitLabel.Height - 12;
            unitLabel.Left = 158 - unitLabel.Width - 10;

            valueLabel = new Label()
            {
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 18),
                Left = 10,
                Text = "0",
                Height = 25,
                Name = text.Replace(' ', '_').Replace('\n', '_')
            };
            valueLabel.Top = 64 - valueLabel.Height - 12;
            panel.Controls.Add(unitLabel);
            panel.Controls.Add(valueLabel);
            valueLabel.BringToFront();
            panel.Controls.Add(headLabel);
            panel.Click += ClickMethod;
            foreach (var label in panel.Controls.OfType<Label>())
            {
                label.Click += ClickMethod;
            }
            panel.Dock = DockStyle.Fill;
        }
        public EventHandler ClickMethod;

        public override Control Label
        {
            get { return panel; }
        }

        public string Value
        {
            get { return valueLabel.Text; }
            set { valueLabel.Text = value; }
        }
    }

    internal class TileButton : TileInfo
    {
        private readonly Color color;
        private Label label;

        public TileButton(string text, int row, int column, EventHandler handler = null, Color? color = null)
            : base(text, row, column)
        {
            this.color = color == null ? Color.White : color.GetValueOrDefault();
            ClickMethod += handler;
            label = new Label
            {
                Text = text,
                ForeColor = this.color,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Century Gothic", 14)
            };
            label.Click += ClickMethod;
        }

        public EventHandler ClickMethod;

        public override Control Label
        {
            get { return label; }
        }

        public bool Visible
        {
            set { if (label.Parent != null) label.Parent.Visible = value; }
            get { return label.Parent != null && label.Parent.Visible; }
        }

    }

}
