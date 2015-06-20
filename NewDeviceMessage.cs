using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace S20_Power_Points
{
	public partial class NewDeviceMessage : Form
	{
		public NewDeviceMessage()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 30, ActiveForm.Location.Y + 100);
			InitializeComponent();
			pictureBoxClose.BackgroundImage = Resources.Close;
			pictureBoxYes.BackgroundImage = Resources.Yes;
			pictureBoxNo.BackgroundImage = Resources.No;
			pictureBoxCancel.BackgroundImage = Resources.Cancel;
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
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			GlobalVar.NewDeviceChoice = "Cancel";
			Close();
		}

		private void pictureBoxYes_Click(object sender, EventArgs e)
		{

			GlobalVar.NewDeviceChoice = "Discover";
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			GlobalVar.NewDeviceChoice = "Cancel";
			Close();
		}

		private void pictureBoxNo_Click(object sender, EventArgs e)
		{
			GlobalVar.NewDeviceChoice = "Register";
				Close()
			;
		}

	}
}
