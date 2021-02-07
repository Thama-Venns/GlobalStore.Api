using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ntvspace.GlobalStoreApi.Management.Models.Mappers;
using Ntvspace.GlobalStoreApi.Management.Models.v1;
using Ntvspace.GlobalStoreApi.Web.Core.Authorization;
using Ntvspace.GlobalStoreApi.Web.Core.RedisCache;
using Ntvspace.GlobalStoreApi.Web.Core.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace Ntvspace.GlobalStoreApi.Management.Controllers.v1
{
  /// <summary>
  /// Provides operations to manage countries.
  /// </summary>
  [ApiVersion("1.0")]
  [SwaggerTag("Provides operations to manage countries.")]
  [Authorize(Policy = Policy.UsecurePolicy)]
  [Produces("application/json")]
  public class CountriesController : ODataController
  {
    private readonly ICountriesRepository _countriesRepository;
    private readonly IResponseCacheRepository _responseCacheRepository;
    private readonly string _cackeKey;

    /// <summary>
    /// Initiates the controller.
    /// </summary>
    /// <param name="countriesRepository"></param>
    /// <param name="responseCacheRepository"></param>
    public CountriesController(ICountriesRepository countriesRepository, IResponseCacheRepository responseCacheRepository)
    {
      _countriesRepository = countriesRepository;
      _responseCacheRepository = responseCacheRepository;
      _cackeKey = "countries";
    }

    /// <summary>
    /// Retrieves a list of countries.
    /// </summary>
    /// <returns></returns>
    [EnableQuery]
    [Produces("application/json")]
    public IQueryable<Country> Get() => Query();

    /// <summary>
    /// Retrieves a list of countries.
    /// </summary>
    /// <param name="key">country name</param>
    /// <returns></returns>
    [EnableQuery]
    public SingleResult<Country> Get([FromODataUri]int key)
    {
      var mapper = new CountryMapper();
      var country = from c in DbQuery().Where(x => x.Id.Equals(key))
                    select mapper.FromEntity(c);

      return SingleResult.Create(country);
    }

    /// <summary>
    /// Retrieves a country by name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [EnableQuery]
    [ODataRoute("GetCountryByName")]
    public Country GetCountryByName([FromODataUri] string name)
    {
      var mapper = new CountryMapper();
      var country = mapper.FromEntity(DbQuery().FirstOrDefault(x => x.Name.Equals(name)));

      return country;
    }

    private IQueryable<Country> Query()
    {
      var mapper = new CountryMapper();
      var coutries = from c in DbQuery()
                     select mapper.FromEntity(c);

      return coutries.AsQueryable();
    }

    private IQueryable<Data.Entities.Country> DbQuery()
    {
      var cachedResponse = _responseCacheRepository.GetResposeAsync(_cackeKey).Result;

      if (string.IsNullOrEmpty(cachedResponse))
      {
        var dbCountries = _countriesRepository.GetAll();
        _responseCacheRepository.SetCacheAsync(_cackeKey, dbCountries, null);
        return dbCountries.AsQueryable();
      }

      var cacheResult = JsonConvert.DeserializeObject<List<Data.Entities.Country>>(cachedResponse);

      return cacheResult.AsQueryable();
    }
  }
}
