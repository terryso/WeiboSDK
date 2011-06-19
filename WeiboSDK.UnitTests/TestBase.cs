using System.Configuration;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Contracts;

namespace WeiboSDK.UnitTests
{
    public abstract class TestBase
    {
        protected IWeiboClient WeiboClient;

        protected TestBase()
        {
            var accessToken = new AccessToken(Global.Consumer, ConfigurationManager.AppSettings["AccessToken"], ConfigurationManager.AppSettings["AccessTokenSecret"]);
            WeiboClient = new WeiboClient(accessToken, ResultFormat.json);
        }
    }
}