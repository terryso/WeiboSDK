using System.Collections.Generic;
using WeiboSDK.Contracts;
using WeiboSDK.Entities;
using WeiboSDK.Extensions;

namespace WeiboSDK.Response.Sina
{
    public class SinaStatusesResponse : SinaResponse, IWeiboResponse
    {
        public IList<SinaStatus> Statuses { get; set; }

        #region IWeiboResponse Members

        public void ConvertFrom(string json)
        {
            Statuses = json.ReadJsonContent<IList<SinaStatus>>();
        }

        #endregion
    }
}