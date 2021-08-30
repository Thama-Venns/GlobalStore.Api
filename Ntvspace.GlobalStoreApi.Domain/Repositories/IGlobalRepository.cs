using Ntvspace.GlobalStoreApi.Domain.Models;
using System.Linq;
using System.Threading;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Repositories
{
    /// <summary>
    /// Provides operations to manage global operations
    /// </summary>
    public interface IGlobalRepository
    {
        /// <summary>
        /// Retrieves global search results.
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        IQueryable<GlobalSearch> GlobalSearch(string searchKey, CancellationToken cancellationToken);
    }
}
