using MediatR;
using Ntvspace.GlobalStoreApi.Domain.Models;
using System.Linq;

namespace Ntvspce.GlobalStoreApi.Application.Locations.Queries
{
    public class GetLocationsQuery : IRequest<IQueryable<Location>>
    {
    }
}
