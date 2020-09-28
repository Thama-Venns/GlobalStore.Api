using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Ntvspace.GlobalStoreApi.Web.Configuration
{
  /// <summary>
  /// Provides operations to configure swagger options.
  /// </summary>
  public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
  {
    readonly IApiVersionDescriptionProvider provider;

    /// <summary>
    /// Ininializes the controller.
    /// </summary>
    /// <param name="provider"></param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
      this.provider = provider;

    /// <summary>
    /// Configures swagger document.
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
      foreach (var description in provider.ApiVersionDescriptions)
      {
        options.SwaggerDoc
        (
          description.GroupName, new OpenApiInfo()
          {
            Title = "Global Store API",
            Description = "Connecting merchants and consumers all over the world",
            Version = "v" + description.ApiVersion.ToString(),
            //TermsOfService = new Uri("https://twitter.com/ntvinn")
          }
        );
      }
    }
  }
}
