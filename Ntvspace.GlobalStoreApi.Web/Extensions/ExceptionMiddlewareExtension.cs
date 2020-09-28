using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ntvspace.GlobalStoreApi.Web.Core.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Extensions
{
  /// <summary>
  /// Provides operations to handle exceptions.
  /// </summary>
  public class ExceptionMiddlewareExtension
  {
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    /// <param name="requestDelegate"></param>
    /// <param name="logger"></param>
    public ExceptionMiddlewareExtension(RequestDelegate requestDelegate, ILogger logger)
    {
      _next = requestDelegate;
      _logger = logger;
    }

    /// <summary>
    /// Invoke request handling.
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      } catch(Exception e)
      {
        await HandleExceptionAsync(httpContext, e);
      }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      HttpException exception = new HttpException
      {
        StatusCode = context.Response.StatusCode,
        Message = e.Message
      };

      return context.Response.WriteAsync(exception.ToString());
    }
  }
}
