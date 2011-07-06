using NUnit.Framework;
using WeiboSDK.Request.Sina;

namespace WeiboSDK.UnitTests.Sina
{
    [TestFixture]
    public class UserTests : SinaTestBase
    {
        [Test]
        public void UserShow_Test()
        {
            // Arrange
            var request = new SinaUserShowRequest("JJ叫我改名给她试新野");

            // Act
            var user = WeiboClient.Get(request).User;

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(request.ScreenName, user.ScreenName);
        }

        [Test]
        public void VerifyCredentials_Test()
        {
            // Arrange
            var request = new SinaVerifyCredentialsRequest();

            // Act
            var user = WeiboClient.Get(request).User;

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("PC遥控器", user.ScreenName);
        }
    }
}