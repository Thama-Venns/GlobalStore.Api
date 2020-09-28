using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Management.Models.v1
{
  /// <summary>
  /// Represents a country
  /// </summary>
  public class Country
  {
    /// <summary>
    /// Gets or sets the country identifier.
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the country name.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the country alpha3code.
    /// </summary>
    public string Alpha3Code { get; set; }
    /// <summary>
    /// Gets or sets the country's capital city.
    /// </summary>
    public string Capital { get; set; }
    /// <summary>
    /// Gets or sets the country region.
    /// </summary>
    public string Region { get; set; }
    /// <summary>
    /// Gets or sets the country subregion.
    /// </summary>
    public string Subregion { get; set; }
    /// <summary>
    /// Gets or sets the country citizen demonym.
    /// </summary>
    public string Demonym { get; set; }
    /// <summary>
    /// Gets or sets the country's flag (image).
    /// </summary>
    public string Flag { get; set; }
    /// <summary>
    /// Gets or sets the country's position latitude.
    /// </summary>
    public double Latitude { get; set; }
    /// <summary>
    /// Gets or sets the country's position longitude.
    /// </summary>
    public double Longitude { get; set; }
    /// <summary>
    /// Gets or sets the country's time zone(s).
    /// </summary>
    public IEnumerable<TimeZone> TimeZones { get; set; }
    /// <summary>
    /// Gets or sets the country's borders.
    /// </summary>
    public IEnumerable<Border> Borders { get; set; }
    /// <summary>
    /// Gets or sets the country's currency(s).
    /// </summary>
    public IEnumerable<Currency> Currencies { get; set; }
  }
}
