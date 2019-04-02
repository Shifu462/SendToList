using System;
using System.Windows.Forms;
using System.Collections.Generic;
using VkNet.Model.Attachments;
using System.Linq;
using SendToList.Extensions;

namespace SendToList
{
	public partial class MainForm : Form
	{
		private MessageCache MessageCache { get; }

		private List<MediaAttachment> Attachments { get; } = new List<MediaAttachment>();

		private bool IsSending { get; set; } = false;

		public bool IsListDistincted => this.checkExclude.Checked;

		internal MainForm(MessageCache _messageCache)
		{
			this.MessageCache = _messageCache;
			this.InitializeComponent();
		}


		private async void Main_Load(object sender, EventArgs e)
		{
			bool anticaptchaInitialized = AnticaptchaWorker.TryInitialize();

			if (anticaptchaInitialized)
				this.Text = $"Главная | Баланс: {AnticaptchaWorker.Api.GetBalance()}";

			VkApp.Auth();
			await WinFormsExt.LoadListsAsync();

			foreach (var friendList in VkApp.CurrentFriendlists)
			{
				this.lstFriendLists.Items.Add($"{friendList.Id}: {friendList.Name}");
				this.lstExclude.Items.Add($"{friendList.Id}: {friendList.Name}");
			}

			this.lstFriendLists.SetSelected(0, true);

			await this.UpdateMessagesSentCount();
		}

		private async void btnSendToList_Click(object sender, EventArgs e)
		{
			if (this.IsSending)
				return;

			this.IsSending = true;

			int listIndex = this.lstFriendLists.GetSelectedId();
			var chosenFriendList = VkApp.Friendlist[listIndex];

			IList<VkNet.Model.User> currentFriendList;
			if (this.IsListDistincted)
			{
				int excludeListId = this.lstExclude.GetSelectedId();
				currentFriendList = chosenFriendList.ExcludeList(VkApp.Friendlist[excludeListId]).ToList();
			}
			else
			{
				currentFriendList = chosenFriendList;
			}

			await this.SendToListAsync(currentFriendList, sender as Button);

			this.IsSending = false;
		}

		private async void btnSendAll_Click(object sender, EventArgs e)
		{
			if (this.IsSending)
				return;

			this.IsSending = true;

			IList<VkNet.Model.User> currentFriendList;
			if (this.IsListDistincted)
			{
				int excludedListId = this.lstExclude.GetSelectedId();
				currentFriendList = VkApp.AllFriends.ExcludeList(VkApp.Friendlist[excludedListId]).ToList();
			}
			else
				currentFriendList = VkApp.AllFriends;

			await this.SendToListAsync(currentFriendList, sender as Button);

			this.IsSending = false;
		}

		private async void ListFriendlists_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lstFriendsInList.Items.Clear();

			var indexFriendist = int.Parse((this.lstFriendLists.SelectedItem as string).Split(':')[0]);

			foreach (var friend in VkApp.Friendlist[indexFriendist])
				this.lstFriendsInList.Items.Add($"{friend.FirstName} {friend.LastName}");

			await this.UpdateMessagesSentCount();
		}

		private void btnAttach_Click(object sender, EventArgs e)
		{
			this.Attachments.Clear();

			var foundAttachments = StringExt.GetAttachmentsFromString(this.txtVideo.Text);
			this.Attachments.AddRange(foundAttachments);

			this.btnAttach.Text = $"Вложения: {this.Attachments.Count}";
		}

		private async void checkExclude_CheckedChanged(object sender, EventArgs e)
		{
			this.lstExclude.Enabled = this.IsListDistincted;
			await this.UpdateMessagesSentCount();
		}

		private void lstExclude_EnabledChanged(object sender, EventArgs e)
		{
			if (this.lstExclude.Enabled && this.lstExclude.Items.Count != 0)
				this.lstExclude.SetSelected(0, true);
		}

		private async void txtMessage_TextChanged(object sender, EventArgs e)
		{
			await this.UpdateMessagesSentCount();
		}

		private async void lstExclude_SelectedIndexChanged(object sender, EventArgs e)
		{
			await this.UpdateMessagesSentCount();
		}
	}
}
