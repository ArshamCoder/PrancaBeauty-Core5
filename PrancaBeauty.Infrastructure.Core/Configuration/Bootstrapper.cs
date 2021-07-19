﻿using Framework.Application.Services.Email;
using Framework.Application.Services.FTP;
using Framework.Application.Services.IpList;
using Framework.Application.Services.Security.AntiShell;
using Framework.Application.Services.Sms;
using Framework.Common.Utilities.Download;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.Application.Apps.AccesslevelsRoles;
using PrancaBeauty.Application.Apps.Address;
using PrancaBeauty.Application.Apps.Categories;
using PrancaBeauty.Application.Apps.Cities;
using PrancaBeauty.Application.Apps.Countries;
using PrancaBeauty.Application.Apps.File;
using PrancaBeauty.Application.Apps.FileServer;
using PrancaBeauty.Application.Apps.Language;
using PrancaBeauty.Application.Apps.Province;
using PrancaBeauty.Application.Apps.Role;
using PrancaBeauty.Application.Apps.Setting;
using PrancaBeauty.Application.Apps.Template;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Application.Common.FtpWapper;
using PrancaBeauty.Domain.Categories.Contracts;
using PrancaBeauty.Domain.FileServer.FileAgg.Contracts;
using PrancaBeauty.Domain.FileServer.ServerAgg.Contracts;
using PrancaBeauty.Domain.Region.CityAgg.Contracts;
using PrancaBeauty.Domain.Region.CountryAgg.Contracts;
using PrancaBeauty.Domain.Region.LanguageAgg.Contracts;
using PrancaBeauty.Domain.Region.ProvinceAgg.Contracts;
using PrancaBeauty.Domain.SettingAgg.Contracts;
using PrancaBeauty.Domain.TemplateAgg.Contracts;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.User.AddressAgg.Contracts;
using PrancaBeauty.Domain.User.RoleAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel;
using PrancaBeauty.Infrastructure.EfCore.Repository.FileServer;
using PrancaBeauty.Infrastructure.EfCore.Repository.Region;
using PrancaBeauty.Infrastructure.EfCore.Repository.Role;
using PrancaBeauty.Infrastructure.EfCore.Repository.Setting;
using PrancaBeauty.Infrastructure.EfCore.Repository.Template;
using PrancaBeauty.Infrastructure.EfCore.Repository.User;
using PrancaBeauty.Infrastructure.EFCore.Repository.Address;
using PrancaBeauty.Infrastructure.EFCore.Repository.Categories;
using PrancaBeauty.Infrastructure.EFCore.Repository.Cities;
using PrancaBeauty.Infrastructure.EFCore.Repository.Counties;
using PrancaBeauty.Infrastructure.EFCore.Repository.Province;
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
            services.AddScoped<IDownloader, Downloader>();
            services.AddScoped<ISmsSender, KaveNegarSmsSender>();
            services.AddScoped<IIpList, IPList>();
            services.AddScoped<IFtpClient, FtpClient>();
            services.AddScoped<IFtpWapper, FtpWapper>();
            services.AddScoped<IAniShell, AniShell>();


            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IAccessLevelRepository, AccessLevelRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IFileServerRepository, FileServerRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IAccesslevelRolesRepository, AccesslevelRolesRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            // Applications
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ITemplateApplication, TemplateApplication>();
            services.AddScoped<ISettingApplication, SettingApplication>();
            services.AddScoped<IAccesslevelApplication, AccesslevelApplication>();
            services.AddScoped<IRoleApplication, RoleApplication>();
            services.AddScoped<ILanguageApplication, LanguageApplication>();
            services.AddScoped<IFileApplication, FileApplication>();
            services.AddScoped<IFileServerApplication, FileServerApplication>();
            services.AddScoped<IAccesslevelRolesApplication, AccesslevelRolesApplication>();
            services.AddScoped<IAddressApplication, AddressApplication>();
            services.AddScoped<ICityApplication, CityApplication>();
            services.AddScoped<ICountryApplication, CountryApplication>();
            services.AddScoped<IProvinceApplication, ProvinceApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();

        }
    }
}
