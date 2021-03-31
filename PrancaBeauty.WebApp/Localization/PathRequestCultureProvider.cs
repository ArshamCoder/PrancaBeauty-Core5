using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using PrancaBeauty.Application.Apps.Language;
using PrancaBeauty.WebApp.Common.Utilities.IpAddress;
using System;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Localization
{
    /// <summary>
    /// تعیین زبان سایت
    /// </summary>
    public class PathRequestCultureProvider : RequestCultureProvider
    {
        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException();

            var languageApplication = (ILanguageApplication)httpContext.RequestServices.GetService(typeof(ILanguageApplication));

            string path = httpContext.Request.Path;
            /*
             * از انتها آدرس صفحه
             * en
             * یا
             * fa
             *میگیرد و زبان سایت به آن تغییر می دهد
             */
            string cultureName = path.Trim('/').Split("/")[0];

            var langCode = await languageApplication.GetCodeByAbbrAsync(cultureName);
            if (langCode == null)
            {
                var ipAddressChecker = (IIpAddressChecker)httpContext.RequestServices.GetService(typeof(IIpAddressChecker));
                string ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();

                if (ipAddressChecker?.CheckIp(ipAddress) == "ir")
                {
                    langCode = "fa-IR";
                }
                else if (ipAddressChecker?.CheckIp(ipAddress) == "us")
                {
                    langCode = "en-US";
                }
                else
                {
                    langCode = "fa-IR";
                }
            }

            return new ProviderCultureResult(langCode, langCode);
        }
    }
}
