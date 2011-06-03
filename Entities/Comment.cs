#region using

using System;
using Newtonsoft.Json;
using WeiboSDK.Extensions;

#endregion

namespace WeiboSDK.Entities
{
    /// <summary>
    ///     表示新浪微博评论信息。
    /// </summary>
    [JsonObject("comment")]
    public class Comment
    {
        /// <summary>
        ///     获取或设置这条评论信息的ID。
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息的内容。
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息的发布来源。
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息是否被当前登录用户收藏。
        /// </summary>
        [JsonProperty("favorited")]
        public bool IsFavorited { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息是否被截断。
        /// </summary>
        [JsonProperty("truncated")]
        public bool IsTruncated { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息的创建时间。
        /// </summary>
        [JsonProperty("created_at"), JsonConverter(typeof (JsonDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息的作者用户信息。
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息评论的新浪微博内容。
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        ///     获取或设置这条评论信息所回复的评论。
        /// </summary>
        [JsonProperty("comment")]
        public Comment ReplyComment { get; set; }

        /// <summary>
        ///     返回这条评论信息的内容。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}