using Newtonsoft.Json;
using System;

namespace LatestConversations.DO
{
    [Serializable()]
    public class ConversationDO
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("with_user_id")]
        public string WithUserId
        {
            get;
            set;
        }

        [JsonProperty("unread_message_count")]
        public int UnreadMessageCount
        {
            get;
            set;
        }
    }
}
