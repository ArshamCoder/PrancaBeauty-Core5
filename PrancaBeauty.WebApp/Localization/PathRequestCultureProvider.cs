using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using PrancaBeauty.Application.Apps.Language;
using System;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Localization
{
    public class PathRequestCultureProvider : RequestCultureProvider
    {
        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException();

            var languageApplication = (ILanguageApplication)httpContext.RequestServices.GetService(typeof(ILanguageApplication));

            string path = httpContext.Request.Path;
            string cultureName = path.Trim('/').Split("/")[0];

            var langCode = await languageApplication.GetCodeByAbbrAsync(cultureName);
            if (langCode == null)
                langCode = "fa-IR";

            return new ProviderCultureResult(langCode, langCode);
        }
    }
}
