﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using PrancaBeauty.Infrastructure.EfCore.Repository.User;
using PrancaBeauty.Infrastructure.Logger.Contracts;
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

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Applications
            services.AddScoped<IUserApplication, UserApplication>();

        }
    }
}
