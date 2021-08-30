using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Domain.Models
{
  /// <summary>
  /// Represents a store.
  /// </summary>
  public class Location
  {
    /// <summary>
    /// Gets or sets the store identifier.
    /// </summary>
    [Key] 
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the store name.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the store website.
    /// </summary>
    public string Website { get; set; }
    /// <summary>
    /// Gets or sets the store image.
    /// </summary>
    public string Image { get; set; }
    /// <summary>
    /// Gets or sets the store description.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the store address.
    /// </summary>
    public Address Address { get; set; }
    /// <summary>
    /// Gets or sets the Merchant
    /// </summary>
    public Merchant Merchant { get; set; }
    /// <summary>
    /// Gets or sets the products
    /// </summary>
    public IEnumerable<Product> Products { get; set; }
  }
}