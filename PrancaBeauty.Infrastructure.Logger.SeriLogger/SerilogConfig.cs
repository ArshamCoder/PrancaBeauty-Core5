using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;

namespace PrancaBeauty.Infrastructure.Logger.SeriLogger
{
    public class SerilogConfig
    {
        public LoggerConfiguration ConfigSqlServer(LogEventLevel logEventLevel)
        {
            var columnOpt = new ColumnOptions();
            columnOpt.Store.Remove(StandardColumn.Properties);
            columnOpt.Store.Add(StandardColumn.LogEvent);// Information - Debug - Warning - Fatal
            columnOpt.LogEvent.DataLength = -1; // -1 == Max
            columnOpt.PrimaryKey = columnOpt.TimeStamp;
            columnOpt.TimeStamp.NonClusteredIndex = true;

            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.MSSqlServer("Server=.;Database=SerilogDb;Trusted_Connection=True;", new MSSqlServerSinkOptions()
                {
                    AutoCreateSqlTable = true,
                    TableName = "tblPrancaBeautyLogs",
                    BatchPeriod = new TimeSpan(0, 0, 1)

                }, columnOptions: columnOpt);
        }
    }
}
