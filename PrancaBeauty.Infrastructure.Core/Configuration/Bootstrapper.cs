﻿using Framework.Application.Services.Email;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.Application.Apps.Setting;
using PrancaBeauty.Application.Apps.Template;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Domain.SettingAgg.Contracts;
using PrancaBeauty.Domain.TemplateAgg.Contracts;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel;
using PrancaBeauty.Infrastructure.EfCore.Repository.Setting;
using PrancaBeauty.Infrastructure.EfCore.Repository.Template;
using PrancaBeauty.Infrastructure.EfCore.Repository.User;
using PrancaBeauty.Infrastructure.Logger.SeriLogger;

namespace PrancaBeauty.Infrastructure.Core.Configuration
{
    public static class Bootstrapper
    {
        public static void Config(this IServiceCollection services)
        {
            //services.AddDbContext<MainContext>(opt =>
            //    opt.UseSqlServer("Server=.;Database=PrancaBeautyDb;Trusted_Connection=True;"));

            //services.AddScoped<ILogger, Serilogger>();
            //services.AddScoped<IUserRepository, UserRepository>();


            services.AddDbContext<MainContext>(opt => opt.UseSqlServer("Server=.;Database=PrancaBeautyDb;Trusted_Connection=True;"));

            services.AddScoped<ILogger, Serilogger>();
            services.AddScoped<IEmailSender, GmailSender>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IAccessLevelRepository, AccessLevelRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();

            // Applications
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ITemplateApplication, TemplateApplication>();
            services.AddScoped<ISettingApplication, SettingApplication>();
            services.AddScoped<IAccesslevelApplication, AccesslevelApplication>();

        }
    }
}
