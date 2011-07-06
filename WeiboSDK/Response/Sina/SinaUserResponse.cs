using WeiboSDK.Contracts;
using WeiboSDK.Entities.Sina;
using WeiboSDK.Extensions;

namespace WeiboSDK.Response.Sina
{
    public class SinaUserResponse : SinaResponse, IWeiboResponse
    {
        public SinaUser User { get; set; }

        #region IWeiboResponse Members

        public void ConvertFrom(string json)
        {
            User = json.ReadJsonContent<SinaUser>();
        }

        #endregion
    }
}