using Microsoft.EntityFrameworkCore;
using Ntvspace.GlobalStoreApi.Data.Context;
using Ntvspace.GlobalStoreApi.Management.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Core.Operations
{
  /// <summary>
  /// Provides operations to populate lacation related entities to the db.
  /// </summary>
  public class LocationDataSeed
  {
    private readonly GlobalStoreDbContext _globalStoreDbContext;
    private readonly CountriesService _countriesService;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    /// <param name="globalStoreDbContext"></param>
    /// <param name="countriesService"></param>
    public LocationDataSeed(GlobalStoreDbContext globalStoreDbContext, CountriesService countriesService)
    {
      _globalStoreDbContext = globalStoreDbContext;
      _countriesService = countriesService;
    }

    /// <summary>
    /// Stores api results to the database.
    /// </summary>
    public void PopulateLocationData()
    {

      var results = Query().Result;

      var countries = results.Select(x => new Data.Entities.Country
      {
        Alpha3Code = x.Alpha3Code,
        Capital = x.Capital,
        Demonym = x.Demonym,
        Flag = x.Flag,
        Latitude = x.Latitude,
        Longitude = x.Longitude,
        Name = x.Name,
        Region = x.Region,
        Subregion = x.Subregion,
        CountryBorders = new List<Data.Entities.CountryBorder>(),
        CountryCurrencies = new List<Data.Entities.CountryCurrency>(),
        CountryTimeZones = new List<Data.Entities.CountryTimeZone>(),
      }); ;

      var borders = results.SelectMany(x => x.CountryBorders).Select(x => x.Border).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name);
      var timeZones = results.SelectMany(x => x.CountryTimeZones).Select(x => x.TimeZone).GroupBy(x => x.TimeZoneUtc).Select(x => x.FirstOrDefault()).OrderBy(x => x.TimeZoneUtc);
      var currencies = results.SelectMany(x => x.CountryCurrencies).Select(x => x.Currency).GroupBy(x => x.Code).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name);

      _globalStoreDbContext.Countries.AddRange(countries.Distinct());
      _globalStoreDbContext.Borders.AddRange(borders.Distinct());
      _globalStoreDbContext.TimeZones.AddRange(timeZones.Distinct());
      _globalStoreDbContext.Currencies.AddRange(currencies.Distinct());

      _globalStoreDbContext.SaveChanges();
    }

    /// <summary>
    /// Populates api relationships in the database.
    /// </summary>
    public async Task PopulateRelationShips()
    {
      var countries = ApiQuery().Result.OrderBy(x => x.Name);
      var dbcountries = _globalStoreDbContext.Countries.OrderBy(x => x.Name).ToList();

      // Populate CoutryBorders
      var borders = _globalStoreDbContext.Borders.OrderBy(x => x.Name);
      var addBorders = new List<Data.Entities.CountryBorder>();

      foreach (var country in dbcountries)
      {
        var record = countries.FirstOrDefault(x => x.Name.Equals(country.Name)).Borders;
        await borders.ForEachAsync(x =>
         {
           if (record.Contains(x.Name))
           {
             addBorders.Add(new Data.Entities.CountryBorder
             {
               BorderId = x.Id,
               CountryId = country.Id
             });
           }
         });
      }
      _globalStoreDbContext.CountryBorders.AddRange(addBorders);

      #region

      //foreach (var border in borders)
      //{
      //  var record = countries.FirstOrDefault(x => x.Borders.Contains(border.Name));
      //  if (record != null)
      //  {
      //    if(record.Borders.Any(x => x.Equals(border.Name)))
      //    {
      //      var country = dbcountries.FirstOrDefault(x => x.Name.Equals(record.Name));
      //      _globalStoreDbContext.CountryBorders.Add(new Data.Entities.CountryBorder
      //      {
      //        BorderId = border.Id,
      //        CountryId = country.Id
      //      });
      //    }
      //  }
      //}
      #endregion

      // Populate CoutryTimeZones
      var timeZones = _globalStoreDbContext.TimeZones;
      var addTimezones = new List<Data.Entities.CountryTimeZone>();
      foreach (var country in dbcountries)
      {
        var record = countries.FirstOrDefault(x => x.Name.Equals(country.Name)).TimeZones;
        await timeZones.ForEachAsync(x =>
        {
          if (record.Contains(x.TimeZoneUtc))
          {
            addTimezones.Add(new Data.Entities.CountryTimeZone
            {
              TimeZoneId = x.Id,
              CountryId = country.Id
            });
          }
        });
      }
      _globalStoreDbContext.CountryTimeZones.AddRange(addTimezones);

      #region
      //foreach (var timeZone in timeZones)
      //{
      //  var record = countries.FirstOrDefault(x => x.TimeZones.Contains(timeZone.TimeZoneUtc));

      //  if (record != null)
      //  {
      //    if (record.TimeZones.Any(x => x.Equals(timeZone.TimeZoneUtc)))
      //    {
      //      var country = dbcountries.FirstOrDefault(x => x.Name.Equals(record.Name));
      //      _globalStoreDbContext.CountryTimeZones.Add(new Data.Entities.CountryTimeZone
      //      {
      //        TimeZoneId = timeZone.Id,
      //        CountryId = country.Id,
      //      });
      //    } 
      //  }
      //}
      #endregion

      //Populate CoutryCurrencies
      var currencies = _globalStoreDbContext.Currencies;
      var addCurrencies = new List<Data.Entities.CountryCurrency>();
      foreach (var country in dbcountries)
      {
        var record = countries.FirstOrDefault(x => x.Name.Equals(country.Name)).Currencies.Select(x => x.Name);
        await currencies.ForEachAsync(x =>
        {
          if (record.Contains(x.Name))
          {
            addCurrencies.Add(new Data.Entities.CountryCurrency
            {
              CurrencyId = x.Id,
              CountryId = country.Id
            });
          }
        });
      }

      _globalStoreDbContext.CountryCurrencies.AddRange(addCurrencies);

      #region

      //foreach (var currency in currencies)
      //{
      //  var record = countries.FirstOrDefault(x => x.Currencies.Select(x => x.Code).Contains(currency.Code));

      //  if (record != null)
      //  {
      //    if (record.Currencies.Any(x => x.Equals(currency.Name ) && x.Symbol.Equals(currency.Symbol)))
      //    {
      //      var country = dbcountries.FirstOrDefault(x => x.Name.Equals(record.Name));
      //      _globalStoreDbContext.CountryCurrencies.Add(new Data.Entities.CountryCurrency
      //      {
      //        CurrencyId = currency.Id,
      //        CountryId = country.Id
      //      });
      //    }
      //  }
      //}
      #endregion
      await _globalStoreDbContext.SaveChangesAsync();

    }

    /// Maps api results to entity model.
    private async Task<IQueryable<Data.Entities.Country>> Query()
    {
      var ApiResults = await ApiQuery();
      var etResults = from c in ApiResults
                      select new Data.Entities.Country
                      {
                        Name = c.Name,
                        Subregion = c.Subregion,
                        Capital = c.Capital,
                        Alpha3Code = c.Alpha3Code,
                        Demonym = c.Demonym,
                        Flag = c.Flag,
                        Region = c.Region,
                        Latitude = c.LatLng.FirstOrDefault(),
                        Longitude = c.LatLng.Skip(1).FirstOrDefault(),
                        CountryBorders = (from cb in c.Borders
                                          select new Data.Entities.CountryBorder
                                          {
                                            Border = new Data.Entities.Border
                                            {
                                              Name = cb
                                            }
                                          }).ToList(),
                        //Cities = new List<Data.Entities.City>(),
                        CountryCurrencies = (from x in c.Currencies
                                             select new Data.Entities.CountryCurrency
                                             {
                                               Currency = new Data.Entities.Currency
                                               {
                                                 Name = x.Name,
                                                 Code = x.Code,
                                                 Symbol = x.Symbol
                                               }
                                             }).ToList(),
                        CountryTimeZones = (from ctz in c.TimeZones
                                            select new Data.Entities.CountryTimeZone
                                            {
                                              TimeZone = new Data.Entities.TimeZone
                                              {
                                                TimeZoneUtc = ctz
                                              }
                                            }).ToList()
                      };

      return etResults;
    }

    /// Retrieves api results.
    private async Task<IQueryable<Data.Models.CountryModel>> ApiQuery()
    {
      return await _countriesService.GetCountriesAsync();
    }
  }
}
