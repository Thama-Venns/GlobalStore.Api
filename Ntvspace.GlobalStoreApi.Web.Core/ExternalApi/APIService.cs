using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Core.ExternalApi
{
  /// <summary>
  /// Provides operations to make basic Http calls
  /// </summary>
  public class APIService : IAPIService
  {
    /// <summary>
    /// Makes a GET Request to an external rest api
    /// </summary>
    /// <returns></returns>
    public async Task<HttpResponseMessage> GetAsync(Uri uri)
    {
      using (var httpClient = new HttpClient())
      {
        string url = uri.ToString();
        httpClient.BaseAddress = new Uri(url);

        var response = await httpClient.GetAsync(url).ConfigureAwait(false);
        return response;
      }
    }

    /// <summary>
    /// Makes a POST Request to an external rest api
    /// </summary>
    /// <returns></returns>
    public async Task<HttpResponseMessage> PostAsync(Uri uri, string content)
    {
      using (var httpClient = new HttpClient())
      {
        string url = uri.ToString();
        httpClient.BaseAddress = new Uri(url);

        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(url, stringContent).ConfigureAwait(false);
        return response;
      }
    }
  }
}
