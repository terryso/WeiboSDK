#region using

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using SocialKit.LightRest;
using Weibo.Contracts;
using Weibo.Entities;
using Weibo.Extensions;

#endregion

namespace Weibo
{
    public class NormalWeiboClient : IWeiboClient
    {
        private readonly ResultFormat _format;
        private readonly RestClient _client;
        private readonly string _appKey;

        public NormalWeiboClient(ResultFormat format) : this("suchuanyi@126.com", "19977934566", format)
        {
        }

        public NormalWeiboClient(string username, string password, ResultFormat format)
        {
            if (username.IsNullOrEmpty())
                throw new ArgumentNullException("username", "用户名不能为空");

            if(password.IsNullOrEmpty())
                throw new ArgumentNullException("password", "密码不能为空");

            _format = format;
            _appKey = "59261381";
            _client = new RestClient();

            var usernamePassword = username + ":" + password;
            var headers = new NameValueCollection();
            headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));

            _client.TransportSettings.Credentials = new NetworkCredential(username, password);
            _client.TransportSettings.Headers = headers;
        }

        #region IWeiboClient Members

        public IList<Status> GetPublicWeibos()
        {
            var request = new HttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/public_timeline.{0}?source={1}"
                              .FormatWith(_format, _appKey));
            return _client.Send(request).ReadJsonContent<IList<Status>>();
        }

        public IList<Status> GetUserWeibos(string screenName)
        {
            var request = new HttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/user_timeline.{0}?screen_name={2}&source={1}"
                              .FormatWith(_format, _appKey, HttpUtility.UrlEncode(screenName)));
            return _client.Send(request).ReadJsonContent<IList<Status>>();
        }

        public Comment Comment(string id, string cid, string comment)
        {
            var url = "http://api.t.sina.com.cn/statuses/comment.{0}".FormatWith(_format);
            var form = new HttpUrlEncodedForm().Append("source", _appKey).Append("id", id).Append("comment", comment);
            var request = new HttpRequestMessage("POST", url, form);
            return _client.Send(request).ReadJsonContent<Comment>();
        }

        public IList<Comment> GetMyComments()
        {
            throw new NotImplementedException();
        }

        public Comment DestoryComment(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     获取@我的微博列表
        /// </summary>
        /// <returns></returns>
        public IList<Status> GetMyMentions(string sinceId, string page, string count)
        {
            var uri = new StringBuilder("http://api.t.sina.com.cn/statuses/mentions.{0}?source={1}".FormatWith(_format, _appKey));

            if (page.IsNotNullOrEmpty())
                uri.AppendFormat("&since_id={0}", sinceId);

            if (page.IsNotNullOrEmpty())
                uri.AppendFormat("&page={0}", page);

            if (count.IsNotNullOrEmpty())
                uri.AppendFormat("&count={0}", count);

            var request = new HttpRequestMessage("GET", uri.ToString());
            return _client.Send(request).ReadJsonContent<IList<Status>>();
        }

        /// <summary>
        ///     删除指定Id的微博
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Status DestoryStatus(string id)
        {
            var request = new HttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/destroy/{2}.{0}?source={1}"
                              .FormatWith(_format, _appKey, id));
            return _client.Send(request).ReadJsonContent<Status>();
        }

        /// <summary>
        ///     验证当前用户身份是否合法
        /// </summary>
        /// <returns></returns>
        public User VerifyCredentials()
        {
            var request = new HttpRequestMessage("GET", "http://api.t.sina.com.cn/account/verify_credentials.{0}?source={1}"
                              .FormatWith(_format, _appKey));
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
            var sb = new StringBuilder("http://api.t.sina.com.cn/statuses/search.{0}?source={1}".FormatWith(_format, _appKey));

            if (q.IsNotNullOrEmpty())
                sb.AppendFormat("&q={0}", HttpUtility.UrlEncode(q));

            if (filterOri.IsNotNullOrEmpty())
                sb.AppendFormat("&filter_ori={0}", filterOri);

            if (filterPic.IsNotNullOrEmpty())
                sb.AppendFormat("&filter_pic={0}", filterPic);

            if (fuid.IsNotNullOrEmpty())
                sb.AppendFormat("&fuid={0}", fuid);

            if (province.IsNotNullOrEmpty())
                sb.AppendFormat("&province={0}", province);

            if (city.IsNotNullOrEmpty())
                sb.AppendFormat("&city={0}", city);

            if (startTime.IsNotNullOrEmpty())
                sb.AppendFormat("&starttime={0}", startTime);

            if (endTime.IsNotNullOrEmpty())
                sb.AppendFormat("&endtime={0}", endTime);

            if (page.IsNotNullOrEmpty())
                sb.AppendFormat("&page={0}", page);

            if (count.IsNotNullOrEmpty())
                sb.AppendFormat("&count={0}", count);

            var request = new HttpRequestMessage("GET", sb.ToString());

            return _client.Send(request).ReadJsonContent<IList<Status>>();
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
            var request = new HttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/friends.{0}?source={1}&screen_name={2}"
                              .FormatWith(_format, _appKey, HttpUtility.UrlEncode(screenName)));
            return _client.Send(request).ReadJsonContent<IList<User>>();
        }

        /// <summary>
        /// 发布一条微博信息
        /// </summary>
        /// <param name="status">微博</param>
        /// <returns></returns>
        public Status UpdateStatus(string status)
        {
            var url = "http://api.t.sina.com.cn/statuses/update.{0}".FormatWith(_format);
            var form = new HttpUrlEncodedForm().Append("source", _appKey).Append("status", status);
            var request = new HttpRequestMessage("POST", url, form);
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
            var form = new HttpMultipartMimeForm().AppendValue("source", _appKey)
                                                  .AppendValue("status", status)
                                                  .AppendFile("pic", pic);        

            var request = new HttpRequestMessage("POST", url, form);
            return _client.Send(request).ReadJsonContent<Status>();
        }

        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博消息
        /// </summary>
        /// <returns></returns>
        public IList<Status> GetFriendsTimeline(long sinceID)
        {
            var request = new HttpRequestMessage("GET", "http://api.t.sina.com.cn/statuses/friends_timeline.{0}?source={1}&since_id={2}"
                              .FormatWith(_format, _appKey, sinceID));
            return _client.Send(request).ReadJsonContent<IList<Status>>();
        }

        /// <summary>
        /// 根据微博昵称获取好友列表
        /// </summary>
        /// <param name="screenName">微博昵称</param>
        /// <returns></returns>
        public IList<User> GetFriends(string screenName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}