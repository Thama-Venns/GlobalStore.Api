using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Ntvspace.GlobalStoreApi.Web.Configuration;
using Ntvspace.GlobalStoreApi.Web.Core.Settings;
using Ntvspace.GlobalStoreApi.Web.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ntvspace.GlobalStoreApi.Web.Extensions
{
  /// <summary>
  /// Provides operations to register Mvc services to DI.
  /// </summary>
  public static class MvcExtension
  {
    /// <summary>
    /// Add Mvc services to DI.
    /// </summary>
    public static void AddMvcExtensions(this IServiceCollection services)
    {
      services.AddApiVersioning(options => options.ReportApiVersions = true);
      services.AddOData().EnableApiVersioning();
      services.AddODataApiExplorer(options =>
      {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
      });
      services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

      services.AddSwaggerGen(options =>
      {
        options.OperationFilter<SwaggerDefaultValues>();
        options.EnableAnnotations();

        options.IncludeXmlComments(Path.Combine(XmlCommentsFilePath, "Ntvspace.GlobalStoreApi.Web.xml"));
        options.IncludeXmlComments(Path.Combine(XmlCommentsFilePath, "Ntvspace.GlobalStoreApi.Management.xml"));

        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
          Type = SecuritySchemeType.OAuth2,
          Flows = new OpenApiOAuthFlows
          {
            Implicit = new OpenApiOAuthFlow
            {
              AuthorizationUrl = new Uri(Security.AuthorizationUrl, UriKind.Absolute),
              TokenUrl = new Uri(Security.TokenUrl, UriKind.Absolute),
              Scopes = new Dictionary<string, string>
              {
                { "globalApi", "Access api information"},
                { "read", "Access identity information"},
                { "write", "GlobalApi Read Access" }
              }
            }
          }
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            },
            new[] { "globalApi", "read", "write" }
          }
        });
      });
    }

    static string XmlCommentsFilePath
    {
      get
      {
        var basePath = PlatformServices.Default.Application.ApplicationBasePath;
        return basePath;
      }
    }

  }
}
