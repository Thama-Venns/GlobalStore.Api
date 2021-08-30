using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Ntvspace.GlobalStoreApi.Web
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
  public class Program
  {
    public static void Main(string[] args)
    {
      // ConfigureLogging();
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((context, config) => 
            {
                config.Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"])) 
                { 
                    AutoRegisterTemplate = true,
                    IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-" +
                                  $"{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
                })
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .ReadFrom.Configuration(context.Configuration);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
