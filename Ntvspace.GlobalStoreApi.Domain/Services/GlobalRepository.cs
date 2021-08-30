using Ntvspace.GlobalStoreApi.Data.Context;
using Ntvspace.GlobalStoreApi.Domain.Constants;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Services
{
    /// <summary>
    /// Provides operations for search queries.
    /// </summary>
    public class GlobalRepository: IGlobalRepository
    {
        private readonly GlobalStoreDbContext _dbContext;

        /// <summary>
        /// Initializes the service
        /// </summary>
        public GlobalRepository(GlobalStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves global search results.
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public IQueryable<GlobalSearch> GlobalSearch(string searchKey, CancellationToken cancellationToken)
        {
            List<GlobalSearch> results = new List<GlobalSearch>();
            var merchQuery =  (from m in _dbContext.Merchants.Where(x => x.Name.Contains(searchKey))
                              select new GlobalSearch 
                              { 
                                  Id = m.Id, 
                                  Label = m.Name, 
                                  Type = EntityTypes.Merchant.ToString() 
                              }).AsQueryable();

            results.AddRange(merchQuery);

            //var storeQuery = await from s in _dbContext.Stores.Where(x => x.Name.Contains(searchKey)).ToListAsync();
            //var categoryQuery = await from c in _dbContext.Categories.Where(x => x.Name.Contains(searchKey)).ToListAsync();
            //var creditorQuery = await from creditor in _dbContext.Creditors.Where(x => x.Name.Contains(searchKey)).ToListAsync();
            //var productQuery = await from p in _dbContext.Products.Where(x => x.Name.Contains(searchKey)).ToListAsync();

            return results.AsQueryable();
        }
    }
}
