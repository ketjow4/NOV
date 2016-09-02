namespace MissionPlanner.GCSViews
{
    partial class InputFlightPlanning<T>
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.MinMaxLabel = new System.Windows.Forms.Label();
			this.NineButton = new System.Windows.Forms.Button();
			this.EightButton = new System.Windows.Forms.Button();
			this.SevenButton = new System.Windows.Forms.Button();
			this.SixButton = new System.Windows.Forms.Button();
			this.FiveButton = new System.Windows.Forms.Button();
			this.FourButton = new System.Windows.Forms.Button();
			this.ThreeButton = new System.Windows.Forms.Button();
			this.TwoButton = new System.Windows.Forms.Button();
			this.OneButton = new System.Windows.Forms.Button();
			this.BackspaceButton = new System.Windows.Forms.Button();
			this.DotButton = new System.Windows.Forms.Button();
			this.ZeroButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.CancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.InputTextBox = new System.Windows.Forms.TextBox();
			this.InfoLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.MinMaxLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.NineButton, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.EightButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.SevenButton, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.SixButton, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.FiveButton, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.FourButton, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.ThreeButton, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.TwoButton, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.OneButton, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.BackspaceButton, 3, 6);
			this.tableLayoutPanel1.Controls.Add(this.DotButton, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.ZeroButton, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.InputTextBox, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.InfoLabel, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 370);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// MinMaxLabel
			// 
			this.MinMaxLabel.AutoSize = true;
			this.MinMaxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.tableLayoutPanel1.SetColumnSpan(this.MinMaxLabel, 3);
			this.MinMaxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MinMaxLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.MinMaxLabel.ForeColor = System.Drawing.Color.White;
			this.MinMaxLabel.Location = new System.Drawing.Point(2, 48);
			this.MinMaxLabel.Margin = new System.Windows.Forms.Padding(2);
			this.MinMaxLabel.Name = "MinMaxLabel";
			this.MinMaxLabel.Size = new System.Drawing.Size(396, 42);
			this.MinMaxLabel.TabIndex = 18;
			this.MinMaxLabel.Text = "Min - Max";
			this.MinMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NineButton
			// 
			this.NineButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.NineButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NineButton.FlatAppearance.BorderSize = 0;
			this.NineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NineButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.NineButton.ForeColor = System.Drawing.Color.White;
			this.NineButton.Location = new System.Drawing.Point(268, 140);
			this.NineButton.Margin = new System.Windows.Forms.Padding(2);
			this.NineButton.Name = "NineButton";
			this.NineButton.Size = new System.Drawing.Size(130, 42);
			this.NineButton.TabIndex = 15;
			this.NineButton.Text = "9";
			this.NineButton.UseVisualStyleBackColor = false;
			this.NineButton.Click += new System.EventHandler(this.NineButton_Click);
			// 
			// EightButton
			// 
			this.EightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.EightButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EightButton.FlatAppearance.BorderSize = 0;
			this.EightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EightButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.EightButton.ForeColor = System.Drawing.Color.White;
			this.EightButton.Location = new System.Drawing.Point(135, 140);
			this.EightButton.Margin = new System.Windows.Forms.Padding(2);
			this.EightButton.Name = "EightButton";
			this.EightButton.Size = new System.Drawing.Size(129, 42);
			this.EightButton.TabIndex = 14;
			this.EightButton.Text = "8";
			this.EightButton.UseVisualStyleBackColor = false;
			this.EightButton.Click += new System.EventHandler(this.EightButton_Click);
			// 
			// SevenButton
			// 
			this.SevenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.SevenButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SevenButton.FlatAppearance.BorderSize = 0;
			this.SevenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SevenButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.SevenButton.ForeColor = System.Drawing.Color.White;
			this.SevenButton.Location = new System.Drawing.Point(2, 140);
			this.SevenButton.Margin = new System.Windows.Forms.Padding(2);
			this.SevenButton.Name = "SevenButton";
			this.SevenButton.Size = new System.Drawing.Size(129, 42);
			this.SevenButton.TabIndex = 13;
			this.SevenButton.Text = "7";
			this.SevenButton.UseVisualStyleBackColor = false;
			this.SevenButton.Click += new System.EventHandler(this.SevenButton_Click);
			// 
			// SixButton
			// 
			this.SixButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.SixButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SixButton.FlatAppearance.BorderSize = 0;
			this.SixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SixButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.SixButton.ForeColor = System.Drawing.Color.White;
			this.SixButton.Location = new System.Drawing.Point(268, 186);
			this.SixButton.Margin = new System.Windows.Forms.Padding(2);
			this.SixButton.Name = "SixButton";
			this.SixButton.Size = new System.Drawing.Size(130, 42);
			this.SixButton.TabIndex = 12;
			this.SixButton.Text = "6";
			this.SixButton.UseVisualStyleBackColor = false;
			this.SixButton.Click += new System.EventHandler(this.SixButton_Click);
			// 
			// FiveButton
			// 
			this.FiveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.FiveButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FiveButton.FlatAppearance.BorderSize = 0;
			this.FiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.FiveButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FiveButton.ForeColor = System.Drawing.Color.White;
			this.FiveButton.Location = new System.Drawing.Point(135, 186);
			this.FiveButton.Margin = new System.Windows.Forms.Padding(2);
			this.FiveButton.Name = "FiveButton";
			this.FiveButton.Size = new System.Drawing.Size(129, 42);
			this.FiveButton.TabIndex = 11;
			this.FiveButton.Text = "5";
			this.FiveButton.UseVisualStyleBackColor = false;
			this.FiveButton.Click += new System.EventHandler(this.FiveButton_Click);
			// 
			// FourButton
			// 
			this.FourButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.FourButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FourButton.FlatAppearance.BorderSize = 0;
			this.FourButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.FourButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FourButton.ForeColor = System.Drawing.Color.White;
			this.FourButton.Location = new System.Drawing.Point(2, 186);
			this.FourButton.Margin = new System.Windows.Forms.Padding(2);
			this.FourButton.Name = "FourButton";
			this.FourButton.Size = new System.Drawing.Size(129, 42);
			this.FourButton.TabIndex = 10;
			this.FourButton.Text = "4";
			this.FourButton.UseVisualStyleBackColor = false;
			this.FourButton.Click += new System.EventHandler(this.FourButton_Click);
			// 
			// ThreeButton
			// 
			this.ThreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.ThreeButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ThreeButton.FlatAppearance.BorderSize = 0;
			this.ThreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ThreeButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ThreeButton.ForeColor = System.Drawing.Color.White;
			this.ThreeButton.Location = new System.Drawing.Point(268, 232);
			this.ThreeButton.Margin = new System.Windows.Forms.Padding(2);
			this.ThreeButton.Name = "ThreeButton";
			this.ThreeButton.Size = new System.Drawing.Size(130, 42);
			this.ThreeButton.TabIndex = 9;
			this.ThreeButton.Text = "3";
			this.ThreeButton.UseVisualStyleBackColor = false;
			this.ThreeButton.Click += new System.EventHandler(this.ThreeButton_Click);
			// 
			// TwoButton
			// 
			this.TwoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.TwoButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TwoButton.FlatAppearance.BorderSize = 0;
			this.TwoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TwoButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.TwoButton.ForeColor = System.Drawing.Color.White;
			this.TwoButton.Location = new System.Drawing.Point(135, 232);
			this.TwoButton.Margin = new System.Windows.Forms.Padding(2);
			this.TwoButton.Name = "TwoButton";
			this.TwoButton.Size = new System.Drawing.Size(129, 42);
			this.TwoButton.TabIndex = 8;
			this.TwoButton.Text = "2";
			this.TwoButton.UseVisualStyleBackColor = false;
			this.TwoButton.Click += new System.EventHandler(this.TwoButton_Click);
			// 
			// OneButton
			// 
			this.OneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.OneButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OneButton.FlatAppearance.BorderSize = 0;
			this.OneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OneButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.OneButton.ForeColor = System.Drawing.Color.White;
			this.OneButton.Location = new System.Drawing.Point(2, 232);
			this.OneButton.Margin = new System.Windows.Forms.Padding(2);
			this.OneButton.Name = "OneButton";
			this.OneButton.Size = new System.Drawing.Size(129, 42);
			this.OneButton.TabIndex = 7;
			this.OneButton.Text = "1";
			this.OneButton.UseVisualStyleBackColor = false;
			this.OneButton.Click += new System.EventHandler(this.OneButton_Click);
			// 
			// BackspaceButton
			// 
			this.BackspaceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.BackspaceButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BackspaceButton.FlatAppearance.BorderSize = 0;
			this.BackspaceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BackspaceButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.BackspaceButton.ForeColor = System.Drawing.Color.White;
			this.BackspaceButton.Location = new System.Drawing.Point(268, 278);
			this.BackspaceButton.Margin = new System.Windows.Forms.Padding(2);
			this.BackspaceButton.Name = "BackspaceButton";
			this.BackspaceButton.Size = new System.Drawing.Size(130, 42);
			this.BackspaceButton.TabIndex = 6;
			this.BackspaceButton.Text = "←";
			this.BackspaceButton.UseVisualStyleBackColor = false;
			this.BackspaceButton.Click += new System.EventHandler(this.BackspaceButton_Click);
			// 
			// DotButton
			// 
			this.DotButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.DotButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DotButton.FlatAppearance.BorderSize = 0;
			this.DotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DotButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.DotButton.ForeColor = System.Drawing.Color.White;
			this.DotButton.Location = new System.Drawing.Point(135, 278);
			this.DotButton.Margin = new System.Windows.Forms.Padding(2);
			this.DotButton.Name = "DotButton";
			this.DotButton.Size = new System.Drawing.Size(129, 42);
			this.DotButton.TabIndex = 5;
			this.DotButton.Text = ".";
			this.DotButton.UseVisualStyleBackColor = false;
			this.DotButton.Click += new System.EventHandler(this.DotButton_Click);
			// 
			// ZeroButton
			// 
			this.ZeroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.ZeroButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ZeroButton.FlatAppearance.BorderSize = 0;
			this.ZeroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ZeroButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ZeroButton.ForeColor = System.Drawing.Color.White;
			this.ZeroButton.Location = new System.Drawing.Point(2, 278);
			this.ZeroButton.Margin = new System.Windows.Forms.Padding(2);
			this.ZeroButton.Name = "ZeroButton";
			this.ZeroButton.Size = new System.Drawing.Size(129, 42);
			this.ZeroButton.TabIndex = 4;
			this.ZeroButton.Text = "0";
			this.ZeroButton.UseVisualStyleBackColor = false;
			this.ZeroButton.Click += new System.EventHandler(this.ZeroButton_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.CancelButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.OkButton, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 325);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 42);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// CancelButton
			// 
			this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.CancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CancelButton.FlatAppearance.BorderSize = 0;
			this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CancelButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.CancelButton.ForeColor = System.Drawing.Color.White;
			this.CancelButton.Location = new System.Drawing.Point(198, 1);
			this.CancelButton.Margin = new System.Windows.Forms.Padding(1);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(195, 40);
			this.CancelButton.TabIndex = 3;
			this.CancelButton.Text = "CANCEL";
			this.CancelButton.UseVisualStyleBackColor = false;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.OkButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OkButton.FlatAppearance.BorderSize = 0;
			this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OkButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.OkButton.ForeColor = System.Drawing.Color.White;
			this.OkButton.Location = new System.Drawing.Point(1, 1);
			this.OkButton.Margin = new System.Windows.Forms.Padding(1);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(195, 40);
			this.OkButton.TabIndex = 1;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = false;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// InputTextBox
			// 
			this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tableLayoutPanel1.SetColumnSpan(this.InputTextBox, 3);
			this.InputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InputTextBox.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.InputTextBox.Location = new System.Drawing.Point(2, 94);
			this.InputTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.InputTextBox.Name = "InputTextBox";
			this.InputTextBox.Size = new System.Drawing.Size(396, 40);
			this.InputTextBox.TabIndex = 16;
			this.InputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
			// 
			// InfoLabel
			// 
			this.InfoLabel.AutoSize = true;
			this.InfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.tableLayoutPanel1.SetColumnSpan(this.InfoLabel, 3);
			this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InfoLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.InfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.InfoLabel.Location = new System.Drawing.Point(2, 2);
			this.InfoLabel.Margin = new System.Windows.Forms.Padding(2);
			this.InfoLabel.Name = "InfoLabel";
			this.InfoLabel.Size = new System.Drawing.Size(396, 42);
			this.InfoLabel.TabIndex = 17;
			this.InfoLabel.Text = "Question Here";
			this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// InputFlightPlanning
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Lime;
			this.ClientSize = new System.Drawing.Size(400, 370);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "InputFlightPlanning";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "InputFlightPlanning";
			this.TransparencyKey = System.Drawing.Color.Lime;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ZeroButton;
        private System.Windows.Forms.Button BackspaceButton;
        private System.Windows.Forms.Button DotButton;
        private System.Windows.Forms.Button FourButton;
        private System.Windows.Forms.Button ThreeButton;
        private System.Windows.Forms.Button TwoButton;
        private System.Windows.Forms.Button OneButton;
        private System.Windows.Forms.Button FiveButton;
        private System.Windows.Forms.Button SixButton;
        private System.Windows.Forms.Button SevenButton;
        private System.Windows.Forms.Button EightButton;
        private System.Windows.Forms.Button NineButton;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label MinMaxLabel;
    }
}