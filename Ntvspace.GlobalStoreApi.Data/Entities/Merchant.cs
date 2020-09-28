using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Merchant
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public int MerchantClassificationId { get; set; }
    public virtual MerchantClassification MerchantClassification { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Store> Stores { get; set; }
  }
}
