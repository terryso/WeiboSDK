namespace WeiboSDK.Contracts
{
    public interface ISinaApiService
    {
        #region 获取下行数据集(timeline)接口

        /*获取最新更新的公共微博消息*/
        string public_timeline();
        /*获取当前用户所关注用户的最新微博信息*/
        // (别名: statuses/home_timeline)
        string friend_timeline();
        /*获取用户发布的微博信息列表*/
        string user_timeline(string id, string userID, string screenName, string sinceID, string maxID, string count, string page);
        /*获取@当前用户的微博列表*/
        string mentions();
        /*获取当前用户发送及收到的评论列表*/
        string comments_timeline();
        /*获取当前用户发出的评论*/
        string comments_by_me();
        /*获取指定微博的评论列表*/
        string comments(string id);
        /*批量获取一组微博的评论数及转发数*/
        string counts(string ids);
        //获取当前用户未读消息数
        string unread();

        #endregion

        #region 微博访问接口

        /*获取单条ID的微博信息*/
        string statuses_show(string id);
        /*获取单条ID的微博信息*/
        string statuses_id(string id, string uid);
        /*发布一条微博信息*/
        string statuses_update(string status);
        /*上传图片并发布一条微博信息*/
        string statuses_upload(string status, string file);
        /*删除一条微博信息*/
        string statuses_destroy(int id);
        /*转发一条微博信息（可加评论）*/
        string statuses_repost(int id, string text);
        /*对一条微博信息进行评论*/
        string statuses_comment(long id, long cid, string comment);
        /*删除当前用户的微博评论信息*/
        string statuses_comment_destroy(int id);
        /*回复微博评论信息*/
        string statuses_reply(int id, int cid, string comment);

        #endregion

        #region 用户接口

        /*根据用户ID获取用户资料（授权用户）*/
        string users_show(int user_id);
        /*获取当前用户关注对象列表及最新一条微博信息*/
        string statuses_friends(int user_id);
        /*获取当前用户粉丝列表及最新一条微博信息*/
        string statuses_followers(int user_id);

        #endregion

        #region 私信接口

        /*获取当前用户最新私信列表 (n条)*/
        string direct_messages(int number);
        /*获取当前用户发送的最新私信列表*/
        string direct_messages_sent();
        /*发送一条私信*/
        string direct_messages_new(int user_id, string text);
        /*删除一条私信 */
        string direct_messages_destroy(int message_id);

        #endregion

        #region 关注接口

        /*关注某用户*/
        string friendships_create(int user_id);
        /*取消关注*/
        string friendships_destroy(int user_id);
        /*是否关注某用户(推荐使用friendships/show)*/
        string friendships_exists(int user_a, int user_b);
        /*获取两个用户关系的详细情况  source_id 可为空，为空则取当前用户*/
        string friendships_show(int? source_id, int target_id);

        #endregion

        #region Social Graph接口

        /*获取用户关注对象uid列表*/
        string friends_ids(int user_id);
        /*获取用户粉丝对象uid列表*/
        string followers_ids(int user_id);

        #endregion

        #region 账号接口

        /*验证当前用户身份是否合法*/
        string account_verify_credentials();
        /*获取当前用户API访问频率限制*/
        string account_rate_limit_status();
        /*当前用户退出登录*/
        string account_end_session();
        /*更改头像*/
        string account_update_profile_image(string image_path);
        /*更改资料*/
        //string account_update_profile();
        /*注册新浪微博帐号*/
        //string account_register();

        #endregion

        #region 收藏接口

        /*获取当前用户的收藏列表*/
        string favorites();
        /*添加收藏*/
        string favorites_create(int id);
        /*删除当前用户收藏的微博信息*/
        string favorites_destroy(int fav_id);

        #endregion
    }
}