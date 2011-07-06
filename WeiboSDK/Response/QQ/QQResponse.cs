using System;
using Newtonsoft.Json.Linq;

namespace WeiboSDK.Response.QQ
{
    [Serializable]
    public abstract class QQResponse
    {
        public string Ret { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }

        protected void ConvertFrom(JObject jo)
        {
            Ret = jo["ret"].ToString();
            Message = jo["msg"].ToString();
            ErrorCode = jo["errcode"].ToString();
        }
    }
}