﻿#region using

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Newtonsoft.Json;
using WeiboSDK.Extensions;

#endregion

namespace WeiboSDK.Entities
{
    /// <summary>
    ///     表示新浪微博用户信息。
    /// </summary>
    [Serializable]
    [JsonObject("user")]
    public class User
    {
        private string _city;
        private string _province;

        /// <summary>
        ///     获取或设置当前用户信息的ID。
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的昵称。
        /// </summary>
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的友好显示名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的省份编码。
        /// </summary>
        [JsonProperty("province")]
        public int? ProvinceId { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的城市编码。
        /// </summary>
        [JsonProperty("city")]
        public int? CityId { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的地址。
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的个人描述。
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的博客地址。
        /// </summary>
        [JsonProperty("url")]
        public string BlogUrl { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的自定义头像图片地址。
        /// </summary>
        [JsonProperty("profile_image_url")]
        public string ProfileImage { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的自定义微博地址域名。
        /// </summary>
        [JsonProperty("domain")]
        public string ProfileDomain { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的性别。
        /// </summary>
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的粉丝数量。
        /// </summary>
        [JsonProperty("followers_count")]
        public long? FollowerCount { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的关注数量。
        /// </summary>
        [JsonProperty("friends_count")]
        public long? FriendCount { get; set; }

        /// <summary>
        ///     获取或设置当前用户发布的新浪微博的数量。
        /// </summary>
        [JsonProperty("statuses_count")]
        public long? StatusCount { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的创建时间。
        /// </summary>
        [JsonProperty("created_at"), JsonConverter(typeof (JsonDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息的收藏数量。
        /// </summary>
        [JsonProperty("favourites_count")]
        public long? FavouriteCount { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息是否被当前登录用户关注。
        /// </summary>
        [JsonProperty("following")]
        public bool IsFollowing { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息是否通过认证。
        /// </summary>
        [JsonProperty("verified")]
        public bool IsVerified { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息是否allow_all_act_msg。
        /// </summary>
        [JsonProperty("allow_all_act_msg")]
        public bool IsAllowAllActMessage { get; set; }

        /// <summary>
        ///     获取或设置当前用户信息是否启用了地理位置。
        /// </summary>
        [JsonProperty("geo_enabled")]
        public bool IsGeoEnabled { get; set; }

        /// <summary>
        ///     获取当前用户信息的省份名称。
        /// </summary>
        public string Province
        {
            get { return _province ?? (_province = UserHelper.GetProvince(ProvinceId)); }
        }

        /// <summary>
        ///     获取当前用户信息的城市名称。
        /// </summary>
        public string City
        {
            get
            {
                if (_city == null)
                    _city = UserHelper.GetCity(ProvinceId, CityId);

                return _city;
            }
        }

        /// <summary>
        ///     返回当前用户的昵称。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ScreenName;
        }
    }

    /// <summary>
    ///     表示性别。
    /// </summary>
    public enum Gender
    {
        /// <summary>
        ///     表示男性。
        /// </summary>
        M,

        /// <summary>
        ///     表示女性。
        /// </summary>
        F,

        /// <summary>
        ///     表示性别未知。
        /// </summary>
        N
    }

    /// <summary>
    ///     用户信息辅助类。
    /// </summary>
    public static class UserHelper
    {
        /// <summary>
        ///     表示省份城市XML文件路径。
        /// </summary>
        private static readonly string ProvinceXmlFile = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase),
            "provinces.xml");

        public static string GetUserHomeUrl(object domain, string id)
        {
            const string baseUri = "http://t.sina.com.cn/";
            return domain != null && domain.ToString().IsNotNullOrEmpty() ? baseUri + domain : baseUri + id;
        }

        public static string GetGenderName(string gender)
        {
            switch (gender)
            {
                case "M":
                    return "男";
                case "F":
                    return "女";
                default:
                    return "未知";
            }
        }

        /// <summary>
        ///     获取省份名称。
        /// </summary>
        /// <param name = "provinceId">用户信息的省份ID。</param>
        /// <returns></returns>
        public static string GetProvince(int? provinceId)
        {
            if (!provinceId.HasValue)
                return string.Empty;

            return (from x in XElement.Parse(ProviceXML).Elements("province")
                    where Convert.ToInt32(x.Attribute("id").Value) == provinceId.Value
                    select x.Attribute("name").Value).FirstOrDefault();
        }

        /// <summary>
        ///     获取城市名称。
        /// </summary>
        /// <param name = "provinceId">用户信息的省份ID。</param>
        /// <param name = "cityId">用户信息的城市ID。</param>
        /// <returns></returns>
        public static string GetCity(int? provinceId, int? cityId)
        {
            if (!provinceId.HasValue || !cityId.HasValue)
                return string.Empty;

            return (from cx in
                        (from x in XElement.Parse(ProviceXML).Elements("province")
                         where Convert.ToInt32(x.Attribute("id").Value) == provinceId.Value
                         select x).Elements("city")
                    where Convert.ToInt32(cx.Attribute("id").Value) == cityId.Value
                    select cx.Attribute("name").Value).FirstOrDefault();
        }

        private static string ProviceXML =
            @"<?xml version='1.0' encoding='utf-8' ?>
<provinces>
  <province id='11' name='北京'>
    <city id='1' name='东城区'/>
    <city id='2' name='西城区'/>
    <city id='3' name='崇文区'/>
    <city id='4' name='宣武区'/>
    <city id='5' name='朝阳区'/>
    <city id='6' name='丰台区'/>
    <city id='7' name='石景山区'/>
    <city id='8' name='海淀区'/>
    <city id='9' name='门头沟区'/>
    <city id='11' name='房山区'/>
    <city id='12' name='通州区'/>
    <city id='13' name='顺义区'/>
    <city id='14' name='昌平区'/>
    <city id='15' name='大兴区'/>
    <city id='16' name='怀柔区'/>
    <city id='17' name='平谷区'/>
    <city id='28' name='密云县'/>
    <city id='29' name='延庆县'/>
  </province>
  <province id='12' name='天津'>
    <city id='1' name='和平区'/>
    <city id='2' name='河东区'/>
    <city id='3' name='河西区'/>
    <city id='4' name='南开区'/>
    <city id='5' name='河北区'/>
    <city id='6' name='红桥区'/>
    <city id='7' name='塘沽区'/>
    <city id='8' name='汉沽区'/>
    <city id='9' name='大港区'/>
    <city id='10' name='东丽区'/>
    <city id='11' name='西青区'/>
    <city id='12' name='津南区'/>
    <city id='13' name='北辰区'/>
    <city id='14' name='武清区'/>
    <city id='15' name='宝坻区'/>
    <city id='21' name='宁河县'/>
    <city id='23' name='静海县'/>
    <city id='25' name='蓟县'/>
  </province>
  <province id='13' name='河北'>
    <city id='1' name='石家庄'/>
    <city id='2' name='唐山'/>
    <city id='3' name='秦皇岛'/>
    <city id='4' name='邯郸'/>
    <city id='5' name='邢台'/>
    <city id='6' name='保定'/>
    <city id='7' name='张家口'/>
    <city id='8' name='承德'/>
    <city id='9' name='沧州'/>
    <city id='10' name='廊坊'/>
    <city id='11' name='衡水'/>
  </province>
  <province id='14' name='山西'>
    <city id='1' name='太原'/>
    <city id='2' name='大同'/>
    <city id='3' name='阳泉'/>
    <city id='4' name='长治'/>
    <city id='5' name='晋城'/>
    <city id='6' name='朔州'/>
    <city id='7' name='晋中'/>
    <city id='8' name='运城'/>
    <city id='9' name='忻州'/>
    <city id='10' name='临汾'/>
    <city id='23' name='吕梁'/>
  </province>
  <province id='15' name='内蒙古'>
    <city id='1' name='呼和浩特'/>
    <city id='2' name='包头'/>
    <city id='3' name='乌海'/>
    <city id='4' name='赤峰'/>
    <city id='5' name='通辽'/>
    <city id='6' name='鄂尔多斯'/>
    <city id='7' name='呼伦贝尔'/>
    <city id='22' name='兴安盟'/>
    <city id='25' name='锡林郭勒盟'/>
    <city id='26' name='乌兰察布盟'/>
    <city id='28' name='巴彦淖尔盟'/>
    <city id='29' name='阿拉善盟'/>
  </province>
  <province id='21' name='辽宁'>
    <city id='1' name='沈阳'/>
    <city id='2' name='大连'/>
    <city id='3' name='鞍山'/>
    <city id='4' name='抚顺'/>
    <city id='5' name='本溪'/>
    <city id='6' name='丹东'/>
    <city id='7' name='锦州'/>
    <city id='8' name='营口'/>
    <city id='9' name='阜新'/>
    <city id='10' name='辽阳'/>
    <city id='11' name='盘锦'/>
    <city id='12' name='铁岭'/>
    <city id='13' name='朝阳'/>
    <city id='14' name='葫芦岛'/>
  </province>
  <province id='22' name='吉林'>
    <city id='1' name='长春'/>
    <city id='2' name='吉林'/>
    <city id='3' name='四平'/>
    <city id='4' name='辽源'/>
    <city id='5' name='通化'/>
    <city id='6' name='白山'/>
    <city id='7' name='松原'/>
    <city id='8' name='白城'/>
    <city id='24' name='延边朝鲜族自治州'/>
  </province>
  <province id='23' name='黑龙江'>
    <city id='1' name='哈尔滨'/>
    <city id='2' name='齐齐哈尔'/>
    <city id='3' name='鸡西'/>
    <city id='4' name='鹤岗'/>
    <city id='5' name='双鸭山'/>
    <city id='6' name='大庆'/>
    <city id='7' name='伊春'/>
    <city id='8' name='佳木斯'/>
    <city id='9' name='七台河'/>
    <city id='10' name='牡丹江'/>
    <city id='11' name='黑河'/>
    <city id='12' name='绥化'/>
    <city id='27' name='大兴安岭'/>
  </province>
  <province id='31' name='上海'>
    <city id='1' name='黄浦区'/>
    <city id='3' name='卢湾区'/>
    <city id='4' name='徐汇区'/>
    <city id='5' name='长宁区'/>
    <city id='6' name='静安区'/>
    <city id='7' name='普陀区'/>
    <city id='8' name='闸北区'/>
    <city id='9' name='虹口区'/>
    <city id='10' name='杨浦区'/>
    <city id='12' name='闵行区'/>
    <city id='13' name='宝山区'/>
    <city id='14' name='嘉定区'/>
    <city id='15' name='浦东新区'/>
    <city id='16' name='金山区'/>
    <city id='17' name='松江区'/>
    <city id='18' name='青浦区'/>
    <city id='19' name='南汇区'/>
    <city id='20' name='奉贤区'/>
    <city id='30' name='崇明县'/>
  </province>
  <province id='32' name='江苏'>
    <city id='1' name='南京'/>
    <city id='2' name='无锡'/>
    <city id='3' name='徐州'/>
    <city id='4' name='常州'/>
    <city id='5' name='苏州'/>
    <city id='6' name='南通'/>
    <city id='7' name='连云港'/>
    <city id='8' name='淮安'/>
    <city id='9' name='盐城'/>
    <city id='10' name='扬州'/>
    <city id='11' name='镇江'/>
    <city id='12' name='泰州'/>
    <city id='13' name='宿迁'/>
  </province>
  <province id='33' name='浙江'>
    <city id='1' name='杭州'/>
    <city id='2' name='宁波'/>
    <city id='3' name='温州'/>
    <city id='4' name='嘉兴'/>
    <city id='5' name='湖州'/>
    <city id='6' name='绍兴'/>
    <city id='7' name='金华'/>
    <city id='8' name='衢州'/>
    <city id='9' name='舟山'/>
    <city id='10' name='台州'/>
    <city id='11' name='丽水'/>
  </province>
  <province id='34' name='安徽'>
    <city id='1' name='合肥'/>
    <city id='2' name='芜湖'/>
    <city id='3' name='蚌埠'/>
    <city id='4' name='淮南'/>
    <city id='5' name='马鞍山'/>
    <city id='6' name='淮北'/>
    <city id='7' name='铜陵'/>
    <city id='8' name='安庆'/>
    <city id='10' name='黄山'/>
    <city id='11' name='滁州'/>
    <city id='12' name='阜阳'/>
    <city id='13' name='宿州'/>
    <city id='14' name='巢湖'/>
    <city id='15' name='六安'/>
    <city id='16' name='亳州'/>
    <city id='17' name='池州'/>
    <city id='18' name='宣城'/>
  </province>
  <province id='35' name='福建'>
    <city id='1' name='福州'/>
    <city id='2' name='厦门'/>
    <city id='3' name='莆田'/>
    <city id='4' name='三明'/>
    <city id='5' name='泉州'/>
    <city id='6' name='漳州'/>
    <city id='7' name='南平'/>
    <city id='8' name='龙岩'/>
    <city id='9' name='宁德'/>
  </province>
  <province id='36' name='江西'>
    <city id='1' name='南昌'/>
    <city id='2' name='景德镇'/>
    <city id='3' name='萍乡'/>
    <city id='4' name='九江'/>
    <city id='5' name='新余'/>
    <city id='6' name='鹰潭'/>
    <city id='7' name='赣州'/>
    <city id='8' name='吉安'/>
    <city id='9' name='宜春'/>
    <city id='10' name='抚州'/>
    <city id='11' name='上饶'/>
  </province>
  <province id='37' name='山东'>
    <city id='1' name='济南'/>
    <city id='2' name='青岛'/>
    <city id='3' name='淄博'/>
    <city id='4' name='枣庄'/>
    <city id='5' name='东营'/>
    <city id='6' name='烟台'/>
    <city id='7' name='潍坊'/>
    <city id='8' name='济宁'/>
    <city id='9' name='泰安'/>
    <city id='10' name='威海'/>
    <city id='11' name='日照'/>
    <city id='12' name='莱芜'/>
    <city id='13' name='临沂'/>
    <city id='14' name='德州'/>
    <city id='15' name='聊城'/>
    <city id='16' name='滨州'/>
    <city id='17' name='菏泽'/>
  </province>
  <province id='41' name='河南'>
    <city id='1' name='郑州'/>
    <city id='2' name='开封'/>
    <city id='3' name='洛阳'/>
    <city id='4' name='平顶山'/>
    <city id='5' name='安阳'/>
    <city id='6' name='鹤壁'/>
    <city id='7' name='新乡'/>
    <city id='8' name='焦作'/>
    <city id='9' name='濮阳'/>
    <city id='10' name='许昌'/>
    <city id='11' name='漯河'/>
    <city id='12' name='三门峡'/>
    <city id='13' name='南阳'/>
    <city id='14' name='商丘'/>
    <city id='15' name='信阳'/>
    <city id='16' name='周口'/>
    <city id='17' name='驻马店'/>
  </province>
  <province id='42' name='湖北'>
    <city id='1' name='武汉'/>
    <city id='2' name='黄石'/>
    <city id='3' name='十堰'/>
    <city id='5' name='宜昌'/>
    <city id='6' name='襄樊'/>
    <city id='7' name='鄂州'/>
    <city id='8' name='荆门'/>
    <city id='9' name='孝感'/>
    <city id='10' name='荆州'/>
    <city id='11' name='黄冈'/>
    <city id='12' name='咸宁'/>
    <city id='13' name='随州'/>
    <city id='28' name='恩施土家族苗族自治州'/>
  </province>
  <province id='43' name='湖南'>
    <city id='1' name='长沙'/>
    <city id='2' name='株洲'/>
    <city id='3' name='湘潭'/>
    <city id='4' name='衡阳'/>
    <city id='5' name='邵阳'/>
    <city id='6' name='岳阳'/>
    <city id='7' name='常德'/>
    <city id='8' name='张家界'/>
    <city id='9' name='益阳'/>
    <city id='10' name='郴州'/>
    <city id='11' name='永州'/>
    <city id='12' name='怀化'/>
    <city id='13' name='娄底'/>
    <city id='31' name='湘西土家族苗族自治州'/>
  </province>
  <province id='44' name='广东'>
    <city id='1' name='广州'/>
    <city id='2' name='韶关'/>
    <city id='3' name='深圳'/>
    <city id='4' name='珠海'/>
    <city id='5' name='汕头'/>
    <city id='6' name='佛山'/>
    <city id='7' name='江门'/>
    <city id='8' name='湛江'/>
    <city id='9' name='茂名'/>
    <city id='12' name='肇庆'/>
    <city id='13' name='惠州'/>
    <city id='14' name='梅州'/>
    <city id='15' name='汕尾'/>
    <city id='16' name='河源'/>
    <city id='17' name='阳江'/>
    <city id='18' name='清远'/>
    <city id='19' name='东莞'/>
    <city id='20' name='中山'/>
    <city id='51' name='潮州'/>
    <city id='52' name='揭阳'/>
    <city id='53' name='云浮'/>
  </province>
  <province id='45' name='广西'>
    <city id='1' name='南宁'/>
    <city id='2' name='柳州'/>
    <city id='3' name='桂林'/>
    <city id='4' name='梧州'/>
    <city id='5' name='北海'/>
    <city id='6' name='防城港'/>
    <city id='7' name='钦州'/>
    <city id='8' name='贵港'/>
    <city id='9' name='玉林'/>
    <city id='10' name='百色'/>
    <city id='11' name='贺州'/>
    <city id='12' name='河池'/>
    <city id='21' name='南宁'/>
    <city id='22' name='柳州'/>
  </province>
  <province id='46' name='海南'>
    <city id='1' name='海口'/>
    <city id='2' name='三亚'/>
    <city id='90' name='其他'/>
  </province>
  <province id='50' name='重庆'>
    <city id='1' name='万州区'/>
    <city id='2' name='涪陵区'/>
    <city id='3' name='渝中区'/>
    <city id='4' name='大渡口区'/>
    <city id='5' name='江北区'/>
    <city id='6' name='沙坪坝区'/>
    <city id='7' name='九龙坡区'/>
    <city id='8' name='南岸区'/>
    <city id='9' name='北碚区'/>
    <city id='10' name='万盛区'/>
    <city id='11' name='双桥区'/>
    <city id='12' name='渝北区'/>
    <city id='13' name='巴南区'/>
    <city id='14' name='黔江区'/>
    <city id='15' name='长寿区'/>
    <city id='22' name='綦江县'/>
    <city id='23' name='潼南县'/>
    <city id='24' name='铜梁县'/>
    <city id='25' name='大足县'/>
    <city id='26' name='荣昌县'/>
    <city id='27' name='璧山县'/>
    <city id='28' name='梁平县'/>
    <city id='29' name='城口县'/>
    <city id='30' name='丰都县'/>
    <city id='31' name='垫江县'/>
    <city id='32' name='武隆县'/>
    <city id='33' name='忠县'/>
    <city id='34' name='开县'/>
    <city id='35' name='云阳县'/>
    <city id='36' name='奉节县'/>
    <city id='37' name='巫山县'/>
    <city id='38' name='巫溪县'/>
    <city id='40' name='石柱土家族自治县'/>
    <city id='41' name='秀山土家族苗族自治县'/>
    <city id='42' name='酉阳土家族苗族自治县'/>
    <city id='43' name='彭水苗族土家族自治县'/>
    <city id='81' name='江津市'/>
    <city id='82' name='合川市'/>
    <city id='83' name='永川市'/>
    <city id='84' name='南川市'/>
  </province>
  <province id='51' name='四川'>
    <city id='1' name='成都'/>
    <city id='3' name='自贡'/>
    <city id='4' name='攀枝花'/>
    <city id='5' name='泸州'/>
    <city id='6' name='德阳'/>
    <city id='7' name='绵阳'/>
    <city id='8' name='广元'/>
    <city id='9' name='遂宁'/>
    <city id='10' name='内江'/>
    <city id='11' name='乐山'/>
    <city id='13' name='南充'/>
    <city id='14' name='眉山'/>
    <city id='15' name='宜宾'/>
    <city id='16' name='广安'/>
    <city id='17' name='达州'/>
    <city id='18' name='雅安'/>
    <city id='19' name='巴中'/>
    <city id='20' name='资阳'/>
    <city id='32' name='阿坝'/>
    <city id='33' name='甘孜'/>
    <city id='34' name='凉山'/>
  </province>
  <province id='52' name='贵州'>
    <city id='1' name='贵阳'/>
    <city id='2' name='六盘水'/>
    <city id='3' name='遵义'/>
    <city id='4' name='安顺'/>
    <city id='22' name='铜仁'/>
    <city id='23' name='黔西南'/>
    <city id='24' name='毕节'/>
    <city id='26' name='黔东南'/>
    <city id='27' name='黔南'/>
  </province>
  <province id='53' name='云南'>
    <city id='1' name='昆明'/>
    <city id='3' name='曲靖'/>
    <city id='4' name='玉溪'/>
    <city id='5' name='保山'/>
    <city id='6' name='昭通'/>
    <city id='23' name='楚雄'/>
    <city id='25' name='红河'/>
    <city id='26' name='文山'/>
    <city id='27' name='思茅'/>
    <city id='28' name='西双版纳'/>
    <city id='29' name='大理'/>
    <city id='31' name='德宏'/>
    <city id='32' name='丽江'/>
    <city id='33' name='怒江'/>
    <city id='34' name='迪庆'/>
    <city id='35' name='临沧'/>
  </province>
  <province id='54' name='西藏'>
    <city id='1' name='拉萨'/>
    <city id='21' name='昌都'/>
    <city id='22' name='山南'/>
    <city id='23' name='日喀则'/>
    <city id='24' name='那曲'/>
    <city id='25' name='阿里'/>
    <city id='26' name='林芝'/>
  </province>
  <province id='61' name='陕西'>
    <city id='1' name='西安'/>
    <city id='2' name='铜川'/>
    <city id='3' name='宝鸡'/>
    <city id='4' name='咸阳'/>
    <city id='5' name='渭南'/>
    <city id='6' name='延安'/>
    <city id='7' name='汉中'/>
    <city id='8' name='榆林'/>
    <city id='9' name='安康'/>
    <city id='10' name='商洛'/>
  </province>
  <province id='62' name='甘肃'>
    <city id='1' name='兰州'/>
    <city id='2' name='嘉峪关'/>
    <city id='3' name='金昌'/>
    <city id='4' name='白银'/>
    <city id='5' name='天水'/>
    <city id='6' name='武威'/>
    <city id='7' name='张掖'/>
    <city id='8' name='平凉'/>
    <city id='9' name='酒泉'/>
    <city id='10' name='庆阳'/>
    <city id='24' name='定西'/>
    <city id='26' name='陇南'/>
    <city id='29' name='临夏'/>
    <city id='30' name='甘南'/>
  </province>
  <province id='63' name='青海'>
    <city id='1' name='西宁'/>
    <city id='21' name='海东'/>
    <city id='22' name='海北'/>
    <city id='23' name='黄南'/>
    <city id='25' name='海南'/>
    <city id='26' name='果洛'/>
    <city id='27' name='玉树'/>
    <city id='28' name='海西'/>
  </province>
  <province id='64' name='宁夏'>
    <city id='1' name='银川'/>
    <city id='2' name='石嘴山'/>
    <city id='3' name='吴忠'/>
    <city id='4' name='固原'/>
  </province>
  <province id='65' name='新疆'>
    <city id='1' name='乌鲁木齐'/>
    <city id='2' name='克拉玛依'/>
    <city id='21' name='吐鲁番'/>
    <city id='22' name='哈密'/>
    <city id='23' name='昌吉'/>
    <city id='27' name='博尔塔拉'/>
    <city id='28' name='巴音郭楞'/>
    <city id='29' name='阿克苏'/>
    <city id='30' name='克孜勒苏'/>
    <city id='31' name='喀什'/>
    <city id='32' name='和田'/>
    <city id='40' name='伊犁'/>
    <city id='42' name='塔城'/>
    <city id='43' name='阿勒泰'/>
  </province>
  <province id='71' name='台湾'>
    <city id='1' name='台北'/>
    <city id='2' name='高雄'/>
    <city id='90' name='其他'/>
  </province>
  <province id='81' name='香港'>
    <city id='1' name='香港'/>
  </province>
  <province id='82' name='澳门'>
    <city id='1' name='澳门'/>
  </province>
  <province id='100' name='其他'>
  </province>
  <province id='400' name='海外'>
    <city id='1' name='美国'/>
    <city id='2' name='英国'/>
    <city id='3' name='法国'/>
    <city id='4' name='俄罗斯'/>
    <city id='5' name='加拿大'/>
    <city id='6' name='巴西'/>
    <city id='7' name='澳大利亚'/>
    <city id='8' name='印尼'/>
    <city id='9' name='泰国'/>
    <city id='10' name='马来西亚'/>
    <city id='11' name='新加坡'/>
    <city id='12' name='菲律宾'/>
    <city id='13' name='越南'/>
    <city id='14' name='印度'/>
    <city id='15' name='日本'/>
    <city id='16' name='其他'/>
  </province>
</provinces>";
    }
}