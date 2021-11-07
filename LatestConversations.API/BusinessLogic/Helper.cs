using LatestConversations.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatestConversations.API.BusinessLogic
{
    public class Helper
    {
        private static Helper _instance;
        private Helper()
        {

        }

        public static Helper Instance
        {
            get 
            { 
                if(_instance == null)
                {
                    _instance = new Helper();
                }

                return _instance;
            }
        }

        public MessageDO GetLatestMessage(List<MessageDO> messages) 
        {
            MessageDO latestMsg = new MessageDO();
            foreach (var msg in messages)
            {
                if (msg.CreatedAt > latestMsg.CreatedAt)
                {
                    latestMsg = msg;
                }
            }
            return latestMsg;
        }
    }
}
