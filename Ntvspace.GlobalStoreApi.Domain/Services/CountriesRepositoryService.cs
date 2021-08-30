using Ntvspace.GlobalStoreApi.Data.Context;
using Ntvspace.GlobalStoreApi.Data.Entities;
using Ntvspace.GlobalStoreApi.Web.Domain.Infrastructure;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Services
{
  public class CountriesRepositoryService : Repository<Country>, ICountriesRepository
  {
    public CountriesRepositoryService(GlobalStoreDbContext globalStoreDbContext) : base(globalStoreDbContext)
    {
        
    }
  }
}
