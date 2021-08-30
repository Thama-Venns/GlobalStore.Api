using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ntvspace.GlobalStoreApi.Web.Core.Authorization;
using Ntvspace.GlobalStoreApi.Web.Core.Settings;

namespace Ntvspace.GlobalStoreApi.Web.Extensions
{
  /// <summary>
  /// Provides operations to register Security services to DI.
  /// </summary>
  public static class SecurityExtension
  {
    /// <summary>
    /// Add Security services to DI.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddSecurityExtensions(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.Authority = Security.Authority;
          options.Audience = Security.ApiName;
          options.RequireHttpsMetadata = false;
        });

      services.AddAuthorization(options =>
      {
        options.AddPolicy(Policy.UsecurePolicy, requirement =>
        {
          requirement.AddRequirements(
            new UsecureAuthorizationRequirement());
        });
        options.AddPolicy(Policy.ClientPolicy, requirement => {
            requirement.RequireScope("globalApi");
        });
      });

      services.AddScoped<IAuthorizationHandler, UsecureAuthorizationHandler>();
    }
  }
}
