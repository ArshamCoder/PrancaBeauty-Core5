using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
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
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(_SecretCode),
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateIssuer = true,
                        ValidIssuer = issuer
                    };

                });

        }




        public static void UseJwtAuthentication(this IApplicationBuilder app, string cookieName)
        {
            app.UseMiddleware<JwtAuthenticationWebAppMiddleware>(_SecretKey, cookieName);
            app.UseAuthentication();
            app.UseAuthorization();
        }






    }
}
