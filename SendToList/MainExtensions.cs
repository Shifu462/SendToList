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
        

        private static async Task LoadListsAsync()
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

        private async Task SendToListAsync(IEnumerable<VkNet.Model.User> currentFriendlist, Button buttonSend)
        {
            string MessageTemplate = TextMessage.Text;

            int allFriendsInListCount = currentFriendlist.Count();
            int sentCount = 0;

            if (!Program.UsersGotMessage.Keys.Contains(MessageTemplate))
                Program.UsersGotMessage.Add(MessageTemplate, new List<long>());

            foreach (var friend in currentFriendlist)
            {
                // If already sent to him, skip.
                if (Program.UsersGotMessage[MessageTemplate].Contains(friend.Id))
                    continue;

                string MessageToFriend = MessageTemplate.Replace("<firstname>", friend.FirstName);

                while (true)
                {
                    try
                    {
                        Program.VK.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                        {
                            Message = MessageToFriend,
                            UserId = friend.Id,
                            Attachments = Attachments,
                            CaptchaKey = Program.LastCaptcha,
                            CaptchaSid = Program.LastCaptchaSid
                        });

                        Program.ClearCaptchaInfo();
                        Program.UsersGotMessage[MessageTemplate].Add(friend.Id);
                        buttonSend.Text = $"Отправлено: {++sentCount}/{allFriendsInListCount}";

                        if (Program.Anticaptcha != null)
                            this.Text = $"Главная | Баланс: {Program.Anticaptcha.Balance} | {buttonSend.Text}";
                        else
                            this.Text = $"Главная | Баланс: --- | {buttonSend.Text}";

                        break;
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
                        return;
                    }
                    catch (AccessDeniedException ex)
                    {
                        string errormessage = $"Отказано в доступе. \nПользователь ID: {friend.Id}\n\n" +
                            $"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";

                        new Thread(() => MessageBox.Show(errormessage)).Start();
                        break;
                    }
                    catch (UnknownException ex)
                    {
                        string errormessage = $"Неизвестная ошибка на стороне VK. \nПользователь ID: {friend.Id}\n\n" +
                            $"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";

                        new Thread(() => MessageBox.Show(errormessage)).Start();
                        break;
                    }
                    catch (Exception ex)
                    {
                        string errormessage = $"Неизвестная общая ошибка. \nПользователь ID: {friend.Id}\n\n" +
                            $"  {ex.Message}";

                        new Thread(() => MessageBox.Show(errormessage)).Start();
                        break;
                    }
                }
            }
            
        } // method brace

    }
}
