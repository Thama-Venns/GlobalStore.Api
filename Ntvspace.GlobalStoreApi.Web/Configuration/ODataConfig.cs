using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using Ntvspace.GlobalStoreApi.Management.Models.v1;
using System.Security.Claims;

namespace Ntvspace.GlobalStoreApi.Web.Configuration
{
  /// <summary>
  /// Provides the configuration for registering the OData service routes.
  /// </summary>
  public class ODataConfig : IModelConfiguration
  {
    /// <summary>
    /// Applies model configurations using the provided builder for the specified API version.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="apiVersion"></param>
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
    {
      var countries = builder.EntitySet<Country>("Countries").EntityType.HasKey(k => k.Id);
      var countryByName = builder.Function("GetCountryByName")
                                 .Returns<Country>()
                                 .Parameter<string>("name");

      var stores = builder.EntitySet<Store>("Stores").EntityType.HasKey(k => k.Id);
      var merchants = builder.EntitySet<Merchant>("Merchants").EntityType.HasKey(k => k.Id);

      var test = builder.Function("GetClaims")
                  .ReturnsCollection<string>();

      builder.Action("CreateLocations");
    }
  }
}
