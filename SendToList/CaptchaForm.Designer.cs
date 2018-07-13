namespace SendToList
{
    partial class CaptchaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureCaptcha = new System.Windows.Forms.PictureBox();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.btnCaptcha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureCaptcha
            // 
            this.PictureCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureCaptcha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureCaptcha.ErrorImage = null;
            this.PictureCaptcha.InitialImage = null;
            this.PictureCaptcha.Location = new System.Drawing.Point(12, 28);
            this.PictureCaptcha.Name = "PictureCaptcha";
            this.PictureCaptcha.Size = new System.Drawing.Size(421, 69);
            this.PictureCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureCaptcha.TabIndex = 0;
            this.PictureCaptcha.TabStop = false;
            // 
            // TextCaptcha
            // 
            this.txtCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtCaptcha.Location = new System.Drawing.Point(140, 134);
            this.txtCaptcha.Name = "TextCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(162, 29);
            this.txtCaptcha.TabIndex = 1;
            this.txtCaptcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCaptcha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextCaptcha_KeyDown);
            // 
            // ButtonCaptcha
            // 
            this.btnCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCaptcha.Location = new System.Drawing.Point(140, 176);
            this.btnCaptcha.Name = "ButtonCaptcha";
            this.btnCaptcha.Size = new System.Drawing.Size(162, 34);
            this.btnCaptcha.TabIndex = 2;
            this.btnCaptcha.Text = "Капча!";
            this.btnCaptcha.UseVisualStyleBackColor = true;
            this.btnCaptcha.Click += new System.EventHandler(this.ButtonCaptcha_Click);
            // 
            // CaptchaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 222);
            this.Controls.Add(this.btnCaptcha);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.PictureCaptcha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CaptchaForm";
            this.Text = "Captcha";
            this.Load += new System.EventHandler(this.CaptchaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureCaptcha;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.Button btnCaptcha;
    }
}