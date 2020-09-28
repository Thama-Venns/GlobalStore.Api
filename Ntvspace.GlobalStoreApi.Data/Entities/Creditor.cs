using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Creditor
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Deleted { get; set; }
    public string Website { get; set; }
    public string Logo { get; set; }
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
  }
}
