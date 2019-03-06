using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using WebAppRodarForce.Api.Extensions;
using ProjetoPaulo.Data.Context;
using ProjetoPaulo.Domain.Config;

namespace ProjetoPaulo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
               .MigrateDbContext<PauloContext>((context, services) =>
               {
                   var env = services.GetService<IHostingEnvironment>();
                   var settings = services.GetService<IOptions<ConfiguracaoProjeto>>();

               }).Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseHealthChecks("/hc")
                .UseStartup<Startup>()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((builderContext, config) =>
            {
                config.AddEnvironmentVariables();
            }).ConfigureLogging((hostingContext, builder) =>
            {
                builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                builder.AddConsole();
                builder.AddDebug();
            })
            .Build();
    }
}
