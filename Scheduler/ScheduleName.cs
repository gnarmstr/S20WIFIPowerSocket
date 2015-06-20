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
	public partial class ScheduleName : Form
	{
		public ScheduleName()
		{
			Location = new Point(GlobalVar.MainFormLocxationX + 60, GlobalVar.MainFormLocxationY + 10);
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
			GlobalVar.CancelRequest = true;
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			if (textBoxScheduleName.Text != "")
			{
				foreach (var compare in GlobalVar.Schedule_Name)
				{
					if (textBoxScheduleName.Text == compare)
					{
						Hide();
						GlobalVar.MessageBoxData = "There is already a Schedule with that name. Please enter new name.";
						var okMessage = new OkMessage();
						okMessage.ShowDialog();
						Show();
						return;
					}
				}
				GlobalVar.Schedule_Name.Add(textBoxScheduleName.Text);
				GlobalVar.CancelRequest = false;
			}
			else
			{
				GlobalVar.CancelRequest = true;
			}
			
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
