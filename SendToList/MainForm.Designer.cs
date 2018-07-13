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
            this.lstFriendLists = new System.Windows.Forms.ListBox();
            this.ListFriendsInList = new System.Windows.Forms.ListBox();
            this.btnSendToList = new System.Windows.Forms.Button();
            this.readlabelChooseList = new System.Windows.Forms.Label();
            this.TextMessage = new System.Windows.Forms.TextBox();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.readlabelAttachments = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.lstExclude = new System.Windows.Forms.ListBox();
            this.checkExclude = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstFriendLists
            // 
            this.lstFriendLists.FormattingEnabled = true;
            this.lstFriendLists.Location = new System.Drawing.Point(19, 36);
            this.lstFriendLists.Margin = new System.Windows.Forms.Padding(10);
            this.lstFriendLists.Name = "lstFriendLists";
            this.lstFriendLists.Size = new System.Drawing.Size(243, 212);
            this.lstFriendLists.TabIndex = 0;
            this.lstFriendLists.SelectedIndexChanged += new System.EventHandler(this.ListFriendlists_SelectedIndexChanged);
            // 
            // ListFriendsInList
            // 
            this.ListFriendsInList.FormattingEnabled = true;
            this.ListFriendsInList.Location = new System.Drawing.Point(282, 36);
            this.ListFriendsInList.Margin = new System.Windows.Forms.Padding(10);
            this.ListFriendsInList.Name = "ListFriendsInList";
            this.ListFriendsInList.Size = new System.Drawing.Size(216, 212);
            this.ListFriendsInList.TabIndex = 1;
            // 
            // btnSendToList
            // 
            this.btnSendToList.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSendToList.Location = new System.Drawing.Point(19, 259);
            this.btnSendToList.Name = "btnSendToList";
            this.btnSendToList.Size = new System.Drawing.Size(479, 54);
            this.btnSendToList.TabIndex = 2;
            this.btnSendToList.Text = "Отправить списку!";
            this.btnSendToList.UseVisualStyleBackColor = true;
            this.btnSendToList.Click += new System.EventHandler(this.btnSendToList_Click);
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
            this.TextMessage.Location = new System.Drawing.Point(514, 350);
            this.TextMessage.Multiline = true;
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.Size = new System.Drawing.Size(648, 140);
            this.TextMessage.TabIndex = 4;
            this.TextMessage.Text = "Привет, <firstname>!";
            // 
            // txtVideo
            // 
            this.txtVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtVideo.Location = new System.Drawing.Point(514, 36);
            this.txtVideo.Multiline = true;
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.Size = new System.Drawing.Size(382, 212);
            this.txtVideo.TabIndex = 5;
            // 
            // readlabelAttachments
            // 
            this.readlabelAttachments.AutoSize = true;
            this.readlabelAttachments.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readlabelAttachments.Location = new System.Drawing.Point(511, 14);
            this.readlabelAttachments.Name = "readlabelAttachments";
            this.readlabelAttachments.Size = new System.Drawing.Size(216, 19);
            this.readlabelAttachments.TabIndex = 6;
            this.readlabelAttachments.Text = "Укажите ссылки на вложения:";
            // 
            // btnAttach
            // 
            this.btnAttach.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAttach.Location = new System.Drawing.Point(515, 259);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(381, 54);
            this.btnAttach.TabIndex = 8;
            this.btnAttach.Text = "Прикрепить";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(511, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Текст сообщения:";
            // 
            // btnSendAll
            // 
            this.btnSendAll.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSendAll.Location = new System.Drawing.Point(20, 350);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(478, 140);
            this.btnSendAll.TabIndex = 10;
            this.btnSendAll.Text = "Отправить всем!";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // lstExclude
            // 
            this.lstExclude.Enabled = false;
            this.lstExclude.FormattingEnabled = true;
            this.lstExclude.Location = new System.Drawing.Point(919, 36);
            this.lstExclude.Margin = new System.Windows.Forms.Padding(10);
            this.lstExclude.Name = "lstExclude";
            this.lstExclude.Size = new System.Drawing.Size(243, 212);
            this.lstExclude.TabIndex = 11;
            this.lstExclude.EnabledChanged += new System.EventHandler(this.lstExclude_EnabledChanged);
            // 
            // checkExclude
            // 
            this.checkExclude.AutoSize = true;
            this.checkExclude.Location = new System.Drawing.Point(919, 17);
            this.checkExclude.Name = "checkExclude";
            this.checkExclude.Size = new System.Drawing.Size(124, 17);
            this.checkExclude.TabIndex = 12;
            this.checkExclude.Text = "Исключить список:";
            this.checkExclude.UseVisualStyleBackColor = true;
            this.checkExclude.CheckedChanged += new System.EventHandler(this.checkExclude_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 514);
            this.Controls.Add(this.checkExclude);
            this.Controls.Add(this.lstExclude);
            this.Controls.Add(this.btnSendAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.readlabelAttachments);
            this.Controls.Add(this.txtVideo);
            this.Controls.Add(this.TextMessage);
            this.Controls.Add(this.readlabelChooseList);
            this.Controls.Add(this.btnSendToList);
            this.Controls.Add(this.ListFriendsInList);
            this.Controls.Add(this.lstFriendLists);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Главная | Баланс: ---";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFriendLists;
        private System.Windows.Forms.ListBox ListFriendsInList;
        private System.Windows.Forms.Button btnSendToList;
        private System.Windows.Forms.Label readlabelChooseList;
        private System.Windows.Forms.TextBox TextMessage;
        private System.Windows.Forms.TextBox txtVideo;
        private System.Windows.Forms.Label readlabelAttachments;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.ListBox lstExclude;
        private System.Windows.Forms.CheckBox checkExclude;
    }
}

