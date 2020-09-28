namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class CountryTimeZone
  {
    public int CountryId { get; set; }
    public int TimeZoneId { get; set; }
    public virtual Country Country { get; set; }
    public virtual TimeZone TimeZone { get; set; }
  }
}
