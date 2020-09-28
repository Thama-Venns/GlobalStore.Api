using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class ProductCategory
  {
    [Key]
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual Product Product { get; set; }
  }
}
