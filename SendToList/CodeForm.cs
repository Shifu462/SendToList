using System;
using System.Linq;
using System.Windows.Forms;

namespace SendToList
{
    public partial class CodeForm : Form
    {
        public CodeForm()
        {
			this.InitializeComponent();
        }

        private void ButtonCode_Click(object sender, EventArgs e)
        {
            try
            {

                var url = this.TextCode.Text;

				Info.AccessToken = this.GetPropertyValue( url, "access_token" );
				this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверьте правильность введённых данных. \n\n(Ошибка:{ex.Message})");
                Application.Exit();
                return;
            }
        }

		private string GetPropertyValue(string url, string propertyName)
        {
            string[] urlParams = url.Split(new char[] { '?', '&' });
            return urlParams.FirstOrDefault(p => p.Contains(propertyName + "="))
                                    .Split('=')[1]; // {propertyName}=*text*" split by '=', take *text*
        }

        private void TextCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
				this.ButtonCode_Click(this, new EventArgs());
        }
    }
}
