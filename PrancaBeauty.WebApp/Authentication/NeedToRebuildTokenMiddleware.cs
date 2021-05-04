using Framework.Application.Consts;
using Microsoft.AspNetCore.Http;
using PrancaBeauty.WebApp.Common.ExMethod;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Authentication
{
    /// <summary>
    /// بعد از ویرایش سطح دسترسی
    /// باید کاربرانی که آن سطح دسترسی دارند
    /// از سایت برن بیرون و دوباره لاگین کنند
    /// </summary>
    public class NeedToRebuildTokenMiddleware
    {
        private readonly RequestDelegate _next;
        public NeedToRebuildTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
            {
                string userId = context.User.GetUserDetails().UserId;
                if (CacheUsersToRebuildToken.Any(userId))
                {
                    context.Response.Cookies.Delete(AuthConst.CookieName);

                    CacheUsersToRebuildToken.Remove(userId);
                }
            }

            await _next(context);
        }
    }
}
