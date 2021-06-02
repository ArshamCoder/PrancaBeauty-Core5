using Microsoft.AspNetCore.Http;
using System.Net;

namespace PrancaBeauty.WebApp.Common.ExMethod
{
    public static class HttpRequestEx
    {
        public static string GetCurrentUrl(this HttpRequest request)
        {
            string url = request.Scheme + "://" + request.Host + request.Path;
            if (request.QueryString.HasValue)
                url += request.QueryString.Value;

            return url;
        }

        public static string GetCurrentUrlEncoded(this HttpRequest request)
        {
            string Url = request.Scheme + "://" + request.Host + request.Path;
            if (request.QueryString.HasValue)
                Url += request.QueryString.Value;

            return WebUtility.UrlEncode(Url);
        }
    }
}
