using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Province
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<City> Cities { get; set; }
  }
}
