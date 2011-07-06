using System.Configuration;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Contracts;
using WeiboSDK.Enums;
using WeiboSDK.Factories;

namespace WeiboSDK.UnitTests.Sina
{
    public abstract class SinaTestBase
    {
        protected IWeiboClient WeiboClient;

        protected SinaTestBase()
        {
            var accessToken = new AccessToken(ConsumerFactory.SinaConsumer, ConfigurationManager.AppSettings["SinaAccessToken"], ConfigurationManager.AppSettings["SinaAccessTokenSecret"]);
            WeiboClient = new WeiboClient(accessToken, ResultFormat.json);
        }
    }
}