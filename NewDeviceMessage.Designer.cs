namespace S20_Power_Points
{
	partial class NewDeviceMessage
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
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxYes = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBoxNo = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.buttonMainTitle = new System.Windows.Forms.Button();
			this.pictureBoxClose = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxCancel.Location = new System.Drawing.Point(518, 124);
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
			this.pictureBoxYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxYes.Location = new System.Drawing.Point(298, 124);
			this.pictureBoxYes.Name = "pictureBoxYes";
			this.pictureBoxYes.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxYes.TabIndex = 14;
			this.pictureBoxYes.TabStop = false;
			this.pictureBoxYes.Tag = "7";
			this.pictureBoxYes.Click += new System.EventHandler(this.pictureBoxYes_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.pictureBoxNo);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.pictureBoxCancel);
			this.panel1.Controls.Add(this.pictureBoxYes);
			this.panel1.Location = new System.Drawing.Point(12, 63);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(626, 216);
			this.panel1.TabIndex = 59;
			// 
			// pictureBoxNo
			// 
			this.pictureBoxNo.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxNo.Location = new System.Drawing.Point(411, 124);
			this.pictureBoxNo.Name = "pictureBoxNo";
			this.pictureBoxNo.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxNo.TabIndex = 61;
			this.pictureBoxNo.TabStop = false;
			this.pictureBoxNo.Tag = "7";
			this.pictureBoxNo.Click += new System.EventHandler(this.pictureBoxNo_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Crimson;
			this.label2.Location = new System.Drawing.Point(15, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(593, 91);
			this.label2.TabIndex = 60;
			this.label2.Text = "Has the device you are about to add already been registered on the network, eithe" +
    "r by this app or the WIMO mobile apps?";
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 10000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// buttonMainTitle
			// 
			this.buttonMainTitle.BackColor = System.Drawing.Color.Transparent;
			this.buttonMainTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonMainTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMainTitle.Location = new System.Drawing.Point(12, 12);
			this.buttonMainTitle.Name = "buttonMainTitle";
			this.buttonMainTitle.Size = new System.Drawing.Size(577, 43);
			this.buttonMainTitle.TabIndex = 90;
			this.buttonMainTitle.Text = "S20 WIFI SOCKET CONTROL - NEW DEVICE";
			this.buttonMainTitle.UseVisualStyleBackColor = false;
			this.buttonMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseDown);
			this.buttonMainTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseMove);
			this.buttonMainTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseUp);
			// 
			// pictureBoxClose
			// 
			this.pictureBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxClose.Location = new System.Drawing.Point(595, 12);
			this.pictureBoxClose.Name = "pictureBoxClose";
			this.pictureBoxClose.Size = new System.Drawing.Size(43, 43);
			this.pictureBoxClose.TabIndex = 89;
			this.pictureBoxClose.TabStop = false;
			this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
			// 
			// NewDeviceMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(650, 290);
			this.Controls.Add(this.buttonMainTitle);
			this.Controls.Add(this.pictureBoxClose);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(650, 290);
			this.MinimumSize = new System.Drawing.Size(650, 290);
			this.Name = "NewDeviceMessage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cervical  Spine Movement";
			this.Load += new System.EventHandler(this.DeviceName_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxYes;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button buttonMainTitle;
		private System.Windows.Forms.PictureBox pictureBoxClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBoxNo;
	}
}