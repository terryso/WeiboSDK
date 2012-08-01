using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeiboSDK.Contracts;
using WeiboSDK.Entities;
using WeiboSDK.Extensions;

namespace WeiboSDK.Response.Sina
{
    public class SinaTrendsResponse : SinaResponse, IWeiboResponse
    {
        public IList<SinaStatus> Statuses { get; set; }
        public int TotalNumber { get; set; }

        #region Implementation of IWeiboResponse

        public void ConvertFrom(string json)
        {
            /*var obj = (JContainer)json.ReadJsonContent();

            var statuses = obj["statuses"];
            foreach (var status in statuses)
            {
                var id = status["id"];
                Statuses.Add(status.Value<SinaStatus>());
            }
            TotalNumber = obj["total_number"].Value<int>();*/

            var xml = JsonConvert.DeserializeXmlNode(json);


        }

        #endregion
    }
}