using System;
using Newtonsoft.Json;

namespace WeiboSDK.Entities.QQ
{
    [Serializable]
    public class QQStatus
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}