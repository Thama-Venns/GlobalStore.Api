using System.Collections.Generic;

namespace Ntvspace.Data.GlobalStore.Entities
{
  public class Store
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
  }
}
