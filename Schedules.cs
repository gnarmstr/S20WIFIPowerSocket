using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
		public Schedules()
		{
			Location = new Point(GlobalVar.MainFormLocxationX + 60, GlobalVar.MainFormLocxationY + 10);
			InitializeComponent();
			pictureBoxClose.BackgroundImage = Resources.Close;
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
			comboBoxDeviceName.SelectedIndex = 0;
		}

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

		private void DeviceName_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{

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

		private void pictureBoxAdd_Click(object sender, EventArgs e)
		{
			Hide();
			var scheduleName = new ScheduleName();
			scheduleName.ShowDialog();
			if (GlobalVar.CancelRequest == false)
			{
				GlobalVar.Schedule_Time.Add(dateTimePicker1.Value);
				GlobalVar.Schedule_Toggle.Add(GlobalVar.ToggleEvent);
				GlobalVar.Schedule_Mon.Add(checkBoxMon.Checked);
				GlobalVar.Schedule_Tue.Add(checkBoxTue.Checked);
				GlobalVar.Schedule_Wed.Add(checkBoxWed.Checked);
				GlobalVar.Schedule_Thu.Add(checkBoxThu.Checked);
				GlobalVar.Schedule_Fri.Add(checkBoxFri.Checked);
				GlobalVar.Schedule_Sat.Add(checkBoxSat.Checked);
				GlobalVar.Schedule_Sun.Add(checkBoxSun.Checked);
				comboBoxSchedulerName.Items.Add(GlobalVar.Schedule_Name[GlobalVar.Schedule_Name.Count - 1]);
				comboBoxSchedulerName.SelectedIndex = comboBoxSchedulerName.Items.Count - 1;
				CreateTaskRunWeekly();
			}

			Show();
		}

		private void comboBoxDeviceName_SelectedIndexChanged(object sender, EventArgs e)
		{
			SchedulerChange();
		}

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
			}
		}

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

		private void CreateTaskRunWeekly()
		{

			using (TaskService ts = new TaskService())
			{
				if (checkBoxMon.Checked | checkBoxTue.Checked | checkBoxWed.Checked | checkBoxThu.Checked | checkBoxFri.Checked | checkBoxSat.Checked | checkBoxSun.Checked)
				{
					bool dayAdded = false;

					TaskDefinition td = ts.NewTask();
					td.RegistrationInfo.Description = "S20 Power Control";
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
						}
					}
					td.Triggers.Add(week);
					if (GlobalVar.ToggleEvent)
					{
						td.Actions.Add(new ExecAction(@"C:/S20ON.bat", null, null));

					}
					else
					{
						td.Actions.Add(new ExecAction(@"C:/S20OFF.bat", null, null));
					}
					
					ts.RootFolder.RegisterTaskDefinition(GlobalVar.Schedule_Name[GlobalVar.Schedule_Name.Count - 1], td);
				}
			}
		}

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

		private void SchedulerUpdate()
		{
			if (comboBoxSchedulerName.Items.Count != 0)
			{
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
			}
		}

		private void comboBoxSchedulerName_SelectedIndexChanged(object sender, EventArgs e)
		{
			SchedulerChange();
		}

		private void checkBoxMon_Leave(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxTue_Leave(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxWed_Leave(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxThu_Leave(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxFri_Leave(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxSat_Leave(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void checkBoxSun_Leave(object sender, EventArgs e)
		{
			SchedulerUpdate();
		}

		private void pictureBoxDelete_Click(object sender, EventArgs e)
		{
			if (comboBoxSchedulerName.Items.Count > 0)
			{
				DeleteTask();
				GlobalVar.Schedule_Time.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Toggle.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Mon.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Tue.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Wed.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Thu.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Fri.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Sat.RemoveAt(comboBoxSchedulerName.SelectedIndex);
				GlobalVar.Schedule_Sun.RemoveAt(comboBoxSchedulerName.SelectedIndex);
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
	}
}
