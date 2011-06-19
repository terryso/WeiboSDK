using System;
using NUnit.Framework;

namespace WeiboSDK.UnitTests
{
    [TestFixture]
    public class StatusTests : TestBase
    {
        [Test]
        public void GetPublicWeibos_Test()
        {
            // Arrange

            // Act
            var weibos = WeiboClient.GetPublicWeibos();

            // Assert
            Assert.IsNotNull(weibos);
            Assert.IsTrue(weibos.Count > 0);

            Console.WriteLine(weibos.Count);
            Console.WriteLine(weibos[0].User.ScreenName);
        }
    }
}