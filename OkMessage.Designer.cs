﻿namespace S20_Power_Points
{
	partial class OkMessage
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
			this.pictureBoxYes = new System.Windows.Forms.PictureBox();
			this.labelMessage = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxYes
			// 
			this.pictureBoxYes.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxYes.Location = new System.Drawing.Point(253, 143);
			this.pictureBoxYes.Name = "pictureBoxYes";
			this.pictureBoxYes.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxYes.TabIndex = 14;
			this.pictureBoxYes.TabStop = false;
			this.pictureBoxYes.Tag = "7";
			this.pictureBoxYes.Click += new System.EventHandler(this.pictureBoxYes_Click);
			// 
			// labelMessage
			// 
			this.labelMessage.BackColor = System.Drawing.Color.Transparent;
			this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMessage.ForeColor = System.Drawing.Color.RoyalBlue;
			this.labelMessage.Location = new System.Drawing.Point(3, 9);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(570, 131);
			this.labelMessage.TabIndex = 22;
			this.labelMessage.Text = "Settings and Data have been saved.";
			this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.labelMessage);
			this.panel1.Controls.Add(this.pictureBoxYes);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(576, 226);
			this.panel1.TabIndex = 24;
			// 
			// OkMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(600, 250);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(600, 250);
			this.MinimumSize = new System.Drawing.Size(600, 250);
			this.Name = "OkMessage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Domestic Activities";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxYes;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.Panel panel1;
	}
}