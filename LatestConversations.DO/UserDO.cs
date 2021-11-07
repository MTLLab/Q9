using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatestConversations.DO
{
    public class UserDO
    {
        [JsonProperty("id")]
        public string Id 
        {
            get;
            set;
        }

        [JsonProperty("username")]
        public string UserName
        {
            get;
            set;
        }

        [JsonProperty("avatar_url")]
        public string AvatarUrl
        {
            get;
            set;
        }
    }
}
