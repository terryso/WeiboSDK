#region using

using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.Sina;

#endregion

namespace WeiboSDK.Request.Sina
{
    public class SinaTrendsRequest : SinaRequestBase, IWeiboRequest<SinaTrendsResponse>
    {
        public string Trend { get; set; }
        public int? Count { get; set; }
        public int? Page { get; set; }

        #region Implementation of IWeiboRequest<SinaStatusesResponse>

        public string Url
        {
            get { return "https://api.weibo.com/2/trends/statuses."; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary {{"trend", Trend}, {"count", Count}, {"page", Page}};
                return dict;
            }
        }

        #endregion
    }
}