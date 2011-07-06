using System.Text;
using SocialKit.LightRest;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Contracts;
using WeiboSDK.Enums;

namespace WeiboSDK
{
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

        public T Post<T>(IUploadRequest<T> request) where T : IWeiboResponse, new()
        {
            var url = new StringBuilder(request.Url);
            if (request.WeiboType == WeiboType.Sina)
                url.Append(_format);

            var form = new HttpMultipartMimeForm();

            if (request.WeiboType == WeiboType.QQ)
                form.AppendValue("format", _format.ToString());

            if (request.Parameters.Count > 0)
            {
                foreach (var parameter in request.Parameters)
                {
                    form.AppendValue(parameter.Key, parameter.Value);
                }
            }

            if(request.FileParameters.Count > 0)
            {
                foreach (var fileParameter in request.FileParameters)
                {
                    form.AppendFile(fileParameter.Key, fileParameter.Value);
                }
            }

            var oauthRequest = new OAuthHttpRequestMessage("POST", url.ToString(), form).Sign(_accessToken);
            var result = _client.Send(oauthRequest).ReadContentAsString();

            var response = new T();
            response.ConvertFrom(result);

            return response;
        }

        public T Post<T>(IWeiboRequest<T> request) where T : IWeiboResponse, new()
        {
            var url = new StringBuilder(request.Url);
            if (request.WeiboType == WeiboType.Sina)
                url.Append(_format);

            var form = new HttpUrlEncodedForm();

            if (request.WeiboType == WeiboType.QQ)
                form.Append("format", _format.ToString());

            if(request.Parameters.Count > 0)
            {
                foreach (var parameter in request.Parameters)
                {
                    form.Append(parameter.Key, parameter.Value);
                }
            }

            var oauthRequest = new OAuthHttpRequestMessage("POST", url.ToString(), form).Sign(_accessToken);
            var result = _client.Send(oauthRequest).ReadContentAsString();

            var response = new T();
            response.ConvertFrom(result);

            return response;
        }

        public T Get<T>(IWeiboRequest<T> request) where T : IWeiboResponse, new()
        {
            var url = new StringBuilder(request.Url);
            if (request.WeiboType == WeiboType.Sina)
                url.Append(_format + "?");
            else
                url.AppendFormat("?format={0}&", _format);
            
            if(request.Parameters != null)
            {
                foreach (var parameter in request.Parameters)
                {
                    url.AppendFormat(parameter.Key + "={0}&", parameter.Value);
                } 
            }

            url.Remove(url.Length - 1, 1);

            var oauthRequest = new OAuthHttpRequestMessage("GET", url.ToString()).Sign(_accessToken);
            var result = _client.Send(oauthRequest).ReadContentAsString();

            var response = new T();
            response.ConvertFrom(result);

            return response;
        }
    }
}