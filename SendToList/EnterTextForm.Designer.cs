namespace SendToList
{
    partial class EnterTextForm
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
			this.EnteredText = new System.Windows.Forms.TextBox();
			this.SubmitTextButton = new System.Windows.Forms.Button();
			this.readlabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// EnteredText
			// 
			this.EnteredText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.EnteredText.Location = new System.Drawing.Point(12, 53);
			this.EnteredText.Name = "EnteredText";
			this.EnteredText.Size = new System.Drawing.Size(387, 30);
			this.EnteredText.TabIndex = 0;
			this.EnteredText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextCode_KeyDown);
			// 
			// SubmitTextButton
			// 
			this.SubmitTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.SubmitTextButton.Location = new System.Drawing.Point(147, 103);
			this.SubmitTextButton.Name = "SubmitTextButton";
			this.SubmitTextButton.Size = new System.Drawing.Size(113, 38);
			this.SubmitTextButton.TabIndex = 1;
			this.SubmitTextButton.Text = "Готово!";
			this.SubmitTextButton.UseVisualStyleBackColor = true;
			this.SubmitTextButton.Click += new System.EventHandler(this.ButtonCode_Click);
			// 
			// readlabel
			// 
			this.readlabel.AutoSize = true;
			this.readlabel.Location = new System.Drawing.Point(9, 9);
			this.readlabel.Name = "readlabel";
			this.readlabel.Size = new System.Drawing.Size(58, 13);
			this.readlabel.TabIndex = 2;
			this.readlabel.Text = "{readlabel}";
			// 
			// EnterTextForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(411, 164);
			this.Controls.Add(this.readlabel);
			this.Controls.Add(this.SubmitTextButton);
			this.Controls.Add(this.EnteredText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "EnterTextForm";
			this.Text = "Авторизация пользователя";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EnteredText;
        private System.Windows.Forms.Button SubmitTextButton;
        private System.Windows.Forms.Label readlabel;
    }
}