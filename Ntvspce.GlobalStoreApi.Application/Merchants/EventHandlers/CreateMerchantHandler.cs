using MediatR;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Merchants.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspce.GlobalStoreApi.Application.Merchants.EventHandlers
{
    /// <summary>
    /// Provides operations to register a merchant
    /// </summary>
    public class CreateMerchantHandler : IRequestHandler<CreateMerchantCommand, int>
    {
        private IMerchantsRepository _merchantRepository;

        /// <summary>
        /// Initializes the handler
        /// </summary>
        /// <param name="merchantRepository"></param>
        public CreateMerchantHandler(IMerchantsRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }


        /// <summary>
        /// Handles a merchant registration request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        async public Task<int> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            var newMerchant = await _merchantRepository.CreateMerchant(request.Merchant, cancellationToken);
            return newMerchant.Id;
        }
    }
}
