namespace MissionPlanner.GCSViews
{
    partial class PlatformChoose
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
            this.Grid = new System.Windows.Forms.TableLayoutPanel();
            this.AlbatrosButton = new System.Windows.Forms.Button();
            this.OgarButton = new System.Windows.Forms.Button();
            this.Grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.ColumnCount = 2;
            this.Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Grid.Controls.Add(this.OgarButton, 0, 0);
            this.Grid.Controls.Add(this.AlbatrosButton, 0, 0);
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Name = "Grid";
            this.Grid.RowCount = 1;
            this.Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Grid.Size = new System.Drawing.Size(460, 90);
            this.Grid.TabIndex = 0;
            // 
            // AlbatrosButton
            // 
            this.AlbatrosButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.AlbatrosButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlbatrosButton.FlatAppearance.BorderSize = 0;
            this.AlbatrosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlbatrosButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlbatrosButton.ForeColor = System.Drawing.Color.White;
            this.AlbatrosButton.Location = new System.Drawing.Point(1, 1);
            this.AlbatrosButton.Margin = new System.Windows.Forms.Padding(1);
            this.AlbatrosButton.Name = "AlbatrosButton";
            this.AlbatrosButton.Size = new System.Drawing.Size(228, 88);
            this.AlbatrosButton.TabIndex = 2;
            this.AlbatrosButton.Text = "ALBATROS";
            this.AlbatrosButton.UseVisualStyleBackColor = false;
            this.AlbatrosButton.Click += new System.EventHandler(this.AlbatrosButton_Click);
            // 
            // OgarButton
            // 
            this.OgarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.OgarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OgarButton.FlatAppearance.BorderSize = 0;
            this.OgarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OgarButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OgarButton.ForeColor = System.Drawing.Color.White;
            this.OgarButton.Location = new System.Drawing.Point(231, 1);
            this.OgarButton.Margin = new System.Windows.Forms.Padding(1);
            this.OgarButton.Name = "OgarButton";
            this.OgarButton.Size = new System.Drawing.Size(228, 88);
            this.OgarButton.TabIndex = 3;
            this.OgarButton.Text = "OGAR";
            this.OgarButton.UseVisualStyleBackColor = false;
            this.OgarButton.Click += new System.EventHandler(this.OgarButton_Click);
            // 
            // PlatformChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(460, 90);
            this.Controls.Add(this.Grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlatformChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PlatformChoose";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlatformChoose_FormClosing);
            this.Grid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Grid;
        private System.Windows.Forms.Button AlbatrosButton;
        private System.Windows.Forms.Button OgarButton;
    }
}