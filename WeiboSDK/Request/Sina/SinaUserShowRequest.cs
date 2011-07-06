using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.Sina;

namespace WeiboSDK.Request.Sina
{
    /// <summary>
    /// 获取用户资料请求
    /// 对应API：http://open.weibo.com/wiki/index.php/Users/show
    /// </summary>
    public class SinaUserShowRequest : SinaRequestBase, IWeiboRequest<SinaUserResponse>
    {
        public SinaUserShowRequest(long userid)
        {
            UserId = userid;
        }

        public SinaUserShowRequest(string screenName)
        {
            ScreenName = screenName;
        }

        public long? UserId { get; set; }

        public string ScreenName { get; set; }

        #region ISinaRequest<SinaUserResponse> Members

        public string Url
        {
            get { return "http://api.t.sina.com.cn/users/show."; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary
                {
                    {"user_id", UserId}, 
                    {"screen_name", ScreenName}
                };
                return dict;
            }
        }

        #endregion
    }
}