using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using PrancaBeauty.Application.Apps.Language;
using System.Globalization;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Fillters
{
    public class FillLangIdParametrFilter : IAsyncPageFilter
    {
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var languageApplication = (ILanguageApplication)context.HttpContext.GetService<ILanguageApplication>();
            string langCode = CultureInfo.CurrentCulture.Name;

            var langId = await languageApplication.GetLangIdByLangCodeAsync(langCode);

            context.HandlerArguments.Add("LangId", langId);

            await next();
        }

        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {

        }
    }
}
