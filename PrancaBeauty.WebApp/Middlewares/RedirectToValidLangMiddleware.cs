using Microsoft.AspNetCore.Http;
using PrancaBeauty.Application.Apps.Language;
using PrancaBeauty.Application.Apps.Setting;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Middlewares
{
    public class RedirectToValidLangMiddleware
    {
        private readonly RequestDelegate _Next;
        public RedirectToValidLangMiddleware(RequestDelegate next)
        {
            _Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // GET فقط برای حالت 
            if (context.Request.Method.ToLower() == "get")
            {
                string[] Paths = context.Request.Path.HasValue ?
                    context.Request.Path.Value.Trim(new char[] { '/' }).Split("/")
                    : new string[] { };

                var _SettingApplication = (ISettingApplication)context.RequestServices.GetService(typeof(ISettingApplication));
                var _LanguageApplication = (ILanguageApplication)context.RequestServices.GetService(typeof(ILanguageApplication));

                if (Paths.Any())
                {
                    // زبان انتخاب شده
                    string langAbbr = Paths.First();

                    var isValid = await _LanguageApplication.IsValidAbbrForSiteLangAsync(langAbbr);
                    if (!isValid)
                    {
                        string SiteUrl = (await _SettingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl;

                        // replace
                        // کردن بخش اول آدرس مرورگر که کاربر فرستاده اینجا
                        Paths[0] = "fa";

                        context.Response.StatusCode = 301;
                        context.Response.Redirect(SiteUrl + "/" + string.Join("/", Paths));
                    }
                }
                else
                {
                    string siteUrl = (await _SettingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl;
                    context.Response.Redirect(siteUrl + "/fa");
                }
            }

            await _Next(context);
        }
    }
}
