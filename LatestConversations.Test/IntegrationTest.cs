using LatestConversations.API.Controllers;
using LatestConversations.Service;
using LatestConversations.DO;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using LatestConversations.API.ViewModel;

namespace LatestConversations.Test
{
    public class IntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Verify_LatestConversationSummary()
        {
            string expectedResult = JsonConvert.SerializeObject(IntegrationTestHelper.Instance.GetExpectedSummaryResponse());
            Mock<IUnityService> mockService = IntegrationTestHelper.Instance.GetUnityServiceMock();
            LatestConversationsController controller = new LatestConversationsController(mockService.Object);
            string actualResult =JsonConvert.SerializeObject(controller.Get());
            
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}