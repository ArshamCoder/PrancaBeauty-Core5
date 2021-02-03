using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace PrancaBeauty.Infrastructure.Logger.SeriLogger
{
    public static class SerilogEx
    {
        public static void UseSerilog_SqlServer(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((builder, logger) =>
            {
                logger = new SerilogConfig().ConfigSqlServer(LogEventLevel.Warning);
            });
        }

        public static void UseSerilog_Console(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((builder, logger) =>
            {
                logger.WriteTo.Console().MinimumLevel.Is(LogEventLevel.Verbose);
            });
        }
    }
}
