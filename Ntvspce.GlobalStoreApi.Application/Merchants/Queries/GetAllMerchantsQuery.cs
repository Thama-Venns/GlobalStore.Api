using MediatR;
using Ntvspace.GlobalStoreApi.Domain.Models;
using System.Linq;

namespace Ntvspce.GlobalStoreApi.Application.Merchants.Queries
{
    public class GetAllMerchantsQuery : IRequest<IQueryable<Merchant>>
    {
    }
}
