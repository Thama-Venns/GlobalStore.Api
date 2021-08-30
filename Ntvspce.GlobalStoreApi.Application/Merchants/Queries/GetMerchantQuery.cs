using MediatR;
using Microsoft.AspNet.OData;
using Ntvspace.GlobalStoreApi.Domain.Models;

namespace Ntvspce.GlobalStoreApi.Application.Merchants.Queries
{
    public class GetMerchantQuery : IRequest<SingleResult>
    {
        public int MerchantId { get; set; }
    }
}
