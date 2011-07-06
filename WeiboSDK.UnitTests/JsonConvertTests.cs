using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Newtonsoft.Json;
using WeiboSDK.Entities.QQ;

namespace WeiboSDK.UnitTests
{
    [TestFixture]
    public class JsonConvertTests
    {
        [Test]
        public void Convert_To_QQUserGetResponse_Test()
        {
            // Arrange
            var jsonString = "{\"data\":{\"birth_day\":24,\"birth_month\":8,\"birth_year\":1985,\"city_code\":\"1\",\"country_code\":\"1\",\"edu\":null,\"email\":\"37795272@qq.com\",\"fansnum\":30,\"head\":\"http://app.qlogo.cn/mbloghead/68cbfdbf40deb5445e5e\",\"idolnum\":36,\"introduction\":\"Geeker、技术控、UC小书童。 PC遥控器作者：http://suchuayi.sinaapp.com\",\"isent\":0,\"isvip\":0,\"location\":\"广东 广州\",\"name\":\"suchuanyi\",\"nick\":\"四眼蒙面侠\",\"province_code\":\"44\",\"sex\":1,\"tag\":[{\"id\":\"3428083006598920604\",\"name\":\"上网\"},{\"id\":\"7632343735443733612\",\"name\":\"听音乐\"},{\"id\":\"16048819732071827387\",\"name\":\"K歌\"}],\"tweetnum\":46,\"verifyinfo\":\"\"},\"errcode\":0,\"msg\":\"ok\",\"ret\":0}";

            // Act
            var response = JsonConvert.DeserializeObject<JObject>(jsonString);
            var user = JsonConvert.DeserializeObject<QQUser>(response["data"].ToString());

            // Assert
            Assert.IsNotNull(user);
        }

        [Test]
        public void Convert_To_QQStatusesGetResponse_Test()
        {
            // Arrange
            var jsonString = "{\"data\":{\"hasnext\":0,\"info\":[{\"city_code\":\"\",\"count\":0,\"country_code\":\"\",\"from\":\"QQ签名\",\"fromurl\":\"QQ签名\",\"geo\":0,\"head\":\"http://app.qlogo.cn/mbloghead/68cbfdbf40deb5445e5e\",\"id\":\"47032096626287\",\"image\":null,\"isvip\":0,\"location\":\"\",\"mcount\":0,\"music\":null,\"name\":\"suchuanyi\",\"nick\":\"四眼蒙面侠\",\"origtext\":\"近期工作总结，各种入门啊。linux、mono、python、boo、nginx……\",\"province_code\":\"\",\"self\":1,\"source\":null,\"status\":0,\"text\":\"近期工作总结，各种入门啊。linux、mono、python、boo、nginx……\",\"timestamp\":1309777252,\"type\":1,\"video\":null},{\"city_code\":\"\",\"count\":0,\"country_code\":\"\",\"from\":\"QQ签名\",\"fromurl\":\"QQ签名\",\"geo\":0,\"head\":\"http://app.qlogo.cn/mbloghead/68cbfdbf40deb5445e5e\",\"id\":\"32122065744949\",\"image\":null,\"isvip\":0,\"location\":\"\",\"mcount\":0,\"music\":null,\"name\":\"suchuanyi\",\"nick\":\"四眼蒙面侠\",\"origtext\":\"近期工作总结，各种入门啊。linux、mono、python、boo、nginx……\",\"province_code\":\"\",\"self\":1,\"source\":null,\"status\":0,\"text\":\"近期工作总结，各种入门啊。linux、mono、python、boo、nginx……\",\"timestamp\":1309777162,\"type\":1,\"video\":null}],\"timestamp\":1309801497,\"totalnum\":46,\"user\":{\"suchuanyi\":\"四眼蒙面侠\"}},\"errcode\":0,\"msg\":\"ok\",\"ret\":0}";

            // Act
            var response = JsonConvert.DeserializeObject<JObject>(jsonString);

            // Assert
            Assert.IsNotNull(response);
        }
    }
}