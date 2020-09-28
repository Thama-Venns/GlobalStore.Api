using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Core.ExternalApi
{
  /// <summary>
  /// Provides operations to expose basic Http methods for rest api calls
  /// </summary>
  public interface IAPIService
  {
    Task<HttpResponseMessage> PostAsync(Uri uri, string context);
    Task<HttpResponseMessage> GetAsync(Uri uri);
  }
}
