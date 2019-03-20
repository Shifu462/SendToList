using System.Collections.Generic;
using System.Linq;
using VkNet.Model;

namespace SendToList.Extensions
{
	public static class CollectionExt
    {
        internal static IEnumerable<User> ExcludeList(this IEnumerable<User> given,
			IEnumerable<User> excludedIds)
		{
			return given.Where(i => !excludedIds.Any(e => (i.Id == e.Id)));
		}

		internal static IEnumerable<long> ToLong(this IEnumerable<User> friendList)
		{
			return friendList.Select(friend => friend.Id);
		}
    }
}
