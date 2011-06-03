#region using

using System;

#endregion

namespace WeiboSDK.Extensions
{
    /// <summary>
    ///     日期时间扩展方法类。
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     表示年的格式化字符串。
        /// </summary>
        private const string YearFormat = "yyyy年";

        /// <summary>
        ///     表示月日和时间的格式化字符串。
        /// </summary>
        private const string MonthDayTimeFormat = "M月d日 H:mm";

        private const int Second = 1;
        private const int Minute = 60*Second;
        private const int Hour = 60*Minute;
        private const int Day = 24*Hour;

        /// <summary>
        ///     将一个可空日期转换成一个时间段的字符串。
        /// </summary>
        /// <param name = "dateTime">要转换的一个可空日期对象。</param>
        /// <returns></returns>
        public static string ToDuration(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return string.Empty;

            return ToDuration(dateTime.Value);
        }

        /// <summary>
        ///     将一个日期转换成一个时间段的字符串。
        /// </summary>
        /// <param name = "dateTime">要转换的日期。</param>
        /// <returns></returns>
        public static string ToDuration(this DateTime dateTime)
        {
            var span = DateTime.Now - dateTime;
            var secondsElapsedToday =
                (DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)).
                    TotalSeconds;
            var delta = span.TotalSeconds;

            if (delta < 0 || DateTime.Now.Year != dateTime.Year)
            {
                return dateTime.ToString(YearFormat + MonthDayTimeFormat);
            }
            else if (delta >= (secondsElapsedToday + 1*Day))
            {
                return "前天 " + dateTime.ToString("H:mm");
            }
            else if (delta >= secondsElapsedToday)
            {
                return "昨天 " + dateTime.ToString("H:mm");
            }
            else if (delta >= 1*Hour)
            {
                return dateTime.ToString("H:mm");
            }
            else if (delta >= 1*Minute)
            {
                return span.Minutes + " 分钟前";
            }
            else
            {
                return "刚才";
            }
        }
    }
}