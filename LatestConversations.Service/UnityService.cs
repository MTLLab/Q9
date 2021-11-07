using LatestConversations.DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace LatestConversations.Service
{
    public class UnityService : IUnityService
    {
        string conversationsURL = "https://rechomework.prd.mz.internal.unity3d.com/api/conversations";
        string messagesURL = "https://rechomework.prd.mz.internal.unity3d.com/api/conversations/{0}/messages";
        string userURL = "https://rechomework.prd.mz.internal.unity3d.com/api/users/{0}";

        public List<ConversationDO> LoadConversations() 
        {
            List<ConversationDO> result = new List<ConversationDO>();

            string response = GetResponse(conversationsURL);

            result = JsonConvert.DeserializeObject<List<ConversationDO>>(response);

            return result;
        }

        public List<MessageDO> LoadMessages(string conversationId)
        {
            List<MessageDO> result = new List<MessageDO>();

            string url = string.Format(messagesURL, conversationId);

            string response = GetResponse(url);

            result = JsonConvert.DeserializeObject<List<MessageDO>>(response);

            return result;
        }

        public UserDO LoadUser(string userId)
        {
            UserDO result = new UserDO();

            string url = string.Format(userURL, userId);

            string response = GetResponse(url);

            result = JsonConvert.DeserializeObject<UserDO>(response);

            return result;
        }

        private string GetResponse(string url)
        {
            string result = string.Empty;

            WebRequest request = WebRequest.Create(url);
            
            request.Method = "GET";
            
            WebResponse response = request.GetResponse();
            
            using (Stream responseStream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(responseStream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
