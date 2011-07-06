using System;
using NUnit.Framework;
using PCRemote.Core.Utilities;
using WeiboSDK.Request.QQ;
using WeiboSDK.Request.Sina;

namespace WeiboSDK.UnitTests.QQ
{
    [TestFixture]
    public class StatusTests : QQTestBase
    {
        [Test]
        public void Add_A_Status_Test()
        {
            // Arrange
            var text = "≤‚ ‘∑¢ÀÕŒ¢≤© " + DateTime.Now.ToLongTimeString();
            var request = new QQStatusAddRequest(text);
            request.ClientIp = IPUtility.GetFirstLocalIP();

            // Act
            var response = WeiboClient.Post(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual("0", response.Ret);

            Console.WriteLine(response.Id);
            Console.WriteLine(response.Timestamp);

        }

        [Test]
        public void Add_A_Status_With_Picture_Test()
        {
            // Arrange
            var text = "≤‚ ‘∑¢Õº∆¨Œ¢≤© " + DateTime.Now.ToLongTimeString();
            var request = new QQStatusAddWithPicRequest(text, "c:\\Unnamed.jpg");

            // Act
            var response = WeiboClient.Post(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual("0", response.Ret);

            Console.WriteLine(response.Id);
            Console.WriteLine(response.Timestamp);

        }

        [Test]
        public void Get_Broadcast_Timeline_Test()
        {
            // Arrange
            var request = new QQBroadcastTimelineRequest {ReqNum = 1};

            // Act
            var statuses = WeiboClient.Get(request).Statuses;

            // Assert
            Assert.IsNotNull(statuses);
            Assert.AreEqual(1, statuses.Count);
        }
    }
}