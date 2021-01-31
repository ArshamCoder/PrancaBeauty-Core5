using Framework.Common.ExMethod;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Authentication
{
    public class JwtAuthenticationWebAppMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secretKey;
        private readonly string _cookieName;

        public JwtAuthenticationWebAppMiddleware(RequestDelegate next, string secretKey, string cookieName)
        {
            _next = next;
            _secretKey = secretKey;
            _cookieName = cookieName;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies[_cookieName] != null)
            {
                string encryptedToken = context.Request.Cookies[_cookieName];
                context.Request.Headers.Add("Authorization", encryptedToken.AesDecrypt(_secretKey));
            }

            await _next(context);
        }
    }
}
