using MediatR;
using Ntvspace.GlobalStoreApi.Domain.Models;
using System.Linq;

namespace Ntvspce.GlobalStoreApi.Application.Search.Queries
{
    public class GlobalSearchQuery : IRequest<IQueryable<GlobalSearch>>
    {
        public string Keyword { get; set; }
    }
}
