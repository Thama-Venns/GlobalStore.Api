using System;
using System.Text.Json;

namespace Ntvspace.GlobalStoreApi.Web.Core.Models
{
  /// <summary>
  /// Represents an Http Exception
  /// </summary>
  public class HttpError
  {
    /// <summary>
    /// Gets or sets the http response
    /// </summary>
    public int StatusCode { get; set; }
    /// <summary>
    /// Gets or sets the response message.
    /// </summary>
    public string Message { get; set; }

    public string ToJsonString()
    {
        return JsonSerializer.Serialize(this);
    }
    }
}
