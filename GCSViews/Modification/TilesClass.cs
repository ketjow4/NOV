﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IronPython.Runtime.Operations;

namespace MissionPlanner.GCSViews.Modification
{
    public abstract class TileInfo
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

    public class TileData : TileInfo
    {
        private readonly string unit;
        private readonly Panel panel;
        private readonly Label valueLabel;
        private readonly Label unitLabel;
        public TileData(string text, int row, int column, string unit = "", EventHandler handler = null)
            : base(text, row, column)
        {
            this.unit = unit;
            ClickMethod = handler;
            //panel = new Panel { Size = new Size(163, 64) };
            //panel = new Panel { Size = new Size((int)(MainV2.View.Width * 0.1019), (int)(MainV2.View.Height * 0.072)) };
            panel = new Panel { Size = new Size(127, 55) };
            // panel.Dock = DockStyle.Fill;
            ;
            var headLabel = new Label()
            {
                Text = text,
                ForeColor = Color.FromArgb(255, 41, 171, 226),
                //Font = new Font("Century Gothic", 10, FontStyle.Italic),
                Font = new Font("Century Gothic", 8, FontStyle.Italic),
                //Top = 10,
                //Left = 10,
                //Width = 168,
                Top = 7,
                Left = 2,
                Width = 130,
                TextAlign = ContentAlignment.TopLeft

            };
            unitLabel = new Label()
            {
                Text = unit,
                ForeColor = Color.White,
                //Font = new Font("Century Gothic", 12),
                Font = new Font("Century Gothic", 10),
                TextAlign = ContentAlignment.BottomRight,
            };
            //unitLabel.Top = 64 - unitLabel.Height - 12;
            //unitLabel.Left = 168 - unitLabel.Width - 10;
            unitLabel.Top = 55 - unitLabel.Height - 8;
            unitLabel.Left = 130 - unitLabel.Width - 0;

            valueLabel = new Label()
            {
                ForeColor = Color.White,
                //Font = new Font("Century Gothic", 18),
                Font = new Font("Century Gothic", 15),
                //Left = 10,
                //Text = "0",
                //Height = 25,
                Left = 4,
                Text = "0",
                Height = 20,
                Width = 80,         //new for 1280x800 design
                Name = text.Replace(' ', '_').Replace('\n', '_')
            };
            //valueLabel.Top = 64 - valueLabel.Height - 12;
            valueLabel.Top = 55 - valueLabel.Height - 8;
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
                //Font = new Font("Century Gothic", 14)
                Font = new Font("Century Gothic", 11)
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
