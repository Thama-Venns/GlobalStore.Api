using MediatR;
using Microsoft.AspNet.OData;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Locations.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspce.GlobalStoreApi.Application.Locations.EventHandlers
{
    public class GetLocationByKeyHandler : IRequestHandler<GetLocationByKeyQuery, SingleResult<Location>>
    {
        private readonly ILocationsRepository _locationsRepository;

        public GetLocationByKeyHandler(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        async public Task<SingleResult<Location>> Handle(GetLocationByKeyQuery request, CancellationToken cancellationToken)
        {
            var locations = _locationsRepository.GetLocationById(request.LoationId);
            return SingleResult.Create(locations);
        }
    }
}
