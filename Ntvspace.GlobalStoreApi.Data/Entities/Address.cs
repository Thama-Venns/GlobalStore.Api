using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Address
  {
    [Key]
    public int Id { get; set; }
    public string AddressLine { get; set; }
    public string AddressLine2 { get; set; }
    public string ZipCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int CityId { get; set; }
    public int AddressTypeId { get; set; }
    public virtual City City { get; set; }
    public virtual AddressType AddressType { get; set; }
  }
}
