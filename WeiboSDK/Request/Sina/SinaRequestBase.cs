using WeiboSDK.Enums;

namespace WeiboSDK.Request.Sina
{
    public class SinaRequestBase
    {
        public WeiboType WeiboType
        {
            get { return WeiboType.Sina; }
        }
    }
}