using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Authentication
{
    public class JwtAuthenticationWebAppMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthenticationWebAppMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }
}
