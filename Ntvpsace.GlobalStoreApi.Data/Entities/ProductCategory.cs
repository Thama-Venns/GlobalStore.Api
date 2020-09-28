using System.Collections.Generic;

namespace Ntvspace.Data.GlobalStore.Entities
{
  public class ProductCategory
  {
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public ICollection<Product> Products { get; set; }
  }
}
