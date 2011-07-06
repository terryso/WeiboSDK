using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.Sina;

namespace WeiboSDK.Request.Sina
{
    /// <summary>
    /// 验证当前用户身份是否合法请求
    /// 对应API：http://open.weibo.com/wiki/index.php/Account/verify_credentials
    /// </summary>
    public class SinaVerifyCredentialsRequest : SinaRequestBase, IWeiboRequest<SinaUserResponse>
    {
        #region ISinaRequest<SinaUserResponse> Members

        public string Url
        {
            get { return "http://api.t.sina.com.cn/account/verify_credentials."; }
        }

        public IDictionary<string, string> Parameters
        {
            get { return null; }
        }

        #endregion
    }
}