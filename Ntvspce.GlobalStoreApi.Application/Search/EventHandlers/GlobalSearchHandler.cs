using MediatR;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using Ntvspce.GlobalStoreApi.Application.Search.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspce.GlobalStoreApi.Application.Search.EventHandlers
{
    public class GlobalSearchHandler : IRequestHandler<GlobalSearchQuery, IQueryable<GlobalSearch>>
    {
        private readonly IGlobalRepository _globalRepository;
        public GlobalSearchHandler(IGlobalRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        async public Task<IQueryable<GlobalSearch>> Handle(GlobalSearchQuery request, CancellationToken cancellationToken)
        {
            var searchResults = _globalRepository.GlobalSearch(request.Keyword, cancellationToken);
            return searchResults;
        }
    }
}
