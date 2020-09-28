using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Pricing
  {
    public double Price { get; set; }
    public int ProductId { get; set; }
    public int CurrencyId { get; set; }
    public virtual Product Product { get; set; }
    public virtual Currency Currency { get; set; }
  }
}
