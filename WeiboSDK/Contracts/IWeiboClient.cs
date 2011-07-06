namespace WeiboSDK.Contracts
{
    public interface IWeiboClient
    {
        T Post<T>(IUploadRequest<T> request) where T : IWeiboResponse, new();

        T Post<T>(IWeiboRequest<T> request) where T : IWeiboResponse, new();

        T Get<T>(IWeiboRequest<T> request) where T : IWeiboResponse, new();
    }
}