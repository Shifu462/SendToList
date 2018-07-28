using System;
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

            int listIndex = lstFriendLists.GetSelectedId();
            var chosenFriendList = Program.Friendlist[listIndex];

            List<VkNet.Model.User> currentFriendList;
            if (isListDistincted)
            {
                int excludeListId = lstExclude.GetSelectedId();
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

            List<VkNet.Model.User> currentFriendList;
            if (isListDistincted)
            {
                int excludedListId = lstExclude.GetSelectedId();
                currentFriendList = Program.AllFriends.ExcludeList(Program.Friendlist[excludedListId]).ToList();
            }
            else currentFriendList = Program.AllFriends;

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

            await UpdateMessagesSentCount();
        }

        private async void ListFriendlists_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstFriendsInList.Items.Clear();

            var indexFriendist = int.Parse((lstFriendLists.SelectedItem as string).Split(':')[0]);

            foreach (var friend in Program.Friendlist[indexFriendist])
                lstFriendsInList.Items.Add($"{friend.FirstName} {friend.LastName}");

            await UpdateMessagesSentCount();
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
                }

                currentAttach.OwnerId = int.Parse(attachParams[0]);
                currentAttach.Id = int.Parse(attachParams[1]);

                Attachments.Add(currentAttach);
            }

            btnAttach.Text = $"Вложения: {Attachments.Count}";
        }

        private async void checkExclude_CheckedChanged(object sender, EventArgs e)
        {
            isListDistincted = lstExclude.Enabled = !isListDistincted; // Invert All
            await UpdateMessagesSentCount();
        }

        private void lstExclude_EnabledChanged(object sender, EventArgs e)
        {
            if (lstExclude.Enabled && lstExclude.Items.Count != 0)
                lstExclude.SetSelected(0, true);
        }

        private async void txtMessage_TextChanged(object sender, EventArgs e)
        {
            await UpdateMessagesSentCount();
        }

        private async void lstExclude_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateMessagesSentCount();
        }
    }
}
