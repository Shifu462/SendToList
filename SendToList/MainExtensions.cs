using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VkNet.Enums.Filters;

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

    }
}
