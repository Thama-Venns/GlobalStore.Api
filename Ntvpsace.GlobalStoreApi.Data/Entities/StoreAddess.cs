namespace Ntvspace.Data.GlobalStore.Entities
{
  public class StoreAddess
  {
    public int Id { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public City City { get; set; }
  }
}
