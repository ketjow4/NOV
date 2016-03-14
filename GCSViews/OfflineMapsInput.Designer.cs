namespace MissionPlanner.GCSViews
{
    partial class OfflineMapsInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			gTrackBar.ColorPack colorPack1 = new gTrackBar.ColorPack();
			gTrackBar.ColorPack colorPack2 = new gTrackBar.ColorPack();
			gTrackBar.ColorPack colorPack3 = new gTrackBar.ColorPack();
			gTrackBar.ColorPack colorPack4 = new gTrackBar.ColorPack();
			gTrackBar.ColorPack colorPack5 = new gTrackBar.ColorPack();
			gTrackBar.ColorPack colorPack6 = new gTrackBar.ColorPack();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.MinZoomTrackBar = new gTrackBar.gTrackBar();
			this.MaxZoomTrackBar = new gTrackBar.gTrackBar();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.EstimatedSizeMBLabel = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.TilesCountLabel = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.OkButton, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.CancelButton, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.MinZoomTrackBar, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.MaxZoomTrackBar, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 310);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// OkButton
			// 
			this.OkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.OkButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OkButton.FlatAppearance.BorderSize = 0;
			this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OkButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.OkButton.ForeColor = System.Drawing.Color.White;
			this.OkButton.Location = new System.Drawing.Point(2, 260);
			this.OkButton.Margin = new System.Windows.Forms.Padding(2);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(246, 48);
			this.OkButton.TabIndex = 11;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = false;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.CancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CancelButton.FlatAppearance.BorderSize = 0;
			this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CancelButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.CancelButton.ForeColor = System.Drawing.Color.White;
			this.CancelButton.Location = new System.Drawing.Point(252, 260);
			this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(246, 48);
			this.CancelButton.TabIndex = 10;
			this.CancelButton.Text = "CANCEL";
			this.CancelButton.UseVisualStyleBackColor = false;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// MinZoomTrackBar
			// 
			this.MinZoomTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.MinZoomTrackBar.ChangeLarge = 5;
			colorPack1.Border = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack1.Face = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack1.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.MinZoomTrackBar.ColorDown = colorPack1;
			colorPack2.Border = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack2.Face = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack2.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.MinZoomTrackBar.ColorHover = colorPack2;
			colorPack3.Border = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack3.Face = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack3.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.MinZoomTrackBar.ColorUp = colorPack3;
			this.tableLayoutPanel1.SetColumnSpan(this.MinZoomTrackBar, 2);
			this.MinZoomTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MinZoomTrackBar.FloatValueFontColor = System.Drawing.SystemColors.ActiveBorder;
			this.MinZoomTrackBar.Label = "MIN ZOOM";
			this.MinZoomTrackBar.LabelColor = System.Drawing.Color.White;
			this.MinZoomTrackBar.LabelFont = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.MinZoomTrackBar.LabelPadding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.MinZoomTrackBar.LabelShow = true;
			this.MinZoomTrackBar.Location = new System.Drawing.Point(2, 88);
			this.MinZoomTrackBar.Margin = new System.Windows.Forms.Padding(2);
			this.MinZoomTrackBar.MaxValue = 20;
			this.MinZoomTrackBar.MinValue = 1;
			this.MinZoomTrackBar.Name = "MinZoomTrackBar";
			this.MinZoomTrackBar.Size = new System.Drawing.Size(496, 82);
			this.MinZoomTrackBar.SliderShape = gTrackBar.gTrackBar.eShape.Rectangle;
			this.MinZoomTrackBar.SliderSize = new System.Drawing.Size(15, 30);
			this.MinZoomTrackBar.SliderWidthHigh = 1F;
			this.MinZoomTrackBar.SliderWidthLow = 1F;
			this.MinZoomTrackBar.TabIndex = 5;
			this.MinZoomTrackBar.TickColor = System.Drawing.Color.White;
			this.MinZoomTrackBar.TickInterval = 1;
			this.MinZoomTrackBar.TickThickness = 2F;
			this.MinZoomTrackBar.TickType = gTrackBar.gTrackBar.eTickType.Down_Left;
			this.MinZoomTrackBar.UpDownShow = false;
			this.MinZoomTrackBar.Value = 1;
			this.MinZoomTrackBar.ValueAdjusted = 1F;
			this.MinZoomTrackBar.ValueBox = gTrackBar.gTrackBar.eValueBox.Right;
			this.MinZoomTrackBar.ValueBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.MinZoomTrackBar.ValueBoxBorder = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.MinZoomTrackBar.ValueBoxFont = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.MinZoomTrackBar.ValueBoxFontColor = System.Drawing.Color.White;
			this.MinZoomTrackBar.ValueBoxSize = new System.Drawing.Size(40, 40);
			this.MinZoomTrackBar.ValueDivisor = gTrackBar.gTrackBar.eValueDivisor.e1;
			this.MinZoomTrackBar.ValueStrFormat = null;
			this.MinZoomTrackBar.ValueChanged += new gTrackBar.gTrackBar.ValueChangedEventHandler(this.MinZoomTrackBar_ValueChanged);
			// 
			// MaxZoomTrackBar
			// 
			this.MaxZoomTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.MaxZoomTrackBar.ChangeLarge = 5;
			colorPack4.Border = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack4.Face = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack4.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.MaxZoomTrackBar.ColorDown = colorPack4;
			colorPack5.Border = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack5.Face = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack5.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.MaxZoomTrackBar.ColorHover = colorPack5;
			colorPack6.Border = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack6.Face = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			colorPack6.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.MaxZoomTrackBar.ColorUp = colorPack6;
			this.tableLayoutPanel1.SetColumnSpan(this.MaxZoomTrackBar, 2);
			this.MaxZoomTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MaxZoomTrackBar.FloatValueFontColor = System.Drawing.SystemColors.ActiveBorder;
			this.MaxZoomTrackBar.Label = "MAX ZOOM";
			this.MaxZoomTrackBar.LabelColor = System.Drawing.Color.White;
			this.MaxZoomTrackBar.LabelFont = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.MaxZoomTrackBar.LabelPadding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.MaxZoomTrackBar.LabelShow = true;
			this.MaxZoomTrackBar.Location = new System.Drawing.Point(2, 2);
			this.MaxZoomTrackBar.Margin = new System.Windows.Forms.Padding(2);
			this.MaxZoomTrackBar.MaxValue = 20;
			this.MaxZoomTrackBar.MinValue = 1;
			this.MaxZoomTrackBar.Name = "MaxZoomTrackBar";
			this.MaxZoomTrackBar.Size = new System.Drawing.Size(496, 82);
			this.MaxZoomTrackBar.SliderShape = gTrackBar.gTrackBar.eShape.Rectangle;
			this.MaxZoomTrackBar.SliderSize = new System.Drawing.Size(15, 30);
			this.MaxZoomTrackBar.SliderWidthHigh = 1F;
			this.MaxZoomTrackBar.SliderWidthLow = 1F;
			this.MaxZoomTrackBar.TabIndex = 4;
			this.MaxZoomTrackBar.TickColor = System.Drawing.Color.White;
			this.MaxZoomTrackBar.TickInterval = 1;
			this.MaxZoomTrackBar.TickThickness = 2F;
			this.MaxZoomTrackBar.TickType = gTrackBar.gTrackBar.eTickType.Down_Left;
			this.MaxZoomTrackBar.UpDownShow = false;
			this.MaxZoomTrackBar.Value = 1;
			this.MaxZoomTrackBar.ValueAdjusted = 1F;
			this.MaxZoomTrackBar.ValueBox = gTrackBar.gTrackBar.eValueBox.Right;
			this.MaxZoomTrackBar.ValueBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.MaxZoomTrackBar.ValueBoxBorder = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.MaxZoomTrackBar.ValueBoxFont = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.MaxZoomTrackBar.ValueBoxFontColor = System.Drawing.Color.White;
			this.MaxZoomTrackBar.ValueBoxSize = new System.Drawing.Size(40, 40);
			this.MaxZoomTrackBar.ValueDivisor = gTrackBar.gTrackBar.eValueDivisor.e1;
			this.MaxZoomTrackBar.ValueStrFormat = null;
			this.MaxZoomTrackBar.ValueChanged += new gTrackBar.gTrackBar.ValueChangedEventHandler(this.MaxZoomTrackBar_ValueChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.16667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.16667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
			this.tableLayoutPanel2.Controls.Add(this.EstimatedSizeMBLabel, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.button3, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.TilesCountLabel, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 175);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 80);
			this.tableLayoutPanel2.TabIndex = 12;
			// 
			// EstimatedSizeMBLabel
			// 
			this.EstimatedSizeMBLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.EstimatedSizeMBLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EstimatedSizeMBLabel.FlatAppearance.BorderSize = 0;
			this.EstimatedSizeMBLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.EstimatedSizeMBLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.EstimatedSizeMBLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EstimatedSizeMBLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.EstimatedSizeMBLabel.ForeColor = System.Drawing.Color.White;
			this.EstimatedSizeMBLabel.Location = new System.Drawing.Point(392, 2);
			this.EstimatedSizeMBLabel.Margin = new System.Windows.Forms.Padding(2);
			this.EstimatedSizeMBLabel.Name = "EstimatedSizeMBLabel";
			this.EstimatedSizeMBLabel.Size = new System.Drawing.Size(100, 76);
			this.EstimatedSizeMBLabel.TabIndex = 15;
			this.EstimatedSizeMBLabel.Text = "0";
			this.EstimatedSizeMBLabel.UseVisualStyleBackColor = false;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button3.ForeColor = System.Drawing.Color.White;
			this.button3.Location = new System.Drawing.Point(248, 2);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(140, 76);
			this.button3.TabIndex = 14;
			this.button3.Text = "ESTIMATED SIZE (MB)";
			this.button3.UseVisualStyleBackColor = false;
			// 
			// TilesCountLabel
			// 
			this.TilesCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.TilesCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TilesCountLabel.FlatAppearance.BorderSize = 0;
			this.TilesCountLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.TilesCountLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.TilesCountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TilesCountLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.TilesCountLabel.ForeColor = System.Drawing.Color.White;
			this.TilesCountLabel.Location = new System.Drawing.Point(146, 2);
			this.TilesCountLabel.Margin = new System.Windows.Forms.Padding(2);
			this.TilesCountLabel.Name = "TilesCountLabel";
			this.TilesCountLabel.Size = new System.Drawing.Size(98, 76);
			this.TilesCountLabel.TabIndex = 13;
			this.TilesCountLabel.Text = "0";
			this.TilesCountLabel.UseVisualStyleBackColor = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(2, 2);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(140, 76);
			this.button1.TabIndex = 12;
			this.button1.Text = "TILES COUNT";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// OfflineMapsInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Lime;
			this.ClientSize = new System.Drawing.Size(500, 310);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "OfflineMapsInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OfflineMapsInput";
			this.TransparencyKey = System.Drawing.Color.Lime;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private gTrackBar.gTrackBar MaxZoomTrackBar;
        private gTrackBar.gTrackBar MinZoomTrackBar;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button EstimatedSizeMBLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button TilesCountLabel;
        private System.Windows.Forms.Button button1;
    }
}