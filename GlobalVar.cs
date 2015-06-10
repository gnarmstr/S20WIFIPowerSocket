using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace S20_Power_Points
{
	class GlobalVar
	{
		public static string SettingsPath;

		public static bool PowerStatusOn;

		public static bool CancelDiscover;

		public static int PowerStatus;

		public static IPAddress IP_Address;

		public static IPAddress RX_Data;

		public static IPAddress IP_Address_BCast;

		public static byte[] TwentiesBuffer = { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

		public static byte[] Off = { 0x00, 0x00, 0x00, 0x00, 0x00 };

		public static byte[] PwrCmd = { 0x68, 0x64, 0x00, 0x17, 0x64, 0x63 }; //new byte[6]; //

		public static byte[] SubscribeCmd = { 0x68, 0x64, 0x00, 0x1e, 0x63, 0x6c };

		public static byte[] On = { 0x00, 0x00, 0x00, 0x00, 0x01 };

		public static byte[] Mac = new byte[6]; // = {172, 207, 35, 54, 6, 120}; // HEX value is { 0xac, 0xcf, 0x23, 0x36, 0x06, 0x78 };

		public static byte[] ReverseMac = new byte[6];

		public static int ConvertMacValue;

	//	public static String[] HexValue = new string[6];

	//	public static string MacAddress;

		public static int MainFormLocxationX;

		public static int MainFormLocxationY;

		public static List<string> IpAddress = new List<String>();

		public static List<string> HexValue = new List<String>();

		public static List<string> ReverseHexValue = new List<String>();

		public static List<string> MacAddress = new  List<String>();

		public static List<string> ReverseMacAddress = new List<String>();

		public static List<string> Device_Name = new List<String>();

		public static bool dataReceived;

	//	public static string DeviceName;

		public static int receiveTimeOut;

		public static int DeviceNumber;

		public static bool dragging;

		public static int offsetX;

		public static int offsetY;




		public static bool startup;

		public static bool FirstTimeStart;


	}
}
