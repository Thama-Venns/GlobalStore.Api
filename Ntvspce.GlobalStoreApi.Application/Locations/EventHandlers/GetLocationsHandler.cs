using MediatR;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Locations.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspce.GlobalStoreApi.Application.Locations.EventHandlers
{
    public class GetLocationsHandler : IRequestHandler<GetLocationsQuery, IQueryable<Location>>
    {
        private readonly ILocationsRepository _locationsRepository;

        public GetLocationsHandler(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        async Task<IQueryable<Location>> IRequestHandler<GetLocationsQuery, IQueryable<Location>>.Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = _locationsRepository.GetAllLocations();
            return locations;
        }
    }
}
