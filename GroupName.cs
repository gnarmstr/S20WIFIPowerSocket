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
	public partial class GroupName : Form
	{
		public GroupName()
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

		private void GroupName_Load(object sender, EventArgs e)
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
			Ok_Button();
		}

		private void Ok_Button()
		{
			GlobalVar.CancelAnything = true;
			if (textBoxGroupName.Text != "")
			{
				foreach (var compare in GlobalVar.Group_Name)
				{
					if (textBoxGroupName.Text == compare)
					{
						Hide();
						GlobalVar.MessageBoxData = "There is already a Grouip with that name. Please enter new name.";
						var okMessage = new OkMessage();
						okMessage.ShowDialog();
						Show();
						textBoxGroupName.Text = "";
						return;
					}
				}
				GlobalVar.Group_Name.Add(textBoxGroupName.Text);
	//			GlobalVar.GroupDeviceName.Add(textBoxGroupName.Text);
				GlobalVar.CancelAnything = false;
			}
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBoxGroupName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Convert.ToInt32(e.KeyChar) == 13)
			{
				Ok_Button();
			}
		}

	}
}
