using WeiboSDK.Enums;

namespace WeiboSDK.Request.QQ
{
    public abstract class QQRequestBase
    {
        public WeiboType WeiboType
        {
            get { return WeiboType.QQ; }
        }
    }
}