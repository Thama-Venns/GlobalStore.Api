using Ntvspace.GlobalStore.Data.External;

namespace Ntvspace.Data.GlobalStore.Entities
{
  public class City
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }
  }
}
