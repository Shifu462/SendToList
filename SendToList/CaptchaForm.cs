using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnticaptchaApi.JsonApiResponse;

namespace SendToList
{
    public partial class CaptchaForm : Form
    {
        private readonly string _captchaUrl;
        public double CaptchaCost { get; private set; } = 0;

        public CaptchaForm(string CaptchaUrl)
        {
            InitializeComponent();
            _captchaUrl = CaptchaUrl;

            if (Program.Anticaptcha == null || Program.Anticaptcha.Balance < 0.005)
                return;

            txtCaptcha.Enabled = btnCaptcha.Enabled = false;
            this.Text = $"Капча | Anticaptcha начала решение!";

            Thread captchaSolver = new Thread(new ThreadStart(SolveAndSubmitCaptcha));
            captchaSolver.Start();
        }

        private async void CaptchaForm_Load(object sender, EventArgs e)
        {
            PictureCaptcha.ImageLocation = _captchaUrl;
        }


        //
        // Auto
        //
        // Without opening form
        //

        private void SolveAndSubmitCaptcha()
        {
            string solvedCaptcha = SolveCaptcha(_captchaUrl);
            Program.LastCaptcha = solvedCaptcha.Trim();
        }

        private string SolveCaptcha(string captchaUrl)
        {
            int taskId = int.MinValue; // random default value

            taskId = Program.Anticaptcha.CreateTask(captchaUrl);

            var tr = new AnticaptchaTaskResult();
            while (!tr.IsDone)
                tr = Program.Anticaptcha.GetTaskResult(taskId);

            CaptchaCost = tr.Cost;
            return tr.Solution.Text;
        }

        //
        // Manual
        //

        private void ButtonCaptcha_Click(object sender, EventArgs e)
        {
            Program.LastCaptcha = txtCaptcha.Text.Trim();
            this.Close();
        }

        private void TextCaptcha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Program.Anticaptcha == null)
                ButtonCaptcha_Click(this, new EventArgs());
        }

    }
}
