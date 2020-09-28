using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Product
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public string Code { get; set; }
    public double Price { get; set; }
    public int MerchantId { get; set; }
    public virtual Merchant Merchant { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
  }
}
