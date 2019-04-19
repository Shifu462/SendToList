using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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


        private async Task UpdateMessagesSentCount()
        {
            var SentMessagesList = JsonModel.JsonMessageList.Instance();

            var message = SentMessagesList.FindMessageByText(txtMessage.Text);
            var alreadySentUsers = message != null ? message.UserIds : new List<long>();

            var chosenFriendlist = Program.Friendlist[lstFriendLists.GetSelectedId()].ToLong();

            int allCount = Program.AllFriends.Count;
            int chosenCount = chosenFriendlist.Count();

            var allNotSent = Program.AllFriends.ToLong().Except(alreadySentUsers);
            var chosenNotSent = chosenFriendlist.Except(alreadySentUsers);

            int chosenSentCount = chosenCount - chosenNotSent.Count();

            if (checkExclude.Checked)
            {
                var excludedList = Program.Friendlist[lstExclude.GetSelectedId()].ToLong();

                allNotSent = allNotSent.Except(excludedList);
                chosenNotSent = chosenNotSent.Except(excludedList);

                allCount = Program.AllFriends.ToLong().Except(excludedList).Count();

                if (lstFriendLists.GetSelectedId() == lstExclude.GetSelectedId())
                {
                    chosenSentCount = 0;
                    chosenCount = 0;
                }
            }

            int allSentCount = allCount - allNotSent.Count();

            lblSentAllCount.Text = $"{allSentCount}/{allCount} друзьям " +
                $"(не отправлено {allNotSent.Count()})";

            lblSentToListCount.Text = $"{chosenSentCount}/{chosenCount} " +
                $"друзьям из выбранного списка " +
                $"(не отправлено {chosenNotSent.Count()})";
        }

        private static async Task LoadListsAsync()
        {
            Program.AllFriends = (await Program.VK.Friends.GetAsync(new VkNet.Model.RequestParams.FriendsGetParams
            {
                Fields = ProfileFields.FirstName
            })).ToList();
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

        private async Task SendToListAsync(IEnumerable<VkNet.Model.User> currentFriendlist, Button buttonSend)
        {
            var MessagesToSaveList = JsonModel.JsonMessageList.Instance();

            string MessageTemplate = txtMessage.Text;

            int allFriendsInListCount = currentFriendlist.Count();
            int sentCount = 0;

            foreach (var friend in currentFriendlist)
            {
                if (MessagesToSaveList.AlreadySentMessage(MessageTemplate, friend.Id))
                    continue;

                string messageToCurrentFriend = MessageTemplate.Replace("<firstname>", friend.FirstName);

                var isSent = await TrySendMessage(messageToCurrentFriend, friend.Id);

                if (isSent)
                {
                    MessagesToSaveList.Add(MessageTemplate, friend.Id);
                    sentCount++;
                    await UpdateMessagesSentCount();
                }

                Program.ClearCaptchaInfo();
                if (Program.Anticaptcha != null)
                    this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance} | {buttonSend.Text}";
                else
                    this.Text = $"Главная | Баланс: --- | {buttonSend.Text}";
            }
        } 

        private async Task<bool> TrySendMessage(string messageText, long userId)
        {
            while (true)
            {
                try
                {
                    Program.VK.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                    {
                        Message = messageText,
                        UserId = userId,
                        Attachments = Attachments,
                        CaptchaKey = Program.LastCaptcha,
                        CaptchaSid = Program.LastCaptchaSid
                    });

                    return true;
                }
                catch (CaptchaNeededException captcha)
                {
                    Program.LastCaptchaSid = captcha.Sid;
                    Program.LastCaptchaUri = captcha.Img.AbsoluteUri;

                    if (Program.Anticaptcha != null)
                        this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance} | Решается капча";
                    else
                        this.Text = $"Главная | Баланс: --- | Решается капча";

                    using (var captchaForm = new CaptchaForm(captcha.Img.AbsoluteUri))
                    {
                        if (Program.Anticaptcha == null && (true || Program.Anticaptcha.Balance < 0.005))
                            captchaForm.ShowDialog();

                        // Wait
                        while (Program.LastCaptcha == null)
                            continue;
                    }

                    if (Program.Anticaptcha != null)
                        this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance} | {Program.LastCaptcha}";
                }
                catch (TooManyRequestsException)
                {
                    this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance} | Слишком много запросов в секунду.";
                    await Task.Delay(1000);
                }
                catch (TooMuchSentMessagesException ex)
                {
                    string errormessage = $"Лимит на рассылку исчерпан. Рассылка будет остановлена. \n\n" +
                        $"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";
                    MessageBox.Show(errormessage);
                    return false;
                }
                catch (AccessDeniedException ex)
                {
                    string errormessage = $"Отказано в доступе. \nПользователь ID: {userId}\n\n" +
                        $"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";

                    new Thread(() => MessageBox.Show(errormessage)).Start();
                    return false;
                }
                catch (UnknownException ex)
                {
                    string errormessage = $"Неизвестная ошибка на стороне VK. \nПользователь ID: {userId}\n\n" +
                        $"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";

                    new Thread(() => MessageBox.Show(errormessage)).Start();
                    return false;
                }
                catch (Exception ex)
                {
                    string errormessage = $"Неизвестная общая ошибка. \nПользователь ID: {userId}\n\n" +
                        $"  {ex.Message}";

                    new Thread(() => MessageBox.Show(errormessage)).Start();
                    return false;
                }
            }
        }
        

    }
}
