﻿#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using GemBox.Spreadsheet;
using System.Net;
using System.Net.Sockets;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Quartz;
using Quartz.Impl;
using DataTable = System.Data.DataTable;
using Timer = System.Threading.Timer;
using Microsoft.Win32.TaskScheduler;


#endregion

namespace S20_Power_Points
{
	public partial class MainForm : Form
	{
		// TO DO LIST

		#region Initialization

		public MainForm()
		{
			InitializeComponent();
			NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
			IPHostEntry host;
			string localIP = "?";
			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily.ToString() == "InterNetwork")
				{
					GlobalVar.BroardcastIpAddress = ip.ToString();
					break;
				}
			}
			string [] splitString = GlobalVar.BroardcastIpAddress.Split('.');
			GlobalVar.BroardcastIpAddress = splitString[0];
			GlobalVar.BroardcastIpAddress += "." + splitString[1];
			GlobalVar.BroardcastIpAddress += "." + splitString[2];
			GlobalVar.BroardcastIpAddress += ".255";

			var allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

			for (int i = 0; i < allNetworkInterfaces.Count(); i++)
			{
				if (allNetworkInterfaces[i].NetworkInterfaceType.ToString().Contains("Wireless"))
				{
					GlobalVar.ConnectionType = "Wireless";
					pictureBoxWifiConnection.BackgroundImage = Resources.NetworkOn;
					break;
				}
				pictureBoxWifiConnection.BackgroundImage = Resources.NetworkOff;
			}

			if (Directory.Exists(GlobalVar.DocumnetsFolder))
			{
				Directory.Delete(GlobalVar.DocumnetsFolder + @"\Sequencer", true);
			}

			Settings();
			LoadData();
			GlobalVar.startup = false;
			if (comboBoxDeviceName.Items.Count != 0)
			{
				getStatus();
			}

			Create_Batch_Files.CreateBatchFiles();

