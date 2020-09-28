using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Management.Models.v1
{
  /// <summary>
  /// Represts a product.
  /// </summary>
  public class Product
  {
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the product name.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the product description.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the product code.
    /// </summary>
    public string Code { get; set; }
  }
}
