#region Using

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using GemBox.Spreadsheet;
using System.Net;
using System.Net.Sockets;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

#endregion

namespace S20_Power_Points
{
	public partial class MainForm : Form
	{
		#region Initialization

		public MainForm()
		{
			InitializeComponent();
			Settings();
			LoadData();
			GlobalVar.startup = false;
			getStatus();
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
			GlobalVar.SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"Property Management and Analysis");
			SaveAll.Image = Tools.ResizeImage(Resources.Save, 130, 30);
			
			GlobalVar.startup = true;
			GlobalVar.dataReceived = false;
			GlobalVar.IP_Address_BCast = IPAddress.Parse("192.168.0.255");
			GlobalVar.receiveTimeOut = 3000;
			GlobalVar.PowerStatusOn = false;

	//		panelMainPoints.BackgroundImage = Resources.powerbutton;
			BackgroundImageLayout = ImageLayout.Stretch;
			buttonInstructions.BackgroundImage = Resources.button_Blue_Small;
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			pictureBoxTogglePWR.BackgroundImage = Resources.Power_Unknown;
			pictureBoxDelete.BackgroundImage = Resources.delete;
			pictureBoxAdd.BackgroundImage = Resources.add;
		}

		#endregion

		#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();

			#region Profiles

			//try
			//{
			//	FileStream stream = File.OpenRead(@"c:\users\geoff\documents\PowerCmd.txt");
			//	stream.Read(GlobalVar.PwrCmd, 0, GlobalVar.PwrCmd.Length);
			//	stream.Close();
			//}
			//catch
			//{
				
