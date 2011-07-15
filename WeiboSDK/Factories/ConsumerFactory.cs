using SocialKit.LightRest.OAuth;

namespace WeiboSDK.Factories
{
    public class ConsumerFactory
    {
        public static Consumer SinaConsumer
        {
            get { return GetConsumer("����΢��"); }
        }

        public static Consumer QQConsumer
        {
            get { return GetConsumer("��Ѷ΢��"); }
        }

        public static Consumer GetConsumer(string weiboType)
        {
            Consumer consumer = null;
            switch (weiboType)
            {
                case "����΢��":
                    consumer = new Consumer
                    {
                        Key = "����΢��Key",
                        Secret = "����΢��Secret",
                        RequestTokenUri = "http://api.t.sina.com.cn/oauth/request_token",
                        AuthorizeUri = "http://api.t.sina.com.cn/oauth/authorize",
                        AccessTokenUri = "http://api.t.sina.com.cn/oauth/access_token"
                    };
                    break;
                case "��Ѷ΢��":
                    consumer = new Consumer
                    {
                        Key = "��Ѷ΢��Key",
                        Secret = "��Ѷ΢��Secret",
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