using System.Collections.Generic;
using WeiboSDK.Enums;

namespace WeiboSDK.Contracts
{
    public interface IWeiboRequest<T> where T : IWeiboResponse, new()
    {
        WeiboType WeiboType { get; }

        string Url { get; }

        IDictionary<string, string> Parameters { get; }
    }
}