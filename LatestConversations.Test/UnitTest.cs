using LatestConversations.API.BusinessLogic;
using LatestConversations.DO;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatestConversations.Test
{
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Get_LatestMessage_SingleItem()
        {
            string messageExample = @"[
                  {'id': '2', 'conversation_id': '2', 'body': 'Hello!', 'from_user_id': '3', 'created_at': '2016-08-24T10:15:00.670Z'}
                ]";
            
            List<MessageDO> messages = JsonConvert.DeserializeObject<List<MessageDO>>(messageExample);

            string expectResult = JsonConvert.SerializeObject(messages[0]);
            string actualResult = JsonConvert.SerializeObject(Helper.Instance.GetLatestMessage(messages));
            Assert.AreEqual(expectResult, actualResult);
        }

        [Test]
        public void Get_LatestMessage_MultipleItem()
        {
            string messageExample = @"[
                  {'id': '3', 'conversation_id': '3', 'body': 'Hi!', 'from_user_id': '1', 'created_at': '2016-08-23T10:15:00.670Z'},
                  {'id': '7', 'conversation_id': '3', 'body': 'Waddap!', 'from_user_id': '4', 'created_at': '2016-08-23T10:14:00.670Z'}
                ]";

            List<MessageDO> messages = JsonConvert.DeserializeObject<List<MessageDO>>(messageExample);

            string expectResult = JsonConvert.SerializeObject(messages[0]);
            string actualResult = JsonConvert.SerializeObject(Helper.Instance.GetLatestMessage(messages));
            Assert.AreEqual(expectResult, actualResult);
        }

        [Test]
        public void Get_LatestMessage_ZeroItem()
        {
            string messageExample = @"[]";

            List<MessageDO> messages = JsonConvert.DeserializeObject<List<MessageDO>>(messageExample);

            string expectResult = JsonConvert.SerializeObject(new MessageDO());
            string actualResult = JsonConvert.SerializeObject(Helper.Instance.GetLatestMessage(messages));
            Assert.AreEqual(expectResult, actualResult);
        }
    }
}
