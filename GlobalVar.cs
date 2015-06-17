using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms.VisualStyles;

namespace S20_Power_Points
{
	class GlobalVar
	{
		public static string SettingsPath;

		public static bool PowerStatusOn;

		public static string MessageBoxData;

		public static bool ToggleEvent;

		public static bool CancelDiscover;

		public static int PowerStatus;

		public static IPAddress IP_Address;

		public static IPAddress RX_Data;

		public static IPAddress IP_Address_BCast;

		public static byte[] TwentiesBuffer = { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

		public static byte[] Off = { 0x00, 0x00, 0x00, 0x00, 0x00 };

		public static byte[] PwrCmd = { 0x68, 0x64, 0x00, 0x17, 0x64, 0x63 };

		public static byte[] RenameCmd = { 0x68, 0x64, 0x00, 0xa5, 0x74, 0x6d };

		public static byte[] RenameCmd1 = {0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x01, 0x8a, 0x00, 0x01, 0x00, 0x43, 0x25};

		public static byte[] RenameCmd2 = { 0x38, 0x38, 0x38, 0x38, 0x38, 0x38, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

		public static byte[] RenameCmd3 =
		{
			0x04, 0x00, 0x20, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00,
			0x10, 0x27, 0x2a, 0x79, 0x6f, 0xd0, 0x10, 0x27, 0x76, 0x69, 0x63, 0x65, 0x6e, 0x74, 0x65, 0x72, 0x2e, 0x6f, 0x72,
			0x76, 0x69, 0x62, 0x6f, 0x2e, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xc0, 0xa8, 0x01, 0xc8, 0xc0, 0xa8, 0x01, 0x01, 0xff,
			0xff, 0xff, 0x00, 0x01, 0x01, 0x00, 0x0a, 0x00, 0xff, 0x00, 0xff
		};

		public static byte[] DeviceName = { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

		public static byte[] SubscribeCmd = { 0x68, 0x64, 0x00, 0x1e, 0x63, 0x6c };

		public static byte[] On = { 0x00, 0x00, 0x00, 0x00, 0x01 };

		public static byte[] Mac = new byte[6];

		public static byte[] ReverseMac = new byte[6];

		public static int ConvertMacValue;

		public static int MainFormLocxationX;

		public static int MainFormLocxationY;

		public static List<string> IpAddress = new List<String>();

		public static List<string> HexValue = new List<String>();

		public static List<string> ReverseHexValue = new List<String>();

		public static List<string> MacAddress = new  List<String>();

		public static List<string> ReverseMacAddress = new List<String>();

		public static List<string> Device_Name = new List<String>();

		public static bool dataReceived;

		public static List<string> Schedule_Name = new List<String>();

		public static List<DateTime> Schedule_Time = new List<DateTime>();

		public static List<bool> Schedule_Mon = new List<bool>();

		public static List<bool> Schedule_Tue = new List<bool>();

		public static List<bool> Schedule_Wed = new List<bool>();

		public static List<bool> Schedule_Thu = new List<bool>();

		public static List<bool> Schedule_Fri = new List<bool>();

		public static List<bool> Schedule_Sat = new List<bool>();

		public static List<bool> Schedule_Sun = new List<bool>();

		public static List<bool> Schedule_Toggle = new List<bool>();

		public static bool CancelRequest;


		public static int receiveTimeOut;

		public static int DeviceNumber;

		public static bool dragging;

		public static int offsetX;

		public static int offsetY;




		public static bool startup;

		public static bool FirstTimeStart;


	}
}
