using System;
using System.Threading;
using System.Windows.Forms;
using AnticaptchaApi.JsonApiResponse;

namespace SendToList
{
    public partial class CaptchaForm : Form
    {
        public CaptchaForm(string CaptchaUrl)
        {
            InitializeComponent();
            PictureCaptcha.ImageLocation = CaptchaUrl;

            if (Program.Anticaptcha != null && Program.Anticaptcha.Balance >= 0.005)
            {
                ButtonCaptcha.Enabled = false;
                Thread captchaSolver = new Thread(new ThreadStart(SolveAndSubmitCaptcha));
                captchaSolver.Start();
            }

        }

        private void ButtonCaptcha_Click(object sender, EventArgs e)
        {
            Program.LastCaptcha = TextCaptcha.Text.Trim();
            this.Close();
        }

        private void TextCaptcha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Program.Anticaptcha == null)
                ButtonCaptcha_Click(this, new EventArgs());
        }

        private string SolveCaptcha(string captchaUrl)
        {
            var taskId = Program.Anticaptcha.CreateTask(captchaUrl);
            this.Text = $"Капча | Anticaptcha начала решение!";

            AnticaptchaTaskResult tr = new AnticaptchaTaskResult();

            while (!tr.IsDone)
                tr = Program.Anticaptcha.GetTaskResult(taskId);

            return tr.Solution.Text;
        }

        private void SolveAndSubmitCaptcha()
        {
            TextCaptcha.Text = SolveCaptcha(PictureCaptcha.ImageLocation);
            ButtonCaptcha_Click(this, new EventArgs());
        }
    }
}
