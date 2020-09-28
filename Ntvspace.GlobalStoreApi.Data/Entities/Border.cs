using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Border
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CountryBorder> CountryBorders { get; set; }
  }
}
