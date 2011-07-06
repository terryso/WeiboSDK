using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.Sina;

namespace WeiboSDK.Request.Sina
{
    /// <summary>
    /// 返回用户最新发表的微博消息列表请求
    /// 对应API：http://open.weibo.com/wiki/index.php/Statuses/user_timeline
    /// </summary>
    public class SinaUserTimelineRequest : SinaRequestBase, IWeiboRequest<SinaStatusesResponse>
    {
        /// <summary>
        /// 用户ID，主要是用来区分用户ID跟微博昵称。
        /// 当微博昵称为数字导致和用户ID产生歧义，特别是当微博昵称和用户ID一样的时候，建议使用该参数
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 微博昵称，主要是用来区分用户UID跟微博昵称，当二者一样而产生歧义的时候，建议使用该参数
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// 若指定此参数，则只返回ID比since_id大（即比since_id发表时间晚的）的微博消息。
        /// </summary>
        public long? SinceId { get; set; }

        /// <summary>
        /// 若指定此参数，则返回ID小于或等于max_id的微博消息
        /// </summary>
        public long? MaxId { get; set; }

        /// <summary>
        /// 指定每页返回的记录条数。
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// 页码。注意：最多返回200条分页内容。
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 是否基于当前应用来获取数据。1为限制本应用微博，0为不做限制。
        /// </summary>
        public int? BaseApp { get; set; }

        /// <summary>
        /// 微博类型，0全部，1原创，2图片，3视频，4音乐. 返回指定类型的微博信息内容。
        /// </summary>
        public int? Feature { get; set; }

        public string Url
        {
            get { return "http://api.t.sina.com.cn/statuses/user_timeline."; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary
                {
                    {"user_id", UserId},
                    {"screen_name", ScreenName},
                    {"since_id", SinceId},
                    {"max_id", MaxId},
                    {"count", Count},
                    {"page", Page},
                    {"base_app", BaseApp},
                    {"feature", Feature}
                };

                return dict;
            }
        }
    }
}