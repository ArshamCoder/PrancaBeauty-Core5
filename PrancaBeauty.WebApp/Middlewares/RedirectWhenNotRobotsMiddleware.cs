using Microsoft.AspNetCore.Http;
using PrancaBeauty.Application.Apps.Language;
using PrancaBeauty.Application.Apps.Setting;
using System.Globalization;
using System.Threading.Tasks;
using UAParser;

namespace PrancaBeauty.WebApp.Middlewares
{
    public class RedirectWhenNotRobotsMiddleware
    {
        private readonly RequestDelegate _Next;
        public RedirectWhenNotRobotsMiddleware(RequestDelegate next)
        {
            _Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //if (context.Request.GetCurrentUrl().Trim('/').ToLower().EndsWith("/robotindex"))
            if (context.Request.Path == "/")
            {
                var settingApplication = (ISettingApplication)context.RequestServices.GetService(typeof(ISettingApplication));
                var languageApplication = (ILanguageApplication)context.RequestServices.GetService(typeof(ILanguageApplication));

                ClientInfo clientInfo = Parser.GetDefault().Parse(context.Request.Headers["User-Agent"].ToString());
                if (!clientInfo.Device.IsSpider)
                {
                    string siteUrl = (await settingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl;
                    string langAbbr = await languageApplication.GetAbbrByCodeAsync(CultureInfo.CurrentCulture.Name);

                    context.Response.Redirect(siteUrl + "/" + langAbbr);
                }
            }

            await _Next(context);
        }
    }
}
