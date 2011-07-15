using System;
using NUnit.Framework;
using WeiboSDK.Request.QQ;
using WeiboSDK.Utilities;

namespace WeiboSDK.UnitTests.QQ
{
    [TestFixture]
    public class CommentTests : QQTestBase
    {
        [Test]
        public void Add_A_Comment_Test()
        {
            // Arrange
            var text = "≤‚ ‘∑¢∆¿¬€ " + DateTime.Now.ToLongTimeString();
            var reid = "47032096626287";
            var request = new QQCommentAddRequest(reid, text) {ClientIp = IPUtility.GetFirstLocalIP()};

            // Act
            var response = WeiboClient.Post(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual("0", response.Ret);

            Console.WriteLine(response.Id);
            Console.WriteLine(response.Timestamp);
        }
    }
}