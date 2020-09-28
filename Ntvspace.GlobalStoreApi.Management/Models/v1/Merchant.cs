using System.Collections.Generic;

namespace Ntvspace.GlobalStoreApi.Management.Models.v1
{
  /// <summary>
  /// Represents a merchant
  /// </summary>
  public class Merchant
  {
    /// <summary>
    /// Gets or sets the merchant identifier.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the merchant name.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the website.
    /// </summary>
    public string Website { get; set; }
    /// <summary>
    /// Gets or sets the merchant description
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the merchant logo.
    /// </summary>
    public string Logo { get; set; }
    /// <summary>
    /// Gets or sets the merchant classification.
    /// </summary>
    public  string MerchantClassification { get; set; }
    /// <summary>
    /// Gets or sets the merchant addresses.
    /// </summary>
    public IEnumerable<Address> Addresses { get; set; }
    /// <summary>
    /// Gets or sets merchant stores.
    /// </summary>
    public IEnumerable<Store> Stores { get; set; }
  }
}
