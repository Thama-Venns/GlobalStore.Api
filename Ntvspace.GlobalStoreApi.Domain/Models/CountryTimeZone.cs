namespace Ntvspace.GlobalStoreApi.Domain.Models
{
  /// <summary>
  /// Represents a country timezone.
  /// </summary>
  public class CountryTimeZone
  {
    /// <summary>
    /// Gets or sets a country timezone.
    /// </summary>
    public string TimeZone { get; set; }
    /// <summary>
    /// Gets or sets a country.
    /// </summary>
    public Country Country { get; set; }
  }
}
