using System.Collections.Generic;

namespace Ntvspace.GlobalStoreApi.Data.Models
{
  public class CountryModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alpha3Code { get; set; }
    public string Capital { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public string Demonym { get; set; }
    public string Flag { get; set; }
    public ICollection<string> TimeZones { get; set; }
    public ICollection<string> Borders { get; set; }
    public ICollection<CurrencyModel> Currencies { get; set; }
    public double[] LatLng { get; set; }
  }
}
