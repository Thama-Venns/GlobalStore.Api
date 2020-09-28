//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.DependencyInjection;
//using Ntvspace.GlobalStoreApi.Web.Core.Repositories;
//using System;
//using System.Threading.Tasks;
//using System.Linq;
//using Microsoft.AspNet.OData;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

//namespace Ntvspace.GlobalStoreApi.Management.RedisCache
//{
//  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//  public class CacheAttribute : EnableQueryAttribute, IAsyncActionFilter
//  {
//    private Type type;

//    public CacheAttribute(Type t)
//    {
//      type = t;
//    }

//    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//    {
//      // Check if response is cached.
//      var oArgs = context.ActionArguments;

//      string cacheKey = $"{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}";
//      var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheRepository>();
//      var cacheResponse = cacheService.GetResposeAsync(cacheKey).Result;

//      if (cacheResponse != null)
//      {
//        context.Result = new ContentResult
//        {
//          Content = cacheResponse,
//          ContentType = "application/json",
//          StatusCode = 200
//        };

//        //var resp = type.GetType();
//        //var o = Activator.CreateInstance(resp);
//        //await next();
//      }

//      // Get response fetch from db and cache.
//      var result = (await next()).Result;

//      if (result is ObjectResult response)
//      {
//        await cacheService.CacheResponseAsync(cacheKey, response);
//      }
//    }
//  }
//}
