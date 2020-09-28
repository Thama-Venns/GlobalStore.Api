using Ntvspace.GlobalStoreApi.Web.Core.Infrastructure;
using Ntvspace.GlobalStoreApi.Web.Core.Repositories;

namespace Ntvspace.GlobalStoreApi.Web.Core.Services
{
  public class MerchantsRepository: Repository<Data.Entities.Merchant>, IMerchantsRepository
  {
    public MerchantsRepository(Data.Context.GlobalStoreDbContext globalStoreDbContext): base(globalStoreDbContext)
    {
    }
  }
}
