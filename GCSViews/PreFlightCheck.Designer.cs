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
            this.myLabel1 = new MissionPlanner.Controls.MyLabel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.Gps_fix.SuspendLayout();
            this.batteryVoltage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReadyButton
            // 
            this.ReadyButton.Location = new System.Drawing.Point(309, 583);
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(105, 44);
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
            this.checkBox1.Size = new System.Drawing.Size(396, 36);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Wind isn\'t too strong";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // employee_data
            // 
            this.employee_data.FormattingEnabled = true;
            this.employee_data.Location = new System.Drawing.Point(18, 41);
            this.employee_data.Name = "employee_data";
            this.employee_data.Size = new System.Drawing.Size(268, 21);
            this.employee_data.TabIndex = 5;
            this.employee_data.SelectedIndexChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // myLabel1
            // 
            this.myLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.myLabel1.Location = new System.Drawing.Point(18, 12);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.resize = false;
            this.myLabel1.Size = new System.Drawing.Size(75, 23);
            this.myLabel1.TabIndex = 6;
            this.myLabel1.Text = "Employee";
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox2.Location = new System.Drawing.Point(3, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(396, 36);
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
            this.checkBox3.Size = new System.Drawing.Size(396, 36);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "No physical damege seen on UAV";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.CanBeArmed);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox8, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkBox7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBox6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBox5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 227);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 350);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox7.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox7.Location = new System.Drawing.Point(3, 255);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(396, 38);
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
            this.checkBox6.Size = new System.Drawing.Size(396, 36);
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
            this.checkBox5.Size = new System.Drawing.Size(396, 36);
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
            this.checkBox4.Size = new System.Drawing.Size(396, 36);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.Text = "Propellers can move freely";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // SkipButton
            // 
            this.SkipButton.Location = new System.Drawing.Point(9, 583);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(74, 44);
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
            this.Gps_fix.Location = new System.Drawing.Point(107, 68);
            this.Gps_fix.Name = "Gps_fix";
            this.Gps_fix.Size = new System.Drawing.Size(83, 38);
            this.Gps_fix.TabIndex = 12;
            // 
            // batteryVoltage
            // 
            this.batteryVoltage.Controls.Add(this.label2);
            this.batteryVoltage.Location = new System.Drawing.Point(18, 68);
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
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(98, 583);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(114, 44);
            this.myButton1.TabIndex = 16;
            this.myButton1.Text = "Compass Calibration";
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox8.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox8.Location = new System.Drawing.Point(3, 299);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(396, 36);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.Text = "Throttle on RC is all way down";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // PreFlightCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 638);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.warning_label);
            this.Controls.Add(this.batteryVoltage);
            this.Controls.Add(this.Gps_fix);
            this.Controls.Add(this.SkipButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.myLabel1);
            this.Controls.Add(this.employee_data);
            this.Controls.Add(this.ReadyButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreFlightCheck";
            this.Text = "PreFlightCheck";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Gps_fix.ResumeLayout(false);
            this.Gps_fix.PerformLayout();
            this.batteryVoltage.ResumeLayout(false);
            this.batteryVoltage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MyButton ReadyButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox employee_data;
        private Controls.MyLabel myLabel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private MyButton myButton1;
        private System.Windows.Forms.CheckBox checkBox8;


    }
}