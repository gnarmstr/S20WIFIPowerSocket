using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace S20_Power_Points
{
	public partial class DeviceName : Form
	{
		public DeviceName()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 30, ActiveForm.Location.Y + 100);
			InitializeComponent();
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			BackgroundImage = Resources.BlackBackground;
			BackgroundImageLayout = ImageLayout.Stretch;
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
			GlobalVar.CancelDiscover = true;
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			if (textBoxDeviceName.Text != "")
			{
				foreach (var compare in GlobalVar.Device_Name)
				{
					if (textBoxDeviceName.Text == compare)
					{
						Hide();
						GlobalVar.MessageBoxData = "There is already a Device with that name. Please enter new name.";
						var okMessage = new OkMessage();
						okMessage.ShowDialog();
						Show();
						textBoxDeviceName.Text = "";
						return;
					}
				}
				
				var result = string.Join(" ", textBoxDeviceName.Text.Select(c => String.Format("{0:X2}", Convert.ToInt32(c))));

				string[] hexValuesSplit = result.Split(' ');
				for (int i = 0; i < GlobalVar.DeviceName.Length; i++)
				{
					if (i < hexValuesSplit.Count())
					{
						GlobalVar.DeviceName[i] = Convert.ToByte(hexValuesSplit[i], 16);
					}
				}

				GlobalVar.Device_Name.Add(textBoxDeviceName.Text);
				GlobalVar.CancelDiscover = false;
			}
			else
			{
				GlobalVar.CancelDiscover = true;
			}
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			GlobalVar.CancelDiscover = true;
			Close();
		}

	}
}
