namespace Ntvspace.GlobalStoreApi.Web.Core.Settings
{
  /// <summary>
  /// Represents redis caching properties.
  /// </summary>
  public class RedisCacheSettings
  {
    /// <summary>
    /// Gets the redis cache enabled flag.
    /// </summary>
    public static bool Enabled { get; }
    /// <summary>
    /// Gets the redis cache connection string
    /// </summary>
    public static string  ConnectionString { get; }
  }
}
