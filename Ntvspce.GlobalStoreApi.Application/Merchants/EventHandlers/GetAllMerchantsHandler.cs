using MediatR;
using Microsoft.Extensions.Logging;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Merchants.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspce.GlobalStoreApi.Application.Merchants.EventHandlers
{
    public class GetAllMerchantsHandler : IRequestHandler<GetAllMerchantsQuery, IQueryable<Merchant>>
    {
        private readonly IMerchantsRepository _merchantsRepository;
        public GetAllMerchantsHandler(IMerchantsRepository merchantsRepository)
        {
            _merchantsRepository = merchantsRepository;
        }

        async public Task<IQueryable<Merchant>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
        {
            var merchants = _merchantsRepository.GetMerchants(cancellationToken);
            return merchants;
        }
    }
}
