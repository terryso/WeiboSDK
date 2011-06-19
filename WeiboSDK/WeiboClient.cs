#region using

using System;
using System.Collections.Generic;
using System.Web;
using SocialKit.LightRest;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Contracts;
using WeiboSDK.Entities;
using WeiboSDK.Extensions;

#endregion

namespace WeiboSDK
{
    public enum ResultFormat
    {
        json = 0,
        xml = 1
    }

    public class WeiboClient : IWeiboClient
    {
        private readonly AccessToken _accessToken;
        private readonly ResultFormat _format;
        private readonly RestClient _client;

        public WeiboClient(AccessToken accessToken) : this(accessToken, ResultFormat.json)
        {
        }

        public WeiboClient(AccessToken accessToken, ResultFormat format)
        {
            _accessToken = accessToken;
            _format = format;

            _client = new RestClient();
        }

        #region IWeiboClient Members

        /// <summary>
        ///    获取最新更新的公共微博消息
        /// </summary>
        /// <returns></returns>
        public IList<Status> GetPublicWeibos()
        {
            var request = new OAuthHttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/public_timeline.{0}".FormatWith(_format))
                                                      .Sign(_accessToken);
            return _client.Send(request).ReadJsonContent<IList<Status>>();
        }

        /// <summary>
        ///     获取指定用户发布的微博列表
        /// </summary>
        /// <param name = "screenName"></param>
        /// <returns></returns>
        public IList<Status> GetUserWeibos(string screenName)
        {
            var request = new OAuthHttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/user_timeline.{0}?screen_name={1}"
                                                    .FormatWith(_format, HttpUtility.UrlEncode(screenName)))
                                                    .Sign(_accessToken);
                              ;
            return _client.Send(request).ReadJsonContent<IList<Status>>();
        }

        public Comment Comment(string id, string cid, string comment)
        {
            var form = new HttpUrlEncodedForm().Append("id", id)
                .Append("comment", comment);

            var request = new OAuthHttpRequestMessage(
                "POST", "http://api.t.sina.com.cn/statuses/comment.{0}".FormatWith(_format),
                form).Sign(_accessToken);

            return _client.Send(request).ReadJsonContent<Comment>();
        }

        /// <summary>
        ///     获取我发出的评论
        /// </summary>
        /// <returns></returns>
        public IList<Comment> GetMyComments()
        {
            var request = new OAuthHttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/comments_by_me.{0}".FormatWith(_format))
                                                      .Sign(_accessToken);
            return _client.Send(request).ReadJsonContent<IList<Comment>>();
        }

        /// <summary>
        ///     删除指定Id的评论
        /// </summary>
        /// <param name = "id"></param>
        /// <returns></returns>
        public Comment DestoryComment(string id)
        {
            var form = new HttpUrlEncodedForm().Append("id", id);

            var request = new OAuthHttpRequestMessage(
                "POST", "http://api.t.sina.com.cn/statuses/comment_destroy/{1}.{0}".FormatWith(_format, id),
                form).Sign(_accessToken);

            return _client.Send(request).ReadJsonContent<Comment>();
        }

        /// <summary>
        ///     获取@我的微博列表
        /// </summary>
        /// <returns></returns>
        public IList<Status> GetMyMentions(string sinceId, string page, string count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     删除指定Id的微博
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Status DestoryStatus(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     验证当前用户身份是否合法
        /// </summary>
        /// <returns></returns>
        public User VerifyCredentials()
        {
            var request = new OAuthHttpRequestMessage("GET", "http://api.t.sina.com.cn/account/verify_credentials.{0}".FormatWith(_format))
                                                      .Sign(_accessToken);

            return _client.Send(request).ReadJsonContent<User>();
        }

        /// <summary>
        ///     搜索微博(多条件组合) 
        /// </summary>
        /// <param name="q">关键字</param>
        /// <param name="filterOri">是否原创 (0为全部，5为原创，4为转发，默认0)</param>
        /// <param name="filterPic">是否含图 (0为全部，1为含图，2为不含图)</param>
        /// <param name="fuid">微博作者UID</param>
        /// <param name="province">省份ID</param>
        /// <param name="city">城市ID</param>
        /// <param name="startTime">开始时间(unix时间戳)</param>
        /// <param name="endTime">截止时间(unix时间戳)</param>
        /// <param name="page">页码(从1开始, 默认1)</param>
        /// <param name="count">每页返回的微博数，默认返回10条，最大200</param>
        /// <returns></returns>
        public IList<Status> Search(string q, string filterOri, string filterPic, string fuid, string province, string city, string startTime, string endTime, string page, string count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取单条微博的Web访问路径
        /// </summary>
        /// <param name="id">微博Id</param>
        /// <param name="userid">用户Id</param>
        /// <returns></returns>
        public string GetWeiboUrl(string id, string userid)
        {
            return "http://api.t.sina.com.cn/{1}/statuses/{0}".FormatWith(id, userid);
        }

        /// <summary>
        /// 返回用户关注列表，并返回最新微博文章
        /// </summary>
        /// <returns></returns>
        public IList<User> GetMyFriends(string screenName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发布一条微博信息
        /// </summary>
        /// <param name="status">微博</param>
        /// <returns></returns>
        public Status UpdateStatus(string status)
        {
            var form = new HttpUrlEncodedForm().Append("status", status);

            var request = new OAuthHttpRequestMessage(
                "POST", "http://api.t.sina.com.cn/statuses/update.{0}".FormatWith(_format),
                form).Sign(_accessToken);

            return _client.Send(request).ReadJsonContent<Status>();
        }

        /// <summary>
        /// 发表图片微博消息
        /// </summary>
        /// <param name="status">微博</param>
        /// <param name="pic">图片路径</param>
        /// <returns></returns>
        public Status UploadStatus(string status, string pic)
        {
            var url = "http://api.t.sina.com.cn/statuses/upload.{0}".FormatWith(_format);
            var form = new HttpMultipartMimeForm().AppendValue("status", status)
                                                  .AppendFile("pic", pic);

            var request = new OAuthHttpRequestMessage("POST", url, form).Sign(_accessToken);

            return _client.Send(request).ReadJsonContent<Status>();
        }

        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博消息
        /// </summary>
        /// <returns></returns>
        public IList<Status> GetFriendsTimeline(long sinceID)
        {
            var request = new OAuthHttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/friends_timeline.{0}?since_id={1}".FormatWith(_format, sinceID))
                                                      .Sign(_accessToken);

            return _client.Send(request).ReadJsonContent<IList<Status>>();
        }

        /// <summary>
        /// 根据微博昵称获取好友列表
        /// </summary>
        /// <param name="screenName">微博昵称</param>
        /// <returns></returns>
        public IList<User> GetFriends(string screenName)
        {
            var url = "http://api.t.sina.com.cn/statuses/friends.{0}?screen_name={1}";
            var request = new OAuthHttpRequestMessage("GET", url.FormatWith(_format, screenName)).Sign(_accessToken);

            return _client.Send(request).ReadJsonContent<IList<User>>();
        }

        #endregion
    }
}