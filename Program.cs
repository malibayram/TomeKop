using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using Serilog;

namespace TomeKop
{
    public class Program
    {
        public static bool IsLoggedIn = false;
        public static NpgsqlConnection DbCon;
        public static void Main(string[] args)
        {
            // http://zetcode.com/csharp/postgresql/

            DbCon = new NpgsqlConnection("Host=localhost;Username=postgres;Password=2121;Database=tomekop");

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .WriteTo.Console()
           .WriteTo.BrowserConsole()
           .WriteTo.File("log.txt",
               rollingInterval: RollingInterval.Day,
               rollOnFileSizeLimit: true)
           .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
