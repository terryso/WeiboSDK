using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.Sina;

namespace WeiboSDK.Request.Sina
{
    /// <summary>
    /// 发布一条微博信息请求。也可以同时转发某条微博。
    /// 对应API：http://open.weibo.com/wiki/index.php/Statuses/update
    /// </summary>
    public class SinaStatusUpdateRequest : SinaRequestBase, IWeiboRequest<SinaStatusResponse>
    {
        public SinaStatusUpdateRequest(string status)
        {
            Status = status;
        }

        /// <summary>
        /// 要发布的微博消息文本内容
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// 要转发的微博消息ID。 
        /// </summary>
        public long? InReplyToStatusId { get; set; }

        /// <summary>
        /// 纬度。有效范围：-90.0到+90.0，+表示北纬。
        /// </summary>
        public float? Lat { get; set; }

        /// <summary>
        /// 经度。有效范围：-180.0到+180.0，+表示东经。
        /// </summary>
        public float? Long { get; set; }

        /// <summary>
        /// 元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息。
        /// 每条微博可以包含一个或者多个元数据。请以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。
        /// </summary>
        public string Annotations { get; set; }

        #region IWeiboRequest<SinaStatusResponse> Members

        public string Url
        {
            get { return "http://api.t.sina.com.cn/statuses/update."; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary
                {
                    {"status", Status},
                    {"in_reply_to_status_id", InReplyToStatusId},
                    {"lat", Lat},
                    {"long", Long},
                    {"annotations", Annotations}
                };

                return dict;
            }
        }

        #endregion
    }
}