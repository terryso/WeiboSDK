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
                        Key = "59261381",
                        Secret = "b8ead84f1d63e6518b6cb51d9885cb7b",
                        RequestTokenUri = "http://api.t.sina.com.cn/oauth/request_token",
                        AuthorizeUri = "http://api.t.sina.com.cn/oauth/authorize",
                        AccessTokenUri = "http://api.t.sina.com.cn/oauth/access_token"
                    };
                    break;
                case "ÌÚÑ¶Î¢²©":
                    consumer = new Consumer
                    {
                        Key = "b5853647954f4f1eaa2d647db7c828d7",
                        Secret = "3d63a9b04c5c6d8793cca0e3b38eb9a2",
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