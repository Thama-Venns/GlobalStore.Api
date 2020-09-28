using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Store
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Website { get; set; }
    public int AddressId { get; set; }
    public int MerchantId { get; set; }
    public virtual Address Address { get; set; }
    public virtual Merchant Merchant { get; set; }
  }
}
