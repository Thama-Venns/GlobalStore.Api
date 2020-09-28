using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStore.Data.External
{
  public class Currency
  {
    [Key]
    public string Code { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
  }
}
