using System;
using Newtonsoft.Json;

namespace WeiboSDK.Entities.QQ
{
    [Serializable]
    public class QQEdu
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("schoolid")]
        public int SchoolId { get; set; }

        [JsonProperty("departmentid")]
        public int DepartmentId { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }
    }
}