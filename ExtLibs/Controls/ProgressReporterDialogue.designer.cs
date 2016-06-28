namespace MissionPlanner.Controls
{
	partial class ProgressReporterDialogue
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
			this.components = new System.ComponentModel.Container();
			this.TitlePanel = new System.Windows.Forms.TableLayoutPanel();
			this.Title = new System.Windows.Forms.Label();
			this.tableLayoutContentPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.ContentLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.detailsButtonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.showErrorDetailsButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.errorPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DetailsLabel = new System.Windows.Forms.Label();
			this.progressPanel = new System.Windows.Forms.TableLayoutPanel();
			this.progressBar1 = new MissionPlanner.Controls.MyProgressBar();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.TitlePanel.SuspendLayout();
			this.tableLayoutContentPanel.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.detailsButtonPanel.SuspendLayout();
			this.errorPanel.SuspendLayout();
			this.progressPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// TitlePanel
			// 
			this.TitlePanel.ColumnCount = 1;
			this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TitlePanel.Controls.Add(this.Title, 0, 0);
			this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TitlePanel.Location = new System.Drawing.Point(0, 0);
			this.TitlePanel.Name = "TitlePanel";
			this.TitlePanel.RowCount = 1;
			this.TitlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TitlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TitlePanel.Size = new System.Drawing.Size(331, 46);
			this.TitlePanel.TabIndex = 0;
			// 
			// Title
			// 
			this.Title.AutoSize = true;
			this.Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Title.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.Title.Location = new System.Drawing.Point(2, 2);
			this.Title.Margin = new System.Windows.Forms.Padding(2);
			this.Title.Name = "Title";
			this.Title.Size = new System.Drawing.Size(327, 42);
			this.Title.TabIndex = 22;
			this.Title.Text = "Progress...";
			this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutContentPanel
			// 
			this.tableLayoutContentPanel.ColumnCount = 3;
			this.tableLayoutContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
			this.tableLayoutContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
			this.tableLayoutContentPanel.Controls.Add(this.tableLayoutPanel2, 1, 1);
			this.tableLayoutContentPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutContentPanel.Location = new System.Drawing.Point(0, 46);
			this.tableLayoutContentPanel.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutContentPanel.Name = "tableLayoutContentPanel";
			this.tableLayoutContentPanel.RowCount = 3;
			this.tableLayoutContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
			this.tableLayoutContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
			this.tableLayoutContentPanel.Size = new System.Drawing.Size(331, 100);
			this.tableLayoutContentPanel.TabIndex = 3;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.ContentLabel, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(327, 96);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// ContentLabel
			// 
			this.ContentLabel.AutoSize = true;
			this.ContentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.ContentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContentLabel.Font = new System.Drawing.Font("Century Gothic", 11F);
			this.ContentLabel.ForeColor = System.Drawing.Color.White;
			this.ContentLabel.Location = new System.Drawing.Point(72, 2);
			this.ContentLabel.Margin = new System.Windows.Forms.Padding(2, 2, 10, 2);
			this.ContentLabel.Name = "ContentLabel";
			this.ContentLabel.Size = new System.Drawing.Size(245, 92);
			this.ContentLabel.TabIndex = 23;
			this.ContentLabel.Text = "Operation in progress";
			this.ContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(10, 10);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(50, 76);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// detailsButtonPanel
			// 
			this.detailsButtonPanel.ColumnCount = 1;
			this.detailsButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.detailsButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.detailsButtonPanel.Controls.Add(this.showErrorDetailsButton, 0, 0);
			this.detailsButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.detailsButtonPanel.Location = new System.Drawing.Point(0, 146);
			this.detailsButtonPanel.Name = "detailsButtonPanel";
			this.detailsButtonPanel.RowCount = 1;
			this.detailsButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.detailsButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.detailsButtonPanel.Size = new System.Drawing.Size(331, 46);
			this.detailsButtonPanel.TabIndex = 11;
			// 
			// showErrorDetailsButton
			// 
			this.showErrorDetailsButton.AutoSize = true;
			this.showErrorDetailsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.showErrorDetailsButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.showErrorDetailsButton.FlatAppearance.BorderSize = 0;
			this.showErrorDetailsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(86)))), ((int)(((byte)(88)))));
			this.showErrorDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.showErrorDetailsButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.showErrorDetailsButton.ForeColor = System.Drawing.Color.White;
			this.showErrorDetailsButton.Location = new System.Drawing.Point(2, 1);
			this.showErrorDetailsButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.showErrorDetailsButton.Name = "showErrorDetailsButton";
			this.showErrorDetailsButton.Size = new System.Drawing.Size(327, 44);
			this.showErrorDetailsButton.TabIndex = 2;
			this.showErrorDetailsButton.Text = "Show error details";
			this.showErrorDetailsButton.UseVisualStyleBackColor = false;
			this.showErrorDetailsButton.Click += new System.EventHandler(this.showErrorDetailsButton_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// errorPanel
			// 
			this.errorPanel.ColumnCount = 1;
			this.errorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.errorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.errorPanel.Controls.Add(this.DetailsLabel, 0, 0);
			this.errorPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.errorPanel.Location = new System.Drawing.Point(0, 192);
			this.errorPanel.Name = "errorPanel";
			this.errorPanel.RowCount = 1;
			this.errorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.errorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.errorPanel.Size = new System.Drawing.Size(331, 100);
			this.errorPanel.TabIndex = 16;
			// 
			// DetailsLabel
			// 
			this.DetailsLabel.AutoSize = true;
			this.DetailsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.DetailsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.DetailsLabel.ForeColor = System.Drawing.Color.White;
			this.DetailsLabel.Location = new System.Drawing.Point(2, 2);
			this.DetailsLabel.Margin = new System.Windows.Forms.Padding(2);
			this.DetailsLabel.Name = "DetailsLabel";
			this.DetailsLabel.Padding = new System.Windows.Forms.Padding(5);
			this.DetailsLabel.Size = new System.Drawing.Size(327, 96);
			this.DetailsLabel.TabIndex = 26;
			this.DetailsLabel.Text = "No details available.";
			// 
			// progressPanel
			// 
			this.progressPanel.ColumnCount = 1;
			this.progressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.progressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.progressPanel.Controls.Add(this.progressBar1, 0, 0);
			this.progressPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.progressPanel.Location = new System.Drawing.Point(0, 292);
			this.progressPanel.Name = "progressPanel";
			this.progressPanel.RowCount = 1;
			this.progressPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.progressPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.progressPanel.Size = new System.Drawing.Size(331, 46);
			this.progressPanel.TabIndex = 17;
			// 
			// progressBar1
			// 
			this.progressBar1.BackColor = System.Drawing.Color.White;
			this.progressBar1.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.progressBar1.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(206)))), ((int)(((byte)(252)))));
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBar1.Location = new System.Drawing.Point(2, 2);
			this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Outline = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
			this.progressBar1.Size = new System.Drawing.Size(327, 42);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 0;
			this.progressBar1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(54)))), ((int)(((byte)(8)))));
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 338);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 46);
			this.flowLayoutPanel1.TabIndex = 18;
			// 
			// ProgressReporterDialogue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Lime;
			this.ClientSize = new System.Drawing.Size(331, 400);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.progressPanel);
			this.Controls.Add(this.errorPanel);
			this.Controls.Add(this.detailsButtonPanel);
			this.Controls.Add(this.tableLayoutContentPanel);
			this.Controls.Add(this.TitlePanel);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ProgressReporterDialogue";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NovMessageBox";
			this.TransparencyKey = System.Drawing.Color.Lime;
			this.Load += new System.EventHandler(this.ProgressReporterDialogue_Load);
			this.TitlePanel.ResumeLayout(false);
			this.TitlePanel.PerformLayout();
			this.tableLayoutContentPanel.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.detailsButtonPanel.ResumeLayout(false);
			this.detailsButtonPanel.PerformLayout();
			this.errorPanel.ResumeLayout(false);
			this.errorPanel.PerformLayout();
			this.progressPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel TitlePanel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutContentPanel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label ContentLabel;
		private System.Windows.Forms.Label Title;
		private System.Windows.Forms.TableLayoutPanel detailsButtonPanel;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button showErrorDetailsButton;
		private System.Windows.Forms.TableLayoutPanel errorPanel;
		private System.Windows.Forms.Label DetailsLabel;
		private System.Windows.Forms.TableLayoutPanel progressPanel;
		private MyProgressBar progressBar1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}