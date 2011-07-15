using SocialKit.LightRest.OAuth;

namespace WeiboSDK.Factories
{
    public class ConsumerFactory
    {
        public static Consumer SinaConsumer
        {
            get { return GetConsumer("ÐÂÀËÎ¢²©"); }
        }

        public static Consumer QQConsumer
        {
            get { return GetConsumer("ÌÚÑ¶Î¢²©"); }
        }

        public static Consumer GetConsumer(string weiboType)
        {
            Consumer consumer = null;
            switch (weiboType)
            {
                case "ÐÂÀËÎ¢²©":
                    consumer = new Consumer
                    {
                        Key = "ÐÂÀËÎ¢²©Key",
                        Secret = "ÐÂÀËÎ¢²©Secret",
                        RequestTokenUri = "http://api.t.sina.com.cn/oauth/request_token",
                        AuthorizeUri = "http://api.t.sina.com.cn/oauth/authorize",
                        AccessTokenUri = "http://api.t.sina.com.cn/oauth/access_token"
                    };
                    break;
                case "ÌÚÑ¶Î¢²©":
                    consumer = new Consumer
                    {
                        Key = "ÌÚÑ¶Î¢²©Key",
                        Secret = "ÌÚÑ¶Î¢²©Secret",
                        RequestTokenUri = "https://open.t.qq.com/cgi-bin/request_token",
                        AuthorizeUri = "https://open.t.qq.com/cgi-bin/authorize",
                        AccessTokenUri = "https://open.t.qq.com/cgi-bin/access_token",
                        Callback = "null"
                    };
                    break;
                default:
                    break;
            }

            return consumer;
        }
    }
}