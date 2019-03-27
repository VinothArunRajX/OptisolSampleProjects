 
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web; 
using System;

namespace WebAppServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalDiagnosticsContext.Set("configDir", "C:\\Log_Files\\");
            GlobalDiagnosticsContext.Set("connectionString", "Data Source=.;Database=ConferenceRoomBooking ;User ID=sa;Password=test123;");
            
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                BuildWebHost(args).Run();
            }
            catch (Exception exception)
            {
                //NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) 
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                 logging.ClearProviders();
                 logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                }) 
                .Build();
    }
}
