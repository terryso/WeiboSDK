using System.Collections.Generic;

namespace WeiboSDK.Contracts
{
    /// <summary>
    /// 腾讯微博上传请求接口，支持同时上传多个文件。
    /// </summary>
    public interface IUploadRequest<T> : IWeiboRequest<T> where T : IWeiboResponse, new()
    {
        /// <summary>
        /// 获取所有的Key-Value形式的文件请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 文件路径
        /// </summary>
        /// <returns>文件请求参数字典</returns>
        IDictionary<string, string> FileParameters { get; }
    }
}
