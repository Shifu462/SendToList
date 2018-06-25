namespace SendToList
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListFriendlists = new System.Windows.Forms.ListBox();
            this.ListFriendsInList = new System.Windows.Forms.ListBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.readlabelChooseList = new System.Windows.Forms.Label();
            this.TextMessage = new System.Windows.Forms.TextBox();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.readlabelAttachments = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListFriendlists
            // 
            this.ListFriendlists.FormattingEnabled = true;
            this.ListFriendlists.Location = new System.Drawing.Point(19, 36);
            this.ListFriendlists.Margin = new System.Windows.Forms.Padding(10);
            this.ListFriendlists.Name = "ListFriendlists";
            this.ListFriendlists.Size = new System.Drawing.Size(243, 277);
            this.ListFriendlists.TabIndex = 0;
            this.ListFriendlists.SelectedIndexChanged += new System.EventHandler(this.ListFriendlists_SelectedIndexChanged);
            // 
            // ListFriendsInList
            // 
            this.ListFriendsInList.FormattingEnabled = true;
            this.ListFriendsInList.Location = new System.Drawing.Point(282, 36);
            this.ListFriendsInList.Margin = new System.Windows.Forms.Padding(10);
            this.ListFriendsInList.Name = "ListFriendsInList";
            this.ListFriendsInList.Size = new System.Drawing.Size(216, 277);
            this.ListFriendsInList.TabIndex = 1;
            // 
            // ButtonSend
            // 
            this.ButtonSend.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSend.Location = new System.Drawing.Point(19, 705);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(479, 66);
            this.ButtonSend.TabIndex = 2;
            this.ButtonSend.Text = "Отправить всем!";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // readlabelChooseList
            // 
            this.readlabelChooseList.AutoSize = true;
            this.readlabelChooseList.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readlabelChooseList.Location = new System.Drawing.Point(16, 13);
            this.readlabelChooseList.Name = "readlabelChooseList";
            this.readlabelChooseList.Size = new System.Drawing.Size(229, 19);
            this.readlabelChooseList.TabIndex = 3;
            this.readlabelChooseList.Text = "Выберите список для рассылки:";
            // 
            // TextMessage
            // 
            this.TextMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextMessage.Location = new System.Drawing.Point(19, 326);
            this.TextMessage.Multiline = true;
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.Size = new System.Drawing.Size(479, 140);
            this.TextMessage.TabIndex = 4;
            this.TextMessage.Text = "Привет, <firstname>!";
            // 
            // txtVideo
            // 
            this.txtVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtVideo.Location = new System.Drawing.Point(19, 500);
            this.txtVideo.Multiline = true;
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.Size = new System.Drawing.Size(479, 145);
            this.txtVideo.TabIndex = 5;
            this.txtVideo.Text = "https://vk.com/videos11920704?z=video-30316056_456283865%2Fpl_11920704_-2\r\nhttps:" +
    "//vk.com/shifer462?z=photo11920704_456253846%2Falbum11920704_00%2Frev";
            // 
            // readlabelAttachments
            // 
            this.readlabelAttachments.AutoSize = true;
            this.readlabelAttachments.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readlabelAttachments.Location = new System.Drawing.Point(16, 478);
            this.readlabelAttachments.Name = "readlabelAttachments";
            this.readlabelAttachments.Size = new System.Drawing.Size(216, 19);
            this.readlabelAttachments.TabIndex = 6;
            this.readlabelAttachments.Text = "Укажите ссылки на вложения:";
            // 
            // btnAttach
            // 
            this.btnAttach.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAttach.Location = new System.Drawing.Point(20, 651);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(478, 34);
            this.btnAttach.TabIndex = 8;
            this.btnAttach.Text = "Прикрепить";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 783);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.readlabelAttachments);
            this.Controls.Add(this.txtVideo);
            this.Controls.Add(this.TextMessage);
            this.Controls.Add(this.readlabelChooseList);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.ListFriendsInList);
            this.Controls.Add(this.ListFriendlists);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Главная | Баланс: ---";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListFriendlists;
        private System.Windows.Forms.ListBox ListFriendsInList;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Label readlabelChooseList;
        private System.Windows.Forms.TextBox TextMessage;
        private System.Windows.Forms.TextBox txtVideo;
        private System.Windows.Forms.Label readlabelAttachments;
        private System.Windows.Forms.Button btnAttach;
    }
}

