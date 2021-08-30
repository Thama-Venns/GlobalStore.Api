using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ntvspace.GlobalStoreApi.Domain.Requests;
using Ntvspace.GlobalStoreApi.Web.Core.Authorization;
using Ntvspce.GlobalStoreApi.Application.Merchants.Commands;
using Ntvspce.GlobalStoreApi.Application.Merchants.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Management.Controllers.v1
{
  /// <summary>
  /// Provides operations to manage merchants.
  /// </summary>
  [ApiVersion("1.0")]
  [SwaggerTag("Provides operations to manage merchants.")]
  [Authorize(Policy = Policy.UsecurePolicy)]
  public class MerchantsController : ODataController
  {
    private readonly IMediator _mediator;
    
    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    /// <param name="mediator"></param>
    public MerchantsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Provides operations to retrieve merchants.
    /// </summary>
    /// <returns></returns>
    [EnableQuery]
    public async Task<IActionResult> Get()
    {
        var merchants = await _mediator.Send(new GetAllMerchantsQuery());
        return Ok(merchants);
    }

    /// <summary>
    /// Retrieves a single merchant with specified id.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [EnableQuery]
    public SingleResult Get(int key)
    {
        var result = _mediator.Send(new GetMerchantQuery() { MerchantId = key }).Result;
        return result;
    }

    /// <summary>
    /// Creates a new merchant.
    /// </summary>
    /// <param name="model">Merchant Request</param>
    /// <returns></returns>
    public async Task<IActionResult> Post([FromBody] MerchantRequest model)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest();
      }

      var command = new CreateMerchantCommand() { Merchant = model };
      int result = await _mediator.Send(command);
      

      return Ok(result);
    }
  }
}
