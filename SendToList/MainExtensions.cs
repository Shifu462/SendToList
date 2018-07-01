using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet.Enums.Filters;
using VkNet.Exception;

namespace SendToList
{
    public partial class MainForm
    {
        const string RegexAttachmentLinkExpression = @"(video|photo)[-]?\d+_\d+";
        Regex RegexAttachment = new Regex(RegexAttachmentLinkExpression);

        private async Task LoadLists()
        {
            Program.CurrentFriendlists = await Program.VK.Friends.GetListsAsync(returnSystem: true);
            Program.Friendlist = new Dictionary<long, List<VkNet.Model.User>>();

            foreach (var list in Program.CurrentFriendlists)
            {
                var friends = await Program.VK.Friends.GetAsync(new VkNet.Model.RequestParams.FriendsGetParams
                {
                    ListId = list.Id,
                    Fields = ProfileFields.FirstName | ProfileFields.LastName
                });

                Program.Friendlist.Add(list.Id, friends.ToList());
            }
        }

        private async Task SendToList(IEnumerable<VkNet.Model.User> currentFriendlist, Button buttonSend)
        {
            string MessageTemplate = TextMessage.Text;

            int allFriendsInListCount = currentFriendlist.Count();
            int sentCount = 0;
            foreach (var friend in currentFriendlist)
            {
                string MessageToFriend = MessageTemplate.Replace("<firstname>", friend.FirstName);

                while (true)
                {
                    try
                    {
                        await Program.VK.Messages.SendAsync(new VkNet.Model.RequestParams.MessagesSendParams
                        {
                            Message = MessageToFriend,
                            UserId = friend.Id,
                            Attachments = Attachments
                        });

                        Program.ClearCaptchaInfo();
                        buttonSend.Text = $"Отправлено: {++sentCount}/{allFriendsInListCount}";
                        break;
                    }
                    catch (CaptchaNeededException captcha)
                    {
                        Program.LastCaptchaSid = captcha.Sid;
                        Program.LastCaptchaUri = captcha.Img.AbsoluteUri;

                        using (var captchaForm = new CaptchaForm(captcha.Img.AbsoluteUri))
                            captchaForm.ShowDialog();

                        if (Program.Anticaptcha != null)
                            this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance.ToString()}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

    }
}
