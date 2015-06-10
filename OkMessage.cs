using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace S20_Power_Points
{
	public partial class OkMessage : Form
	{
		public OkMessage()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 180, ActiveForm.Location.Y + 300);
			InitializeComponent();
			BackgroundImage = Resources.Button_Green;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
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

		private void DomesticActivities_Load(object sender, EventArgs e)
		{
			pictureBoxYes.Image = Tools.GetIcon(Resources.Ok, 40);
		}

		private void pictureBoxYes_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
