using Ntvspace.Data.GlobalStore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStore.Data.External
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
    public ICollection<string> TimeZones { get; set; }
    public ICollection<string> Borders { get; set; }
    public double[] LatLng { get; set; }
    public ICollection<Currency> Currencies { get; set; }
    public ICollection<City> Cities { get; set; }
  }
}
