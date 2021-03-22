using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using PrancaBeauty.Application.Apps.Language;
using System;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Localization
{
    public class PathRequestCultureProvider : RequestCultureProvider
    {
        private readonly ILanguageApplication _languageApplication;

        public PathRequestCultureProvider(ILanguageApplication languageApplication)
        {
            _languageApplication = languageApplication;
        }

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException();

            string Path = httpContext.Request.Path;
            string CultureName = Path.Trim('/').Split("/")[0];



            return Task.FromResult(new ProviderCultureResult(CultureName, CultureName));
        }
    }
}
