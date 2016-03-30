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
			this.pictureBoxAdd = new System.Windows.Forms.PictureBox();
			this.pictureBoxDelete = new System.Windows.Forms.PictureBox();
			this.pictureBoxTogglePWR = new System.Windows.Forms.PictureBox();
			this.labelNetworkConnection = new System.Windows.Forms.Label();
			this.pictureBoxAddGroup = new System.Windows.Forms.PictureBox();
			this.pictureBoxDeleteGroup = new System.Windows.Forms.PictureBox();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBoxGroupName = new System.Windows.Forms.ComboBox();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.pictureBoxClose = new System.Windows.Forms.PictureBox();
			this.buttonMainTitle = new System.Windows.Forms.Button();
			this.pictureBoxNetworkConnection = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxDeviceName = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.textBoxMacAddress = new System.Windows.Forms.TextBox();
			this.buttonInstructions = new System.Windows.Forms.Button();
			this.buttonSettings = new System.Windows.Forms.Button();
			this.buttonSchedules = new System.Windows.Forms.Button();
			this.timerCheckSchedules = new System.Windows.Forms.Timer(this.components);
			this.label6 = new System.Windows.Forms.Label();
			this.pictureBoxWifiConnection = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTogglePWR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDeleteGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNetworkConnection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWifiConnection)).BeginInit();
			this.SuspendLayout();
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 8000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// pictureBoxAdd
			// 
			this.pictureBoxAdd.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxAdd.Location = new System.Drawing.Point(252, 184);
			this.pictureBoxAdd.Name = "pictureBoxAdd";
			this.pictureBoxAdd.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxAdd.TabIndex = 103;
			this.pictureBoxAdd.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxAdd, "Register or add new device.");
			this.pictureBoxAdd.Click += new System.EventHandler(this.pictureBoxAdd_Click);
			// 
			// pictureBoxDelete
			// 
			this.pictureBoxDelete.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxDelete.Location = new System.Drawing.Point(293, 184);
			this.pictureBoxDelete.Name = "pictureBoxDelete";
			this.pictureBoxDelete.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxDelete.TabIndex = 102;
			this.pictureBoxDelete.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxDelete, "Remove selected Device.");
			this.pictureBoxDelete.Click += new System.EventHandler(this.pictureBoxDelete_Click);
			// 
			// pictureBoxTogglePWR
			// 
			this.pictureBoxTogglePWR.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxTogglePWR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxTogglePWR.Location = new System.Drawing.Point(339, 129);
			this.pictureBoxTogglePWR.Name = "pictureBoxTogglePWR";
			this.pictureBoxTogglePWR.Size = new System.Drawing.Size(213, 215);
			this.pictureBoxTogglePWR.TabIndex = 101;
			this.pictureBoxTogglePWR.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxTogglePWR, "Toggle power setting for selected Device.");
			this.pictureBoxTogglePWR.Click += new System.EventHandler(this.pictureBoxTogglePWR_Click);
			// 
			// labelNetworkConnection
			// 
			this.labelNetworkConnection.BackColor = System.Drawing.Color.Transparent;
			this.labelNetworkConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNetworkConnection.ForeColor = System.Drawing.Color.RoyalBlue;
			this.labelNetworkConnection.Location = new System.Drawing.Point(542, 58);
			this.labelNetworkConnection.Name = "labelNetworkConnection";
			this.labelNetworkConnection.Size = new System.Drawing.Size(115, 57);
			this.labelNetworkConnection.TabIndex = 105;
			this.labelNetworkConnection.Text = "Network Availability";
			this.labelNetworkConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labelNetworkConnection, "Monitors network availability.");
			// 
			// pictureBoxAddGroup
			// 
			this.pictureBoxAddGroup.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxAddGroup.Location = new System.Drawing.Point(252, 273);
			this.pictureBoxAddGroup.Name = "pictureBoxAddGroup";
			this.pictureBoxAddGroup.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxAddGroup.TabIndex = 110;
			this.pictureBoxAddGroup.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxAddGroup, "Add new group.");
			this.pictureBoxAddGroup.Click += new System.EventHandler(this.pictureBoxAddGroup_Click);
			// 
			// pictureBoxDeleteGroup
			// 
			this.pictureBoxDeleteGroup.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxDeleteGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxDeleteGroup.Location = new System.Drawing.Point(293, 273);
			this.pictureBoxDeleteGroup.Name = "pictureBoxDeleteGroup";
			this.pictureBoxDeleteGroup.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxDeleteGroup.TabIndex = 109;
			this.pictureBoxDeleteGroup.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxDeleteGroup, "Remove selected Group.");
			this.pictureBoxDeleteGroup.Click += new System.EventHandler(this.pictureBoxDeleteGroup_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label5.Location = new System.Drawing.Point(18, 234);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(129, 25);
			this.label5.TabIndex = 108;
			this.label5.Text = "Group Name:";
			this.toolTip1.SetToolTip(this.label5, "Groups can be used from within Vixen 3 to turn On or Off multiple Devices with on" +
        "e command.");
			// 
			// comboBoxGroupName
			// 
			this.comboBoxGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroupName.FormattingEnabled = true;
			this.comboBoxGroupName.Location = new System.Drawing.Point(23, 272);
			this.comboBoxGroupName.Name = "comboBoxGroupName";
			this.comboBoxGroupName.Size = new System.Drawing.Size(213, 28);
			this.comboBoxGroupName.TabIndex = 107;
			this.toolTip1.SetToolTip(this.comboBoxGroupName, "Groups can be used from within Vixen 3 to turn On or Off multiple Devices with on" +
        "e command.");
			this.comboBoxGroupName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxGroupName_SelectionChangeCommitted);
			// 
			// printDialog1
			// 
			this.printDialog1.UseEXDialog = true;
			// 
			// pictureBoxClose
			// 
			this.pictureBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxClose.Location = new System.Drawing.Point(705, 12);
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
			this.buttonMainTitle.Size = new System.Drawing.Size(691, 43);
			this.buttonMainTitle.TabIndex = 88;
			this.buttonMainTitle.Text = "Ver 1.2                   S20 Power Socket Control                               " +
    "   ";
			this.buttonMainTitle.UseVisualStyleBackColor = true;
			this.buttonMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseDown);
			this.buttonMainTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseMove);
			this.buttonMainTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseUp);
			// 
			// pictureBoxNetworkConnection
			// 
			this.pictureBoxNetworkConnection.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxNetworkConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxNetworkConnection.Location = new System.Drawing.Point(586, 118);
			this.pictureBoxNetworkConnection.Name = "pictureBoxNetworkConnection";
			this.pictureBoxNetworkConnection.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxNetworkConnection.TabIndex = 106;
			this.pictureBoxNetworkConnection.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label4.Location = new System.Drawing.Point(20, 350);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 25);
			this.label4.TabIndex = 104;
			this.label4.Text = "Log:";
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Location = new System.Drawing.Point(15, 378);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBoxLog.Size = new System.Drawing.Size(733, 260);
			this.richTextBoxLog.TabIndex = 96;
			this.richTextBoxLog.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label1.Location = new System.Drawing.Point(18, 145);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 25);
			this.label1.TabIndex = 98;
			this.label1.Text = "Device Name:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(84, 333);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(207, 25);
			this.label3.TabIndex = 100;
			this.label3.Text = "Device MAC Address:";
			this.label3.Visible = false;
			// 
			// comboBoxDeviceName
			// 
			this.comboBoxDeviceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDeviceName.FormattingEnabled = true;
			this.comboBoxDeviceName.Location = new System.Drawing.Point(23, 183);
			this.comboBoxDeviceName.Name = "comboBoxDeviceName";
			this.comboBoxDeviceName.Size = new System.Drawing.Size(213, 28);
			this.comboBoxDeviceName.TabIndex = 1;
			this.comboBoxDeviceName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDeviceName_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label2.Location = new System.Drawing.Point(30, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(179, 25);
			this.label2.TabIndex = 99;
			this.label2.Text = "Device IP Address:";
			this.label2.Visible = false;
			// 
			// textBoxIP
			// 
			this.textBoxIP.Location = new System.Drawing.Point(215, 121);
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.ReadOnly = true;
			this.textBoxIP.Size = new System.Drawing.Size(151, 26);
			this.textBoxIP.TabIndex = 97;
			this.textBoxIP.Visible = false;
			// 
			// textBoxMacAddress
			// 
			this.textBoxMacAddress.Location = new System.Drawing.Point(297, 332);
			this.textBoxMacAddress.Name = "textBoxMacAddress";
			this.textBoxMacAddress.ReadOnly = true;
			this.textBoxMacAddress.Size = new System.Drawing.Size(123, 26);
			this.textBoxMacAddress.TabIndex = 97;
			this.textBoxMacAddress.Visible = false;
			// 
			// buttonInstructions
			// 
			this.buttonInstructions.BackColor = System.Drawing.Color.Transparent;
			this.buttonInstructions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonInstructions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonInstructions.Location = new System.Drawing.Point(25, 72);
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
			this.buttonSettings.Location = new System.Drawing.Point(370, 72);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(149, 34);
			this.buttonSettings.TabIndex = 91;
			this.buttonSettings.Text = "Settings";
			this.buttonSettings.UseVisualStyleBackColor = false;
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			// 
			// buttonSchedules
			// 
			this.buttonSchedules.BackColor = System.Drawing.Color.Transparent;
			this.buttonSchedules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSchedules.Location = new System.Drawing.Point(197, 72);
			this.buttonSchedules.Name = "buttonSchedules";
			this.buttonSchedules.Size = new System.Drawing.Size(149, 34);
			this.buttonSchedules.TabIndex = 92;
			this.buttonSchedules.Text = "Schedules";
			this.buttonSchedules.UseVisualStyleBackColor = false;
			this.buttonSchedules.Click += new System.EventHandler(this.buttonSchedules_Click);
			// 
			// timerCheckSchedules
			// 
			this.timerCheckSchedules.Interval = 500;
			this.timerCheckSchedules.Tick += new System.EventHandler(this.timerCheckSchedules_Tick);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label6.Location = new System.Drawing.Point(648, 59);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(115, 57);
			this.label6.TabIndex = 111;
			this.label6.Text = "WIFI Availability";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.label6, "Monitors network availability.");
			// 
			// pictureBoxWifiConnection
			// 
			this.pictureBoxWifiConnection.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxWifiConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxWifiConnection.Location = new System.Drawing.Point(692, 119);
			this.pictureBoxWifiConnection.Name = "pictureBoxWifiConnection";
			this.pictureBoxWifiConnection.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxWifiConnection.TabIndex = 112;
			this.pictureBoxWifiConnection.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(760, 650);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pictureBoxWifiConnection);
			this.Controls.Add(this.richTextBoxLog);
			this.Controls.Add(this.pictureBoxAddGroup);
			this.Controls.Add(this.labelNetworkConnection);
			this.Controls.Add(this.pictureBoxDeleteGroup);
			this.Controls.Add(this.buttonSchedules);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonSettings);
			this.Controls.Add(this.comboBoxGroupName);
			this.Controls.Add(this.buttonInstructions);
			this.Controls.Add(this.pictureBoxNetworkConnection);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonMainTitle);
			this.Controls.Add(this.pictureBoxClose);
			this.Controls.Add(this.pictureBoxAdd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBoxDelete);
			this.Controls.Add(this.textBoxMacAddress);
			this.Controls.Add(this.pictureBoxTogglePWR);
			this.Controls.Add(this.textBoxIP);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxDeviceName);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(400, 250);
			this.MaximumSize = new System.Drawing.Size(760, 650);
			this.MinimumSize = new System.Drawing.Size(760, 650);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = " ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTogglePWR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDeleteGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNetworkConnection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWifiConnection)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.PictureBox pictureBoxClose;
		private System.Windows.Forms.Button buttonMainTitle;
		private System.Windows.Forms.Button buttonInstructions;
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
		private System.Windows.Forms.Button buttonSchedules;
		private System.Windows.Forms.ComboBox comboBoxDeviceName;
		private System.Windows.Forms.Timer timerCheckSchedules;
		private System.Windows.Forms.PictureBox pictureBoxNetworkConnection;
		private System.Windows.Forms.Label labelNetworkConnection;
		private System.Windows.Forms.PictureBox pictureBoxAddGroup;
		private System.Windows.Forms.PictureBox pictureBoxDeleteGroup;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBoxGroupName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox pictureBoxWifiConnection;
	}
}

