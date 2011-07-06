using WeiboSDK.Contracts;
using WeiboSDK.Entities;
using WeiboSDK.Extensions;

namespace WeiboSDK.Response.Sina
{
    public class SinaStatusResponse : SinaResponse, IWeiboResponse
    {
        public SinaStatus Status { get; set; }

        #region IWeiboResponse Members

        public void ConvertFrom(string json)
        {
            Status = json.ReadJsonContent<SinaStatus>();
        }

        #endregion
    }
}