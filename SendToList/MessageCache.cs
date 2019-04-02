using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SendToList
{
	internal sealed class MessageCache : IEnumerable<JsonMessage>
	{
		[JsonProperty("messages")]
		private IList<JsonMessage> Messages { get; set; }

		[JsonIgnore]
		private static MessageCache jsonMessageList;

		private MessageCache(IList<JsonMessage> messages) 
		{
			this.Messages = messages;
		}

		public JsonMessage this[int index]
		{
			get => this.Messages[index];
			set => this.Messages[index] = value;
		}
		
		/// <summary>
		/// Находит сообщение по тексту messageText.
		/// </summary>
		public JsonMessage this[string messageText] => this.FindMessageByText(messageText);

		public static MessageCache Instance(string fromFilename = "messages.json")
		{
			if (MessageCache.jsonMessageList != null)
				return MessageCache.jsonMessageList;

			if (File.Exists(fromFilename))
			{
				string fileText = File.ReadAllText(fromFilename);
				var messages = JsonConvert.DeserializeObject<MessageCache>(fileText).Messages;
				MessageCache.jsonMessageList = new MessageCache(messages);
				return MessageCache.jsonMessageList;
			}

			MessageCache.jsonMessageList = new MessageCache(new List<JsonMessage>());
			return MessageCache.jsonMessageList;
		}

		public IEnumerable<long> IntersectUsersByText(string messageText, IEnumerable<long> toIntersectList)
		{
			JsonMessage message = this.FindMessageByText(messageText);

			if (message == null && message.UserIds.Count == 0)
				return new List<long>();

			return message.UserIds.Intersect(toIntersectList);
		}

		private JsonMessage FindMessageByText(string messageText)
		{
			return this.Messages.FirstOrDefault(m => m.Text == messageText);
		}

		public void Add(string messageText, long userId)
		{
			var messageFromList = this[messageText];

			if (messageFromList != null)
				messageFromList.UserIds.Add(userId);
			else
			{
				this.Messages.Add(new JsonMessage
				{
					Text = messageText,
					UserIds = new List<long> { userId }
				});
			}

			this.SaveJsonToFile("messages.json");
		}

		public bool Contains(string messageText)
		{
			return this.Messages.Any(mes => mes.Text == messageText);
		}

		public bool AlreadySentMessage(string messageText, long userId)
		{
			if (!this.Contains(messageText))
				return false;

			var message = this[messageText];
			return message.UserIds.Contains(userId);
		}

		private void SaveJsonToFile(string filename)
		{
			var thisSerialized = JsonConvert.SerializeObject(this);
			File.WriteAllText(filename, thisSerialized);
		}

		public IEnumerator<JsonMessage> GetEnumerator() => this.Messages.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => this.Messages.GetEnumerator();
	}

	internal sealed class JsonMessage
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("user_ids")]
		public IList<long> UserIds { get; set; }

		public long this[int index]
		{
			get => this.UserIds[index];
			set => this.UserIds[index] = value;
		}
	}
}
