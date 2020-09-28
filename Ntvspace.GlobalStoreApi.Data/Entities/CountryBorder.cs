namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class CountryBorder
  {
    public int CountryId { get; set; }
    public int BorderId { get; set; }
    public virtual Border Border { get; set; }
    public virtual Country Country { get; set; }
  }
}
