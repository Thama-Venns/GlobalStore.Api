﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ntvspace.GlobalStoreApi.Web.Configuration;
using Ntvspace.GlobalStoreApi.Web.Core.Models;

namespace Ntvspace.GlobalStoreApi.Web.Extensions
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseNativeGlobalExceptionErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    // Log exception and/or run some other necessary code...

                    var errorResponse = new HttpError();

                    errorResponse.StatusCode = exception.HResult;
                    errorResponse.Message = exception.Message;

                    //if (exception is HttpException httpException)
                    //{
                    //    errorResponse.StatusCode = httpException.StatusCode;
                    //    errorResponse.Message = httpException.Message;
                    //}

                    context.Response.StatusCode = (int)errorResponse.StatusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorResponse.ToJsonString());
                });
            });

            return app;
        }

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}
