using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace PrancaBeauty.WebApp.Config
{
    public static class StartupEx
    {
        public static IServiceCollection WebEncoderConfig(this IServiceCollection services)
        {
            return services.Configure<WebEncoderOptions>(opt =>
             {
                 opt.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
             });
        }

        public static IMvcBuilder AddRazorPageConfig(this IServiceCollection services)
        {
            return services.AddRazorPages(x =>
            {
                x.Conventions.AddPageRoute("/Home/Index", "");
            });

        }

        public static IServiceCollection AddLocalization(this IServiceCollection services, string resourcePath)
        {
            return services.AddLocalization(x => x.ResourcesPath = resourcePath);
        }


        public static IApplicationBuilder UseLocalization(this IApplicationBuilder app, List<CultureInfo> supportedLangs, string defCultureName = "fa-IR")
        {
            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(defCultureName),
                SupportedCultures = supportedLangs,
                SupportedUICultures = supportedLangs,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new CookieRequestCultureProvider(),
                    new QueryStringRequestCultureProvider()
                }
            };

            return app.UseRequestLocalization(options);
        }

    }
}
