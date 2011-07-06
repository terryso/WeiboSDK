using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.QQ;

namespace WeiboSDK.Request.QQ
{
    /// <summary>
    /// 发表一条带图片的微博请求
    /// 对应API：http://open.t.qq.com/api/t/add_pic
    /// </summary>
    public class QQStatusAddWithPicRequest : QQRequestBase, IUploadRequest<QQStatusPostResponse>
    {
        public QQStatusAddWithPicRequest(string content, string pic)
        {
            Content = content;
            Pic = pic;
        }

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

        /// <summary>
        /// 图片
        /// </summary>
        public string Pic { get; private set; }

        #region IUploadRequest<QQStatusPostResponse> Members

        public string Url
        {
            get { return "http://open.t.qq.com/api/t/add_pic"; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary
                {
                    {"content", Content},
                    {"clientip", ClientIp},
                    {"jing", Jing},
                    {"wei", Wei}
                };

                return dict;
            }
        }

        /// <summary>
        /// 获取所有的Key-Value形式的文件请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 文件路径
        /// </summary>
        /// <returns>文件请求参数字典</returns>
        public IDictionary<string, string> FileParameters
        {
            get
            {
                var dict = new WeiboDictionary {{"pic", Pic}};

                return dict;
            }
        }

        #endregion
    }
}