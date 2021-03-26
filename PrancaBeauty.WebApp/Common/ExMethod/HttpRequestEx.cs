using Microsoft.AspNetCore.Http;

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
    }
}
