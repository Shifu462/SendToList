namespace SendToList
{
    partial class CodeForm
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
            this.TextCode = new System.Windows.Forms.TextBox();
            this.ButtonCode = new System.Windows.Forms.Button();
            this.readlabelAllow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextCode
            // 
            this.TextCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TextCode.Location = new System.Drawing.Point(12, 53);
            this.TextCode.Name = "TextCode";
            this.TextCode.Size = new System.Drawing.Size(387, 30);
            this.TextCode.TabIndex = 0;
            this.TextCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextCode_KeyDown);
            // 
            // ButtonCode
            // 
            this.ButtonCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonCode.Location = new System.Drawing.Point(147, 103);
            this.ButtonCode.Name = "ButtonCode";
            this.ButtonCode.Size = new System.Drawing.Size(113, 38);
            this.ButtonCode.TabIndex = 1;
            this.ButtonCode.Text = "Готово!";
            this.ButtonCode.UseVisualStyleBackColor = true;
            this.ButtonCode.Click += new System.EventHandler(this.ButtonCode_Click);
            // 
            // readlabelAllow
            // 
            this.readlabelAllow.AutoSize = true;
            this.readlabelAllow.Location = new System.Drawing.Point(12, 9);
            this.readlabelAllow.Name = "readlabelAllow";
            this.readlabelAllow.Size = new System.Drawing.Size(384, 26);
            this.readlabelAllow.TabIndex = 2;
            this.readlabelAllow.Text = "Разрешите приложению доступ и скопируйте ссылку из адресной строки.\r\nПример: http" +
    "s://oauth.vk.com/blank.html#code=d4943b464ac2b8";
            // 
            // CodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 158);
            this.Controls.Add(this.readlabelAllow);
            this.Controls.Add(this.ButtonCode);
            this.Controls.Add(this.TextCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CodeForm";
            this.Text = "Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextCode;
        private System.Windows.Forms.Button ButtonCode;
        private System.Windows.Forms.Label readlabelAllow;
    }
}