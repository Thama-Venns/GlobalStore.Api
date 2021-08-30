using MediatR;
using Ntvspace.GlobalStoreApi.Domain.Requests;

namespace Ntvspce.GlobalStoreApi.Application.Merchants.Commands
{
    public class CreateMerchantCommand : IRequest<int>
    {
        public MerchantRequest Merchant { get; set; }
    }
}
