using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.QQ;

namespace WeiboSDK.Request.QQ
{
    /// <summary>
    /// 获取我发表时间线请求
    /// 对应API：http://open.t.qq.com/api/statuses/broadcast_timeline
    /// </summary>
    public class QQBroadcastTimelineRequest : QQRequestBase, IWeiboRequest<QQStatusesResponse>
    {
        /// <summary>
        /// 分页标识（0：第一页，1：向下翻页，2向上翻页）
        /// </summary>
        public int? PageFlag { get; set; }

        /// <summary>
        /// 本页起始时间（第一页 时填0，继续向下翻页：填上一次请求返回的最后一条记录时间）
        /// </summary>
        public string PageTime { get; set; }

        /// <summary>
        /// 每次请求记录的条数（1-100条）
        /// </summary>
        public int? ReqNum { get; set; }

        /// <summary>
        /// 第一页 时填0,继续向下翻页，填上一次请求返回的最后一条记录ID，翻页用
        /// </summary>
        public string LastId { get; set; }

        /// <summary>
        /// 拉取类型, 0x1 原创发表 0x2 转载 0x8 回复 0x10 空回 0x20 提及 0x40 点评
        /// 如需拉取多个类型请|上(0x1|0x2) 得到3，type=3即可,填零表示拉取所有类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 内容过滤 填零表示所有类型 1-带文本 2-带链接 4图片 8-带视频 0x10-带音频
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 权限标识 1 表示只显示我发表的
        /// </summary>
        public string AccessLevel { get; set; }

        #region IQQRequest<QQStatusesGetResponse> Members

        public string Url
        {
            get { return "http://open.t.qq.com/api/statuses/broadcast_timeline"; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary
                {
                    {"pageflag", PageFlag},
                    {"pagetime", PageTime},
                    {"reqnum", ReqNum},
                    {"lastid", LastId},
                    {"type", Type},
                    {"contenttype", ContentType},
                    {"accesslevel", AccessLevel}
                };

                return dict;
            }
        }

        #endregion
    }
}