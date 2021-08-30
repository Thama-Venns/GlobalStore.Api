using MediatR;
using Microsoft.AspNet.OData;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Merchants.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspce.GlobalStoreApi.Application.Merchants.EventHandlers
{
    public class GetMerchantHandler : IRequestHandler<GetMerchantQuery, SingleResult>
    {
        private readonly IMerchantsRepository _merchantsRepository;
        public GetMerchantHandler(IMerchantsRepository merchantsRepository)
        {
            _merchantsRepository = merchantsRepository;
        }

        async public Task<SingleResult> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var merchants = _merchantsRepository.GetMerchants(cancellationToken).Where(x => x.Id.Equals(request.MerchantId));
            return SingleResult.Create(merchants);
        }
    }
}
