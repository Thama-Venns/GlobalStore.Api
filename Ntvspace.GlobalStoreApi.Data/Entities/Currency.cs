using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Currency
  {
    [Key]
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; }
  }
}
