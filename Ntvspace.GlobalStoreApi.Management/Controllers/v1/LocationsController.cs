using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Domain.Models.Requests;
using Ntvspace.GlobalStoreApi.Web.Core.Authorization;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Locations.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Management.Controllers.v1
{
    /// <summary>
    /// Provides operations to manage stores.
    /// </summary>
    [ApiVersion("1.0")]
    [SwaggerTag("Provides operations to manage stores.")]
    [Authorize(Policy = Policy.UsecurePolicy)]

    public class LocationsController : ODataController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes the controller.
        /// </summary>
        /// <param name="mediator"></param>
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        /// <summary>
        /// Retrieves a list of store details
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public async Task<IQueryable<Location>> Get()
        {
            return await _mediator.Send(new GetLocationsQuery());
        }

        /// <summary>
        /// Rereieves a store/location's details
        /// </summary>
        /// <param name="key">loationId</param>
        /// <returns></returns>
        [EnableQuery]
        public async Task<SingleResult<Location>> Get(int key)
        {
            return await _mediator.Send(new GetLocationByKeyQuery() { LoationId = key });
        }

        /// <summary>
        /// Rereieves a store/location's details
        /// </summary>
        /// <param name="merchantId">merchantId</param>
        /// <returns></returns>
        [EnableQuery]
        public async Task<IQueryable<Location>> GetMerchantLocations(int merchantId)
        {
            return await _mediator.Send(new GetMerchantLocationsQuery() { MerchantId = merchantId });
        }

        /// <summary>
        /// Creates a new store.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public IActionResult Post([FromBody] StoreRequest model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

            
        //}
    }
}
