using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using PrancaBeauty.WebApp.Authentication.Jwt;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using System;
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
                    //new CookieRequestCultureProvider(),
                    //new QueryStringRequestCultureProvider()
                    new PathRequestCultureProvider()
                }
            };

            return app.UseRequestLocalization(options);
        }


        public static IMvcBuilder AddCustomViewLocalization(this IMvcBuilder builder, string resourcePath)
        {
            builder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, option =>
            {
                option.ResourcesPath = resourcePath;
            });
            return builder;
        }

        public static IMvcBuilder AddCustomDataAnnotationLocalization(this IMvcBuilder builder, IServiceCollection services, Type typeOfSharedResource)
        {
            builder.AddDataAnnotationsLocalization(option =>
            {
                var localizer = new FactoryLocalizer().Set(services, typeOfSharedResource);
                option.DataAnnotationLocalizerProvider = (type, factory) => localizer;
            });
            return builder;
        }


        public static IServiceCollection AddInject(this IServiceCollection services)
        {
            //تزریق وابستگی
            services.AddSingleton<ILocalizer, Localizer>();
            services.AddSingleton<IMsgBox, MsgBox>();
            services.AddScoped<IJwtBuilder, JwtBuilder>();

            return services;
        }



    }
}
