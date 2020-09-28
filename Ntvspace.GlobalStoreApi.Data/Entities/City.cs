using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class City
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int ProvinceId { get; set; }
    public virtual Province Province { get; set; }
  }
}
