using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace S20_Power_Points
{
	class Create_Batch_Files
	{

		public static void CreateBatchFiles()
		{
			if (!Directory.Exists(GlobalVar.DocumnetsFolder))
			{
				Directory.CreateDirectory(GlobalVar.DocumnetsFolder);
				Directory.CreateDirectory(GlobalVar.DocumnetsFolder + @"\ToDo");
				Directory.CreateDirectory(GlobalVar.DocumnetsFolder + @"\Schedules");
			}
			if (Directory.Exists(GlobalVar.DocumnetsFolder + @"\ToDo"))
			{
				Directory.Delete(GlobalVar.DocumnetsFolder + @"\ToDo", true);
			}
			Directory.CreateDirectory(GlobalVar.DocumnetsFolder + @"\ToDo");
			Directory.CreateDirectory(GlobalVar.DocumnetsFolder + @"\Schedules");
			Directory.CreateDirectory(GlobalVar.DocumnetsFolder + @"\Sequencer");

			//Create Batch for Devices
			for (int i = 0; i < GlobalVar.Device_Name.Count; i++)
			{
				// Create a file to write to. 
				using (
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\Sequencer\" + GlobalVar.Device_Name[i] + "_Sequence_On.bat"))
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
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\Sequencer\" + GlobalVar.Device_Name[i] + "_Sequence_Off.bat"))
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

			//Create Batch for All S20's
			// Create a file to write to. 
			using (StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\Sequencer\All_Sequence_Off.bat"))
			{
				sw.WriteLine(@"@echo off");
				sw.WriteLine(@"set /a counter=0");
				sw.WriteLine(@":numbers");
				sw.WriteLine(@"set /a counter=%counter%+1");
				sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
				sw.WriteLine(@"echo " + @"All> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
				sw.WriteLine(@"echo " + @"All_Off>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
				sw.WriteLine(@"goto :eof)");
				sw.WriteLine(@"goto :numbers");
			}
			using (StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\Sequencer\All_Sequence_On.bat"))
			{
				sw.WriteLine(@"@echo off");
				sw.WriteLine(@"set /a counter=0");
				sw.WriteLine(@":numbers");
				sw.WriteLine(@"set /a counter=%counter%+1");
				sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
				sw.WriteLine(@"echo " + @"All> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
				sw.WriteLine(@"echo " + @"All_On>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
				sw.WriteLine(@"goto :eof)");
				sw.WriteLine(@"goto :numbers");
			}

			//Create Batch for Groups
			for (int i = 0; i < GlobalVar.Group_Name.Count; i++)
			{
				// Create a file to write to. 
				using (
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\Sequencer\" + GlobalVar.Group_Name[i] + "_Group_Sequence_On.bat"))
				{
					sw.WriteLine(@"@echo off");
					sw.WriteLine(@"set /a counter=0");
					sw.WriteLine(@":numbers");
					sw.WriteLine(@"set /a counter=%counter%+1");
					sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
					sw.WriteLine(@"echo " + GlobalVar.Group_Name[i] + @"_Group> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"echo " + GlobalVar.Group_Name[i] + @"_On>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"goto :eof)");
					sw.WriteLine(@"goto :numbers");
				}
				// Create a file to write to. 
				using (
					StreamWriter sw = File.CreateText(GlobalVar.DocumnetsFolder + @"\Sequencer\" + GlobalVar.Group_Name[i] + "_Group_Sequence_Off.bat"))
				{
					sw.WriteLine(@"@echo off");
					sw.WriteLine(@"set /a counter=0");
					sw.WriteLine(@":numbers");
					sw.WriteLine(@"set /a counter=%counter%+1");
					sw.WriteLine(@"if exist " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt (goto :numbers) else (");
					sw.WriteLine(@"echo " + GlobalVar.Group_Name[i] + @"_Group> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"echo " + GlobalVar.Group_Name[i] + @"_Off>> " + GlobalVar.DocumnetsFolder + @"\ToDo\S20WIFIControl%counter%.txt");
					sw.WriteLine(@"goto :eof)");
					sw.WriteLine(@"goto :numbers");
				}
			}
		}
	}
}
