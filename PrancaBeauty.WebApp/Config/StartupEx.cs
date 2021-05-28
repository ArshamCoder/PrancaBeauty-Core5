﻿using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using PrancaBeauty.WebApp.Authentication.Jwt;
using PrancaBeauty.WebApp.Common.Utilities.IpAddress;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Middlewares;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using WebMarkupMin.AspNetCore5;
using WebMarkupMin.Core;

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

        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            return services.AddAuthorization(opt =>
            {
                /*
                 * AdminPage
                 * در اینجا رول کاربری است که می تواند به صفحه ادمین دسترسی پیدا کند
                 * و به صورت آرایه ای از رول ها هست و میتواند چندتا رول برای یک پالسی
                 * تعریف کنیم
                 */
                opt.AddPolicy("AdminPanelPolicy", pol => pol.RequireRole(new string[] { "AdminPage" }));
            });
        }
        public static IMvcBuilder AddRazorPageConfig(this IServiceCollection services)
        {
            return services.AddRazorPages(x =>
            {
                x.Conventions.AddPageRoute("/Home/RobotIndex", "");
                x.Conventions.AuthorizeFolder("/Admin/", "AdminPanelPolicy");
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
            /*
             * AddSingleton == یکبار اجرا می شود و به تمامی کاربران اختصاص داده می شود
             */
            services.AddSingleton<ILocalizer, Localizer>();
            services.AddSingleton<IMsgBox, MsgBox>();
            services.AddScoped<IJwtBuilder, JwtBuilder>();
            services.AddSingleton<IIpAddressChecker, IpAddressChecker>();

            return services;
        }

        public static IApplicationBuilder UseRedirectNotRobots(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RedirectWhenNotRobotsMiddleware>();
        }


        public static IApplicationBuilder RedirectStatusCode(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                await next.Invoke();

                if (context.Response.StatusCode == 401)
                {
                    var rqf = context.Request.HttpContext.Features.Get<IRequestCultureFeature>();
                    string culture = rqf.RequestCulture.Culture.Parent.Name;

                    context.Response.Redirect($"/{culture}/Auth/Login");
                }

                //if (context.Response.StatusCode == 429)
                //{
                //    var rqf = context.Request.HttpContext.Features.Get<IRequestCultureFeature>();
                //    string culture = rqf.RequestCulture.Culture.Parent.Name;

                //    context.Response.Redirect($"/{culture}/Error/429");
                //}

                if (context.Response.StatusCode == 404)
                {
                    var rqf = context.Request.HttpContext.Features.Get<IRequestCultureFeature>();
                    string culture = rqf.RequestCulture.Culture.Parent.Name;

                    context.Response.Redirect($"/{culture}/Error/404");
                }

                if (context.Response.StatusCode == 400)
                {
                    var rqf = context.Request.HttpContext.Features.Get<IRequestCultureFeature>();
                    string culture = rqf.RequestCulture.Culture.Parent.Name;

                    context.Response.Redirect($"/{culture}/Error/400");
                }
            });
        }


        public static IServiceCollection RateLimitConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddMemoryCache();

            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

            services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            return services;
        }
        public static void AddCustomWebMarkupMin(this IServiceCollection services)
        {
            services.AddWebMarkupMin(opt =>
            {
                opt.AllowMinificationInDevelopmentEnvironment = true;
                opt.AllowCompressionInDevelopmentEnvironment = true;
            }).AddHtmlMinification(opt =>
            {
                opt.MinificationSettings.WhitespaceMinificationMode = WhitespaceMinificationMode.None;
            });
        }


        public static IServiceCollection GZipConfig(this IServiceCollection services)
        {
            services.Configure<BrotliCompressionProviderOptions>(opt =>
            {
                opt.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(opt =>
            {
                opt.EnableForHttps = true;
                opt.MimeTypes = new List<string> {
                    "application/javascript",
                    "application/rss+xml",
                    "application/vnd.ms-fontobject",
                    "application/x-font",
                    "application/x-font-opentype",
                    "application/x-font-otf",
                    "application/x-font-truetype",
                    "application/x-font-ttf",
                    "application/x-javascript",
                    "application/xhtml+xml",
                    "application/xml",
                    "font/opentype",
                    "font/otf",
                    "font/ttf",
                    "image/svg+xml",
                    "image/x-icon",
                    "text/css",
                    "text/html",
                    "text/javascript",
                    "text/plain",
                    "text/xml"
                };
                opt.Providers.Add<BrotliCompressionProvider>();
            });

            return services;
        }

        public static IApplicationBuilder UseCustomCaching(this IApplicationBuilder application)
        {
            return application.Use(async (context, next) =>
            {
                string path = context.Request.Path;

                // css, js
                if (path.EndsWith(".css") || path.EndsWith(".js"))
                {
                    TimeSpan maxAge = new TimeSpan(365, 0, 0, 0);
                    context.Request.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
                }

                // fonts
                else if (path.EndsWith(".woff") || path.EndsWith(".woff2") || path.EndsWith(".tff") || path.EndsWith(".svg") || path.EndsWith(".eot"))
                {
                    TimeSpan maxAge = new TimeSpan(365, 0, 0, 0);
                    context.Request.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
                }

                // Directory
                else if (path.Contains("/lib/"))
                {
                    TimeSpan maxAge = new TimeSpan(365, 0, 0, 0);
                    context.Request.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
                }

                // Images
                else if (path.EndsWith(".png") || path.EndsWith(".jpg") || path.EndsWith(".jpeg") || path.EndsWith(".bmp") || path.EndsWith(".gif"))
                {
                    TimeSpan maxAge = new TimeSpan(365, 0, 0, 0);
                    context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
                }

                // View
                else
                {
                    context.Response.Headers.Append("Cache-Control", "no-cache");
                    context.Response.Headers.Append("Cache-Control", "private, no-store");
                }

                await next();
            });
        }
    }




}
