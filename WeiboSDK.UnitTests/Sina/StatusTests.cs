using System;
using NUnit.Framework;
using WeiboSDK.Request.Sina;

namespace WeiboSDK.UnitTests.Sina
{
    [TestFixture]
    public class StatusTests : SinaTestBase
    {
        [Test]
        public void Get_User_Timeline_Test()
        {
            // Arrange
            var request = new SinaUserTimelineRequest {Count = 1};

            // Act
            var statuses = WeiboClient.Get(request).Statuses;

            // Assert
            Assert.IsNotNull(statuses);
            Assert.AreEqual(1, statuses.Count);

        }

        [Test]
        public void Add_A_Status_Test()
        {
            // Arrange
            var text = "²âÊÔ·¢Î¢²© " + DateTime.Now.ToLongTimeString();
            var requets = new SinaStatusUpdateRequest(text);

            // Act
            var status = WeiboClient.Post(requets).Status;

            // Assert
            Assert.IsNotNull(status);
            Assert.AreEqual(text, status.Text);

        }

        [Test]
        public void Add_A_Status_With_Picture_Test()
        {
            // Arrange
            var text = "²âÊÔ·¢Í¼Æ¬Î¢²© " + DateTime.Now.ToLongTimeString();
            var request = new SinaStatusUploadRequest(text, "c:\\Unnamed.jpg");

            // Act
            var status = WeiboClient.Post(request).Status;

            // Assert
            Assert.IsNotNull(status);
            Assert.AreEqual(text, status.Text);
        }

        [Test]
        public void Get_Trends_Test()
        {
            // Arrage
            var request = new SinaTrendsRequest {Trend = "Å·ÃÀ½ÖÅÄ"};

            // Act
            var statuses = WeiboClient.Get(request).Statuses;

            // Assert
            Assert.IsNotNull(statuses);
            Assert.IsTrue(statuses.Count > 0);
        }
    }
}