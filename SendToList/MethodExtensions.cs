using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SendToList
{
    public static class MethodExtensions
    {
        internal static IEnumerable<VkNet.Model.User> ExcludeList(this IEnumerable<VkNet.Model.User> given, 
            IEnumerable<VkNet.Model.User> excludedIds)
        {
            return given.Where(i => !excludedIds.Any(e => (i.Id == e.Id)));
        }

        internal static IEnumerable<long> ToLong(this List<VkNet.Model.User> friendList)
        {
            return friendList.Select(friend => friend.Id);
        }

        internal static int GetSelectedId(this ListBox listBox)
        {
            return int.Parse(listBox.SelectedItem.ToString().Split(':')[0]);
        }
    }
}
