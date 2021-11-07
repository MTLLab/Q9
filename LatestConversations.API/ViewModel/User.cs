using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatestConversations.API.ViewModel
{
    public class User
    {
        [JsonProperty("id")]
        public string Id 
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
