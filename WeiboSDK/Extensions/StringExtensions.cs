#region using



#endregion

using Newtonsoft.Json;

namespace WeiboSDK.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     读取 JSON 数据为指定的类型。
        /// </summary>
        /// <typeparam name = "T">要转换的类型。</typeparam>
        /// <param name = "response">HTTP 响应消息。</param>
        /// <returns></returns>
        public static T ReadJsonContent<T>(this string response)
        {
            return response == null ? default(T) : JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        ///     读取 JSON 数据。
        /// </summary>
        /// <param name = "response">HTTP 响应消息。</param>
        /// <returns></returns>
        public static object ReadJsonContent(this string response)
        {
            return response == null ? null : JsonConvert.DeserializeObject(response);
        }

        /// <summary>
        ///     Switches the IsNullOrEmpty to a more readable format
        /// </summary>
        /// <param name = "theString">
        ///     The the string.
        /// </param>
        /// <returns>
        ///     True if the string is null or empty
        /// </returns>
        public static bool IsNullOrEmpty(this string theString)
        {
            return string.IsNullOrEmpty(theString);
        }

        /// <summary>
        ///     Switches the IsNotNullOrEmpty to a more readable format
        /// </summary>
        /// <param name = "theString">
        ///     The the string.
        /// </param>
        /// <returns>
        ///     True if the string is not null or empty
        /// </returns>
        public static bool IsNotNullOrEmpty(this string theString)
        {
            return !string.IsNullOrEmpty(theString);
        }

        /// <summary>
        ///     Formats a string with the specified args
        /// </summary>
        /// <param name = "theString">
        ///     The the string.
        /// </param>
        /// <param name = "args">
        ///     The format args.
        /// </param>
        /// <returns>
        ///     The formatted string
        /// </returns>
        public static string FormatWith(this string theString, params object[] args)
        {
            return string.Format(theString, args);
        }
    }
}