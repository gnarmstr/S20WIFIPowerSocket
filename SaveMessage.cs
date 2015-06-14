using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace S20_Power_Points
{
	public partial class SaveMessage : Form
	{
		public SaveMessage()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 60, ActiveForm.Location.Y + 140);
			InitializeComponent();
			BackgroundImage = Resources.Button_Green;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.BlackBackground;
			SaveClose = 0;
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
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			pictureBoxNo.Image = Tools.GetIcon(Resources.No, 40);
		}

		public static int SaveClose;

		
		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			SaveClose = 0;
			Close();
		}

		private void pictureBoxYes_Click(object sender, EventArgs e)
		{
			SaveClose = 1;
			Close();
		}

		private void pictureBoxNo_Click(object sender, EventArgs e)
		{
			SaveClose = 2;
			Close();
		}

	}
}
