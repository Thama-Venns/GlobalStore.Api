using Ntvspace.GlobalStoreApi.Management.Models.v1;
using System.Linq;

namespace Ntvspace.GlobalStoreApi.Management.Models.Mappers
{
  /// <summary>
  /// Provides operations to map data from/to a rest api and model object.
  /// </summary>
  public class CountryMapper
  {
    /// <summary>
    /// Maps data retrieved from an external rest api to a model object.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public Country FromApi(Data.Models.CountryModel source)
    {
      var target = new Country
      {
                     Name = source.Name,
                     Alpha3Code = source.Alpha3Code,
                     Capital = source.Capital,
                     Demonym = source.Demonym,
                     Region = source.Region,
                     Subregion = source.Subregion,
                     Flag = source.Flag,
                     TimeZones = source.TimeZones.Select(x => new TimeZone { TimeZoneUtc = x }),
                     Longitude = source.LatLng.FirstOrDefault(),
                     Latitude = source.LatLng.Skip(1).FirstOrDefault(),
                     Borders = source.Borders.Select(x => new Border { Name = x }),
                     Currencies = (from cur in source.Currencies
                                  select new Currency
                                  {
                                    Code = cur.Code,
                                    Name = cur.Name,
                                    Symbol = cur.Symbol
                                  }).Distinct(),
                    };

      return target;
    }

    /// <summary>
    /// Maps data retrieved from an external rest api to a model object.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public Country FromEntity(Data.Entities.Country source)
    {
      var target = new Country
      {
        Id = source.Id,
        Name = source.Name,
        Alpha3Code = source.Alpha3Code,
        Capital = source.Capital,
        Demonym = source.Demonym,
        Region = source.Region,
        Subregion = source.Subregion,
        Flag = source.Flag,
        Longitude = source.Longitude,
        Latitude = source.Latitude,
        TimeZones = source.CountryTimeZones.Select(x => x.TimeZone).Select(x => new TimeZone { Id = x.Id, TimeZoneUtc = x.TimeZoneUtc }),
        Borders = source.CountryBorders.Select(x => x.Border).Select(x => new Border { Id = x.Id, Name = x.Name }),
        Currencies = (from cur in source.CountryCurrencies.Select(x => x.Currency)
                      select new Currency
                      {
                        Code = cur.Code,
                        Name = cur.Name,
                        Symbol = cur.Symbol
                      })
      };

      return target;
    }
  }
}
