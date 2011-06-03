#region using



#endregion

using Newtonsoft.Json;
using SocialKit.LightRest;

namespace WeiboSDK.Extensions
{
    /// <summary>
    ///     HTTP 响应消息扩展类。
    /// </summary>
    internal static class HttpResponseMessageExtensions
    {
        /// <summary>
        ///     读取 JSON 数据为指定的类型。
        /// </summary>
        /// <typeparam name = "T">要转换的类型。</typeparam>
        /// <param name = "response">HTTP 响应消息。</param>
        /// <returns></returns>
        public static T ReadJsonContent<T>(this HttpResponseMessage response)
        {
            return response == null ? default(T) : JsonConvert.DeserializeObject<T>(response.ReadContentAsString());
        }

        /// <summary>
        ///     读取 JSON 数据。
        /// </summary>
        /// <param name = "response">HTTP 响应消息。</param>
        /// <returns></returns>
        public static object ReadJsonContent(this HttpResponseMessage response)
        {
            return response == null ? null : JsonConvert.DeserializeObject(response.ReadContentAsString());
        }
    }
}