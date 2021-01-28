using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace PrancaBeauty.WebApp.Authentication
{
    public static class ConfigIdentityJwt
    {
        private static string _SecretKey;
        private static byte[] _SecretCode;




        /// <summary>
        /// پیاده سازی jwt
        /// </summary>
        /// <param name="audience">مصرف کننده توکن</param>
        /// <param name="issuer">صادر کننده توکن</param>
        public static void AddJwtAuthentication(this IServiceCollection services, string secretCode, string secretKey, string audience, string issuer)
        {
            _SecretKey = secretKey;
            _SecretCode = Encoding.ASCII.GetBytes(secretCode);
            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {

                });

        }
    }
}
