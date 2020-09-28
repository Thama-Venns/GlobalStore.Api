using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ntvspace.GlobalStoreApi.Web.Core.ExternalApi;
using Ntvspace.GlobalStoreApi.Web.Core.Settings;

namespace Ntvspace.GlobalStoreApi.Management.Services
{
  /// <summary>
  /// Provides operations to manage countries.
  /// </summary>
  public class CountriesService
  {
    private readonly IAPIService _apiService;
    private readonly IOptions<ApiEndpoint> _options;

    /// <summary>
    /// Initiates the constructor.
    /// </summary>
    /// <param name="apiService"></param>
    public CountriesService(IAPIService apiService, IOptions<ApiEndpoint> options)
    {
      _apiService = apiService;
      _options = options;
    }

    /// <summary>
    /// Retrieves a list of countries from external api.
    /// </summary>
    /// <returns></returns>
    public async Task<IQueryable<Data.Models.CountryModel>> GetCountriesAsync()
    {
      Uri uri = new Uri(_options.Value.RestCountriesEndpoint + "all");
      var response = await _apiService.GetAsync(uri);

      if (!response.IsSuccessStatusCode)
      {
        return Enumerable.Empty<Data.Models.CountryModel>().AsQueryable();
      }

      var result = (response.Content).ReadAsStringAsync().Result;
      var countries = JsonConvert.DeserializeObject<List<Data.Models.CountryModel>>(result);
      return countries.AsQueryable();
    }

    public async Task<IQueryable<Data.Models.CountryModel>> GetCountryByNameAsync(string countryName)
    {
      Uri uri = new Uri(_options.Value.RestCountriesEndpoint + "name/" + countryName);
      var response = await _apiService.GetAsync(uri);

      var result = (response.Content).ReadAsStringAsync().Result;
      var country = JsonConvert.DeserializeObject<List<Data.Models.CountryModel>>(result);

      return country.AsQueryable();
    }
  }
}
