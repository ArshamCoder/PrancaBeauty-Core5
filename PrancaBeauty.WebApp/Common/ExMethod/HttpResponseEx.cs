using Framework.Application.Consts;
using Microsoft.AspNetCore.Http;
using System;

namespace PrancaBeauty.WebApp.Common.ExMethod
{
    public static class HttpResponseEx
    {
        public static void CreateAuthCookie(this HttpResponse response, string authToken, bool remmemberMe)
        {
            // حذف کوکی
            response.Cookies.Delete(AuthConst.CookieName);

            // ایجاد کوکی
            response.Cookies.Append(AuthConst.CookieName, authToken, remmemberMe ?
                new CookieOptions() { Expires = DateTime.Now.AddHours(48) } : new CookieOptions());
        }
    }
}
