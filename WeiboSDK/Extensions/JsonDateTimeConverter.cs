#region using

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace WeiboSDK.Extensions
{
    /// <summary>
    ///     表示自定义的日期时间转换。
    /// </summary>
    internal class JsonDateTimeConverter : CustomCreationConverter<DateTime?>
    {
        private DateTime? date;

        public override DateTime? Create(Type objectType)
        {
            return date;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType != JsonToken.String)
                throw new JsonReaderException("Unexpected date value.");

            date = ToDateTime(reader.Value.ToString());

            return date;
        }

        /// <summary>
        ///     将一个日期字符串转换成 System.DateTime 类型。
        /// </summary>
        /// <param name = "dateString">形如“Fri Jul 16 09:51:20 +0800 2010”的日期时间字符串。</param>
        /// <returns></returns>
        private static DateTime ToDateTime(string dateString)
        {
            //Fri Jul 16 09:51:20 +0800 2010
            string dayOfWeek = dateString.Substring(0, 3).Trim();
            string month = dateString.Substring(4, 3).Trim();
            string dayInMonth = dateString.Substring(8, 2).Trim();
            string time = dateString.Substring(11, 9).Trim();
            string offset = dateString.Substring(20, 5).Trim();
            string year = dateString.Substring(25, 5).Trim();
            string dateTime = string.Format("{0}-{1}-{2} {3}", dayInMonth, month, year, time);

            DateTime convertedDate = DateTime.Parse(dateTime);

            return convertedDate;
        }
    }
}