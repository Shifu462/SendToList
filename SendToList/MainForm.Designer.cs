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
            this.lstFriendsInList = new System.Windows.Forms.ListBox();
            this.btnSendToList = new System.Windows.Forms.Button();
            this.readlabelChooseList = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.readlabelAttachments = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.readlabelMessageText = new System.Windows.Forms.Label();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.lstExclude = new System.Windows.Forms.ListBox();
            this.checkExclude = new System.Windows.Forms.CheckBox();
            this.readlabelSentCount = new System.Windows.Forms.Label();
            this.lblSentToListCount = new System.Windows.Forms.Label();
            this.lblSentAllCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            // lstFriendsInList
            // 
            this.lstFriendsInList.FormattingEnabled = true;
            this.lstFriendsInList.Location = new System.Drawing.Point(282, 36);
            this.lstFriendsInList.Margin = new System.Windows.Forms.Padding(10);
            this.lstFriendsInList.Name = "lstFriendsInList";
            this.lstFriendsInList.Size = new System.Drawing.Size(216, 212);
            this.lstFriendsInList.TabIndex = 1;
            // 
            // btnSendToList
            // 
            this.btnSendToList.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSendToList.Location = new System.Drawing.Point(515, 265);
            this.btnSendToList.Name = "btnSendToList";
            this.btnSendToList.Size = new System.Drawing.Size(382, 42);
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
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMessage.Location = new System.Drawing.Point(19, 278);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(479, 83);
            this.txtMessage.TabIndex = 4;
            this.txtMessage.Text = "Привет, <firstname>!";
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // txtVideo
            // 
            this.txtVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtVideo.Location = new System.Drawing.Point(515, 36);
            this.txtVideo.Multiline = true;
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.Size = new System.Drawing.Size(382, 157);
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
            this.btnAttach.Location = new System.Drawing.Point(515, 206);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(382, 42);
            this.btnAttach.TabIndex = 8;
            this.btnAttach.Text = "Прикрепить вложения";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // readlabelMessageText
            // 
            this.readlabelMessageText.AutoSize = true;
            this.readlabelMessageText.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readlabelMessageText.Location = new System.Drawing.Point(17, 256);
            this.readlabelMessageText.Name = "readlabelMessageText";
            this.readlabelMessageText.Size = new System.Drawing.Size(130, 19);
            this.readlabelMessageText.TabIndex = 9;
            this.readlabelMessageText.Text = "Текст сообщения:";
            // 
            // btnSendAll
            // 
            this.btnSendAll.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSendAll.Location = new System.Drawing.Point(515, 317);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(382, 44);
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
            this.lstExclude.Size = new System.Drawing.Size(218, 212);
            this.lstExclude.TabIndex = 11;
            this.lstExclude.SelectedIndexChanged += new System.EventHandler(this.lstExclude_SelectedIndexChanged);
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
            // readlabelSentCount
            // 
            this.readlabelSentCount.AutoSize = true;
            this.readlabelSentCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readlabelSentCount.Location = new System.Drawing.Point(15, 381);
            this.readlabelSentCount.Name = "readlabelSentCount";
            this.readlabelSentCount.Size = new System.Drawing.Size(257, 19);
            this.readlabelSentCount.TabIndex = 13;
            this.readlabelSentCount.Text = "Такое сообщение уже отправлено:";
            // 
            // lblSentToListCount
            // 
            this.lblSentToListCount.AutoSize = true;
            this.lblSentToListCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSentToListCount.Location = new System.Drawing.Point(15, 419);
            this.lblSentToListCount.Name = "lblSentToListCount";
            this.lblSentToListCount.Size = new System.Drawing.Size(685, 19);
            this.lblSentToListCount.TabIndex = 14;
            this.lblSentToListCount.Text = "{sentCount}/{sendListCount} друзьям из выбранного списка (можно отправить ещё {ca" +
    "nSendCount})";
            // 
            // lblSentAllCount
            // 
            this.lblSentAllCount.AutoSize = true;
            this.lblSentAllCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSentAllCount.Location = new System.Drawing.Point(15, 400);
            this.lblSentAllCount.Name = "lblSentAllCount";
            this.lblSentAllCount.Size = new System.Drawing.Size(527, 19);
            this.lblSentAllCount.TabIndex = 15;
            this.lblSentAllCount.Text = "{sentCount}/{sendListCount} друзьям (можно отправить ещё {canSendCount})";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(674, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Помните, что некоторым друзьям может не отправиться, потому что они ограничили до" +
    "ступ.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F);
            this.label2.Location = new System.Drawing.Point(15, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(920, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Если сообщение не было отправлено пользователю, то во время рассылки появится доп" +
    "олнительное окно с информацией об этом.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(829, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Не забудьте скопировать свой ключ антикапчи (anti-captcha.com) в файл anticaptcha" +
    "_key.txt, если он у вас имеется.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 545);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSentAllCount);
            this.Controls.Add(this.lblSentToListCount);
            this.Controls.Add(this.readlabelSentCount);
            this.Controls.Add(this.checkExclude);
            this.Controls.Add(this.lstExclude);
            this.Controls.Add(this.btnSendAll);
            this.Controls.Add(this.readlabelMessageText);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.readlabelAttachments);
            this.Controls.Add(this.txtVideo);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.readlabelChooseList);
            this.Controls.Add(this.btnSendToList);
            this.Controls.Add(this.lstFriendsInList);
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
        private System.Windows.Forms.ListBox lstFriendsInList;
        private System.Windows.Forms.Button btnSendToList;
        private System.Windows.Forms.Label readlabelChooseList;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtVideo;
        private System.Windows.Forms.Label readlabelAttachments;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label readlabelMessageText;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.ListBox lstExclude;
        private System.Windows.Forms.CheckBox checkExclude;
        private System.Windows.Forms.Label readlabelSentCount;
        private System.Windows.Forms.Label lblSentToListCount;
        private System.Windows.Forms.Label lblSentAllCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

