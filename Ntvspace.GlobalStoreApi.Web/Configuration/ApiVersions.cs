using Microsoft.AspNetCore.Mvc;

namespace Ntvspace.GlobalStoreApi.Web.Configuration
{
  /// <summary>
  /// Represents an api version.
  /// </summary>
  public static class ApiVersions
  {
    /// <summary>
    /// Represents api version 1.0
    /// </summary>
    internal static ApiVersion v1 = new ApiVersion(1, 0);
    /// <summary>
    /// Represents api version 2.0
    /// </summary>
    internal static ApiVersion v2 = new ApiVersion(2, 0);
  }
}
