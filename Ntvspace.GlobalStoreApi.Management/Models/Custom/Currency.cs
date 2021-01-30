using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Management.Models
{
  /// <summary>
  /// Represents a country's currency.
  /// </summary>
  public class Currency
  {
    [Key]
    /// <summary>
    /// Gets or sets the currency code.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the currency name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol.
    /// </summary>
    public string Symbol { get; set; }
  }
}
