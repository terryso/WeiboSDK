using System;
using NUnit.Framework;
using WeiboSDK.Request.Sina;

namespace WeiboSDK.UnitTests.Sina
{
    [TestFixture]
    public class CommentTests : SinaTestBase
    {
        [Test]
        public void Add_Comment_Test()
        {
            // Arrange
            var text = "test send a comment at " + DateTime.Now.ToLongTimeString();
            var request = new SinaCommentAddRequest(13712497764, text);

            // Act
            var comment = WeiboClient.Post(request).Comment;

            // Assert
            Assert.IsNotNull(comment);
            Assert.AreEqual(text, comment.Text);
        }
    }
}