using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Order
  {
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Closed { get; set; }
    public bool Cancelled { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<Product> Products { get; set; }
  }
}
