using System.Collections.Generic;

namespace Ntvspace.Data.GlobalStore.Entities
{
  public class StoreCategory
  {
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public ICollection<Store> Stores { get; set; }
  }
}
