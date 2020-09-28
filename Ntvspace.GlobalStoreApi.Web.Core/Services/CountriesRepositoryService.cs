using Ntvspace.GlobalStoreApi.Data.Context;
using Ntvspace.GlobalStoreApi.Data.Entities;
using Ntvspace.GlobalStoreApi.Web.Core.Infrastructure;
using Ntvspace.GlobalStoreApi.Web.Core.Repositories;

namespace Ntvspace.GlobalStoreApi.Web.Core.Services
{
  public class CountriesRepositoryService : Repository<Country>, ICountriesRepository
  {
    public CountriesRepositoryService(GlobalStoreDbContext globalStoreDbContext) : base(globalStoreDbContext)
    {
        
    }
  }
}
