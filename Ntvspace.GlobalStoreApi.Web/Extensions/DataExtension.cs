using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ntvspace.GlobalStoreApi.Data.Context;
using Ntvspace.GlobalStoreApi.Web.Core.RedisCache;
using Ntvspace.GlobalStoreApi.Web.Core.Settings;

namespace Ntvspace.GlobalStoreApi.Web.Extensions
{
  /// <summary>
  /// Provides operations to register Data services to DI.
  /// </summary>
  public static class DataExtension
  {
    /// <summary>
    /// Add Data services to DI.
    /// </summary>
    public static void AddSDataExtensions(this IServiceCollection services, IConfiguration configuration)
    {
      // Database Context(s)
      services.AddDbContext<GlobalStoreDbContext>(options =>
                       options.UseLazyLoadingProxies()
                       .UseSqlServer(configuration.GetConnectionString("GlobalStoreDbContext"), x =>
                       {
                         x.MigrationsAssembly(typeof(GlobalStoreDbContext).Assembly.FullName);
                         x.CommandTimeout(200);
                       })/*, ServiceLifetime.Transient*/);

      // Redis Cache
      services.AddSingleton(configuration.GetSection("RedisCacheSettings").Get<RedisCacheSettings>());

      services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost");
      services.AddScoped(typeof(IResponseCacheRepository), typeof(ResponseCacheService));
    }
  }
}
