using System.Configuration;
using SocialKit.LightRest.OAuth;

namespace WeiboSDK.UnitTests
{
    public class Global
    {
        public static Consumer Consumer = new Consumer
        {
            Key = ConfigurationManager.AppSettings["AppKey"],
            Secret = ConfigurationManager.AppSettings["AppSecret"],
            RequestTokenUri = "http://api.t.sina.com.cn/oauth/request_token",
            AuthorizeUri = "http://api.t.sina.com.cn/oauth/authorize",
            AccessTokenUri = "http://api.t.sina.com.cn/oauth/access_token"
        };
    }
}