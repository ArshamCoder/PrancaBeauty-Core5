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
                string[] paths = context.Request.Path.HasValue ?
                    context.Request.Path.Value.Trim(new char[] { '/' }).Split("/")
                    : new string[] { };

                var settingApplication = (ISettingApplication)context.RequestServices.GetService(typeof(ISettingApplication));
                var languageApplication = (ILanguageApplication)context.RequestServices.GetService(typeof(ILanguageApplication));

                if (paths.Any())
                {
                    // زبان انتخاب شده
                    string langAbbr = paths.First();

                    var isValid = await languageApplication.IsValidAbbrForSiteLangAsync(langAbbr);
                    if (!isValid)
                    {
                        string siteUrl = (await settingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl;

                        // replace
                        // کردن بخش اول آدرس مرورگر که کاربر فرستاده اینجا
                        paths[0] = "fa";

                        context.Response.StatusCode = 301;
                        context.Response.Redirect(siteUrl + "/" + string.Join("/", paths));
                    }
                }
                else
                {
                    if (settingApplication != null)
                    {
                        string siteUrl = (await settingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl;
                        context.Response.Redirect(siteUrl + "/fa");
                    }
                }
            }

            await _Next(context);
        }
    }
}
