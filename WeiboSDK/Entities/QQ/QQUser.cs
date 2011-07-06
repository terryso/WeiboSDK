using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeiboSDK.Entities.QQ
{
    [Serializable]
    public class QQUser
    {
        [JsonProperty("Uid")]
        public string Uid { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Nick")]
        public string Nick { get; set; }

        [JsonProperty("head")]
        public string Head { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        [JsonProperty("city_code")]
        public string CityCode { get; set; }

        [JsonProperty("isvip")]
        public bool IsVip { get; set; }

        [JsonProperty("isent")]
        public bool IsEnt { get; set; }

        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        [JsonProperty("verifyinfo")]
        public string Verifyinfo { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("birth_month")]
        public string BirthMonth { get; set; }

        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }

        [JsonProperty("sex")]
        public int Sex { get; set; }

        [JsonProperty("fansnum")]
        public int FansNum { get; set; }

        [JsonProperty("idolnum")]
        public int IdolNum { get; set; }

        [JsonProperty("tweetnum")]
        public int TweetNum { get; set; }

        [JsonProperty("tag")]
        public IList<QQTag> Tags { get; set; }

        [JsonProperty("edu")]
        public IList<QQEdu> Edus { get; set; }

    }
}