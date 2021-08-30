using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Domain.Models
{
  /// <summary>
  /// Represents a branch.
  /// </summary>
  public class Branch
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string ZipCode { get; set; }
    public string Province { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

  }
}
