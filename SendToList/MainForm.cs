using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using VkNet.Exception;
using VkNet.Model.Attachments;
using AnticaptchaApi;


namespace SendToList
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        List<MediaAttachment> Attachments = new List<MediaAttachment>();

        private async void btnSendToList_Click(object sender, EventArgs e)
        {
            int listIndex = int.Parse(ListFriendlists.SelectedItem.ToString().Split(':')[0]);
            var currentFriendlist = Program.Friendlist[listIndex];

            await SendToList(currentFriendlist, sender as Button);
        }

        private async void btnSendAll_Click(object sender, EventArgs e)
        {
            var fullFriends = await Program.VK.Friends.GetAsync(new VkNet.Model.RequestParams.FriendsGetParams()
            {
                Fields = VkNet.Enums.Filters.ProfileFields.FirstName
            });

            await SendToList(fullFriends, sender as Button);
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            string anticaptchaKey = File.Exists("anticaptcha_key.txt") ?
                File.ReadAllText("anticaptcha_key.txt") : "";

            if (anticaptchaKey != string.Empty)
            {
                Program.Anticaptcha = new AntiCaptcha(anticaptchaKey);
                this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance.ToString()}";
            }

            Info.Auth();
            await LoadLists();

            foreach (var list in Program.CurrentFriendlists)
                ListFriendlists.Items.Add($"{list.Id}: {list.Name}");

            ListFriendlists.SetSelected(0, true);
        }

        private void ListFriendlists_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListFriendsInList.Items.Clear();

            var IndexFriendist = int.Parse((ListFriendlists.SelectedItem as string).Split(':')[0]);

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

        
    }
}
