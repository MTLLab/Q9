using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatestConversations.DO
{
    public class MessageDO
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("conversation_id")]
        public string ConversationId
        {
            get;
            set;
        }

        [JsonProperty("body")]
        public string Body
        {
            get;
            set;
        }

        [JsonProperty("from_user_id")]
        public string FromUserId
        {
            get;
            set;
        }

        [JsonProperty("created_at")]
        public DateTime CreatedAt
        {
            get;
            set;
        }
    }
}
