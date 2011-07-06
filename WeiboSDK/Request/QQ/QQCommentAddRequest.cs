using System;
using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.QQ;

namespace WeiboSDK.Request.QQ
{
    /// <summary>
    /// 点评一条微博请求
    /// 对应API：http://open.t.qq.com/api/t/comment
    /// </summary>
    public class QQCommentAddRequest : QQRequestBase, IWeiboRequest<QQStatusPostResponse>
    {
        /// <summary>
        /// 评论根结点（非父结点）微博ID
        /// </summary>
        public string Reid { get; private set; }

        /// <summary>
        /// 微博内容 
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 用户IP 必填项，请带上用户浏览器带过来的IP地址，否则会被消息过滤策略拒绝掉
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Jing { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Wei { get; set; }

        public QQCommentAddRequest(string reid, string content)
        {
            Reid = reid;
            Content = content;
        }

        #region IWeiboRequest<QQStatusesResponse> Members

        public string Url
        {
            get { return "http://open.t.qq.com/api/t/comment"; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary
                {
                    {"reid", Reid},
                    {"content", Content},
                    {"clientip", ClientIp},
                    {"jing", Jing},
                    {"wei", Wei}
                };

                return dict;
            }
        }

        #endregion
    }
}