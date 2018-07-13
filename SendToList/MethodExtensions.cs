using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SendToList
{
    public static class MethodExtensions
    {
        public static IEnumerable<VkNet.Model.User> ExcludeList(this IEnumerable<VkNet.Model.User> given, 
            IEnumerable<VkNet.Model.User> excludedIds)
        {
            return given.Where(i => !excludedIds.Any(e => (i.Id == e.Id)));
        }

        internal static int GetFriendlistId(this ListBox listBox)
        {
            return int.Parse(listBox.SelectedItem.ToString().Split(':')[0]);
        }
    }
}
