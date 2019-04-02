using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendToList.Extensions;
using VkNet.Exception;

namespace SendToList
{
	public partial class MainForm
	{
		private async Task UpdateMessagesSentCount()
		{
			var message = this.MessageCache[this.txtMessage.Text];
			var alreadySentUsers = message != null ? message.UserIds : new List<long>();

			var chosenFriendlist = VkApp.Friendlist[this.lstFriendLists.GetSelectedId()].ToLong();

			int allCount = VkApp.AllFriends.Count;
			int chosenCount = chosenFriendlist.Count();

			var allNotSent = VkApp.AllFriends.ToLong().Except(alreadySentUsers);
			var chosenNotSent = chosenFriendlist.Except(alreadySentUsers);

			int chosenSentCount = chosenCount - chosenNotSent.Count();

			if (this.checkExclude.Checked)
			{
				var excludedList = VkApp.Friendlist[this.lstExclude.GetSelectedId()].ToLong();

				allNotSent = allNotSent.Except(excludedList);
				chosenNotSent = chosenNotSent.Except(excludedList);

				allCount = VkApp.AllFriends.ToLong().Except(excludedList).Count();

				if (this.lstFriendLists.GetSelectedId() == this.lstExclude.GetSelectedId())
				{
					chosenSentCount = 0;
					chosenCount = 0;
				}
			}

			int allSentCount = allCount - allNotSent.Count();

			this.lblSentAllCount.Text = $"{allSentCount}/{allCount} друзьям " +
				$"(не отправлено {allNotSent.Count()})";

			this.lblSentToListCount.Text = $"{chosenSentCount}/{chosenCount} " +
				$"друзьям из выбранного списка " +
				$"(не отправлено {chosenNotSent.Count()})";
		}


		private async Task SendToListAsync(IEnumerable<VkNet.Model.User> currentFriendlist, Button buttonSend)
		{
			string _messageTemplate = this.txtMessage.Text.Trim();

			int allFriendsInListCount = currentFriendlist.Count();
			int sentCount = 0;

			foreach (var friend in currentFriendlist)
			{
				if (this.MessageCache.AlreadySentMessage(_messageTemplate, friend.Id))
					continue;

				string messageToCurrentFriend = _messageTemplate.Replace("<firstname>", friend.FirstName);

				var isSent = await this.TrySendMessage(messageToCurrentFriend, friend.Id);

				if (isSent)
				{
					this.MessageCache.Add(_messageTemplate, friend.Id);
					sentCount++;
					await this.UpdateMessagesSentCount();
				}

				AnticaptchaWorker.ClearCaptchaInfo();

				if (AnticaptchaWorker.Api != null)
					this.Text = $"Главная | Баланс: {AnticaptchaWorker.Api.GetBalance()} | {buttonSend.Text}";
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
					VkApp.Api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
					{
						Message = messageText,
						UserId = userId,
						Attachments = Attachments,
						RandomId = VkApp.GetRandomId(),
						CaptchaKey = AnticaptchaWorker.LastCaptcha,
						CaptchaSid = AnticaptchaWorker.LastCaptchaSid,

					});

					return true;
				}
				catch (CaptchaNeededException captcha)
				{
					AnticaptchaWorker.LastCaptchaSid = captcha.Sid;
					AnticaptchaWorker.LastCaptchaUri = captcha.Img.AbsoluteUri;

					var anticaptchaBalance = AnticaptchaWorker.Api.GetBalance(); // TODO: NullReferenceException.

					if (AnticaptchaWorker.Api != null)
						this.Text = $"Главная | Баланс: {anticaptchaBalance} | Решается капча";
					else
						this.Text = $"Главная | Баланс: --- | Решается капча";

					using (var captchaForm = new CaptchaForm(captcha.Img.AbsoluteUri))
					{
						if (AnticaptchaWorker.Api == null && (true || anticaptchaBalance < 0.005)) // TODO: чего нахуй
							captchaForm.ShowDialog();

						// Wait
						while (AnticaptchaWorker.LastCaptcha == null)
							continue;
					}

					if (AnticaptchaWorker.Api != null)
						this.Text = $"Главная | Баланс: {AnticaptchaWorker.Api.GetBalance()} | {AnticaptchaWorker.LastCaptcha}";
				}
				catch (TooManyRequestsException)
				{
					this.Text = $"Главная | Баланс: {AnticaptchaWorker.Api.GetBalance()} | Слишком много запросов в секунду.";
					await Task.Delay(1000);
				}
				catch (TooMuchSentMessagesException ex)
				{
					string errormessage = $"Лимит на рассылку исчерпан. Рассылка будет остановлена. \n\n" +
						$"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";
					MessageBoxExt.ShowInNewThread(errormessage);
					return false;
				}
				catch (AccessDeniedException ex)
				{
					string errormessage = $"Отказано в доступе. \nПользователь ID: {userId}\n\n" +
						$"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";

					MessageBoxExt.ShowInNewThread(errormessage);
					return false;
				}
				catch (UnknownException ex)
				{
					string errormessage = $"Неизвестная ошибка на стороне VK. \nПользователь ID: {userId}\n\n" +
						$"  Код ошибки: {ex.ErrorCode}\n{ex.Message}";

					MessageBoxExt.ShowInNewThread(errormessage);
					return false;
				}
				catch (Exception ex)
				{
					string errormessage = $"Неизвестная общая ошибка. \nПользователь ID: {userId}\n\n" +
						$"  {ex.Message}";

					MessageBoxExt.ShowInNewThread(errormessage);
					return false;
				}
			}
		}


	}
}
