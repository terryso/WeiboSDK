using System;
using NUnit.Framework;
using WeiboSDK.Enums;

namespace WeiboSDK.UnitTests
{
    [TestFixture]
    public class StatusTests : TestBase
    {
        [Test]
        public void GetPublicWeibos_Should_Return_At_Least_One_Status()
        {
            // Arrange

            // Act
            var weibos = WeiboClient.GetPublicWeibos();

            // Assert
            Assert.IsNotNull(weibos);
            Assert.IsTrue(weibos.Count > 0);
            Assert.IsTrue(weibos.Count <= 20);

            Console.WriteLine(weibos.Count);
            Console.WriteLine(weibos[0].Text);
        }

        [Test]
        public void GetPublicWeibos_Can_Get_200_Weibos_At_Most()
        {
            // Arrange

            // Act
            var weibos = WeiboClient.GetPublicWeibos(200);

            // Assert
            Assert.IsNotNull(weibos);
            Assert.IsTrue(weibos.Count > 0);
            Assert.IsTrue(weibos.Count <= 200);

            Console.WriteLine(weibos.Count);
            Console.WriteLine(weibos[0].Text);
        }

        [Test]
        public void GetFriendsWeibos_Should_Return_At_Least_One_Weibo()
        {
            // Arrange

            // Act
            var weibos = WeiboClient.GetFriendsWeibos(-1, -1, null, null, Feature.All);

            // Assert
            Assert.IsNotNull(weibos);
            Assert.IsTrue(weibos.Count > 0);

            Console.WriteLine(weibos.Count);
            Console.WriteLine(weibos[0].Text);
        }
    }
}