using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ntvspace.GlobalStoreApi.Management.Services;
using Ntvspace.GlobalStoreApi.Web.Core.ExternalApi;
using Ntvspace.GlobalStoreApi.Web.Domain.Operations;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspace.GlobalStoreApi.Web.Domain.Services;

namespace Ntvspace.GlobalStoreApi.Web.Extensions
{
  /// <summary>
  /// Adds repositories to DI on startup.
  /// </summary>
  public static class RepositoryRegistryExtension
  {
    /// <summary>
    /// Adds all repositories to DI
    /// </summary>
    /// <param name="services"></param>
    public static void AddRepositoryExtension(this IServiceCollection services)
    {
      // Services
      services.AddScoped(typeof(LocationDataSeed));
      services.AddScoped(typeof(CountriesService));

      //Repositories
      services.AddScoped(typeof(IGlobalRepository), typeof(GlobalRepository));
      services.AddScoped(typeof(IAPIService), typeof(APIService));
      services.AddScoped(typeof(ILocationsRepository), typeof(LocationsRepositoryService));
      services.AddScoped(typeof(ICountriesRepository), typeof(CountriesRepositoryService));
      services.AddScoped(typeof(IMerchantsRepository), typeof(MerchantsRepository));
    }
  }
}
