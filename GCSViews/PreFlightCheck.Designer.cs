﻿using MissionPlanner.Controls;

namespace MissionPlanner.GCSViews
{
    partial class PreFlightCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreFlightCheck));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.employee_data = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBoxTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.warning_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.EmployeeLabel = new MissionPlanner.Controls.MyLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SkipButton = new MissionPlanner.Controls.MyButton();
            this.CompassCalibrationButton = new MissionPlanner.Controls.MyButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.CancelButton = new MissionPlanner.Controls.MyButton();
            this.ReadyButton = new MissionPlanner.Controls.MyButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GPSFix = new MissionPlanner.Controls.MyButton();
            this.BatteryVol = new MissionPlanner.Controls.MyButton();
            this.CheckBoxTableLayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(403, 36);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Wind isn\'t too strong";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // employee_data
            // 
            this.employee_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employee_data.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employee_data.FormattingEnabled = true;
            this.employee_data.Location = new System.Drawing.Point(3, 38);
            this.employee_data.Name = "employee_data";
            this.employee_data.Size = new System.Drawing.Size(201, 28);
            this.employee_data.TabIndex = 5;
            this.employee_data.SelectedIndexChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox2.Location = new System.Drawing.Point(3, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(403, 36);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Propellers are mounted correctly";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox3.Location = new System.Drawing.Point(3, 87);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(403, 36);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "No physical damege seen on UAV";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // CheckBoxTableLayout
            // 
            this.CheckBoxTableLayout.ColumnCount = 1;
            this.tableLayoutPanel2.SetColumnSpan(this.CheckBoxTableLayout, 2);
            this.CheckBoxTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CheckBoxTableLayout.Controls.Add(this.checkBox8, 0, 6);
            this.CheckBoxTableLayout.Controls.Add(this.checkBox7, 0, 5);
            this.CheckBoxTableLayout.Controls.Add(this.checkBox6, 0, 4);
            this.CheckBoxTableLayout.Controls.Add(this.checkBox5, 0, 3);
            this.CheckBoxTableLayout.Controls.Add(this.checkBox4, 0, 3);
            this.CheckBoxTableLayout.Controls.Add(this.checkBox3, 0, 2);
            this.CheckBoxTableLayout.Controls.Add(this.checkBox2, 0, 1);
            this.CheckBoxTableLayout.Controls.Add(this.checkBox1, 0, 0);
            this.CheckBoxTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxTableLayout.Location = new System.Drawing.Point(3, 119);
            this.CheckBoxTableLayout.Name = "CheckBoxTableLayout";
            this.CheckBoxTableLayout.RowCount = 7;
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CheckBoxTableLayout.Size = new System.Drawing.Size(409, 327);
            this.CheckBoxTableLayout.TabIndex = 9;
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox8.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox8.Location = new System.Drawing.Point(3, 299);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(403, 36);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.Text = "Throttle on RC is all way down";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox7.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox7.Location = new System.Drawing.Point(3, 255);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(403, 38);
            this.checkBox7.TabIndex = 12;
            this.checkBox7.Text = "Take into account terrain obstacles";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox6.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox6.Location = new System.Drawing.Point(3, 213);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(403, 36);
            this.checkBox6.TabIndex = 11;
            this.checkBox6.Text = "Landing place is secured";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox5.Location = new System.Drawing.Point(3, 171);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(403, 36);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "The head is properly secured to UAV";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox4.Location = new System.Drawing.Point(3, 129);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(403, 36);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.Text = "Propellers can move freely";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // warning_label
            // 
            this.warning_label.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.warning_label, 2);
            this.warning_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warning_label.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warning_label.ForeColor = System.Drawing.Color.Red;
            this.warning_label.Location = new System.Drawing.Point(3, 68);
            this.warning_label.Margin = new System.Windows.Forms.Padding(3);
            this.warning_label.MaximumSize = new System.Drawing.Size(405, 0);
            this.warning_label.Name = "warning_label";
            this.warning_label.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.warning_label.Size = new System.Drawing.Size(405, 45);
            this.warning_label.TabIndex = 15;
            this.warning_label.UseMnemonic = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.EmployeeLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.warning_label, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.employee_data, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.CheckBoxTableLayout, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.900936F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.893655F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.97573F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.69354F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.53614F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(415, 515);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // EmployeeLabel
            // 
            this.EmployeeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmployeeLabel.Location = new System.Drawing.Point(3, 3);
            this.EmployeeLabel.Name = "EmployeeLabel";
            this.EmployeeLabel.resize = false;
            this.EmployeeLabel.Size = new System.Drawing.Size(201, 29);
            this.EmployeeLabel.TabIndex = 6;
            this.EmployeeLabel.Text = "Employee";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.SkipButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.CompassCalibrationButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 452);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(201, 60);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // SkipButton
            // 
            this.SkipButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkipButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SkipButton.Location = new System.Drawing.Point(3, 3);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(94, 54);
            this.SkipButton.TabIndex = 10;
            this.SkipButton.Text = "Skip prefligh check";
            this.SkipButton.UseVisualStyleBackColor = true;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // CompassCalibrationButton
            // 
            this.CompassCalibrationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompassCalibrationButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CompassCalibrationButton.Location = new System.Drawing.Point(103, 3);
            this.CompassCalibrationButton.Name = "CompassCalibrationButton";
            this.CompassCalibrationButton.Size = new System.Drawing.Size(95, 54);
            this.CompassCalibrationButton.TabIndex = 16;
            this.CompassCalibrationButton.Text = "Compass Calibration";
            this.CompassCalibrationButton.UseVisualStyleBackColor = true;
            this.CompassCalibrationButton.Click += new System.EventHandler(this.CompassCalibrationButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.CancelButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ReadyButton, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(210, 452);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(202, 60);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // CancelButton
            // 
            this.CancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CancelButton.Location = new System.Drawing.Point(3, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(95, 54);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ReadyButton
            // 
            this.ReadyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReadyButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReadyButton.Location = new System.Drawing.Point(104, 3);
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(95, 54);
            this.ReadyButton.TabIndex = 1;
            this.ReadyButton.Text = "Ready to arm";
            this.ReadyButton.UseVisualStyleBackColor = true;
            this.ReadyButton.Click += new System.EventHandler(this.ReadyButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.GPSFix, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BatteryVol, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(210, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel2.SetRowSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 62);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // GPSFix
            // 
            this.GPSFix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPSFix.FlatAppearance.BorderSize = 0;
            this.GPSFix.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GPSFix.Location = new System.Drawing.Point(103, 3);
            this.GPSFix.Name = "GPSFix";
            this.GPSFix.Size = new System.Drawing.Size(94, 56);
            this.GPSFix.TabIndex = 4;
            this.GPSFix.Text = "GPS Fix";
            this.GPSFix.UseVisualStyleBackColor = true;
            // 
            // BatteryVol
            // 
            this.BatteryVol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BatteryVol.FlatAppearance.BorderSize = 0;
            this.BatteryVol.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BatteryVol.Location = new System.Drawing.Point(3, 3);
            this.BatteryVol.Name = "BatteryVol";
            this.BatteryVol.Size = new System.Drawing.Size(94, 56);
            this.BatteryVol.TabIndex = 3;
            this.BatteryVol.Text = "Battery Voltage";
            this.BatteryVol.UseVisualStyleBackColor = true;
            // 
            // PreFlightCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 515);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreFlightCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PreFlightCheck";
            this.Load += new System.EventHandler(this.PreFlightCheck_Load);
            this.CheckBoxTableLayout.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MyButton ReadyButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox employee_data;
        private Controls.MyLabel EmployeeLabel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TableLayoutPanel CheckBoxTableLayout;
        private Controls.MyButton SkipButton;
        private System.Windows.Forms.Label warning_label;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private MyButton CompassCalibrationButton;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MyButton CancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MyButton GPSFix;
        private MyButton BatteryVol;
    }
}