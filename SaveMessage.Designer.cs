namespace S20_Power_Points
{
	partial class SaveMessage
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
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxYes = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBoxNo = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNo)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCancel.Location = new System.Drawing.Point(379, 84);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxCancel.TabIndex = 15;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.Tag = "8";
			this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
			// 
			// pictureBoxYes
			// 
			this.pictureBoxYes.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxYes.Location = new System.Drawing.Point(152, 84);
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
			this.label2.Location = new System.Drawing.Point(67, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(490, 44);
			this.label2.TabIndex = 22;
			this.label2.Text = "Would you like to save all Settings on exit?";
			// 
			// pictureBoxNo
			// 
			this.pictureBoxNo.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxNo.Location = new System.Drawing.Point(268, 84);
			this.pictureBoxNo.Name = "pictureBoxNo";
			this.pictureBoxNo.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxNo.TabIndex = 23;
			this.pictureBoxNo.TabStop = false;
			this.pictureBoxNo.Tag = "8";
			this.pictureBoxNo.Click += new System.EventHandler(this.pictureBoxNo_Click);
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.pictureBoxCancel);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.pictureBoxNo);
			this.panel1.Controls.Add(this.pictureBoxYes);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(576, 176);
			this.panel1.TabIndex = 24;
			// 
			// SaveMessage
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
			this.Name = "SaveMessage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Domestic Activities";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNo)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxYes;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.PictureBox pictureBoxNo;
		private System.Windows.Forms.Panel panel1;
	}
}