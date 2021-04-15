using Framework.Application.Consts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using PrancaBeauty.Infrastructure.Core.Configuration;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Config;
using PrancaBeauty.WebApp.Localization.Resource;
using System.Collections.Generic;
using System.Globalization;

namespace PrancaBeauty.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            #region چند زبانگی

            services.AddLocalization("Localization/Resource");

            #endregion

            #region درست کردن متن فارسی
            // view source
            // در مرورگر بزنیم متن فارسی از حالت کد خارج می کند

            services.WebEncoderConfig();
            #endregion


            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            /*
             * سطح دسترسی ها را برای فولدر هایی که در بخش
             * Page
             * هست تعیین می کنیم
             */
            services.AddCustomAuthorization();

            services.AddRazorPageConfig()
                .AddCustomViewLocalization("Localization/Resource")
                .AddCustomDataAnnotationLocalization(services, typeof(SharedResource))
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.Config();

            services.AddInject();
            services.AddCustomIdentity()
                //ترجمه پیغام های خطا 
                .AddErrorDescriber<CustomErrorDescriber>();

            services.AddJwtAuthentication(AuthConst.SecretCode, AuthConst.SecretKey, AuthConst.Audience, AuthConst.Issuer);
            services.AddKendo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseLocalization(new List<CultureInfo>() { new CultureInfo("en-US"), new CultureInfo("fa-IR") }, "fa-IR");

            app.UseJwtAuthentication(AuthConst.CookieName);


            app.UseRedirectNotRobots();// ایا کاربر اومده تو سایت یا ربات هست
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
