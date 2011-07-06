using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Response.Sina;

namespace WeiboSDK.Request.Sina
{
    /// <summary>
    /// 发表图片微博消息请求。
    /// 对应API：http://open.weibo.com/wiki/index.php/Statuses/upload
    /// </summary>
    public class SinaStatusUploadRequest : SinaRequestBase, IUploadRequest<SinaStatusResponse>
    {
        public SinaStatusUploadRequest(string status, string pic)
        {
            Status = status;
            Pic = pic;
        }

        /// <summary>
        /// 要发布的微博消息文本内容
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// 要上传的图片。仅支持JPEG,GIF,PNG图片,为空返回400错误。目前上传图片大小限制为小于5M。
        /// </summary>
        public string Pic { get; private set; }

        /// <summary>
        /// 纬度。有效范围：-90.0到+90.0，+表示北纬。
        /// </summary>
        public float? Lat { get; set; }

        /// <summary>
        /// 经度。有效范围：-180.0到+180.0，+表示东经。
        /// </summary>
        public float? Long { get; set; }

        #region IUploadRequest<SinaStatusResponse> Members

        public string Url
        {
            get { return "http://api.t.sina.com.cn/statuses/upload."; }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var dict = new WeiboDictionary {{"status", Status}, {"lat", Lat}, {"long", Long}};
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