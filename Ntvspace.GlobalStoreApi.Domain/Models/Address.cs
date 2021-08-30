namespace Ntvspace.GlobalStoreApi.Domain.Models
{
  public class Address
  {
    public int Id { get; set; }
    public string AddressLine { get; set; }
    public string AddressLine2 { get; set; }
    public string ZipCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string AddressType { get; set; }
  }
}
