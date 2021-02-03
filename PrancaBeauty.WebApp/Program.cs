using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PrancaBeauty.Infrastructure.Logger.SeriLogger;
using PrancaBeauty.WebApp;
using System;

namespace BeautyShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                    {
                        //اگر در حالت توسعه بود
                        webBuilder.UseSerilog_Console();
                    }
                    else
                    {
                        webBuilder.UseSerilog_SqlServer();
                    }
                });
    }
}
