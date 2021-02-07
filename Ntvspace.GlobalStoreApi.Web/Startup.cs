using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ntvspace.GlobalStoreApi.Web.Core.Operations;
using Ntvspace.GlobalStoreApi.Web.Core.Settings;
using Ntvspace.GlobalStoreApi.Web.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Linq;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web
{
  /// <summary>
  /// Provides operations to register and configure services.
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// Initializes the constructor
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>
    /// Gets the configuration.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      }));

      services.AddControllers(o => o.EnableEndpointRouting = false);

      services.AddSingleton(Configuration.GetSection("Security").Get<Security>());
      services.Configure<ApiEndpoint>(Configuration.GetSection("ExternalApiEndpoints"));

      // Data [ DbContexts ]
      services.AddSDataExtensions(Configuration);

      // Repository registry [ Repositories, Services ]
      services.AddRepositoryExtension();

      // Security [ Authentication, Authorization ]
      services.AddSecurityExtensions(Configuration);

      // Mvc Services [ Odata, Swagger ]
      services.AddMvcExtensions();

    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// /// <param name="modelBuilder"></param>
    /// <param name="provider"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
                          VersionedODataModelBuilder modelBuilder,
                          IApiVersionDescriptionProvider provider)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors("CorsPolicy");
      app.UseAuthentication();

      // OData controller models.
      var models = modelBuilder.GetEdmModels();
      app.UseMvc(routeBuilder =>
      {
        routeBuilder.EnableDependencyInjection();
        routeBuilder.MapVersionedODataRoutes("odata", "v{version:apiVersion}", models);
        routeBuilder.Count().Filter().Select().OrderBy().Expand().SkipToken().MaxTop(null);
      });

      app.UseSwagger();
      app.UseStaticFiles();
      app.UseSwaggerUI(options =>
      {
        options.DocExpansion(DocExpansion.None);
        options.DisplayRequestDuration();
        options.DefaultModelRendering(ModelRendering.Model);
        
        options.EnableFilter();
        options.DefaultModelExpandDepth(-1);

        options.OAuthClientId(Security.ClientId);
        options.OAuthClientSecret(Security.ClientSecret);
        options.OAuthAppName(Security.ApiName);

        foreach (var description in provider.ApiVersionDescriptions)
        {
          options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            description.GroupName.ToUpperInvariant());
        }
      });
    }
  }
}
