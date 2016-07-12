using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IronPython.Runtime.Operations;
using MissionPlanner.Controls.Modification;

namespace MissionPlanner.GCSViews.Modification
{
    public abstract class TileInfo
    {
        protected readonly string text;

        public double Row { get; private set; }
        public double Column { get; private set; }

        protected TileInfo(string text, double row, double column)
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

    public class TileData : TileInfo
    {
        private readonly string unit;
        private readonly Panel panel;
        private readonly Label valueLabel;
        private readonly Label unitLabel;
        private readonly Label headLabel;
        private readonly List<string> ButtonsNames;


        public TileData(string text, double row, double column, string unit = "", EventHandler handler = null)
            : base(text, row, column)
        {
            
            this.unit = unit;
            ClickMethod = handler;
            panel = new Panel { Size = ResolutionManager.PanelSize };
            ;
            headLabel = new Label()
            {
                Text = text,
                ForeColor = Color.FromArgb(255, 41, 171, 226),
                Font = new Font("Century Gothic", ResolutionManager.HeadLabelFontSize, FontStyle.Italic),
                Top = ResolutionManager.HeadLabelTop,
                Left = ResolutionManager.HeadLabelLeft,
                Width = ResolutionManager.HeadLabelWidth,
                TextAlign = ContentAlignment.TopLeft
            };

            unitLabel = new Label()
            {
                Text = unit,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", ResolutionManager.UnitLabelFontSize),
                TextAlign = ContentAlignment.BottomRight,
            };
            unitLabel.Top = ResolutionManager.UnitLabelTop;
            unitLabel.Left = ResolutionManager.UnitLabelLeft;
           

            valueLabel = new Label()
            {
                ForeColor = Color.White,
                Font = new Font("Century Gothic", ResolutionManager.ValueLabelFontSize),
                Left = ResolutionManager.ValueLabelLeft,
                Text = "0",
                Height = ResolutionManager.ValueLabelHeight,
                Width = ResolutionManager.ValueLabelWidth,         //new for 1280x800 design
                Name = text.Replace(' ', '_').Replace('\n', '_'),                
            };

            //headLabel.AutoSize = true;
            //UnitLabel.AutoSize = true;
            //valueLabel.AutoSize = true;
            //panel.AutoSize = true;


            valueLabel.Top = ResolutionManager.ValueLabelTop;
            panel.Controls.Add(unitLabel);
            panel.Controls.Add(valueLabel);
            valueLabel.BringToFront();
            panel.Controls.Add(headLabel);
            panel.Click += ClickMethod;
            panel.MouseEnter += EnterHover;
            panel.MouseLeave += LeaveHover;
            foreach (var label in panel.Controls.OfType<Label>())
            {
                label.Click += ClickMethod;
                label.MouseEnter += EnterHover;
                label.MouseLeave += LeaveHover;
            }
            panel.Dock = DockStyle.Fill;
            ButtonsNames = new List<string>() {"ALTITUDE ", "OBSERVATION HEAD", "SIDELAP", "OVERLAP", "FLYING SPEED", "ANGLE", "START FROM"};    //ugly!!
        }
        public EventHandler ClickMethod;

        
        private void EnterHover(object sender, EventArgs args)
        {
            foreach (var name in ButtonsNames)
            {
                if(headLabel.Text == name)
                {
                    this.panel.BackColor = Color.FromArgb(85, 86, 88);
                }
            }
        }

        private void LeaveHover(object sender, EventArgs args)
        {
            foreach (var name in ButtonsNames)
            {
                if (headLabel.Text == name)
                {
                    this.panel.BackColor = Color.FromArgb(22, 23, 24);
                }
            }
        }

        public Label UnitLabel
        {
            get { return unitLabel; }
        }

        public Label ValueLabel
        {
            get { return valueLabel; }
        }

        public override Control Label
        {
            get { return panel; }
        }

        public string Value
        {
            get { return valueLabel.Text; }
            set { valueLabel.Text = value; }
        }

        public bool Visible
        {
            set { if (panel.Parent != null) panel.Parent.Visible = value; }
            get { return panel.Parent != null && panel.Parent.Visible; }
        }
    }


    public class TileButton : TileInfo
    {
        private readonly Color color;
        private Label label;
        private static readonly Color hoverColor = Color.FromArgb(85, 86, 88);
        private static readonly Color standardColor = Color.FromArgb(22, 23, 24);

        public TileButton(string text, double row, double column, EventHandler handler = null, Color? color = null)
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
                Font = new Font("Century Gothic", ResolutionManager.TileButtonFontSize)
            };
            label.Click += ClickMethod;
            SetHoverEvents();
                        
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


        public void UnsetHoverEvent()
        {
            label.MouseHover -= EnterHover;
            label.MouseLeave -= LeaveHover;
        }

        public void SetHoverEvents()
        {
            label.MouseEnter += EnterHover;
            label.MouseLeave += LeaveHover;
        }

        private void EnterHover(object sender, EventArgs args)
        {
            if (this.label.BackColor != standardColor)     //when control have other color than dark grey don't change it
                return;
            this.label.BackColor = hoverColor;
        }

        private void LeaveHover(object sender, EventArgs args)
        {
            if (this.label.BackColor != hoverColor)
                return;
            this.label.BackColor = standardColor;
        }

        public void ChangeButtonColor(Color color)
        {
            this.label.BackColor = color;
        }

        public void SetToOriginal()
        {
            this.label.BackColor = standardColor;
        }

        public void SetToHoverColor()
        {
            this.label.BackColor = hoverColor;
        }

        public Color PanelColor
        {
            set {
                    label.BackColor = value;
                }

            get {
                    return label.BackColor;
                }
        }

        public static Color StandardColor
        {
            get
            {
                return standardColor;
            }
        }

        public static Color HoverColor
        {
            get
            {
                return hoverColor;
            }
        }
    }
}
