#region using

using System.Collections.Generic;
using WeiboSDK.Entities;

#endregion

namespace WeiboSDK.Contracts
{
    public interface IWeiboClient
    {
        /// <summary>
        ///     获取最新更新的公共微博消息
        /// </summary>
        /// <returns></returns>
        IList<Status> GetPublicWeibos();

        /// <summary>
        ///     获取指定用户发布的微博列表
        /// </summary>
        /// <param name = "screenName"></param>
        /// <returns></returns>
        IList<Status> GetUserWeibos(string screenName);

        /// <summary>
        ///     对指定微博发表评论
        /// </summary>
        /// <param name = "id">微博Id</param>
        /// <param name = "cid"></param>
        /// <param name = "comment">评论内容</param>
        /// <returns></returns>
        Comment Comment(string id, string cid, string comment);

        /// <summary>
        ///     获取我发出的评论
        /// </summary>
        /// <returns></returns>
        IList<Comment> GetMyComments();

        /// <summary>
        ///     删除指定Id的评论
        /// </summary>
        /// <param name = "id"></param>
        /// <returns></returns>
        Comment DestoryComment(string id);

        /// <summary>
        ///     获取@我的微博列表
        /// </summary>
        /// <returns></returns>
        IList<Status> GetMyMentions(string sinceId, string page, string count);

        /// <summary>
        ///     删除指定Id的微博
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Status DestoryStatus(string id);

        /// <summary>
        ///     验证当前用户身份是否合法
        /// </summary>
        /// <returns></returns>
        User VerifyCredentials();

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
        IList<Status> Search(string q, string filterOri, string filterPic, string fuid, string province, string city,
                             string startTime, string endTime, string page, string count);


        /// <summary>
        /// 获取单条微博的Web访问路径
        /// </summary>
        /// <param name="id">微博Id</param>
        /// <param name="userid">用户Id</param>
        /// <returns></returns>
        string GetWeiboUrl(string id, string userid);

        /// <summary>
        /// 返回用户关注列表，并返回最新微博文章
        /// </summary>
        /// <returns></returns>
        IList<User> GetMyFriends(string screenName);

        /// <summary>
        /// 发布一条微博信息
        /// </summary>
        /// <param name="status">微博</param>
        /// <returns></returns>
        Status UpdateStatus(string status);

        /// <summary>
        /// 发表图片微博消息
        /// </summary>
        /// <param name="status">微博</param>
        /// <param name="pic">图片路径</param>
        /// <returns></returns>
        Status UploadStatus(string status, string pic);

        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博消息
        /// </summary>
        /// <returns></returns>
        IList<Status> GetFriendsTimeline(long sinceId);

        /// <summary>
        /// 根据微博昵称获取好友列表
        /// </summary>
        /// <param name="screenName">微博昵称</param>
        /// <returns></returns>
        IList<User> GetFriends(string screenName);
    }
}