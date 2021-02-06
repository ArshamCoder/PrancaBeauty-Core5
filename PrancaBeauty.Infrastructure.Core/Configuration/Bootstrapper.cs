using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<MainContext>(opt =>
                opt.UseSqlServer("Server=.;Database=PrancaBeautyDb;Trusted_Connection=True;"));

            services.AddSingleton<ILogger, Serilogger>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
