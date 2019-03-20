using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VkNet.Model.Attachments;

namespace SendToList.Extensions
{
	public static class StringExt
    {
		private const string RegexAttachmentLinkExpression = @"(video|photo|wall)[-]?\d+_\d+";
		private static Regex RegexAttachment => new Regex(RegexAttachmentLinkExpression);

        /// <summary>
		/// Берёт список wall1234_11..., разделённых '\n'. (wall, photo, video).
		/// Возвращает список сущностей MediaAttachment из либы VkNet.
		/// </summary>
		internal static IEnumerable<MediaAttachment> GetAttachmentsFromString(string attachmentsLinksString)
		{
			var result = new List<MediaAttachment>();

			var attachmentMatches = StringExt.RegexAttachment.Matches(attachmentsLinksString);

			foreach (Match match in attachmentMatches)
			{
				int typeLength = match.Value.Contains("wall") ?
					"wall".Length : "photo".Length; // "photo".Length == "video".Length

				string type = match.Value.Substring(0, typeLength);

				var attachParams = match.Value.Substring(typeLength).Split('_');

				MediaAttachment currentAttach;

				switch (type)
				{
					case "photo":
						currentAttach = new Photo();
						break;

					case "video":
						currentAttach = new Video();
						break;

					case "wall":
						currentAttach = new VkNet.Model.Post();
						break;

					default:
						continue;
				}

				currentAttach.OwnerId = int.Parse(attachParams[0]);
				currentAttach.Id = int.Parse(attachParams[1]);

				result.Add(currentAttach);
			}

			return result;
		}
    }
}
