namespace Ntvspace.GlobalStoreApi.Web.Core.Authorization
{
  /// <summary>
  /// Represents Authorization policies.
  /// </summary>
  public static class Policy
  {
    /// <summary>
    /// Sets the standard Usecure Authorization policy
    /// </summary>
    public const string UsecurePolicy = "USecureAuthorizationPolicy";

    /// <summary>
    /// Sets the standard SPA Client Authorization policy
    /// </summary>
    public const string ClientPolicy = "ClientAuthorizationPolicy";
   }
}
