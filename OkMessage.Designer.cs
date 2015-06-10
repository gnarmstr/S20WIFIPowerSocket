namespace S20_Power_Points
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
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxYes
			// 
			this.pictureBoxYes.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxYes.Location = new System.Drawing.Point(250, 93);
			this.pictureBoxYes.Name = "pictureBoxYes";
			this.pictureBoxYes.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxYes.TabIndex = 14;
			this.pictureBoxYes.TabStop = false;
			this.pictureBoxYes.Tag = "7";
			this.pictureBoxYes.Click += new System.EventHandler(this.pictureBoxYes_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(88, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(428, 44);
			this.label2.TabIndex = 22;
			this.label2.Text = "Settings and Data have been saved.";
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.pictureBoxYes);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(576, 176);
			this.panel1.TabIndex = 24;
			// 
			// OkMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(600, 200);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(600, 200);
			this.MinimumSize = new System.Drawing.Size(600, 200);
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
	}
}