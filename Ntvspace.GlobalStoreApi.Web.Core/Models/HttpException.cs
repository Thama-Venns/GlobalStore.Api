using System;
using System.Collections.Generic;
using System.Text;

namespace Ntvspace.GlobalStoreApi.Web.Core.Models
{
  /// <summary>
  /// Descricribes an Http Exception
  /// </summary>
  public class HttpException
  {
    /// <summary>
    /// Gets or sets the http response
    /// </summary>
    public int StatusCode { get; set; }
    /// <summary>
    /// Gets or sets the response message.
    /// </summary>
    public string Message { get; set; }
  }
}
