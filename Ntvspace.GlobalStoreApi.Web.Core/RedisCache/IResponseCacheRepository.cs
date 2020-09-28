using System;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Core.RedisCache
{
  /// <summary>
  /// Provide operations to manage reponse caching
  /// </summary>
  public interface IResponseCacheRepository
  {
    /// <summary>
    /// Sets the response cache with custom duration.
    /// </summary>
    /// <param name="cackeKey"></param>
    /// <param name="response"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    Task SetCacheAsync(string cackeKey, object response, TimeSpan? duration);

    /// <summary>
    /// Retrieves the cached response.
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <returns></returns>
    Task<string> GetResposeAsync(string cacheKey);
  }
}
