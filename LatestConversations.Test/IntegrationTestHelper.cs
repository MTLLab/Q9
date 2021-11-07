using LatestConversations.API.ViewModel;
using LatestConversations.DO;
using LatestConversations.Service;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatestConversations.Test
{
    class IntegrationTestHelper
    {
        static IntegrationTestHelper _instance;

        public IntegrationTestHelper()
        {
            
        }

        public static IntegrationTestHelper Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new IntegrationTestHelper();
                }

                return _instance;
            }
        }

        public Mock<IUnityService> GetUnityServiceMock()
        {
            Mock<IUnityService> mockUnityService = new Mock<IUnityService>();
            InitConversationMockData(mockUnityService);
            InitMessageMockData(mockUnityService);
            InitUserMockData(mockUnityService);
            return mockUnityService;
        }

        public List<ConversationSummary> GetExpectedSummaryResponse()
        {
            string conversationResponse = @"[
                  {
                    id: '1',
                    latest_message: {
                      id: '1',
                      body: 'Moi!',
                      from_user: {
                        id: '1',
                        avatar_url: 'http://placekitten.com/g/300/300',
                      },
                      created_at: '2016-08-25T10:15:00.670Z',
                    },
                  },
                  {
                    id: '2',
                    latest_message: {
                      id: '2',
                      body: 'Hello!',
                      from_user: {
                        id: '3',
                        avatar_url: 'http://placekitten.com/g/302/302',
                      },
                      created_at: '2016-08-24T10:15:00.670Z',
                    },
                  },
                  {
                    id: '3',
                    latest_message: {
                      id: '3',
                      body: 'Hi!',
                      from_user: {
                        id: '1',
                        avatar_url: 'http://placekitten.com/g/300/300',
                      },
                      created_at: '2016-08-23T10:15:00.670Z',
                    },
                  },
                  {
                    id: '4',
                    latest_message: {
                      id: '4',
                      body: 'Morning!',
                      from_user: {
                        id: '5',
                        avatar_url: 'http://placekitten.com/g/304/304',
                      },
                      created_at: '2016-08-22T10:15:00.670Z',
                    },
                  },
                  {
                    id: '5',
                    latest_message: {
                      id: '5',
                      body: 'Pleep!',
                      from_user: {
                        id: '6',
                        avatar_url: 'http://placekitten.com/g/305/305',
                      },
                      created_at: '2016-08-21T10:15:00.670Z',
                    },
                  },
                ]";

            List<ConversationSummary> conversations = JsonConvert.DeserializeObject<List<ConversationSummary>>(conversationResponse);
            return conversations;
        }

        private void InitConversationMockData(Mock<IUnityService> mockUnityService)
        {
            string conversationResponse = @"[
                  {'id': '1', 'with_user_id': '2', 'unread_message_count': 1},
                  {'id': '2', 'with_user_id': '3', 'unread_message_count': 0},
                  {'id': '3', 'with_user_id': '4', 'unread_message_count': 0},
                  {'id': '4', 'with_user_id': '5', 'unread_message_count': 0},
                  {'id': '5', 'with_user_id': '6', 'unread_message_count': 0}
                ]";

            List<ConversationDO> conversations = JsonConvert.DeserializeObject<List<ConversationDO>>(conversationResponse);
            
            mockUnityService.Setup(p => p.LoadConversations()).Returns(conversations);
        }

        private void InitMessageMockData(Mock<IUnityService> mockUnityService)
        {
            string conversation1MessagesResponse = @"[
                  { 'id': '1', 'conversation_id': '1', 'body': 'Moi!', 'from_user_id': '1', 'created_at': '2016-08-25T10:15:00.670Z'}
                ]";

            List<MessageDO> conversation1Messages = JsonConvert.DeserializeObject<List<MessageDO>>(conversation1MessagesResponse);
            mockUnityService.Setup(p => p.LoadMessages("1")).Returns(conversation1Messages);

            string conversation2MessagesResponse = @"[
                  {'id': '2', 'conversation_id': '2', 'body': 'Hello!', 'from_user_id': '3', 'created_at': '2016-08-24T10:15:00.670Z'}
                ]";

            List<MessageDO> conversation2Messages = JsonConvert.DeserializeObject<List<MessageDO>>(conversation2MessagesResponse);
            mockUnityService.Setup(p => p.LoadMessages("2")).Returns(conversation2Messages);

            string conversation3MessagesResponse = @"[
                  {'id': '3', 'conversation_id': '3', 'body': 'Hi!', 'from_user_id': '1', 'created_at': '2016-08-23T10:15:00.670Z'},
                  {'id': '7', 'conversation_id': '3', 'body': 'Waddap!', 'from_user_id': '4', 'created_at': '2016-08-23T10:14:00.670Z'}
                ]";

            List<MessageDO> conversation3Messages = JsonConvert.DeserializeObject<List<MessageDO>>(conversation3MessagesResponse);
            mockUnityService.Setup(p => p.LoadMessages("3")).Returns(conversation3Messages);

            string conversation4MessagesResponse = @"[
                  {'id': '4', 'conversation_id': '4', 'body': 'Morning!', 'from_user_id': '5', 'created_at': '2016-08-22T10:15:00.670Z'}
                ]";

            List<MessageDO> conversation4Messages = JsonConvert.DeserializeObject<List<MessageDO>>(conversation4MessagesResponse);
            mockUnityService.Setup(p => p.LoadMessages("4")).Returns(conversation4Messages);

            string conversation5MessagesResponse = @"[
                  {'id': '5', 'conversation_id': '5', 'body': 'Pleep!', 'from_user_id': '6', 'created_at': '2016-08-21T10:15:00.670Z'}
                ]";

            List<MessageDO> conversation5Messages = JsonConvert.DeserializeObject<List<MessageDO>>(conversation5MessagesResponse);
            mockUnityService.Setup(p => p.LoadMessages("5")).Returns(conversation5Messages);
        }

        private void InitUserMockData(Mock<IUnityService> mockUnityService)
        {
            string user1Response = @"{'id': '1', 'username': 'John', 'avatar_url': 'http://placekitten.com/g/300/300'}";

            UserDO user1 = JsonConvert.DeserializeObject<UserDO> (user1Response);
            mockUnityService.Setup(p => p.LoadUser("1")).Returns(user1);

            string user2Response = @"{'id': '2', 'username': 'Amy', 'avatar_url': 'http://placekitten.com/g/301/301'}";

            UserDO user2 = JsonConvert.DeserializeObject<UserDO>(user2Response);
            mockUnityService.Setup(p => p.LoadUser("2")).Returns(user2);

            string user3Response = @"{'id': '3', 'username': 'Jeremy', 'avatar_url': 'http://placekitten.com/g/302/302'}";

            UserDO user3 = JsonConvert.DeserializeObject<UserDO>(user3Response);
            mockUnityService.Setup(p => p.LoadUser("3")).Returns(user3);

            string user4Response = @"{'id': '4', 'username': 'Hannah', 'avatar_url': 'http://placekitten.com/g/303/303'}";

            UserDO user4 = JsonConvert.DeserializeObject<UserDO>(user4Response);
            mockUnityService.Setup(p => p.LoadUser("4")).Returns(user4);

            string user5Response = @"{'id': '5', 'username': 'Charles', 'avatar_url': 'http://placekitten.com/g/304/304'}";

            UserDO user5 = JsonConvert.DeserializeObject<UserDO>(user5Response);
            mockUnityService.Setup(p => p.LoadUser("5")).Returns(user5);

            string user6Response = @"{'id': '6', 'username': 'George', 'avatar_url': 'http://placekitten.com/g/305/305'}";

            UserDO user6 = JsonConvert.DeserializeObject<UserDO>(user6Response);
            mockUnityService.Setup(p => p.LoadUser("6")).Returns(user6);

        }
    }
}
