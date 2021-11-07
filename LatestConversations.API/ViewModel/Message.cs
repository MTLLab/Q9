using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatestConversations.API.ViewModel
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id
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

        [JsonProperty("from_user")]
        public User FromUser
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
