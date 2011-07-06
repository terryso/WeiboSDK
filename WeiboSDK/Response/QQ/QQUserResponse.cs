using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeiboSDK.Contracts;
using WeiboSDK.Entities.QQ;
using WeiboSDK.Extensions;

namespace WeiboSDK.Response.QQ
{
    public class QQUserResponse : QQResponse, IWeiboResponse
    {
        public QQUser User { get; set; }

        #region IWeiboResponse Members

        public void ConvertFrom(string json)
        {
            var jo = JsonConvert.DeserializeObject<JObject>(json);

            ConvertFrom(jo);

            if (Ret == "0")
                User = jo["data"].ToString().ReadJsonContent<QQUser>();
        }

        #endregion
    }
}