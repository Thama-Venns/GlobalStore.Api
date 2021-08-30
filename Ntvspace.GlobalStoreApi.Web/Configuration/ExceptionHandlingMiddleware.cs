using Microsoft.AspNetCore.Http;
using Ntvspace.GlobalStoreApi.Web.Core.Models;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Configuration
{
    /// <summary>
    /// Provides operations to handle exceptions.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes the constructor.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
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
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            HttpError exception = new HttpError
            {
                StatusCode = context.Response.StatusCode,
                Message = e.Message
            };

            _logger.Error(e, e.Message);

            return context.Response.WriteAsync(exception.ToJsonString());
        }
    }
}
