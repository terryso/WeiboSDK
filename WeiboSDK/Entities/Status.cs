#region using

using System;
using Newtonsoft.Json;
using WeiboSDK.Extensions;

#endregion

namespace WeiboSDK.Entities
{
    /// <summary>
    ///     表示新浪微博信息内容。
    /// </summary>
    [Serializable]
    [JsonObject("status")]
    public class Status
    {
        /// <summary>
        ///     获取或设置这条新浪微博信息的创建时间。
        /// </summary>
        [JsonProperty("created_at"), JsonConverter(typeof (JsonDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息的 ID。
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息的内容。
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息的发布来源。
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息是否已被当前登录用户加入收藏。
        /// </summary>
        [JsonProperty("favorited")]
        public bool IsFavorited { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息是否被截断。
        /// </summary>
        [JsonProperty("truncated")]
        public bool IsTruncated { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息回复的新浪微博信息的ID。
        /// </summary>
        [JsonProperty("in_reply_to_status_id")]
        public long? ReplyToStatusId { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息回复的用户ID。
        /// </summary>
        [JsonProperty("in_reply_to_user_id")]
        public long? ReplyToUserId { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息回复的用户昵称。
        /// </summary>
        [JsonProperty("in_reply_to_screen_name")]
        public string ReplyToUserScreenName { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息的缩略图地址。
        /// </summary>
        [JsonProperty("thumbnail_pic")]
        public string ImageThumbnail { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息的中型图地址。
        /// </summary>
        [JsonProperty("bmiddle_pic")]
        public string ImageMiddleSize { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息的原图地址。
        /// </summary>
        [JsonProperty("original_pic")]
        public string ImageOriginal { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息的发布者用户信息。
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        ///     获取或设置这条新浪微博信息转发的新浪微博内容。
        /// </summary>
        [JsonProperty("retweeted_status")]
        public Status RetweetedStatus { get; set; }

        public string ImageLink
        {
            get
            {
                if (ImageThumbnail.IsNullOrEmpty() || ImageOriginal.IsNullOrEmpty())
                {
                    return string.Empty;
                }
                return "<a href='{1}' target='_blank'><img src='{0}' border='0' /></a>".FormatWith(ImageThumbnail,
                                                                                                   ImageOriginal);
            }
        }

        /// <summary>
        ///     返回这条新浪微博的内容。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}