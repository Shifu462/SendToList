using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SendToList.JsonModel
{
    internal sealed class JsonMessageList
    {
        [JsonProperty("messages")]
        private List<JsonMessage> Messages { get; set; }

        [JsonIgnore]
        private static JsonMessageList _jsonMessageList;

        private JsonMessageList()
        {
        }

        public static JsonMessageList Instance(string fromFilename = "messages.json")
        {
            if (_jsonMessageList == null)
            {
                List<JsonMessage> messages;

                if (File.Exists(fromFilename))
                {
                    string fileText = File.ReadAllText(fromFilename);

                    messages = JsonConvert.DeserializeObject<JsonMessageList>(fileText).Messages;
                }
                else
                    messages = new List<JsonMessage>();

                _jsonMessageList = new JsonMessageList
                {
                    Messages = messages
                };
            }

            return _jsonMessageList;
        }

        public IEnumerable<long> IntersectUsersByText(string messageText, IEnumerable<long> toIntersectList)
        {
            var message = FindMessageByText(messageText);

            if (message == null && message.UserIds.Count == 0)
                return new List<long>();

            var userIds = message.UserIds;

            return userIds.Intersect(toIntersectList);
        }

        public JsonMessage FindMessageByText(string messageText){
             return Messages.SingleOrDefault(m => m.Text == messageText);
        }

        public void Add(string messageText, long userId)
        {
            var messageFromList = FindMessageByText(messageText);

            if (messageFromList != null)
                messageFromList.UserIds.Add(userId);
            else
            {
                Messages.Add(new JsonMessage
                {
                    Text = messageText,
                    UserIds = new List<long> { userId }
                });
            }

            SaveJsonToFile("messages.json");
        }

        public bool Contains(string messageText)
        {
            return Messages.Any(mes => mes.Text == messageText);
        }

        public bool AlreadySentMessage(string messageText, long userId)
        {
            if (!Contains(messageText)) return false;

            var message = FindMessageByText(messageText);
            return message.UserIds.Contains(userId);
        }
        
        private void SaveJsonToFile(string filename)
        {
            var thisSerialized = JsonConvert.SerializeObject(this);
            File.WriteAllText(filename, thisSerialized);
        }
        
    }

    internal sealed class JsonMessage
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("user_ids")]
        public List<long> UserIds { get; set; }
    }
}
