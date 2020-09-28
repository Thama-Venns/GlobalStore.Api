using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Core.RedisCache
{
  /// <summary>
  /// Provide operations to manage reponse caching
  /// </summary>
  public class ResponseCacheService : IResponseCacheRepository
  {
    private readonly IDistributedCache _distributedCache;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    /// <param name="distributedCache"></param>
    public ResponseCacheService(IDistributedCache distributedCache)
    {
      _distributedCache = distributedCache;
    }

    /// <summary>
    /// Sets the response cache.
    /// </summary>
    /// <param name="cackeKey"></param>
    /// <param name="response"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public async Task SetCacheAsync(string cackeKey, object response, TimeSpan? duration)
    {
      await SetCache(cackeKey, response, duration);
    }

    /// <summary>
    /// Retrieves the cached response.
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <returns></returns>
    public async Task<string> GetResposeAsync(string cacheKey)
    {
      var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
      
      return cachedResponse;
    }

    private async Task SetCache(string cackeKey, object response, TimeSpan? duration)
    {
      if (response.Equals(null)) return;

      var serializeObject = JsonConvert.SerializeObject(response);

      duration = !duration.HasValue ? new TimeSpan(12, 0, 0) : duration;
      var options = new DistributedCacheEntryOptions
      {
        AbsoluteExpirationRelativeToNow = duration
      };
      
      await _distributedCache.SetStringAsync(cackeKey, serializeObject, options);
    }
  }
}
