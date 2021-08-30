using MediatR;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Locations.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspce.GlobalStoreApi.Application.Locations.EventHandlers
{
    public class GetMerchantLocationsHandler : IRequestHandler<GetMerchantLocationsQuery, IQueryable<Location>>
    {
        private ILocationsRepository _locationsRepository;

        public GetMerchantLocationsHandler(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        async public Task<IQueryable<Location>> Handle(GetMerchantLocationsQuery request, CancellationToken cancellationToken)
        {
            return _locationsRepository.GetMerchantLocations(request.MerchantId);
        }
    }
}
