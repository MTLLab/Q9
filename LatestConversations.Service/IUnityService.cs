using LatestConversations.DO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatestConversations.Service
{
    public interface IUnityService
    {
        public List<ConversationDO> LoadConversations();

        public List<MessageDO> LoadMessages(string conversationId);

        public UserDO LoadUser(string userId);

    }
}
