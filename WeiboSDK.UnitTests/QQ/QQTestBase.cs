using System.Configuration;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Contracts;
using WeiboSDK.Enums;
using WeiboSDK.Factories;

namespace WeiboSDK.UnitTests.QQ
{
    public class QQTestBase
    {
        protected IWeiboClient WeiboClient;

        public QQTestBase()
        {
            var accessToken = new AccessToken(ConsumerFactory.QQConsumer, ConfigurationManager.AppSettings["QQAccessToken"], ConfigurationManager.AppSettings["QQAccessTokenSecret"]);
            WeiboClient = new WeiboClient(accessToken, ResultFormat.json);
        }
    }
}