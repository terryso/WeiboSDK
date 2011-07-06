using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.Sina;

namespace WeiboSDK.Request.Sina
{
    /// <summary>
    /// 发表评论请求
    /// 对应API：http://open.weibo.com/wiki/index.php/Statuses/comment
    /// </summary>
    public class SinaCommentAddRequest : SinaRequestBase, IWeiboRequest<SinaCommentResponse>
    {
        /// <summary>
        /// 要评论的微博消息ID
        /// </summary>
        readonly long _id;

        /// <summary>
        /// 评论内容。必须做URLEncode,信息内容不超过140个汉字。
        /// </summary>
        readonly string _comment;

        /// <summary>
        /// 要回复的评论ID
        /// </summary>
        public long? Cid { get; set; }

        /// <summary>
        /// 1：回复中不自动加入“回复@用户名”，0：回复中自动加入“回复@用户名”.默认为0.
        /// </summary>
        public int? WithoutMention { get; set; }

        /// <summary>
        /// 当评论一条转发微博时，是否评论给原微博。0:不评论给原微博。1：评论给原微博。默认0.
        /// </summary>
        public int? CommentOri { get; set; }

        public SinaCommentAddRequest(long id, string comment)
        {
            _id = id;
            _comment = comment;
        }

        public string Url
        {
            get { return "http://api.t.sina.com.cn/statuses/comment."; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary
                {
                    {"id", _id},
                    {"comment", _comment},
                    {"cid", Cid},
                    {"without_mention", WithoutMention},
                    {"comment_ori", CommentOri}
                };

                return dict;
            }
        }
    }
}