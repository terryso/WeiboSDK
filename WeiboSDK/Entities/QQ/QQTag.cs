using System;
using Newtonsoft.Json;

namespace WeiboSDK.Entities.QQ
{
    [Serializable]
    public class QQTag
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}