namespace S20_Power_Points
{
	partial class Schedules
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
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxSun = new System.Windows.Forms.CheckBox();
			this.checkBoxSat = new System.Windows.Forms.CheckBox();
			this.checkBoxFri = new System.Windows.Forms.CheckBox();
			this.checkBoxThu = new System.Windows.Forms.CheckBox();
			this.checkBoxWed = new System.Windows.Forms.CheckBox();
			this.checkBoxTue = new System.Windows.Forms.CheckBox();
			this.checkBoxMon = new System.Windows.Forms.CheckBox();
			this.buttonEvent = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.pictureBoxAdd = new System.Windows.Forms.PictureBox();
			this.pictureBoxDelete = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxSchedulerName = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxDeviceName = new System.Windows.Forms.ComboBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.buttonMainTitle = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxOK.Location = new System.Drawing.Point(563, 393);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 14;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.checkBoxSun);
			this.panel1.Controls.Add(this.checkBoxSat);
			this.panel1.Controls.Add(this.checkBoxFri);
			this.panel1.Controls.Add(this.checkBoxThu);
			this.panel1.Controls.Add(this.checkBoxWed);
			this.panel1.Controls.Add(this.checkBoxTue);
			this.panel1.Controls.Add(this.checkBoxMon);
			this.panel1.Controls.Add(this.buttonEvent);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.pictureBoxAdd);
			this.panel1.Controls.Add(this.pictureBoxDelete);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.comboBoxSchedulerName);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.comboBoxDeviceName);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.pictureBoxOK);
			this.panel1.Location = new System.Drawing.Point(12, 63);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(646, 476);
			this.panel1.TabIndex = 59;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label6.Location = new System.Drawing.Point(305, 255);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 25);
			this.label6.TabIndex = 119;
			this.label6.Text = "Repeat";
			this.toolTip1.SetToolTip(this.label6, "Select the days for the event to take place.");
			// 
			// checkBoxSun
			// 
			this.checkBoxSun.AutoSize = true;
			this.checkBoxSun.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkBoxSun.ForeColor = System.Drawing.Color.RoyalBlue;
			this.checkBoxSun.Location = new System.Drawing.Point(478, 294);
			this.checkBoxSun.Name = "checkBoxSun";
			this.checkBoxSun.Size = new System.Drawing.Size(52, 50);
			this.checkBoxSun.TabIndex = 11;
			this.checkBoxSun.Text = "Sun";
			this.checkBoxSun.UseVisualStyleBackColor = true;
			this.checkBoxSun.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxSun_MouseClick);
			// 
			// checkBoxSat
			// 
			this.checkBoxSat.AutoSize = true;
			this.checkBoxSat.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkBoxSat.ForeColor = System.Drawing.Color.RoyalBlue;
			this.checkBoxSat.Location = new System.Drawing.Point(426, 294);
			this.checkBoxSat.Name = "checkBoxSat";
			this.checkBoxSat.Size = new System.Drawing.Size(46, 50);
			this.checkBoxSat.TabIndex = 10;
			this.checkBoxSat.Text = "Sat";
			this.checkBoxSat.UseVisualStyleBackColor = true;
			this.checkBoxSat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxSat_MouseClick);
			// 
			// checkBoxFri
			// 
			this.checkBoxFri.AutoSize = true;
			this.checkBoxFri.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxFri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkBoxFri.ForeColor = System.Drawing.Color.RoyalBlue;
			this.checkBoxFri.Location = new System.Drawing.Point(373, 294);
			this.checkBoxFri.Name = "checkBoxFri";
			this.checkBoxFri.Size = new System.Drawing.Size(38, 50);
			this.checkBoxFri.TabIndex = 9;
			this.checkBoxFri.Text = "Fri";
			this.checkBoxFri.UseVisualStyleBackColor = true;
			this.checkBoxFri.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxFri_MouseClick);
			// 
			// checkBoxThu
			// 
			this.checkBoxThu.AutoSize = true;
			this.checkBoxThu.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkBoxThu.ForeColor = System.Drawing.Color.RoyalBlue;
			this.checkBoxThu.Location = new System.Drawing.Point(312, 294);
			this.checkBoxThu.Name = "checkBoxThu";
			this.checkBoxThu.Size = new System.Drawing.Size(51, 50);
			this.checkBoxThu.TabIndex = 8;
			this.checkBoxThu.Text = "Thu";
			this.checkBoxThu.UseVisualStyleBackColor = true;
			this.checkBoxThu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxThu_MouseClick);
			// 
			// checkBoxWed
			// 
			this.checkBoxWed.AutoSize = true;
			this.checkBoxWed.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxWed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkBoxWed.ForeColor = System.Drawing.Color.RoyalBlue;
			this.checkBoxWed.Location = new System.Drawing.Point(251, 294);
			this.checkBoxWed.Name = "checkBoxWed";
			this.checkBoxWed.Size = new System.Drawing.Size(58, 50);
			this.checkBoxWed.TabIndex = 7;
			this.checkBoxWed.Text = "Wed";
			this.checkBoxWed.UseVisualStyleBackColor = true;
			this.checkBoxWed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxWed_MouseClick);
			// 
			// checkBoxTue
			// 
			this.checkBoxTue.AutoSize = true;
			this.checkBoxTue.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkBoxTue.ForeColor = System.Drawing.Color.RoyalBlue;
			this.checkBoxTue.Location = new System.Drawing.Point(194, 294);
			this.checkBoxTue.Name = "checkBoxTue";
			this.checkBoxTue.Size = new System.Drawing.Size(51, 50);
			this.checkBoxTue.TabIndex = 6;
			this.checkBoxTue.Text = "Tue";
			this.checkBoxTue.UseVisualStyleBackColor = true;
			this.checkBoxTue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxTue_MouseClick);
			// 
			// checkBoxMon
			// 
			this.checkBoxMon.AutoSize = true;
			this.checkBoxMon.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkBoxMon.ForeColor = System.Drawing.Color.RoyalBlue;
			this.checkBoxMon.Location = new System.Drawing.Point(133, 294);
			this.checkBoxMon.Name = "checkBoxMon";
			this.checkBoxMon.Size = new System.Drawing.Size(55, 50);
			this.checkBoxMon.TabIndex = 5;
			this.checkBoxMon.Text = "Mon";
			this.checkBoxMon.UseVisualStyleBackColor = true;
			this.checkBoxMon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxMon_MouseClick);
			// 
			// buttonEvent
			// 
			this.buttonEvent.BackColor = System.Drawing.Color.Transparent;
			this.buttonEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonEvent.FlatAppearance.BorderSize = 0;
			this.buttonEvent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonEvent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEvent.Location = new System.Drawing.Point(280, 183);
			this.buttonEvent.Name = "buttonEvent";
			this.buttonEvent.Size = new System.Drawing.Size(112, 47);
			this.buttonEvent.TabIndex = 4;
			this.buttonEvent.UseVisualStyleBackColor = false;
			this.buttonEvent.Click += new System.EventHandler(this.buttonEvent_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label5.Location = new System.Drawing.Point(9, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 25);
			this.label5.TabIndex = 108;
			this.label5.Text = "Event:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label4.Location = new System.Drawing.Point(9, 133);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 25);
			this.label4.TabIndex = 106;
			this.label4.Text = "Time:";
			// 
			// pictureBoxAdd
			// 
			this.pictureBoxAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxAdd.Location = new System.Drawing.Point(541, 18);
			this.pictureBoxAdd.Name = "pictureBoxAdd";
			this.pictureBoxAdd.Size = new System.Drawing.Size(39, 39);
			this.pictureBoxAdd.TabIndex = 105;
			this.pictureBoxAdd.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxAdd, "Create new Schedule");
			this.pictureBoxAdd.Click += new System.EventHandler(this.pictureBoxAdd_Click);
			// 
			// pictureBoxDelete
			// 
			this.pictureBoxDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxDelete.Location = new System.Drawing.Point(594, 18);
			this.pictureBoxDelete.Name = "pictureBoxDelete";
			this.pictureBoxDelete.Size = new System.Drawing.Size(39, 39);
			this.pictureBoxDelete.TabIndex = 104;
			this.pictureBoxDelete.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxDelete, "Remove Selected Schedule");
			this.pictureBoxDelete.Click += new System.EventHandler(this.pictureBoxDelete_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(9, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(158, 25);
			this.label3.TabIndex = 102;
			this.label3.Text = "Schedule Name:";
			// 
			// comboBoxSchedulerName
			// 
			this.comboBoxSchedulerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSchedulerName.FormattingEnabled = true;
			this.comboBoxSchedulerName.Location = new System.Drawing.Point(284, 22);
			this.comboBoxSchedulerName.Name = "comboBoxSchedulerName";
			this.comboBoxSchedulerName.Size = new System.Drawing.Size(246, 28);
			this.comboBoxSchedulerName.TabIndex = 2;
			this.comboBoxSchedulerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxSchedulerName_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label2.Location = new System.Drawing.Point(9, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(180, 25);
			this.label2.TabIndex = 100;
			this.label2.Text = "Associated Device:";
			// 
			// comboBoxDeviceName
			// 
			this.comboBoxDeviceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDeviceName.FormattingEnabled = true;
			this.comboBoxDeviceName.Location = new System.Drawing.Point(284, 75);
			this.comboBoxDeviceName.Name = "comboBoxDeviceName";
			this.comboBoxDeviceName.Size = new System.Drawing.Size(246, 28);
			this.comboBoxDeviceName.TabIndex = 1;
			this.toolTip1.SetToolTip(this.comboBoxDeviceName, "Select the device that will be scheduled.");
			this.comboBoxDeviceName.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeviceName_SelectedIndexChanged);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "HH:mm:ss";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(284, 132);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(157, 26);
			this.dateTimePicker1.TabIndex = 3;
			this.dateTimePicker1.Value = new System.DateTime(2015, 6, 16, 21, 32, 0, 0);
			this.dateTimePicker1.Leave += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
			this.buttonMainTitle.Size = new System.Drawing.Size(646, 43);
			this.buttonMainTitle.TabIndex = 90;
			this.buttonMainTitle.Text = "S20 WIFI SOCKET CONTROL - SCHEDULER";
			this.buttonMainTitle.UseVisualStyleBackColor = false;
			this.buttonMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseDown);
			this.buttonMainTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseMove);
			this.buttonMainTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseUp);
			// 
			// Schedules
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(670, 550);
			this.Controls.Add(this.buttonMainTitle);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(670, 550);
			this.MinimumSize = new System.Drawing.Size(670, 550);
			this.Name = "Schedules";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cervical  Spine Movement";
			this.Load += new System.EventHandler(this.DeviceName_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button buttonMainTitle;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxDeviceName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxSchedulerName;
		private System.Windows.Forms.PictureBox pictureBoxAdd;
		private System.Windows.Forms.PictureBox pictureBoxDelete;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonEvent;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBoxSun;
		private System.Windows.Forms.CheckBox checkBoxSat;
		private System.Windows.Forms.CheckBox checkBoxFri;
		private System.Windows.Forms.CheckBox checkBoxThu;
		private System.Windows.Forms.CheckBox checkBoxWed;
		private System.Windows.Forms.CheckBox checkBoxTue;
		private System.Windows.Forms.CheckBox checkBoxMon;
	}
}