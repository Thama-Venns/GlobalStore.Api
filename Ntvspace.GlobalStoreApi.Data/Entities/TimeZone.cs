using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class TimeZone
  {
    [Key]
    public int Id { get; set; }
    public string TimeZoneUtc { get; set; }
    public virtual ICollection<CountryTimeZone> CountryTimeZones { get; set; }
  }
}
