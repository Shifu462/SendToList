using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnticaptchaApi.JsonApiResponse;

namespace SendToList
{
	public partial class CaptchaForm : Form
    {
        private string CaptchaUrl { get; }

        public double CaptchaCost { get; private set; } = 0;

        public CaptchaForm(string captchaUrl)
        {
			this.InitializeComponent();

			this.CaptchaUrl = captchaUrl;

            if (AnticaptchaWorker.Api == null || AnticaptchaWorker.Api.GetBalance() < 0.005)
                return;

			this.txtCaptcha.Enabled = this.btnCaptcha.Enabled = false;
            this.Text = "Капча | Anticaptcha начала решение!";

			Task.Factory.StartNew(this.SolveAndSubmitCaptcha); // TODO: затестить
        }

        private void CaptchaForm_Load(object sender, EventArgs e)
        {
			this.PictureCaptcha.ImageLocation = this.CaptchaUrl;
        }


        //
        // Auto
        //
        // Without opening form
        //

        private void SolveAndSubmitCaptcha()
        {
            string solvedCaptcha = this.SolveCaptcha(this.CaptchaUrl);
            AnticaptchaWorker.LastCaptcha = solvedCaptcha.Trim();
        }

        private string SolveCaptcha(string captchaUrl)
        {
            int taskId = AnticaptchaWorker.Api.CreateTask(captchaUrl);

            var tr = new AnticaptchaTaskResult();
            while (!tr.IsDone)
                tr = AnticaptchaWorker.Api.GetTaskResult(taskId);

			this.CaptchaCost = tr.Cost;
            return tr.Solution.Text;
        }

        //
        // Manual
        //

        private void ButtonCaptcha_Click(object sender, EventArgs e)
        {
            AnticaptchaWorker.LastCaptcha = this.txtCaptcha.Text.Trim();
            this.Close();
        }

        private void TextCaptcha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && AnticaptchaWorker.Api == null)
				this.ButtonCaptcha_Click(this, new EventArgs());
        }

    }
}
