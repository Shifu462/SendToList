using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet.Enums.Filters;

namespace SendToList.Extensions
{
	public static class WinFormsExt
	{
		internal static async Task LoadListsAsync()
		{
			VkApp.AllFriends = (await VkApp.Api.Friends.GetAsync(new VkNet.Model.RequestParams.FriendsGetParams
			{
				Fields = ProfileFields.FirstName
			})).ToList();
			VkApp.CurrentFriendlists = await VkApp.Api.Friends.GetListsAsync(returnSystem: true);
			VkApp.Friendlist = new Dictionary<long, List<VkNet.Model.User>>();

			foreach (var list in VkApp.CurrentFriendlists)
			{
				var friends = await VkApp.Api.Friends.GetAsync(new VkNet.Model.RequestParams.FriendsGetParams
				{
					ListId = list.Id,
					Fields = ProfileFields.FirstName | ProfileFields.LastName
				});

				VkApp.Friendlist.Add(list.Id, friends.ToList());
			}
		}

		internal static int GetSelectedId(this ListBox listBox)
		{
			return int.Parse(listBox.SelectedItem.ToString().Split(':')[0]);
		}
	}
}
