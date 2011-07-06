using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.QQ;

namespace WeiboSDK.Request.QQ
{
    /// <summary>
    /// 获取自己的详细资料请求
    /// 对应API：http://open.t.qq.com/api/user/info
    /// </summary>
    public class QQUserInfoRequest : QQRequestBase, IWeiboRequest<QQUserResponse>
    {
        #region IWeiboRequest<QQUserResponse> Members

        public string Url
        {
            get { return "http://open.t.qq.com/api/user/info"; }
        }

        public IDictionary<string, string> Parameters
        {
            get { return null; }
        }

        #endregion
    }
}