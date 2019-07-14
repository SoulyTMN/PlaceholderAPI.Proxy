using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceholderAPI.Proxy.Extensions
{
    public static class LoggerExtensions
    {
        public static IServiceCollection AddSerilogLogger(this IServiceCollection services, IConfiguration configuration)
        {
            Environment.SetEnvironmentVariable("BASEDIR", AppContext.BaseDirectory);
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();

            return services;
        }

        public static ILogger WithLogContext(this Microsoft.Extensions.Logging.ILogger logger)
        {
            return Log.Logger;
        }
    }
}
