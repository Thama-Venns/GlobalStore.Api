using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Country
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alpha3Code { get; set; }
    public string Capital { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public string Demonym { get; set; }
    public string Flag { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public virtual ICollection<Province> Provinces { get; set; }
    public virtual ICollection<CountryTimeZone> CountryTimeZones { get; set; }
    public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; }
    public virtual ICollection<CountryBorder> CountryBorders { get; set; }
  }
}
