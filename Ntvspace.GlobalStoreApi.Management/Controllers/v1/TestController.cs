//using Microsoft.AspNet.OData;
//using Microsoft.AspNet.OData.Routing;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Ntvspace.GlobalStoreApi.Web.Core.Authorization;
//using Ntvspace.GlobalStoreApi.Web.Domain.Operations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Ntvspace.GlobalStoreApi.Management.Controllers.v1
//{
//  /// <summary>
//  /// Provides operations to test stuff.
//  /// </summary>
//  [Authorize(Policy = Policy.UsecurePolicy)]
//  public class TestController : ODataController
//  {
//    private readonly LocationDataSeed _locationDataSeed;

//    /// <summary>
//    /// Initializes the controller.
//    /// </summary>
//    public TestController(LocationDataSeed locationDataSeed)
//    {
//      _locationDataSeed = locationDataSeed;
//    }

//    /// <summary>
//    /// Gets user info.
//    /// </summary>
//    [ODataRoute("GetClaims")]
//    public IEnumerable<string> GetClaims()
//    {
//      var user = User.Claims.Select(x => x.Value);
//      return user;
//    }

//    /// <summary>
//    /// Create locations.
//    /// </summary>
//    /// <returns></returns>
//    [ODataRoute("CreateLocations")]
//    public async Task<IActionResult> CreateLocations()
//    {
//      try
//      {
//        _locationDataSeed.PopulateLocationData();
//        await _locationDataSeed.PopulateRelationShips();
//      } catch(Exception e)
//      {
//        return BadRequest(e);
//      }
//      return Ok();
//    }
//  }
//}
