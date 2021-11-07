using LatestConversations.API.ViewModel;
using LatestConversations.Service;
using LatestConversations.DO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LatestConversations.API.BusinessLogic;

namespace LatestConversations.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LatestConversationsController : ControllerBase
    {
        private readonly IUnityService us;
       
        public LatestConversationsController(IUnityService unityService)
        {
            us = unityService;
            
        }

        [HttpGet]
        public List<ConversationSummary> Get()
        {
            List<ConversationSummary> summaries = new List<ConversationSummary>();
            
            //Start with conversation list
            var conversationDOs = us.LoadConversations();
            foreach (var conversationDO in conversationDOs)
            {
                ConversationSummary summary = new ConversationSummary() { Id = conversationDO.Id };
                summaries.Add(summary);

                var messageDOs = us.LoadMessages(conversationDO.Id);
                if (messageDOs == null || messageDOs.Count == 0)
                {
                    continue;
                }

                //Get the latest message info
                var latestMsg = Helper.Instance.GetLatestMessage(messageDOs);

                //Get Latest message related user
                var userDO = us.LoadUser(latestMsg.FromUserId);
                
                //Assembly the response, user => message => summary
                User user = new User()
                {
                    Id = userDO.Id,
                    AvatarUrl = userDO.AvatarUrl
                };

                Message message = new Message()
                {
                    Id = latestMsg.Id,
                    FromUser = user,
                    Body = latestMsg.Body,
                    CreatedAt = latestMsg.CreatedAt
                };

                summary.LatestMessage = message;
            }

            return summaries;
        }
    }
}
