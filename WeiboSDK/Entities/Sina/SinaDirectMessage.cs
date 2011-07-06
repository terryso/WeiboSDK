#region using

using System;
using Newtonsoft.Json;
using WeiboSDK.Extensions;

#endregion

namespace WeiboSDK.Entities.Sina
{
    /// <summary>
    ///     表示新浪微博私信信息。
    /// </summary>
    [JsonObject("direct_message")]
    public class SinaDirectMessage
    {
        /// <summary>
        ///     获取或设置这条新浪微博私信信息的ID。
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的内容。
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的发信人ID。
        /// </summary>
        [JsonProperty("sender_id")]
        public long? SenderId { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的收信人ID。
        /// </summary>
        [JsonProperty("recipient_id")]
        public long? RecipientId { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的发送时间。
        /// </summary>
        [JsonProperty("created_at"), JsonConverter(typeof (JsonDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的发送人昵称。
        /// </summary>
        [JsonProperty("sender_screen_name")]
        public string SenderScreenName { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的收信人昵称。
        /// </summary>
        [JsonProperty("recipient_screen_name")]
        public string RecipientScreenName { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的发送人用户信息。
        /// </summary>
        [JsonProperty("sender")]
        public SinaUser Sender { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博私信信息的收信人用户信息。
        /// </summary>
        [JsonProperty("recipient")]
        public SinaUser Recipient { get; set; }

        /// <summary>
        ///     返回这条新浪微博私信信息的内容。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}