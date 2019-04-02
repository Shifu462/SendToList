using System;
using System.Windows.Forms;

namespace SendToList
{
	public partial class EnterTextForm : Form
	{
		public string Result { get; private set; }

		public EnterTextForm(string readlabelText, string title = "Введите данные")
		{
			this.InitializeComponent();

			this.Text = title;
			this.readlabel.Text = readlabelText;
		}

		private void ButtonCode_Click(object sender, EventArgs e)
		{
			this.Result = this.EnteredText.Text;
			this.Close();
		}

		private void TextCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				this.ButtonCode_Click(this, new EventArgs());
		}
	}
}
