using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeiboSDK.Contracts;
using WeiboSDK.Entities.QQ;
using WeiboSDK.Extensions;

namespace WeiboSDK.Response.QQ
{
    public class QQStatusesResponse : QQResponse, IWeiboResponse
    {
        public IList<QQStatus> Statuses { get; set; }

        #region IWeiboResponse Members

        public void ConvertFrom(string json)
        {
            var jo = JsonConvert.DeserializeObject<JObject>(json);

            ConvertFrom(jo);

            if (Ret == "0")
                Statuses = jo["data"]["info"].ToString().ReadJsonContent<IList<QQStatus>>();
        }

        #endregion
    }
}