using WeiboSDK.Contracts;
using WeiboSDK.Entities.Sina;
using WeiboSDK.Extensions;

namespace WeiboSDK.Response.Sina
{
    public class SinaCommentResponse : SinaResponse, IWeiboResponse
    {
        public SinaComment Comment { get; set; }

        #region IWeiboResponse Members

        public void ConvertFrom(string json)
        {
            Comment = json.ReadJsonContent<SinaComment>();
        }

        #endregion
    }
}