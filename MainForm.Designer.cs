namespace S20_Power_Points
{
	partial class MainForm
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
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SaveAll = new System.Windows.Forms.PictureBox();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.pictureBoxClose = new System.Windows.Forms.PictureBox();
			this.buttonMainTitle = new System.Windows.Forms.Button();
			this.panelMainPoints = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.pictureBoxAdd = new System.Windows.Forms.PictureBox();
			this.pictureBoxDelete = new System.Windows.Forms.PictureBox();
			this.pictureBoxTogglePWR = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonSocketData = new System.Windows.Forms.Button();
			this.comboBoxDeviceName = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.textBoxMacAddress = new System.Windows.Forms.TextBox();
			this.buttonInstructions = new System.Windows.Forms.Button();
			this.buttonSettings = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
			this.panelMainPoints.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTogglePWR)).BeginInit();
			this.SuspendLayout();
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 8000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// SaveAll
			// 
			this.SaveAll.BackColor = System.Drawing.Color.Transparent;
			this.SaveAll.Location = new System.Drawing.Point(848, 631);
			this.SaveAll.Name = "SaveAll";
			this.SaveAll.Size = new System.Drawing.Size(200, 40);
			this.SaveAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.SaveAll.TabIndex = 70;
			this.SaveAll.TabStop = false;
			this.SaveAll.Tag = "20";
			this.toolTip1.SetToolTip(this.SaveAll, "This will Save all settings and lists. ");
			this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
			// 
			// printDialog1
			// 
			this.printDialog1.UseEXDialog = true;
			// 
			// pictureBoxClose
			// 
			this.pictureBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxClose.Location = new System.Drawing.Point(1035, 12);
			this.pictureBoxClose.Name = "pictureBoxClose";
			this.pictureBoxClose.Size = new System.Drawing.Size(43, 43);
			this.pictureBoxClose.TabIndex = 86;
			this.pictureBoxClose.TabStop = false;
			this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
			// 
			// buttonMainTitle
			// 
			this.buttonMainTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonMainTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMainTitle.Location = new System.Drawing.Point(8, 12);
			this.buttonMainTitle.Name = "buttonMainTitle";
			this.buttonMainTitle.Size = new System.Drawing.Size(1021, 43);
			this.buttonMainTitle.TabIndex = 88;
			this.buttonMainTitle.Text = "Ver 0.1                                         S20 Power Socket Control - By Geo" +
    "ff Armstrong                             ";
			this.buttonMainTitle.UseVisualStyleBackColor = true;
			this.buttonMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseDown);
			this.buttonMainTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseMove);
			this.buttonMainTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseUp);
			// 
			// panelMainPoints
			// 
			this.panelMainPoints.BackColor = System.Drawing.Color.Transparent;
			this.panelMainPoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panelMainPoints.Controls.Add(this.label4);
			this.panelMainPoints.Controls.Add(this.richTextBoxLog);
			this.panelMainPoints.Controls.Add(this.pictureBoxAdd);
			this.panelMainPoints.Controls.Add(this.pictureBoxDelete);
			this.panelMainPoints.Controls.Add(this.pictureBoxTogglePWR);
			this.panelMainPoints.Controls.Add(this.label1);
			this.panelMainPoints.Controls.Add(this.SaveAll);
			this.panelMainPoints.Controls.Add(this.label3);
			this.panelMainPoints.Controls.Add(this.buttonSocketData);
			this.panelMainPoints.Controls.Add(this.comboBoxDeviceName);
			this.panelMainPoints.Controls.Add(this.label2);
			this.panelMainPoints.Controls.Add(this.textBoxIP);
			this.panelMainPoints.Controls.Add(this.textBoxMacAddress);
			this.panelMainPoints.Location = new System.Drawing.Point(8, 101);
			this.panelMainPoints.Name = "panelMainPoints";
			this.panelMainPoints.Size = new System.Drawing.Size(1070, 687);
			this.panelMainPoints.TabIndex = 83;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label4.Location = new System.Drawing.Point(25, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 25);
			this.label4.TabIndex = 104;
			this.label4.Text = "Log";
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Location = new System.Drawing.Point(17, 71);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBoxLog.Size = new System.Drawing.Size(279, 475);
			this.richTextBoxLog.TabIndex = 96;
			this.richTextBoxLog.Text = "";
			// 
			// pictureBoxAdd
			// 
			this.pictureBoxAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxAdd.Location = new System.Drawing.Point(690, 80);
			this.pictureBoxAdd.Name = "pictureBoxAdd";
			this.pictureBoxAdd.Size = new System.Drawing.Size(39, 36);
			this.pictureBoxAdd.TabIndex = 103;
			this.pictureBoxAdd.TabStop = false;
			this.pictureBoxAdd.Click += new System.EventHandler(this.pictureBoxAdd_Click);
			// 
			// pictureBoxDelete
			// 
			this.pictureBoxDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxDelete.Location = new System.Drawing.Point(634, 80);
			this.pictureBoxDelete.Name = "pictureBoxDelete";
			this.pictureBoxDelete.Size = new System.Drawing.Size(39, 36);
			this.pictureBoxDelete.TabIndex = 102;
			this.pictureBoxDelete.TabStop = false;
			this.pictureBoxDelete.Click += new System.EventHandler(this.pictureBoxDelete_Click);
			// 
			// pictureBoxTogglePWR
			// 
			this.pictureBoxTogglePWR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxTogglePWR.Location = new System.Drawing.Point(358, 175);
			this.pictureBoxTogglePWR.Name = "pictureBoxTogglePWR";
			this.pictureBoxTogglePWR.Size = new System.Drawing.Size(315, 312);
			this.pictureBoxTogglePWR.TabIndex = 101;
			this.pictureBoxTogglePWR.TabStop = false;
			this.pictureBoxTogglePWR.Click += new System.EventHandler(this.pictureBoxTogglePWR_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label1.Location = new System.Drawing.Point(739, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 25);
			this.label1.TabIndex = 98;
			this.label1.Text = "Device Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(739, 220);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(201, 25);
			this.label3.TabIndex = 100;
			this.label3.Text = "Device MAC Address";
			// 
			// buttonSocketData
			// 
			this.buttonSocketData.Location = new System.Drawing.Point(17, 581);
			this.buttonSocketData.Name = "buttonSocketData";
			this.buttonSocketData.Size = new System.Drawing.Size(220, 90);
			this.buttonSocketData.TabIndex = 91;
			this.buttonSocketData.Text = "Socket Data";
			this.buttonSocketData.UseVisualStyleBackColor = true;
			this.buttonSocketData.Click += new System.EventHandler(this.buttonSocketData_Click);
			// 
			// comboBoxDeviceName
			// 
			this.comboBoxDeviceName.FormattingEnabled = true;
			this.comboBoxDeviceName.Location = new System.Drawing.Point(744, 83);
			this.comboBoxDeviceName.Name = "comboBoxDeviceName";
			this.comboBoxDeviceName.Size = new System.Drawing.Size(316, 28);
			this.comboBoxDeviceName.TabIndex = 96;
			this.comboBoxDeviceName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDeviceName_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label2.Location = new System.Drawing.Point(739, 133);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(173, 25);
			this.label2.TabIndex = 99;
			this.label2.Text = "Device IP Address";
			// 
			// textBoxIP
			// 
			this.textBoxIP.Location = new System.Drawing.Point(745, 171);
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.ReadOnly = true;
			this.textBoxIP.Size = new System.Drawing.Size(316, 26);
			this.textBoxIP.TabIndex = 97;
			// 
			// textBoxMacAddress
			// 
			this.textBoxMacAddress.Location = new System.Drawing.Point(745, 260);
			this.textBoxMacAddress.Name = "textBoxMacAddress";
			this.textBoxMacAddress.ReadOnly = true;
			this.textBoxMacAddress.Size = new System.Drawing.Size(316, 26);
			this.textBoxMacAddress.TabIndex = 97;
			// 
			// buttonInstructions
			// 
			this.buttonInstructions.BackColor = System.Drawing.Color.Transparent;
			this.buttonInstructions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonInstructions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonInstructions.Location = new System.Drawing.Point(25, 61);
			this.buttonInstructions.Name = "buttonInstructions";
			this.buttonInstructions.Size = new System.Drawing.Size(149, 34);
			this.buttonInstructions.TabIndex = 91;
			this.buttonInstructions.Text = "Instructions";
			this.buttonInstructions.UseVisualStyleBackColor = false;
			this.buttonInstructions.Click += new System.EventHandler(this.buttonInstructions_Click);
			// 
			// buttonSettings
			// 
			this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
			this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSettings.Location = new System.Drawing.Point(200, 61);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(149, 34);
			this.buttonSettings.TabIndex = 91;
			this.buttonSettings.Text = "Settings";
			this.buttonSettings.UseVisualStyleBackColor = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(1090, 800);
			this.Controls.Add(this.buttonSettings);
			this.Controls.Add(this.buttonInstructions);
			this.Controls.Add(this.panelMainPoints);
			this.Controls.Add(this.buttonMainTitle);
			this.Controls.Add(this.pictureBoxClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(300, 50);
			this.MaximumSize = new System.Drawing.Size(1090, 800);
			this.MinimumSize = new System.Drawing.Size(1090, 800);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = " ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
			this.panelMainPoints.ResumeLayout(false);
			this.panelMainPoints.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTogglePWR)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox SaveAll;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.PictureBox pictureBoxClose;
		private System.Windows.Forms.Button buttonMainTitle;
		private System.Windows.Forms.Panel panelMainPoints;
		private System.Windows.Forms.Button buttonInstructions;
		private System.Windows.Forms.Button buttonSocketData;
		private System.Windows.Forms.ComboBox comboBoxDeviceName;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.TextBox textBoxMacAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBoxTogglePWR;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.PictureBox pictureBoxAdd;
		private System.Windows.Forms.PictureBox pictureBoxDelete;
		private System.Windows.Forms.Label label4;
	}
}

