using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Ntvspce.GlobalStoreApi.Application.Search.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Management.Controllers.v1
{
    /// <summary>
    /// Provides operations to search global store.
    /// </summary>
    [SwaggerTag("Provides operations to search entities.")]
    public class SearchController: ODataController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes controller.
        /// </summary>
        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve global search results.
        /// </summary>
        /// <param name="searchKey"></param>
        [EnableQuery]
        public async Task<IActionResult> Get(string searchKey)
        {
            var searchResults = await _mediator.Send(new GlobalSearchQuery { Keyword = searchKey });
            return Ok(searchResults);
        }
    }
}
