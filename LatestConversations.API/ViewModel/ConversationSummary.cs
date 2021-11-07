using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatestConversations.API.ViewModel
{
    public class ConversationSummary
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("latest_message")]
        public Message LatestMessage
        {
            get;
            set;
        }
    }
}
