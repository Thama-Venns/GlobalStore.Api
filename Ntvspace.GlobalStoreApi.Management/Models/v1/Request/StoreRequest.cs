namespace Ntvspace.GlobalStoreApi.Management.Models.v1.Request
{
  /// <summary>
  /// Represents a store request.
  /// </summary>
  public class StoreRequest
  {
    /// <summary>
    /// Gets or sets the store identifier.
    /// </summary>
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
    /// Gets or sets the store description.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets a provice.
    /// </summary>
    public string Province { get; set; }
    /// <summary>
    /// Gets or sets the store address line 1.
    /// </summary>
    public string AddressLine { get; set; }
    /// <summary>
    /// Gets or sets the store address line 2.
    /// </summary>
    public string AddressLine2 { get; set; }
    /// <summary>
    /// Gets or sets the zip code.
    /// </summary>
    public string ZipCode { get; set; }
    /// <summary>
    /// Gets or sets the latitude.
    /// </summary>
    public double Latitude { get; set; }
    /// <summary>
    /// Gets or sets the longitude.
    /// </summary>
    public double Longitude { get; set; }
    /// <summary>
    /// Gets or sets the address type.
    /// </summary>
    public int AddressTypeId { get; set; }
    /// <summary>
    /// Gets or sets the identifier for merchant classification.
    /// </summary>
    public int MerchantClassificationId { get; set; }
    /// <summary>
    /// Gets or sets the company name.
    /// </summary>
    public string Merchant { get; set; }
    /// <summary>
    /// Gets or sets the company description.
    /// </summary>
    public string MerchantDescription { get; set; }
    /// <summary>
    /// Gets or sets the company website.
    /// </summary>
    public string CompanyWebsite { get; set; }
    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Gets or sets the country id.
    /// </summary>
    public int CountryId { get; set; }
    
  }
}