using MediatR;
using Microsoft.AspNet.OData;
using Ntvspace.GlobalStoreApi.Domain.Models;

namespace Ntvspce.GlobalStoreApi.Application.Locations.Queries
{
    public class GetLocationByKeyQuery : IRequest<SingleResult<Location>>
    {
        public int LoationId { get; set; }
    }
}
