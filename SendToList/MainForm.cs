﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using VkNet.Exception;
using VkNet.Model.Attachments;
using AnticaptchaApi;
using System.Threading.Tasks;
using System.Linq;

namespace SendToList
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        List<MediaAttachment> Attachments = new List<MediaAttachment>();
        bool sending = false;

        public bool isListDistincted; // Equal at Load() to default checkbox.Checked value.

        private async void btnSendToList_Click(object sender, EventArgs e)
        {
            if (sending)
                return;
            sending = true;

            int listIndex = lstFriendLists.GetFriendlistId();
            var chosenFriendList = Program.Friendlist[listIndex];

            List<VkNet.Model.User> currentFriendList;
            if (isListDistincted)
            {
                int excludeListId = lstExclude.GetFriendlistId();
                currentFriendList = chosenFriendList.ExcludeList(Program.Friendlist[excludeListId]).ToList();
            }
            else currentFriendList = chosenFriendList;

            await SendToListAsync(currentFriendList, sender as Button);

            sending = false;
        }

        private async void btnSendAll_Click(object sender, EventArgs e)
        {
            if (sending)
                return;
            sending = true;

            var fullFriends = await Program.VK.Friends.GetAsync(new VkNet.Model.RequestParams.FriendsGetParams
            {
                Fields = VkNet.Enums.Filters.ProfileFields.FirstName
            });

            List<VkNet.Model.User> currentFriendList;
            if (isListDistincted)
            {
                int excludeListId = lstExclude.GetFriendlistId();
                currentFriendList = fullFriends.ExcludeList(Program.Friendlist[excludeListId]).ToList();
            }
            else currentFriendList = fullFriends.ToList();

            await SendToListAsync(currentFriendList, sender as Button);

            sending = false;
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            isListDistincted = checkExclude.Checked;

            string anticaptchaKey = File.Exists("anticaptcha_key.txt") ?
                File.ReadAllText("anticaptcha_key.txt") : "";

            if (anticaptchaKey != string.Empty)
            {
                Program.Anticaptcha = new AntiCaptcha(anticaptchaKey);
                this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance}";
            }

            Info.Auth();
            await LoadListsAsync();

            foreach (var list in Program.CurrentFriendlists)
            {
                lstFriendLists.Items.Add($"{list.Id}: {list.Name}");
                lstExclude.Items.Add(    $"{list.Id}: {list.Name}");
            }

            lstFriendLists.SetSelected(0, true);
        }

        private void ListFriendlists_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListFriendsInList.Items.Clear();

            var IndexFriendist = int.Parse((lstFriendLists.SelectedItem as string).Split(':')[0]);

            foreach (var friend in Program.Friendlist[IndexFriendist])
                ListFriendsInList.Items.Add($"{friend.FirstName} {friend.LastName}");
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Attachments.Clear();
            MatchCollection attachmentMatches = RegexAttachment.Matches(txtVideo.Text);

            foreach (Match match in attachmentMatches)
            {
                string type = match.Value.Substring(0, 5);
                var attachParams = match.Value.Substring(5).Split('_');

                MediaAttachment currentAttach = new Photo();

                switch (type)
                {
                    case "video":
                        currentAttach = new Video();
                        break;

                    case "photo": // currentAttach = new Photo();
                        break;

                    default:
                        MessageBox.Show("Ошибка! Неправильная ссылка. Номер: " + match.Index);
                        return;
                        break;
                }

                currentAttach.OwnerId = int.Parse(attachParams[0]);
                currentAttach.Id = int.Parse(attachParams[1]);

                Attachments.Add(currentAttach);
            }

            btnAttach.Text = $"Вложения: {Attachments.Count}";
        }

        private void checkExclude_CheckedChanged(object sender, EventArgs e)
        {
            isListDistincted = lstExclude.Enabled = !isListDistincted; // Invert All
        }

        private void lstExclude_EnabledChanged(object sender, EventArgs e)
        {
            if (lstExclude.Enabled && lstExclude.Items.Count != 0)
                lstExclude.SetSelected(0, true);
        }
    }
}
