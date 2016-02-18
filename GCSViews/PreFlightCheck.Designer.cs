using MissionPlanner.Controls;

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
            this.ReadyButton = new MissionPlanner.Controls.MyButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.employee_data = new System.Windows.Forms.ComboBox();
            this.EmployeeLabel = new MissionPlanner.Controls.MyLabel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBoxTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SkipButton = new MissionPlanner.Controls.MyButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Gps_fix = new System.Windows.Forms.Panel();
            this.batteryVoltage = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.warning_label = new System.Windows.Forms.Label();
            this.CompassCalibrationButton = new MissionPlanner.Controls.MyButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.CancelButton = new MissionPlanner.Controls.MyButton();
            this.CheckBoxTableLayout.SuspendLayout();
            this.Gps_fix.SuspendLayout();
            this.batteryVoltage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
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
            this.CheckBoxTableLayout.Location = new System.Drawing.Point(3, 118);
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
            this.CheckBoxTableLayout.Size = new System.Drawing.Size(409, 328);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "GPS FIX";
            // 
            // Gps_fix
            // 
            this.Gps_fix.Controls.Add(this.label1);
            this.Gps_fix.Location = new System.Drawing.Point(210, 68);
            this.Gps_fix.Name = "Gps_fix";
            this.Gps_fix.Size = new System.Drawing.Size(83, 38);
            this.Gps_fix.TabIndex = 12;
            // 
            // batteryVoltage
            // 
            this.batteryVoltage.Controls.Add(this.label2);
            this.batteryVoltage.Location = new System.Drawing.Point(3, 68);
            this.batteryVoltage.Name = "batteryVoltage";
            this.batteryVoltage.Size = new System.Drawing.Size(83, 38);
            this.batteryVoltage.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(5, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 42);
            this.label2.TabIndex = 14;
            this.label2.Text = "Battery \r\nvoltage";
            // 
            // warning_label
            // 
            this.warning_label.AutoSize = true;
            this.warning_label.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warning_label.ForeColor = System.Drawing.Color.Red;
            this.warning_label.Location = new System.Drawing.Point(12, 109);
            this.warning_label.MaximumSize = new System.Drawing.Size(405, 0);
            this.warning_label.Name = "warning_label";
            this.warning_label.Size = new System.Drawing.Size(0, 36);
            this.warning_label.TabIndex = 15;
            this.warning_label.UseMnemonic = false;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.EmployeeLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.employee_data, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.batteryVoltage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Gps_fix, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.CheckBoxTableLayout, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.920259F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.910158F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.723662F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.87469F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57124F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(415, 515);
            this.tableLayoutPanel2.TabIndex = 17;
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
            // PreFlightCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 515);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.warning_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreFlightCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PreFlightCheck";
            this.Load += new System.EventHandler(this.PreFlightCheck_Load);
            this.CheckBoxTableLayout.ResumeLayout(false);
            this.Gps_fix.ResumeLayout(false);
            this.Gps_fix.PerformLayout();
            this.batteryVoltage.ResumeLayout(false);
            this.batteryVoltage.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Gps_fix;
        private System.Windows.Forms.Panel batteryVoltage;
        private System.Windows.Forms.Label label2;
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
    }
}