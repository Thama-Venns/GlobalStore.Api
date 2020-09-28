namespace Ntvspace.GlobalStoreApi.Web.Core.Settings
{
  /// <summary>
  /// Represents api authorisations
  /// </summary>
  public class Security
  {

    /// <summary>
    /// Gets or sets the OAuth authority
    /// </summary>
    public static string Authority { get; set; }

    /// <summary>
    /// Gets or sets the audience
    /// </summary>
    public static string Audience { get; set; }

    /// <summary>
    /// Gets or sets the client id
    /// </summary>
    public static string ClientId { get; set; }

    /// <summary>
    /// Gets or sets the client secret
    /// </summary>
    public static string ClientSecret { get; set; }

    /// <summary>
    /// Gets or sets the authorize endpoint
    /// </summary>
    public static string AuthorizationUrl { get; set; }

    /// <summary>
    /// Gets or sets the token endpoint
    /// </summary>
    public static string TokenUrl { get; set; }

    /// <summary>
    /// Gets or sets the authorize endpoint
    /// </summary>
    public static string ApiName { get; set; }
  }
}
