using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class MerchantClassification
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