			timerCheckSchedules.Enabled = true;

		}

		#endregion

		#region Used to allow graphgic refresh and draw before display to stop flickering
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | 0x2000000;
				return cp;
			}
		}
		#endregion

		#region Settings

		private void Settings()
		{
			GlobalVar.startup = true;
			GlobalVar.dataReceived = false;
			GlobalVar.IP_Address_BCast = IPAddress.Parse(GlobalVar.BroardcastIpAddress);
			GlobalVar.receiveTimeOut = 1000;
			GlobalVar.PowerStatusOn = false;
			GlobalVar.NoSaveMsg = false;
			GlobalVar.ReDiscover = false;
			GlobalVar.PowerStatus = 3;

			BackgroundImageLayout = ImageLayout.Stretch;
			buttonInstructions.BackgroundImage = Resources.button_Blue_Small;
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			pictureBoxDelete.BackgroundImage = Resources.delete;
			pictureBoxAdd.BackgroundImage = Resources.add;
			pictureBoxDeleteGroup.BackgroundImage = Resources.delete;
			pictureBoxAddGroup.BackgroundImage = Resources.add;
			buttonSchedules.BackgroundImage = Resources.button_Blue_Small;
			buttonSettings.BackgroundImage = Resources.button_Blue_Small;
			BackgroundImage = Resources.BlackBackground;
			pictureBoxTogglePWR.BackgroundImage = Resources.Power_Off1;

		}

		#endregion

		#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();

			#region Profiles

			GlobalVar.DeviceNumber = profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, "DeviceNumber", 0);
			GlobalVar.WifiPassword = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "WifiPassword", "");
			string line;
			int i = 0;
			line = "DeviceName";
			if (GlobalVar.DeviceNumber > 0)
			{
				do
				{
					comboBoxDeviceName.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, ""));
					line = "DeviceIP";
					GlobalVar.IpAddress.Add(profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, ""));
					line = "DeviceMAC";
					GlobalVar.MacAddress.Add(profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, ""));
					line = "DeviceReverseMAC";
					GlobalVar.ReverseMacAddress.Add(profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, ""));
					line = "Device_Name";
					GlobalVar.Device_Name.Add(profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, ""));
					line = "GroupDeviceName";
					GlobalVar.GroupDeviceName.Add(profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, ""));
					line = "DeviceName";
					i++;
				} while (i < GlobalVar.DeviceNumber);

				if (GlobalVar.Device_Name.Count > 0)
				{
					textBoxIP.Text = GlobalVar.IpAddress[0];
					textBoxMacAddress.Text = GlobalVar.MacAddress[0];
					WaitCmd();
					comboBoxDeviceName.Text = GlobalVar.Device_Name[0];
					comboBoxDeviceName.SelectedIndex = 0;
				}
			}

			i = 0;
			GlobalVar.SchedulerNumber = profile.GetSetting(XmlProfileSettings.SettingType.Schedules, "SchedulerNumber", 0);
			line = "Schedule_Name";
			if (GlobalVar.SchedulerNumber > 0)
			{
				do
				{
					GlobalVar.Schedule_Name.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, ""));
					line = "ScheduleDeviceName";
					GlobalVar.ScheduleDeviceName.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, ""));
					line = "Schedule_Time";
					string timeAdd = (profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, "19:00:00"));
					GlobalVar.Schedule_Time.Add(DateTime.Parse(timeAdd, CultureInfo.CurrentCulture));
					line = "Schedule_Toggle";
					GlobalVar.Schedule_Toggle.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, true));
					line = "Schedule_Mon";
					GlobalVar.Schedule_Mon.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, false));
					line = "Schedule_Tue";
					GlobalVar.Schedule_Tue.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, false));
					line = "Schedule_Wed";
					GlobalVar.Schedule_Wed.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, false));
					line = "Schedule_Thu";
					GlobalVar.Schedule_Thu.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, false));
					line = "Schedule_Fri";
					GlobalVar.Schedule_Fri.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, false));
					line = "Schedule_Sat";
					GlobalVar.Schedule_Sat.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, false));
					line = "Schedule_Sun";
					GlobalVar.Schedule_Sun.Add(profile.GetSetting(XmlProfileSettings.SettingType.Schedules, line + i, false));
					line = "Schedule_Name";
					i++;
				} while (i < GlobalVar.SchedulerNumber);
			}
			i = 0;
			GlobalVar.GroupNumber = profile.GetSetting(XmlProfileSettings.SettingType.Groups, "GroupNumber", 0);
			line = "Group_Name";
			if (GlobalVar.GroupNumber > 0)
			{
				do
				{
					GlobalVar.Group_Name.Add(profile.GetSetting(XmlProfileSettings.SettingType.Groups, line + i, ""));
					line = "Group_Name";
					comboBoxGroupName.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Groups, line + i, ""));
					i++;
				} while (i < GlobalVar.GroupNumber);
				GroupChange();
			}
			else
			{
				GlobalVar.Group_Name.Add("None");
				GlobalVar.GroupDeviceName.Add("None");
				comboBoxGroupName.Items.Add("None");
				comboBoxGroupName.SelectedIndex = 0;
			}

			#endregion
		}

		#endregion

		#region Main Form Load
		private void MainForm_Load(object sender, EventArgs e)
		{
		}
		#endregion

		#region Drag Main Form around

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

		#region Instructions
		private void buttonInstructions_Click(object sender, EventArgs e)
		{
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			Hide();
			var instructions = new Instructions();
			instructions.ShowDialog();
			Show();
		}
		#endregion

		#region Close Application
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			GlobalVar.comboBoxDeviceName = comboBoxDeviceName.Items.Count;
			Save();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion

		#region Save Data
		public static void Save()
		{
			var profile = new XmlProfileSettings();

			#region Profiles
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "PowerStatus", GlobalVar.PowerStatus);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "WifiPassword", GlobalVar.WifiPassword);

			string line;
			if (GlobalVar.comboBoxDeviceName > 0)
			{
				GlobalVar.DeviceNumber = GlobalVar.comboBoxDeviceName;
				profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, "DeviceNumber", GlobalVar.DeviceNumber.ToString());
				int i = 0;
				line = "DeviceName";
				do
				{
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, Convert.ToString(GlobalVar.Device_Name[i]));
					line = "DeviceIP";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.IpAddress[i]);
					line = "DeviceMAC";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.MacAddress[i]);
					line = "DeviceReverseMAC";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.ReverseMacAddress[i]);
					line = "Device_Name";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.Device_Name[i]);
					line = "GroupDeviceName";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, Convert.ToString(GlobalVar.GroupDeviceName[i]));
					line = "DeviceName";
					i++;
				} while (i < GlobalVar.MacAddress.Count());

			}
	//		else
	//		{
	//			File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\S20 Socket Control\Settings.xml");
	//		}
			if (GlobalVar.Schedule_Name.Count > 0)
			{
				GlobalVar.SchedulerNumber = GlobalVar.Schedule_Name.Count;
				profile.PutSetting(XmlProfileSettings.SettingType.Schedules, "SchedulerNumber", GlobalVar.SchedulerNumber);
				int i = 0;
				line = "Schedule_Name";
				do
				{
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, Convert.ToString(GlobalVar.Schedule_Name[i]));
					line = "ScheduleDeviceName";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, Convert.ToString(GlobalVar.ScheduleDeviceName[i]));
					line = "Schedule_Time";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Time[i].ToString());
					line = "Schedule_Toggle";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Toggle[i]);
					line = "Schedule_Mon";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Mon[i]);
					line = "Schedule_Tue";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Tue[i]);
					line = "Schedule_Wed";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Wed[i]);
					line = "Schedule_Thu";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Thu[i]);
					line = "Schedule_Fri";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Fri[i]);
					line = "Schedule_Sat";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Sat[i]);
					line = "Schedule_Sun";
					profile.PutSetting(XmlProfileSettings.SettingType.Schedules, line + i, GlobalVar.Schedule_Sun[i]);
					line = "Schedule_Name";
					i++;
				} while (i < GlobalVar.Schedule_Name.Count());
			}
			if (GlobalVar.Group_Name.Count > 0)
			{
				GlobalVar.GroupNumber = GlobalVar.Group_Name.Count;
				profile.PutSetting(XmlProfileSettings.SettingType.Groups, "GroupNumber", GlobalVar.GroupNumber);
				int i = 0;
				line = "Group_Name";
				do
				{
					profile.PutSetting(XmlProfileSettings.SettingType.Groups, line + i, Convert.ToString(GlobalVar.Group_Name[i]));
					i++;
				} while (i < GlobalVar.Group_Name.Count());
			}
		}
			#endregion

		#endregion

		#region Wait
		#region Wait 200

		private void WaitCmd()
		{
			int milliseconds = 150;
			Thread.Sleep(milliseconds);
		}
		#endregion

		#region Wait a long time for registering only

		private void WaitCmdLong()
		{
			int milliseconds = 8000;
			Thread.Sleep(milliseconds);
		}
		#endregion

		#region Wait 15

		private void WaitCmd15()
		{
			int milliseconds = 15;
			Thread.Sleep(milliseconds);
		}
		#endregion

		#region Wait 5

		private void WaitCmd5()
		{
			int milliseconds = 5;
			Thread.Sleep(milliseconds);
		}
		#endregion
		#endregion

		#region Toggle Power Button
		private void pictureBoxTogglePWR_Click(object sender, EventArgs e)
		{
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				GlobalVar.MainFormLocxationX = Location.X;
				GlobalVar.MainFormLocxationY = Location.Y;
				if (textBoxIP.Text != "")
				{
					Cursor.Current = Cursors.WaitCursor;

					if (GlobalVar.PowerStatusOn)
					{
						GlobalVar.TogglePower = GlobalVar.Off;
						TogglePower();
					}
					else
					{
						GlobalVar.TogglePower = GlobalVar.On;
						TogglePower();
					}

					Cursor.Current = Cursors.Default;
				}
				else
				{
					GlobalVar.MessageBoxData = "No devices listed. Add new device first.";
					var okMessage = new OkMessage();
					okMessage.ShowDialog();
					richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No devices listed. Add new device first.\n"));
				}
			}
			else
			{
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No network connection detected, please connect to your local network.\n"));
			}
		}
		#endregion

		#region Toggle Power Code

		private void TogglePower()
		{
			if (comboBoxDeviceName.Items.Count == 0)
			{
				GlobalVar.MessageBoxData = "No new devices found";
				var okMessage = new OkMessage();
				okMessage.ShowDialog();
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No new devices found.\n"));
				return;
			}
			Subscribe();
			if (GlobalVar.dataReceived == false)
			{
				return;
			}
			int repeat = 0;
			do
			{
				string[] splitString = GlobalVar.MacAddress[comboBoxDeviceName.SelectedIndex].Split(':');
				var i = 0;
				foreach (string value in splitString)
				{
					if (value != "")
					{
						GlobalVar.Mac[i] = Convert.ToByte(value);
						i++;
					}
				}

				IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 10000);
				//Construct data packet to turn S20 Power socket off
				byte[] sendDataByte = new byte[GlobalVar.PwrCmd.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.TogglePower.Length];
				Array.Copy(GlobalVar.PwrCmd, 0, sendDataByte, 0, GlobalVar.PwrCmd.Length);
				Array.Copy(GlobalVar.Mac, 0, sendDataByte, GlobalVar.PwrCmd.Length, GlobalVar.Mac.Length);
				Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte, GlobalVar.PwrCmd.Length + GlobalVar.Mac.Length, GlobalVar.TwentiesBuffer.Length);
				Array.Copy(GlobalVar.TogglePower, 0, sendDataByte, GlobalVar.PwrCmd.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.Mac.Length, GlobalVar.TogglePower.Length);

				int rxPacket = 22;
				int rxPacketLength = 1;
				string mode = "PowerStatus"; 
				
				sendData(sendDataByte, endPoint);

				receiveData(rxPacket, rxPacketLength, mode, repeat);
				WaitCmd();
				//Code to check if S20 Power is on or off. TO BE DONE
				try
				{
					if (GlobalVar.HexValue[0] == "0")
					{
						richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch Off.\n"));
						pictureBoxTogglePWR.BackgroundImage = Resources.Power_Off1;
						GlobalVar.PowerStatusOn = false;
					}
					else
					{
						richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch On.\n"));
						pictureBoxTogglePWR.BackgroundImage = Resources.Power_On1;
						GlobalVar.PowerStatusOn = true;
					}
				}
				catch
				{
					GlobalVar.HexValue.Add("0");
				}
				
			} while (GlobalVar.dataReceived == false && repeat++ < 2);
			GlobalVar.dataReceived = false;
		}
		#endregion

		#region Send Data
		private void sendData(byte[] buffer, IPEndPoint endPoint)
		{
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			try
			{
				socket.SendTo(buffer, endPoint);
				GlobalVar.dataReceived = true;
				socket.Close();
			}
			catch (Exception)
			{
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("Unable to reach network, ensure you have a network connection\n"));
			}
		}
		#endregion

		#region Receive Data
		public void receiveData(int rxPacket, int rxPacketLength, string mode, int repeat)
		{
			UdpClient client = new UdpClient(10000);
				IPEndPoint server = new IPEndPoint(IPAddress.Broadcast, 10000);

				client.Client.ReceiveTimeout = GlobalVar.receiveTimeOut;
				try
				{

					byte[] packet = client.Receive(ref server);
					GlobalVar.dataReceived = true;
					if (rxPacketLength == 1)
					{
						packet = client.Receive(ref server);
					}
					int i = 0;
					GlobalVar.HexValue.Clear();
					GlobalVar.HexValue.Add("");
					do
					{
						switch (mode)
						{
							case "PowerStatus":
								GlobalVar.HexValue[i] = packet[i + rxPacket].ToString("X");
								break;
							case "Subscribe":
								GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] = GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] +
								                                                     packet[i + rxPacket] + ":";
								GlobalVar.PowerStatus = Convert.ToInt16(packet[23]);
								break;
							case "RediscoverIP":
								GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] = GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] +
								                                                     packet[i + rxPacket] + ":";
								GlobalVar.RX_Data_Rediscover = server.Address;
								break;
							case "Register":
								GlobalVar.HexValue[i] = "True";
								break;
						}
					} while (i++ < rxPacketLength - 1);
				}
				catch
				{
					if (mode == "Register")
					{
						richTextBoxLog.Text = richTextBoxLog.Text.Insert(0,
							("Did not recieve a response from within a predetermined time.\nCheck your network connection or make sure the new device has a flashing red light.\n"));
					}
					else
					{
						if (textBoxIP.Text != "")
						{
							richTextBoxLog.Text = richTextBoxLog.Text.Insert(0,
								("Did not recieve a response from " + GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] +
								 " within a predetermined time.\nCheck your network connection. Retry.\n"));
						}
					}
			}
				client.Close();
		}
		#endregion

		#region Rediscover of IP Addresses on all S20 Sockets

		private void RediscoverDevice()
		{
			if (GlobalVar.Device_Name.Count > 0)
			{
				int repeat = 0;
				int i = comboBoxDeviceName.SelectedIndex;
				do
				{
					//possibly add Subscribe(); //if rediscover is not enough.
					// covert Macaddress to byte
					string[] splitString = GlobalVar.MacAddress[i].Split(':');
					var mac = 0;
					foreach (string value in splitString)
					{
						if (value != "")
						{
							GlobalVar.Mac[mac] = Convert.ToByte(value);
							mac++;
						}
					}

					//Send data
					IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(GlobalVar.IpAddress[i]), 10000);
					//Construct data packet to rediscover IP Address on all S20 Power sockets
					byte[] sendDataByte = new byte[GlobalVar.RediscoverCmd.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length];
					Array.Copy(GlobalVar.RediscoverCmd, 0, sendDataByte, 0, GlobalVar.RediscoverCmd.Length);
					Array.Copy(GlobalVar.Mac, 0, sendDataByte, GlobalVar.RediscoverCmd.Length, GlobalVar.Mac.Length);
					Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte, GlobalVar.RediscoverCmd.Length + GlobalVar.Mac.Length, GlobalVar.TwentiesBuffer.Length);
					
					//Receive data
					int rxPacket = 7; //This is the position in the received data packet where to start.
					int rxPacketLength = 6; //This is the number of bytes to save.
					string mode = "RediscoverIP";
					
					sendData(sendDataByte, endPoint);

					receiveData(rxPacket, rxPacketLength, mode, repeat);
					WaitCmd();
					try
					{
						// Update IP address table
						if (GlobalVar.MacAddress[i] == (GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1].Remove(GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1].Length - 1)));
						{
							GlobalVar.IpAddress[i] = GlobalVar.RX_Data_Rediscover.ToString();
							if (comboBoxDeviceName.SelectedItem.ToString() == GlobalVar.Device_Name[i])
							{
								textBoxIP.Text = GlobalVar.RX_Data.ToString();
							}
						}
					}
					catch
					{
					}

				} while (i++ < GlobalVar.Device_Name.Count - 1);
			}
		}
		#endregion

		#region Discover. Used to Add new devices on the network

		private void pictureBoxAdd_Click(object sender, EventArgs e)
		{
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				GlobalVar.ReDiscover = true;
				AddNewDevice();
			}
			else
			{
			richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No network connection detected, please connect to your local network.\n"));				
			}
		}

		private void AddNewDevice()
		{
			int rxIncr = 0;
			int rxPacket = 7;
			int rxPacketLength = 6;
			bool repeatRx = true;

			//added the line below, will need to check
			GlobalVar.dataReceived = false;
			Cursor.Current = Cursors.WaitCursor;
			IPEndPoint endPoint = new IPEndPoint(GlobalVar.IP_Address_BCast, 10000);

			byte[] buffer = { 0x68, 0x64, 0x00, 0x06, 0x71, 0x61 };
			sendData(buffer, endPoint);
			
			if (GlobalVar.dataReceived)
			{
				do
				{

					int i = 0;
					GlobalVar.HexValue.Clear();
					GlobalVar.HexValue.Add("");
					GlobalVar.ReverseHexValue.Clear();
					GlobalVar.ReverseHexValue.Add("");

					UdpClient client = new UdpClient(10000);
					IPEndPoint server = new IPEndPoint(IPAddress.Broadcast, 10000);

					client.Client.ReceiveTimeout = GlobalVar.receiveTimeOut;

					try
					{
						byte[] packet = client.Receive(ref server);
						do
						{
							GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] = GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] +
																				 packet[i + rxPacket] + ":";
							GlobalVar.ReverseHexValue[GlobalVar.ReverseHexValue.Count() - 1] = packet[i + rxPacket] + ":" +
																						   GlobalVar.ReverseHexValue[
																							   GlobalVar.ReverseHexValue.Count() - 1];
						} while (i++ < rxPacketLength - 1);

						if (Array.IndexOf(GlobalVar.IpAddress.ToArray(), server.Address.ToString()) >= 0)
						//checks if Received IP Address is already registered.
						{
						}
						else
						{ //Will do this if its a new IP Address.
							repeatRx = false;
							GlobalVar.MainFormLocxationX = Location.X;
							GlobalVar.MainFormLocxationY = Location.Y;
							var devicename = new DeviceName();
							devicename.ShowDialog();
							GlobalVar.ReDiscover = true;
							if (GlobalVar.CancelDiscover)
							{
								client.Close();
								return;
							}
							GlobalVar.MacAddress.Add(GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1].Remove(GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1].Length - 1));
							GlobalVar.ReverseMacAddress.Add(GlobalVar.ReverseHexValue[GlobalVar.ReverseHexValue.Count() - 1].Remove(GlobalVar.ReverseHexValue[GlobalVar.ReverseHexValue.Count() - 1].Length - 1));
							GlobalVar.RX_Data = server.Address;
							GlobalVar.GroupDeviceName.Add("None");

							string[] splitString = GlobalVar.ReverseMacAddress[GlobalVar.ReverseMacAddress.Count - 1].Split(':');
							var ii = 0;
							foreach (string value in splitString)
							{
								if (value != "")
								{
									GlobalVar.ReverseMac[ii] = Convert.ToByte(value);
									ii++;
								}
							}

							splitString = GlobalVar.MacAddress[GlobalVar.MacAddress.Count - 1].Split(':');
							var iii = 0;
							foreach (string value in splitString)
							{
								if (value != "")
								{
									GlobalVar.Mac[iii] = Convert.ToByte(value);
									iii++;
								}
							}
							IPEndPoint endPoint1 = new IPEndPoint(GlobalVar.RX_Data, 10000);
							//Rename Socket
							byte[] sendDataByte =
								new byte[
									GlobalVar.RenameCmd.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length +
									GlobalVar.RenameCmd1.Length];
							Array.Copy(GlobalVar.RenameCmd, 0, sendDataByte, 0, GlobalVar.RenameCmd.Length);
							Array.Copy(GlobalVar.Mac, 0, sendDataByte, GlobalVar.RenameCmd.Length, GlobalVar.Mac.Length);
							Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte, GlobalVar.RenameCmd.Length + GlobalVar.Mac.Length,
								GlobalVar.TwentiesBuffer.Length);
							Array.Copy(GlobalVar.RenameCmd1, 0, sendDataByte,
								GlobalVar.RenameCmd.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.Mac.Length, GlobalVar.RenameCmd1.Length);

							byte[] sendDataByte1 =
								new byte[
									sendDataByte.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.ReverseMac.Length];
							Array.Copy(sendDataByte, 0, sendDataByte1, 0, sendDataByte.Length);
							Array.Copy(GlobalVar.Mac, 0, sendDataByte1, sendDataByte.Length, GlobalVar.Mac.Length);
							Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte1, sendDataByte.Length + GlobalVar.Mac.Length,
								GlobalVar.TwentiesBuffer.Length);
							Array.Copy(GlobalVar.ReverseMac, 0, sendDataByte1,
								sendDataByte.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length, GlobalVar.ReverseMac.Length);

							byte[] sendDataByte2 =
								new byte[
									sendDataByte1.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.RenameCmd2.Length +
									GlobalVar.DeviceName.Length];
							Array.Copy(sendDataByte1, 0, sendDataByte2, 0, sendDataByte1.Length);
							Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte2, sendDataByte1.Length, GlobalVar.TwentiesBuffer.Length);
							Array.Copy(GlobalVar.RenameCmd2, 0, sendDataByte2, sendDataByte1.Length + GlobalVar.TwentiesBuffer.Length,
								GlobalVar.RenameCmd2.Length);
							Array.Copy(GlobalVar.DeviceName, 0, sendDataByte2,
								sendDataByte1.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.RenameCmd2.Length,
								GlobalVar.DeviceName.Length);

							byte[] sendDataByte3 = new byte[sendDataByte2.Length + GlobalVar.RenameCmd3.Length];
							Array.Copy(sendDataByte2, 0, sendDataByte3, 0, sendDataByte2.Length);
							Array.Copy(GlobalVar.RenameCmd3, 0, sendDataByte3, sendDataByte2.Length, GlobalVar.RenameCmd3.Length);

							sendData(sendDataByte3, endPoint1);
						}

					}
					catch
					{ }

					client.Close();
				} while (rxIncr++ < GlobalVar.IpAddress.Count * 2 & repeatRx);

				if (repeatRx)
				//checks if Received IP Address is already registered.
				{
					GlobalVar.dataReceived = false;
					GlobalVar.CancelDiscover = true;
					GlobalVar.MainFormLocxationX = Location.X;
					GlobalVar.MainFormLocxationY = Location.Y;
					GlobalVar.MessageBoxData = "No new devices found. If you still have a registered device then please try again.";
					var okMessage = new OkMessage();
					okMessage.ShowDialog();
					richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No new devices found.\n"));
				}

				WaitCmd();
				try
				{
					if (GlobalVar.RX_Data != null && GlobalVar.CancelDiscover == false)
					{
						GlobalVar.IpAddress.Add(GlobalVar.RX_Data.ToString());
						comboBoxDeviceName.Items.Add(GlobalVar.Device_Name[GlobalVar.Device_Name.Count - 1]);
						comboBoxDeviceName.SelectedIndex = comboBoxDeviceName.Items.Count - 1;
						textBoxIP.Text = GlobalVar.RX_Data.ToString();
						GlobalVar.RX_Data = null;
						textBoxMacAddress.Text = GlobalVar.MacAddress[GlobalVar.MacAddress.Count() - 1];
						WaitCmd();
						WaitCmd();
						WaitCmd();
						GroupChange();
						getStatus();
					}
					else
					{
						GlobalVar.MainFormLocxationX = Location.X;
						GlobalVar.MainFormLocxationY = Location.Y;
						registerNewDevcice();
					}
				}
				catch
				{
					GlobalVar.MainFormLocxationX = Location.X;
					GlobalVar.MainFormLocxationY = Location.Y;
					registerNewDevcice();
				}
			}
			else
			{
				GlobalVar.MainFormLocxationX = Location.X;
				GlobalVar.MainFormLocxationY = Location.Y;
				registerNewDevcice();
			}
			GlobalVar.dataReceived = false;
			Cursor.Current = Cursors.Default;
			GlobalVar.comboBoxDeviceName = comboBoxDeviceName.Items.Count;
			Save();
		}

		#endregion

		#region Subscribe

		private void Subscribe() //required before any communications with device.
		{
			RediscoverDevice(); //CHecks if IP address has changed and update if it has.
			int repeat = 0;
			try
			{
				IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 10000);

				string[] splitString = GlobalVar.ReverseMacAddress[comboBoxDeviceName.SelectedIndex].Split(':');
				var i = 0;
				foreach (string value in splitString)
				{
					if (value != "")
					{
						GlobalVar.ReverseMac[i] = Convert.ToByte(value);
						i++;
					}
				}
				splitString = GlobalVar.MacAddress[comboBoxDeviceName.SelectedIndex].Split(':');
				i = 0;
				foreach (string value in splitString)
				{
					if (value != "")
					{
						GlobalVar.Mac[i] = Convert.ToByte(value);
						i++;
					}
				}
				//Construct data packet to turn S20 Power socket on
				byte[] sendDataByte = new byte[GlobalVar.SubscribeCmd.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.ReverseMac.Length];
				Array.Copy(GlobalVar.SubscribeCmd, 0, sendDataByte, 0, GlobalVar.SubscribeCmd.Length);
				Array.Copy(GlobalVar.Mac, 0, sendDataByte, GlobalVar.SubscribeCmd.Length, GlobalVar.Mac.Length);
				Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte, GlobalVar.SubscribeCmd.Length + GlobalVar.Mac.Length, GlobalVar.TwentiesBuffer.Length);
				Array.Copy(GlobalVar.ReverseMac, 0, sendDataByte, GlobalVar.SubscribeCmd.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.Mac.Length, GlobalVar.ReverseMac.Length);
				Array.Copy(GlobalVar.ReverseMac, 0, sendDataByte, GlobalVar.SubscribeCmd.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.Mac.Length, GlobalVar.ReverseMac.Length);
				
				byte[] sendDataByte1 = new byte[sendDataByte.Length + GlobalVar.TwentiesBuffer.Length];
				Array.Copy(sendDataByte, 0, sendDataByte1, 0, sendDataByte.Length);
				Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte1, sendDataByte.Length, GlobalVar.TwentiesBuffer.Length);

				int rxPacket = 4;
				int rxPacketLength = 2;
				string mode = "Subscribe";
				sendData(sendDataByte1, endPoint);
		//		do
		//		{
					receiveData(rxPacket, rxPacketLength, mode, repeat);
		//		} while (GlobalVar.HexValue[0] != "99:108:" && repeat++ < 0);
				WaitCmd();
			}
			catch
			{
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("Unable to reach network, ensure you have a network connection\n"));
			}
		}
		#endregion

		#region Get Device Status
		private void comboBoxDeviceName_SelectionChangeCommitted(object sender, EventArgs e)
		{
			GroupChange();
			getStatus();				
		}
		
		private void getStatus()
		{
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				pictureBoxNetworkConnection.BackgroundImage = Resources.NetworkOn;
				if (GlobalVar.Device_Name.Count > 0)
				{
					textBoxIP.Text = GlobalVar.IpAddress[comboBoxDeviceName.SelectedIndex];
					textBoxMacAddress.Text = GlobalVar.MacAddress[comboBoxDeviceName.SelectedIndex];
					comboBoxDeviceName.Text = GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex];
					Subscribe();
					switch (GlobalVar.PowerStatus)
					{
						case 1:
							richTextBoxLog.Text = richTextBoxLog.Text.Insert(0,
								(GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch On.\n"));
							pictureBoxTogglePWR.BackgroundImage = Resources.Power_On1;
							GlobalVar.PowerStatusOn = true;
							break;
						case 0:
							richTextBoxLog.Text = richTextBoxLog.Text.Insert(0,
								(GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch Off.\n"));
							pictureBoxTogglePWR.BackgroundImage = Resources.Power_Off1;
							GlobalVar.PowerStatusOn = false;
							break;
						case 3:
							richTextBoxLog.Text = richTextBoxLog.Text.Insert(0,
								(GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] +
								 " can not be found, please ensure you are connected to your local network and that the device is plugged in and switched on at the mains.\n"));
							pictureBoxTogglePWR.BackgroundImage = Resources.Power_Unknown;
							break;
					}
				}
				else
				{
					GlobalVar.MessageBoxData =
						"No new devices found. If you do have some that have not been registered then please ensure you have registered initially through WIWO software first.";
					var okMessage = new OkMessage();
					okMessage.ShowDialog();
					richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No new devices found.\n"));
				}
			}
			else
			{
				pictureBoxNetworkConnection.BackgroundImage = Resources.NetworkOff;
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No network connection detected, please connect to your local network.\n"));
			}
		}
		#endregion

		#region Monitors for network connection
		private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
		{
			if (e.IsAvailable)
			{
				pictureBoxNetworkConnection.BackgroundImage = Resources.NetworkOn;
			}
			else
			{
				pictureBoxNetworkConnection.BackgroundImage = Resources.NetworkOff;
			}
		}
		#endregion

		#region Delete Device
		private void pictureBoxDelete_Click(object sender, EventArgs e)
		{
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			Cursor.Current = Cursors.WaitCursor;
			if (GlobalVar.Device_Name.Count > 0)
			{
				try
				{
					for (int i = 0; i < GlobalVar.Schedule_Name.Count; i++)
					{
						if (GlobalVar.ScheduleDeviceName[i] == comboBoxDeviceName.Text)
						{
							using (TaskService ts = new TaskService())
							{
									ts.RootFolder.DeleteTask(GlobalVar.Schedule_Name[i]);
							}
							GlobalVar.ScheduleDeviceName.RemoveAt(i);
							GlobalVar.Schedule_Time.RemoveAt(i);
							GlobalVar.Schedule_Toggle.RemoveAt(i);
							GlobalVar.Schedule_Mon.RemoveAt(i);
							GlobalVar.Schedule_Tue.RemoveAt(i);
							GlobalVar.Schedule_Wed.RemoveAt(i);
							GlobalVar.Schedule_Thu.RemoveAt(i);
							GlobalVar.Schedule_Fri.RemoveAt(i);
							GlobalVar.Schedule_Sat.RemoveAt(i);
							GlobalVar.Schedule_Sun.RemoveAt(i);
							GlobalVar.Schedule_Name.RemoveAt(i);
							i--;
						}
					}
				}
				catch
				{
				}
					GlobalVar.IpAddress.RemoveAt(comboBoxDeviceName.SelectedIndex);
					GlobalVar.MacAddress.RemoveAt(comboBoxDeviceName.SelectedIndex);
					GlobalVar.Device_Name.RemoveAt(comboBoxDeviceName.SelectedIndex);
					GlobalVar.ReverseMacAddress.RemoveAt(comboBoxDeviceName.SelectedIndex);

					GlobalVar.GroupDeviceName.RemoveAt(comboBoxDeviceName.SelectedIndex);

					comboBoxDeviceName.Items.RemoveAt(comboBoxDeviceName.SelectedIndex);
					if (GlobalVar.Device_Name.Count > 0)
					{
						textBoxIP.Text = GlobalVar.IpAddress[0];
						textBoxMacAddress.Text = GlobalVar.MacAddress[0];
						comboBoxDeviceName.Text = GlobalVar.Device_Name[0];
						comboBoxDeviceName.SelectedIndex = 0;
						getStatus();
					}
					else
					{
						textBoxIP.Text = "";
						textBoxMacAddress.Text = "";
						comboBoxDeviceName.Text = "";
					}
				GroupChange();
			}
			else
			{
				GlobalVar.MessageBoxData = "No devices listed to delete.";
				var okMessage = new OkMessage();
				okMessage.ShowDialog();
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("No devices to delete.\n"));
			}
			Cursor.Current = Cursors.Default;
			GlobalVar.comboBoxDeviceName = comboBoxDeviceName.Items.Count;
			Save();
		}
		#endregion

		#region Register New Device

		private void registerNewDevcice()
		{
			if (GlobalVar.ReDiscover & GlobalVar.ConnectionType == "Wireless")
			{
				var registerDevice = new RegisterDevice();
				registerDevice.ShowDialog();

				Cursor.Current = Cursors.WaitCursor;
				if (GlobalVar.CancelRegistration)
				{
					return;
				}
				var tmp3 = GlobalVar.WifiPasswordArray.ToList();
				int pwdLength = GlobalVar.WifiPassword.Length;
				int i = 0;
				do
				{
					tmp3.Add(0x05);
				} while (i++ < pwdLength - 1);

				//Send Broadcast password
				i = 0;
				do
				{
					IPEndPoint endPoint1 = new IPEndPoint(GlobalVar.IP_Address_BCast, 49999);
					byte[] buffer1 =
					{
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05
					};
					sendData(buffer1, endPoint1);
					WaitCmd15();
				} while (i++ < 199);
				i = 0;
				do
				{
					IPEndPoint endPoint2 = new IPEndPoint(GlobalVar.IP_Address_BCast, 49999);
					byte[] buffer2 =
					{
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05
					};
					sendData(buffer2, endPoint2);
					WaitCmd15();
				} while (i++ < 2);

				//Following is the wireless password
				char[] arr = GlobalVar.WifiPassword.ToCharArray();
				foreach (var value in arr)
				{
					int ii = 0;
					decimal decValue = value;
					var tmp = GlobalVar.WifiPasswordArrayNumber.ToList();
					do
					{
						tmp.Add(0x05);
					} while (ii++ < decValue - 1);

					IPEndPoint endPoint3 = new IPEndPoint(GlobalVar.IP_Address_BCast, 49999);
					byte[] buffer3 = tmp.ToArray();
					sendData(buffer3, endPoint3);
					WaitCmd5();

				}
				//End of Password

				i = 0;
				do
				{
					IPEndPoint endPoint13 = new IPEndPoint(GlobalVar.IP_Address_BCast, 49999);
					byte[] buffer13 =
					{
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
						0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05
					};
					sendData(buffer13, endPoint13);
					WaitCmd15();
				} while (i++ < 2);

				//332 packets plus password length.
				i = 0;
				do
				{
					IPEndPoint endPoint14 = new IPEndPoint(GlobalVar.IP_Address_BCast, 49999);
					byte[] buffer14 = tmp3.ToArray().ToArray();
					sendData(buffer14, endPoint14);
					WaitCmd15();
				} while (i++ < 2);

				WaitCmdLong(); //ensures enough time for device to register with network.

				pictureBoxTogglePWR.BackgroundImage = Resources.Power_Off1;

				int repeat = 0;
				int rxPacket = 1;
				int rxPacketLength = 1;
				string mode = "Register";
				receiveData(rxPacket, rxPacketLength, mode, repeat);


				GlobalVar.ReDiscover = false;
				AddNewDevice();

			}
			else
			{
				GlobalVar.MessageBoxData = "No devices found and no new devices can be registered due to no WIFI connection. Register any new devices with the WiWo mobile app or use the S20 app with a WIFI connection.";
				var okMessage = new OkMessage();
				okMessage.ShowDialog();
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("Can not remove the None group.\n"));
			}
		}

		#endregion

		#region Load Scheduler
		private void buttonSchedules_Click(object sender, EventArgs e)
		{
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			if (comboBoxDeviceName.Items.Count != 0)
			{
				Hide();
				var schedules = new Schedules();
				schedules.ShowDialog();
				BringToFront();
				Show();
			}
			else
			{
				GlobalVar.MessageBoxData = "You must have a Device registered before you can use the scheduler.";
				var okMessage = new OkMessage();
				okMessage.ShowDialog();
			}
		}
		#endregion

		#region Timer to check for any requests from Vixen 3 or the Windows scheduler.
		private void timerCheckSchedules_Tick(object sender, EventArgs e)
		{
			string[] scheduleFiles = Directory.GetFiles(GlobalVar.DocumnetsFolder + @"\ToDo");

			if (scheduleFiles.Any())
			{
				Cursor.Current = Cursors.WaitCursor;
				//	 Open the file to read from. 
				using (StreamReader sr = File.OpenText(scheduleFiles[0]))
				{
					var i = 0;
					string [] s = new string[100];
					string s1;
					while ((s1 = sr.ReadLine()) != null)
					{
						s[i] = s1;
						i++;
					}
					if (s[0].Contains("Group"))
					{
						s[0] = "Group";
					}
					switch (s[0])
					{
						case "All":
							for (int ii = 0; ii < GlobalVar.Device_Name.Count; ii++)
							{
								comboBoxDeviceName.Text = GlobalVar.Device_Name[ii];
								textBoxIP.Text = GlobalVar.IpAddress[comboBoxDeviceName.SelectedIndex];
								textBoxMacAddress.Text = GlobalVar.MacAddress[comboBoxDeviceName.SelectedIndex];
								if (s[1].Contains("On"))
								{
									GlobalVar.TogglePower = GlobalVar.On;
									TogglePower();
								}
								else
								{
									GlobalVar.TogglePower = GlobalVar.Off;
									TogglePower();
								}
								WaitCmd();
							}
							break;
						case "Group":
					//		Test this code for groups.
							string[] splitGroupName = s[1].Split('_');
							for (int ii = 0; ii < GlobalVar.GroupDeviceName.Count; ii++)
							{
								if (GlobalVar.GroupDeviceName[ii] == splitGroupName[0])
								{
									comboBoxDeviceName.Text = GlobalVar.Device_Name[ii];
									textBoxIP.Text = GlobalVar.IpAddress[comboBoxDeviceName.SelectedIndex];
									textBoxMacAddress.Text = GlobalVar.MacAddress[comboBoxDeviceName.SelectedIndex];
									if (splitGroupName[1].Contains("On"))
									{
										GlobalVar.TogglePower = GlobalVar.On;
										TogglePower();
									}
									else
									{
										GlobalVar.TogglePower = GlobalVar.Off;
										TogglePower();
									}
								}
							}
							break;
						default:
							comboBoxDeviceName.Text = s[0];
							textBoxIP.Text = GlobalVar.IpAddress[comboBoxDeviceName.SelectedIndex];
							textBoxMacAddress.Text = GlobalVar.MacAddress[comboBoxDeviceName.SelectedIndex];
							if (s[1].Contains("On"))
							{
								GlobalVar.TogglePower = GlobalVar.On;
								TogglePower();
							}
							else
							{
								GlobalVar.TogglePower = GlobalVar.Off;
								TogglePower();
							}
							break;
					}
				}
				File.Delete(scheduleFiles[0]);
				WaitCmd();
				Cursor.Current = Cursors.Default;
			}
		}
		#endregion

		#region Software Settings Form
		private void buttonSettings_Click(object sender, EventArgs e)
		{
			Hide();
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			var settings = new Settings();
			settings.ShowDialog();
			BringToFront();
			Show();
		}
		#endregion

		#region Groups - Used for Sequencers (Vixen)

		#region Add new Group
		private void pictureBoxAddGroup_Click(object sender, EventArgs e)
		{
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			if (GlobalVar.Device_Name.Count > 0)
			{
				var groupname = new GroupName();
				groupname.ShowDialog();
				if (!GlobalVar.CancelAnything)
				{
					comboBoxGroupName.Items.Add(GlobalVar.Group_Name[GlobalVar.Group_Name.Count - 1]);
					comboBoxGroupName.SelectedIndex = comboBoxGroupName.Items.Count - 1;
					GroupUpdate();

					Create_Batch_Files.CreateBatchFiles();
				}
			}
			else
			{
				GlobalVar.MessageBoxData = "Can't create any groups until you have some devices.";
				var okMessage = new OkMessage();
				okMessage.ShowDialog();
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("Can't create any groups until you have some devices.\n"));
			}
		}
		#endregion

		#region Delete Group
		private void pictureBoxDeleteGroup_Click(object sender, EventArgs e)
		{
			if (GlobalVar.Group_Name.Count > 0)
			{
				if (comboBoxGroupName.SelectedIndex == 0)
				{
					GlobalVar.MessageBoxData ="Can not remove the None group.";
					GlobalVar.MainFormLocxationX = Location.X;
					GlobalVar.MainFormLocxationY = Location.Y;
					var okMessage = new OkMessage();
					okMessage.ShowDialog();
					richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("Can not remove the None group.\n"));
				}
				else
				{
					for (int i = 0; i < GlobalVar.GroupDeviceName.Count; i++)
					{
						if (GlobalVar.GroupDeviceName[i] == GlobalVar.Group_Name[comboBoxGroupName.SelectedIndex])
						{
							GlobalVar.GroupDeviceName[i] = "None";
						}
					}
					File.Delete(GlobalVar.DocumnetsFolder + @"\" + comboBoxGroupName.SelectedItem + @"_Group_Sequence_On.bat");
					File.Delete(GlobalVar.DocumnetsFolder + @"\" + comboBoxGroupName.SelectedItem + @"_Group_Sequence_Off.bat");
					GlobalVar.Group_Name.RemoveAt(comboBoxGroupName.SelectedIndex);
					comboBoxGroupName.Items.RemoveAt(comboBoxGroupName.SelectedIndex);
					comboBoxGroupName.SelectedIndex = 0;
					GlobalVar.NoSaveMsg = true;
					Create_Batch_Files.CreateBatchFiles();
					Save();
				}
			}
		}
		#endregion

		#region Updates, Changes
		private void GroupUpdate()
		{
			if (comboBoxDeviceName.Items.Count != 0)
			{
				GlobalVar.GroupDeviceName[comboBoxDeviceName.SelectedIndex] = comboBoxGroupName.SelectedItem.ToString();
			}
			GlobalVar.NoSaveMsg = true;
			Save();
		}

		private void GroupChange()
		{
			if (comboBoxDeviceName.Items.Count > 0)
			{
				comboBoxGroupName.SelectedItem = GlobalVar.GroupDeviceName[comboBoxDeviceName.SelectedIndex];
				GlobalVar.NoSaveMsg = true;
				Save();
			}
		}

		private void comboBoxGroupName_SelectionChangeCommitted(object sender, EventArgs e)
		{
			GroupUpdate();
		}
		#endregion

		#endregion
	}
}
