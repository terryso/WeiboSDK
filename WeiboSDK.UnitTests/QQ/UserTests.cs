using NUnit.Framework;
using WeiboSDK.Entities.QQ;
using WeiboSDK.Request.QQ;

namespace WeiboSDK.UnitTests.QQ
{
    [TestFixture]
    public class UserTests : QQTestBase
    {
        [Test]
        public void Get_User_Info_Test()
        {
            // Arrange
            var request = new QQUserInfoRequest();

            // Act
            QQUser user = WeiboClient.Get(request).User;

            // Assert
            Assert.IsNotNull(user);

            Assert.AreEqual("suchuanyi", user.Name);
            Assert.AreEqual("Àƒ—€√…√Êœ¿", user.Nick);
        }
    }
}