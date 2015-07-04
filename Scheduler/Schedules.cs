using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;
using Microsoft.VisualBasic;
using Microsoft.Win32.TaskScheduler;

namespace S20_Power_Points
{
	public partial class Schedules : Form
	{
		#region Settings
		public Schedules()
		{
			Location = new Point(GlobalVar.MainFormLocxationX + 10, GlobalVar.MainFormLocxationY);
			InitializeComponent();
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			BackgroundImage = Resources.BlackBackground;
			BackgroundImageLayout = ImageLayout.Stretch;
			pictureBoxDelete.BackgroundImage = Resources.delete;
			pictureBoxAdd.BackgroundImage = Resources.add;
			buttonEvent.BackgroundImage = Resources.On;
			GlobalVar.ToggleEvent = true;
			dateTimePicker1.ShowUpDown = true;

			for (int i = 0; i < GlobalVar.Device_Name.Count; i++)
			{
				comboBoxDeviceName.Items.Add(GlobalVar.Device_Name[i]);
			}
			if (Directory.Exists(GlobalVar.DocumnetsFolder))
			{
				Directory.Delete(GlobalVar.DocumnetsFolder + @"\ToDo", true);
				Directory.Delete(GlobalVar.DocumnetsFolder, true);
				Directory.CreateDirectory(GlobalVar.DocumnetsFolder);
				int milliseconds = 200;
				Thread.Sleep(milliseconds);
				Directory.CreateDirectory(GlobalVar.DocumnetsFolder + @"\ToDo");
				Thread.Sleep(milliseconds);
			}

			for (int i = 0; i < GlobalVar.Schedule_Name.Count; i++)
			{
				comboBoxSchedulerName.Items.Add(GlobalVar.Schedule_Name[i]);

			}

			if (comboBoxSchedulerName.Items.Count > 0)
			{
				comboBoxSchedulerName.SelectedIndex = 0;
				SchedulerChange();
			}
			else
			{
				comboBoxDeviceName.SelectedIndex = 0;
			}
			for (int i = 0; i < GlobalVar.Schedule_Name.Count; i++)
			{
				comboBoxSchedulerName.SelectedIndex = i;
				CreateBatch();
				CreateTaskRunWeekly();
				CreateNonScheduleBatch();
			}

			for (int i = 0; i < GlobalVar.Device_Name.Count; i++)
			{
				// Create a file to write to. 
				using (
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\" + GlobalVar.Device_Name[i] + "_Sequence_On.bat"))
				{
					sw.WriteLine(@"@echo off");
					sw.WriteLine(@"set /a counter=0");
					sw.WriteLine(@":numbers");
					sw.WriteLine(@"set /a counter=%counter%+1");
					sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"_On>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"goto :eof)");
					sw.WriteLine(@"goto :numbers");
				}
				// Create a file to write to. 
				using (
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\" + GlobalVar.Device_Name[i] + "_Sequence_Off.bat"))
				{
					sw.WriteLine(@"@echo off");
					sw.WriteLine(@"set /a counter=0");
					sw.WriteLine(@":numbers");
					sw.WriteLine(@"set /a counter=%counter%+1");
					sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"_Off>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"goto :eof)");
					sw.WriteLine(@"goto :numbers");
				}
			}
		}

		private void DeviceName_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
		}
		#endregion

