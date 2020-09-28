namespace Ntvspace.GlobalStoreApi.Management.Models
{
  /// <summary>
  /// Represents a time zone.
  /// </summary>
  public class TimeZone
  {
    /// <summary>
    /// Gets or sets Timezone identifier.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the timezone name.
    /// </summary>
    public string TimeZoneUtc { get; set; }
  }
}