			//}
			GlobalVar.DeviceNumber = profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, "DeviceNumber", 0);
			GlobalVar.PowerStatus = profile.GetSetting(XmlProfileSettings.SettingType.DeviceSettings, "PowerStatus", 0);
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
					line = "DeviceName";
					i++;
				} while (i < GlobalVar.DeviceNumber);
				textBoxIP.Text = GlobalVar.IpAddress[0];
				textBoxMacAddress.Text = GlobalVar.MacAddress[0];
				int milliseconds = 200;
				Thread.Sleep(milliseconds);
				comboBoxDeviceName.Text = GlobalVar.Device_Name[0];
				comboBoxDeviceName.SelectedIndex = 0;
			}

			#endregion
		}

		#endregion

		#region Main Form Load
		private void MainForm_Load(object sender, EventArgs e)
		{
			if (GlobalVar.FirstTimeStart)
			{
				var firstTime = new FirstTime();
				firstTime.ShowDialog();
				GlobalVar.FirstTimeStart = false;
			}
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

			var instructions = new Instructions();
			instructions.ShowDialog();
		}
		#endregion

		#region Close Application
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
				e.Cancel = false;
				switch (SaveMessage.SaveClose)
				{
					case 0:
						e.Cancel = true;
						break;
					case 1:
						Save();
						break;
					case 2:
						break;
				}
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			var saveMessage = new SaveMessage();
			saveMessage.ShowDialog();
			Close();
		}

		#endregion

		#region Save Data
		private void Save()
		{
			var profile = new XmlProfileSettings();

			#region Profiles
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "PowerStatus", GlobalVar.PowerStatus);


			//using (Stream file = File.OpenWrite(@"c:\users\geoff\documents\PowerCmd.txt"))
			//{
			//	file.Write(GlobalVar.PwrCmd, 0, GlobalVar.PwrCmd.Length);
			//}

			string line;
			if (comboBoxDeviceName.Items.Count > 0)
			{
				GlobalVar.DeviceNumber = comboBoxDeviceName.Items.Count;
				profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, "DeviceNumber", GlobalVar.DeviceNumber.ToString());
				int i = 0;
				line = "DeviceName";
				do
				{
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i,Convert.ToString(comboBoxDeviceName.Items[i]));
					line = "DeviceIP";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.IpAddress[i]);
					line = "DeviceMAC";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.MacAddress[i]);
					line = "DeviceReverseMAC";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.ReverseMacAddress[i]);
					line = "Device_Name";
					profile.PutSetting(XmlProfileSettings.SettingType.DeviceSettings, line + i, GlobalVar.Device_Name[i]);
					line = "DeviceName";
					i++;
				} while (i < GlobalVar.MacAddress.Count());
			}

			var okMessage = new OkMessage();
			okMessage.ShowDialog();
		}
			#endregion

		private void SaveAll_Click(object sender, EventArgs e)
		{
			Save();
		}
		#endregion

		#region Power Off

		private void PowerOff()
		{
			if (comboBoxDeviceName.Items.Count == 0)
			{
				MessageBox.Show(@"No devices listed, please select Discover to find new sockets.");
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
				if (comboBoxDeviceName.Items.Count == 0)
				{
					MessageBox.Show(@"No devices listed, please select Discover to find new sockets.");
					return;
				}

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
				byte[] sendDataByte = new byte[GlobalVar.PwrCmd.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.Off.Length];
				Array.Copy(GlobalVar.PwrCmd, 0, sendDataByte, 0, GlobalVar.PwrCmd.Length);
				Array.Copy(GlobalVar.Mac, 0, sendDataByte, GlobalVar.PwrCmd.Length, GlobalVar.Mac.Length);
				Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte, GlobalVar.PwrCmd.Length + GlobalVar.Mac.Length, GlobalVar.TwentiesBuffer.Length);
				Array.Copy(GlobalVar.Off, 0, sendDataByte, GlobalVar.PwrCmd.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.Mac.Length, GlobalVar.Off.Length);
				sendData(sendDataByte, endPoint);

				int rxPacket = 22;
				int rxPacketLength = 1;
				string mode = "PowerStatus";
				receiveData(rxPacket, rxPacketLength, mode);
				//Code to check if S20 Power is on or off. TO BE DONE
				try
				{
					if (GlobalVar.HexValue[0] == "0")
					{
						richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch Off.\n"));
						pictureBoxTogglePWR.BackgroundImage = Resources.Power_Off;
						GlobalVar.PowerStatusOn = false;
					}
				}
				catch
				{
					GlobalVar.HexValue.Add("0");
				}
				GlobalVar.dataReceived = false;
			} while (GlobalVar.HexValue[0] == "1" && repeat++ < 5);
		}
		#endregion

		#region Power On

		private void PowerOn()
		{
			//	GlobalVar.IP_Address_BCast = IPAddress.Parse("192.168.0.24");
			if (comboBoxDeviceName.Items.Count == 0)
			{
				MessageBox.Show(@"No devices listed, please select Discover to find new sockets.");
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
				//Construct data packet to turn S20 Power socket on
				byte[] sendDataByte = new byte[GlobalVar.PwrCmd.Length + GlobalVar.Mac.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.On.Length];
				Array.Copy(GlobalVar.PwrCmd, 0, sendDataByte, 0, GlobalVar.PwrCmd.Length);
				Array.Copy(GlobalVar.Mac, 0, sendDataByte, GlobalVar.PwrCmd.Length, GlobalVar.Mac.Length);
				Array.Copy(GlobalVar.TwentiesBuffer, 0, sendDataByte, GlobalVar.PwrCmd.Length + GlobalVar.Mac.Length, GlobalVar.TwentiesBuffer.Length);
				Array.Copy(GlobalVar.On, 0, sendDataByte, GlobalVar.PwrCmd.Length + GlobalVar.TwentiesBuffer.Length + GlobalVar.Mac.Length, GlobalVar.On.Length);
				sendData(sendDataByte, endPoint);

				int rxPacket = 22;
				int rxPacketLength = 1;
				string mode = "PowerStatus";
				receiveData(rxPacket, rxPacketLength, mode);

				//Code to check if S20 Power is on or off. TO BE DONE
				try
				{
					if (GlobalVar.HexValue[0] == "1")
					{
						richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch On.\n"));
						pictureBoxTogglePWR.BackgroundImage = Resources.Power_On;
						GlobalVar.PowerStatusOn = true;
					}
				}
				catch
				{
					GlobalVar.HexValue.Add("0");
				}

				GlobalVar.dataReceived = false;
			} while (GlobalVar.HexValue[0] == "0" && repeat++ < 5);
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
		public void receiveData(int rxPacket, int rxPacketLength, string mode)
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
				Debug.WriteLine(Encoding.ASCII.GetString(packet));
				GlobalVar.RX_Data = server.Address;
				int i = 0;
				GlobalVar.HexValue.Clear();
				GlobalVar.HexValue.Add("");
				GlobalVar.ReverseHexValue.Clear();
				GlobalVar.ReverseHexValue.Add("");
				do
				{
					switch (mode)
					{
						case "Discover":
							GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] = GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] + packet[i + rxPacket] + ":";
							GlobalVar.ReverseHexValue[GlobalVar.ReverseHexValue.Count() - 1] = packet[i + rxPacket] + ":" + GlobalVar.ReverseHexValue[GlobalVar.ReverseHexValue.Count() - 1];							
							break;
						case "PowerStatus":
							GlobalVar.HexValue[i] = packet[i + rxPacket].ToString("X");
							break;
						case "Subscribe":
							GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] = GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1] + packet[i + rxPacket] + ":";
							GlobalVar.PowerStatus = Convert.ToInt16(packet[23]);
							break;
					}
				} while (i++ < rxPacketLength - 1);
				if (mode == "Discover")
				{
					GlobalVar.MacAddress.Add(GlobalVar.HexValue[GlobalVar.HexValue.Count() - 1]);
					GlobalVar.ReverseMacAddress.Add(GlobalVar.ReverseHexValue[GlobalVar.ReverseHexValue.Count() - 1]);
				}
			}
			catch
			{
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("Did not recieve a response from " + comboBoxDeviceName.SelectedText + "within a predetermined time. Check your network connection.\n"));
			}

			client.Close();
		}
		#endregion

		#region Discover //Used to get new devices on the network
		private void pictureBoxAdd_Click(object sender, EventArgs e)
		{
			var devicename = new DeviceName();
			devicename.ShowDialog();
			if (GlobalVar.CancelDiscover)
			{
				return;
			}
			IPEndPoint endPoint = new IPEndPoint(GlobalVar.IP_Address_BCast, 10000);

			byte[] buffer = { 0x68, 0x64, 0x00, 0x06, 0x71, 0x61 };
			sendData(buffer, endPoint);

			if (GlobalVar.dataReceived)
			{
				int rxPacket = 7;
				int rxPacketLength = 6;
				string mode = "Discover";
				receiveData(rxPacket, rxPacketLength, mode); //Enable this when not testing without network.
				//		GlobalVar.RX_Data = IPAddress.Parse("192.168.0.24"); //remove this line when not testing without network.
				if (GlobalVar.RX_Data != null)
				{
					GlobalVar.IpAddress.Add(GlobalVar.RX_Data.ToString());
					comboBoxDeviceName.Items.Add(GlobalVar.Device_Name[GlobalVar.Device_Name.Count - 1]);
					comboBoxDeviceName.SelectedIndex = comboBoxDeviceName.Items.Count - 1;
					textBoxIP.Text = GlobalVar.RX_Data.ToString();
					textBoxMacAddress.Text = GlobalVar.MacAddress[GlobalVar.MacAddress.Count() - 1];
					buttonSubscribe_Click(null, null);
				}
			}
			GlobalVar.dataReceived = false;
		}
		#endregion

		#region Subscribe

		private void Subscribe()
		{
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

//				byte[] buffer = { 0x68, 0x64, 0x00, 0x1e, 0x63, 0x6c, 0xac, 0xcf, 0x23, 0x36, 0x06, 0x78, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x78, 0x06, 0x36, 0x23, 0xcf, 0xac, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
				sendData(sendDataByte1, endPoint);
				int rxPacket = 4;
				int rxPacketLength = 2;
				string mode = "Subscribe";
				do
				{
					receiveData(rxPacket, rxPacketLength, mode);
				} while (GlobalVar.HexValue[0] != "99:108:" && repeat++ < 5);
				int milliseconds = 200;
				Thread.Sleep(milliseconds);
			}
			catch
			{
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, ("Unable to reach network, ensure you have a network connection\n"));
			}
		}
		private void buttonSubscribe_Click(object sender, EventArgs e)
		{
			
		}
		#endregion

		#region Socket Data
		private void buttonSocketData_Click(object sender, EventArgs e)
		{
			if (comboBoxDeviceName.Items.Count == 0)
			{
				MessageBox.Show(@"No devices listed, please select Discover to find new sockets.");
				return;
			}
			IPEndPoint endPoint = new IPEndPoint(GlobalVar.IP_Address, 10000);

			byte[] buffer = { 0x68, 0x64, 0x00, 0x1E, 0x63, 0x6c, 0xac, 0xcf, 0x23, 0x36, 0x06, 0x78, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x78, 0x06, 0x36, 0x23, 0xcf, 0xac, 0x00, 0x00, 0x00, 0x00 };
			sendData(buffer, endPoint);
		}
		#endregion

		private void pictureBoxTogglePWR_Click(object sender, EventArgs e)
		{
			if (GlobalVar.PowerStatusOn)
			{
				PowerOff();
			}
			else
			{
				PowerOn();
			}
		}

		private void comboBoxDeviceName_SelectionChangeCommitted(object sender, EventArgs e)
		{
			getStatus();
		}

		private void getStatus()
		{
			textBoxIP.Text = GlobalVar.IpAddress[comboBoxDeviceName.SelectedIndex];
			textBoxMacAddress.Text = GlobalVar.MacAddress[comboBoxDeviceName.SelectedIndex];
			comboBoxDeviceName.Text = GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex];
			Subscribe();
			if (GlobalVar.PowerStatus == 1)
			{
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch On.\n"));
				pictureBoxTogglePWR.BackgroundImage = Resources.Power_On;
				GlobalVar.PowerStatusOn = true;
			}
			else
			{
				richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (GlobalVar.Device_Name[comboBoxDeviceName.SelectedIndex] + " is switch Off.\n"));
				pictureBoxTogglePWR.BackgroundImage = Resources.Power_Off;
				GlobalVar.PowerStatusOn = false;
			}
		}

		private void pictureBoxDelete_Click(object sender, EventArgs e)
		{
			GlobalVar.IpAddress.RemoveAt(comboBoxDeviceName.SelectedIndex);
			GlobalVar.MacAddress.RemoveAt(comboBoxDeviceName.SelectedIndex);
			GlobalVar.Device_Name.RemoveAt(comboBoxDeviceName.SelectedIndex);
			GlobalVar.ReverseMacAddress.RemoveAt(comboBoxDeviceName.SelectedIndex);
			comboBoxDeviceName.Items.RemoveAt(comboBoxDeviceName.SelectedIndex);
			textBoxIP.Text = GlobalVar.IpAddress[0];
			textBoxMacAddress.Text = GlobalVar.MacAddress[0];
			comboBoxDeviceName.Text = GlobalVar.Device_Name[0];
			comboBoxDeviceName.SelectedIndex = 0;
			getStatus();
		}
	}
}