		#region Move Form
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | 0x2000000;
				return cp;
			}
		}

		private void buttonMainTitle_MouseDown(object sender, MouseEventArgs e)
		{
			FormDrag.formDrag_MouseDown(e);
		}

		private void buttonMainTitle_MouseMove(object sender, MouseEventArgs e)
		{
			if (GlobalVar.dragging)
			{
				Left = e.X + Left - GlobalVar.offsetX;
				Top = e.Y + Top - GlobalVar.offsetY;
			}
		}

		private void buttonMainTitle_MouseUp(object sender, MouseEventArgs e)
		{
			FormDrag.formDrag_MouseUp(e);
		}
		#endregion

		#region Add Schedule
		private void pictureBoxAdd_Click(object sender, EventArgs e)
		{
			Hide();
			var scheduleName = new ScheduleName();
			scheduleName.ShowDialog();
			if (GlobalVar.CancelRequest == false)
			{

				GlobalVar.ScheduleDeviceName.Add(comboBoxDeviceName.Items[0].ToString());
				checkBoxMon.Checked = false;
				checkBoxTue.Checked = false;
				checkBoxWed.Checked = false;
				checkBoxThu.Checked = false;
				checkBoxFri.Checked = false;
				checkBoxSat.Checked = false;
				checkBoxSun.Checked = false;
				GlobalVar.Schedule_Time.Add(dateTimePicker1.Value);
				GlobalVar.Schedule_Toggle.Add(GlobalVar.ToggleEvent);
				GlobalVar.Schedule_Mon.Add(false);
				GlobalVar.Schedule_Tue.Add(false);
				GlobalVar.Schedule_Wed.Add(false);
				GlobalVar.Schedule_Thu.Add(false);
				GlobalVar.Schedule_Fri.Add(false);
				GlobalVar.Schedule_Sat.Add(false);
				GlobalVar.Schedule_Sun.Add(false);
				comboBoxSchedulerName.Items.Add(GlobalVar.Schedule_Name[GlobalVar.Schedule_Name.Count - 1]);
				comboBoxSchedulerName.SelectedIndex = comboBoxSchedulerName.Items.Count - 1;
				CreateTaskRunWeekly();
			}
			CreateBatch();
			Show();
			GlobalVar.NoSaveMsg = true;
			MainForm.Save();
		}
		#endregion

		#region Delete Schedule
		private void pictureBoxDelete_Click(object sender, EventArgs e)
		{
			if (comboBoxSchedulerName.Items.Count > 0)
			{
				DeleteTask();
				if (File.Exists(GlobalVar.DocumnetsFolder + @"\" + comboBoxSchedulerName.SelectedItem + ".bat"))
				{
					File.Delete(GlobalVar.DocumnetsFolder + @"\" + comboBoxSchedulerName.SelectedItem + ".bat");
				}
				GlobalVar.ScheduleDeviceName.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Time.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Toggle.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Mon.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Tue.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Wed.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Thu.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Fri.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Sat.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Sun.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Name.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				comboBoxSchedulerName.Items.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				if (comboBoxSchedulerName.Items.Count > 0)
				{
					comboBoxSchedulerName.SelectedIndex = 0;
				}
				else
				{
					comboBoxSchedulerName.Text = "";
				}
			}
			GlobalVar.NoSaveMsg = true;
			MainForm.Save();
		}
		#endregion

		#region Change Schedule
		private void SchedulerChange()
		{
			if (comboBoxSchedulerName.Items.Count > 0)
			{
				dateTimePicker1.Value = GlobalVar.Schedule_Time[comboBoxSchedulerName.SelectedIndex];
				GlobalVar.ToggleEvent = GlobalVar.Schedule_Toggle[comboBoxSchedulerName.SelectedIndex];
				checkBoxMon.Checked = GlobalVar.Schedule_Mon[comboBoxSchedulerName.SelectedIndex];
				checkBoxTue.Checked = GlobalVar.Schedule_Tue[comboBoxSchedulerName.SelectedIndex];
				checkBoxWed.Checked = GlobalVar.Schedule_Wed[comboBoxSchedulerName.SelectedIndex];
				checkBoxThu.Checked = GlobalVar.Schedule_Thu[comboBoxSchedulerName.SelectedIndex];
				checkBoxFri.Checked = GlobalVar.Schedule_Fri[comboBoxSchedulerName.SelectedIndex];
				checkBoxSat.Checked = GlobalVar.Schedule_Sat[comboBoxSchedulerName.SelectedIndex];
				checkBoxSun.Checked = GlobalVar.Schedule_Sun[comboBoxSchedulerName.SelectedIndex];
				comboBoxDeviceName.SelectedItem = GlobalVar.ScheduleDeviceName[comboBoxSchedulerName.SelectedIndex];
				if (GlobalVar.ToggleEvent)
				{
					buttonEvent.BackgroundImage = Resources.On;
					GlobalVar.ToggleEvent = true;
				}
				else
				{
					buttonEvent.BackgroundImage = Resources.Off;
					GlobalVar.ToggleEvent = false;
				}

				GlobalVar.NoSaveMsg = true;
				MainForm.Save();
			}
		}
		#endregion

		#region Update Schedule
		private void SchedulerUpdate()
		{
			if (comboBoxSchedulerName.Items.Count != 0)
			{
				GlobalVar.ScheduleDeviceName[comboBoxSchedulerName.SelectedIndex] = comboBoxDeviceName.SelectedItem.ToString();
				GlobalVar.Schedule_Time[comboBoxSchedulerName.SelectedIndex] = dateTimePicker1.Value;
				GlobalVar.Schedule_Toggle[comboBoxSchedulerName.SelectedIndex] = GlobalVar.ToggleEvent;
				GlobalVar.Schedule_Mon[comboBoxSchedulerName.SelectedIndex] = checkBoxMon.Checked;
				GlobalVar.Schedule_Tue[comboBoxSchedulerName.SelectedIndex] = checkBoxTue.Checked;
				GlobalVar.Schedule_Wed[comboBoxSchedulerName.SelectedIndex] = checkBoxWed.Checked;
				GlobalVar.Schedule_Thu[comboBoxSchedulerName.SelectedIndex] = checkBoxThu.Checked;
				GlobalVar.Schedule_Fri[comboBoxSchedulerName.SelectedIndex] = checkBoxFri.Checked;
				GlobalVar.Schedule_Sat[comboBoxSchedulerName.SelectedIndex] = checkBoxSat.Checked;
				GlobalVar.Schedule_Sun[comboBoxSchedulerName.SelectedIndex] = checkBoxSun.Checked;
				CreateTaskRunWeekly();
				CreateBatch();
			}
			GlobalVar.NoSaveMsg = true;
			MainForm.Save();
		}
		#endregion

		#region Create Batch file
		private void CreateBatch()
		{
			if (File.Exists(GlobalVar.DocumnetsFolder + @"\" + comboBoxSchedulerName.SelectedItem + ".bat"))
				{
					File.Delete(GlobalVar.DocumnetsFolder + @"\" + comboBoxSchedulerName.SelectedItem + ".bat");
				}
				string deviceStatus;
				if (GlobalVar.ToggleEvent)
				{
					deviceStatus = "On";
				}
				else
				{
					deviceStatus = "Off";
				}

				// Create a file to write to. 
				using (StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\" + comboBoxSchedulerName.SelectedItem + ".bat"))
				{
					sw.WriteLine(@"@echo off");
					sw.WriteLine(@"set /a counter=0");
					sw.WriteLine(@":numbers");
					sw.WriteLine(@"set /a counter=%counter%+1");
					sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
					sw.WriteLine(@"echo " + comboBoxDeviceName.SelectedItem + @"> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"echo " + comboBoxDeviceName.SelectedItem + @"_" + deviceStatus + @">> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"goto :eof)");
					sw.WriteLine(@"goto :numbers");
				}
		}
		#endregion

		#region Create Non schedule Batch file

		private void CreateNonScheduleBatch()
		{
			for (int i = 0; i < GlobalVar.Device_Name.Count; i++)
			{
				// Create a file to write to. 
				using (
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\" + GlobalVar.Device_Name[i] + "_Sequence_On.bat"))
				{
					sw.WriteLine(@"@echo off");
					sw.WriteLine(@"set /a counter=0");
					sw.WriteLine(@":numbers");
					sw.WriteLine(@"set /a counter=%counter%+1");
					sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"_On>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"goto :eof)");
					sw.WriteLine(@"goto :numbers");
				}
				// Create a file to write to. 
				using (
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\" + GlobalVar.Device_Name[i] + "_Sequence_Off.bat"))
				{
					sw.WriteLine(@"@echo off");
					sw.WriteLine(@"set /a counter=0");
					sw.WriteLine(@":numbers");
					sw.WriteLine(@"set /a counter=%counter%+1");
					sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"echo " + GlobalVar.Device_Name[i] + @"_Off>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"goto :eof)");
					sw.WriteLine(@"goto :numbers");
				}
			}
		}
		#endregion

		#region Create Daily Task
		private void CreateTaskRunDaily()
		{

			using (TaskService ts = new TaskService())
			{
				TaskDefinition td = ts.NewTask();
				td.RegistrationInfo.Description = "My first task scheduler";
				DailyTrigger daily = new DailyTrigger();
				daily.StartBoundary = dateTimePicker1.Value; //Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 16:30:00");
				daily.DaysInterval = 1;

				td.Triggers.Add(daily);
				td.Actions.Add(new ExecAction(@"C:/sample.exe", null, null));
				ts.RootFolder.RegisterTaskDefinition("TaskName", td);
			}
		}
		#endregion

		#region Create Weekly Task

		private void CreateTaskRunWeekly()
		{

			using (TaskService ts = new TaskService())
			{
					bool dayAdded = false;

					TaskDefinition td = ts.NewTask();
					td.RegistrationInfo.Description = "S20 Power Control for " + comboBoxSchedulerName.SelectedItem;
					WeeklyTrigger week = new WeeklyTrigger();
					week.StartBoundary = dateTimePicker1.Value;
					week.WeeksInterval = 1;
					if (checkBoxMon.Checked)
					{
						week.DaysOfWeek = DaysOfTheWeek.Monday;
						dayAdded = true;
					}
					if (checkBoxTue.Checked)
					{
						if (dayAdded)
						{
							week.DaysOfWeek = week.DaysOfWeek | DaysOfTheWeek.Tuesday;
						}
						else
						{
							week.DaysOfWeek = DaysOfTheWeek.Tuesday;
							dayAdded = true;
						}
					}
					if (checkBoxWed.Checked)
					{
						if (dayAdded)
						{
							week.DaysOfWeek = week.DaysOfWeek | DaysOfTheWeek.Wednesday;
						}
						else
						{
							week.DaysOfWeek = DaysOfTheWeek.Wednesday;
							dayAdded = true;
						}
					}
					if (checkBoxThu.Checked)
					{
						if (dayAdded)
						{
							week.DaysOfWeek = week.DaysOfWeek | DaysOfTheWeek.Thursday;
						}
						else
						{
							week.DaysOfWeek = DaysOfTheWeek.Thursday;
							dayAdded = true;
						}
					}
					if (checkBoxFri.Checked)
					{
						if (dayAdded)
						{
							week.DaysOfWeek = week.DaysOfWeek | DaysOfTheWeek.Friday;
						}
						else
						{
							week.DaysOfWeek = DaysOfTheWeek.Friday;
							dayAdded = true;
						}
					}
					if (checkBoxSat.Checked)
					{
						if (dayAdded)
						{
							week.DaysOfWeek = week.DaysOfWeek | DaysOfTheWeek.Saturday;
						}
						else
						{
							week.DaysOfWeek = DaysOfTheWeek.Saturday;
							dayAdded = true;
						}
					}
					if (checkBoxSun.Checked)
					{
						if (dayAdded)
						{
							week.DaysOfWeek = week.DaysOfWeek | DaysOfTheWeek.Sunday;
						}
						else
						{
							week.DaysOfWeek = DaysOfTheWeek.Sunday;
							dayAdded = true;
						}
					}
				if (dayAdded)
				{
					td.Triggers.Add(week);
					td.Settings.DisallowStartIfOnBatteries = false;
					td.Settings.StopIfGoingOnBatteries = false;
					td.Actions.Add(new ExecAction(GlobalVar.DocumnetsFolder + @"\" + comboBoxSchedulerName.SelectedItem + ".bat", null,
						GlobalVar.DocumnetsFolder + @"\"));
					ts.RootFolder.RegisterTaskDefinition(GlobalVar.Schedule_Name[comboBoxSchedulerName.SelectedIndex], td);
				}
				else
				{
					DeleteTask();
				}
			}
		}

		#endregion

		#region Delete Task
		private void DeleteTask()
		{
			using (TaskService ts = new TaskService())
			{
				if (ts.GetTask(comboBoxSchedulerName.SelectedItem.ToString()) != null)
				{
					ts.RootFolder.DeleteTask(comboBoxSchedulerName.SelectedItem.ToString());
				}
			}
		}
		#endregion

		#region Button and Value change actions
		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			GlobalVar.NoSaveMsg = false;
			Close();
		}

		private void buttonEvent_Click(object sender, EventArgs e)
		{
			if (GlobalVar.ToggleEvent)
			{
				buttonEvent.BackgroundImage = Resources.Off;
				GlobalVar.ToggleEvent = false;
			}
			else
			{
				buttonEvent.BackgroundImage = Resources.On;
				GlobalVar.ToggleEvent = true;
			}
			SchedulerUpdate();
		}
		private void comboBoxDeviceName_SelectedIndexChanged(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void comboBoxSchedulerName_SelectedIndexChanged(object sender, EventArgs e)
		{
			SchedulerChange();
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxMon_MouseClick(object sender, MouseEventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxTue_MouseClick(object sender, MouseEventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxWed_MouseClick(object sender, MouseEventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxThu_MouseClick(object sender, MouseEventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxFri_MouseClick(object sender, MouseEventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxSat_MouseClick(object sender, MouseEventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxSun_MouseClick(object sender, MouseEventArgs e)
		{
			SchedulerUpdate();
		}
		#endregion
	}
}
