using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Domain.Requests;
using Ntvspace.GlobalStoreApi.Web.Domain.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Repositories
{
  public interface IMerchantsRepository: IRepository<Data.Entities.Merchant>
  {
        IQueryable<Merchant> GetMerchants(CancellationToken cancelletionToken);
        Task<Data.Entities.Merchant> CreateMerchant(MerchantRequest request,CancellationToken cancelletionToken);
        IQueryable<Location> GetLocations(int merchantId, CancellationToken cancelletionToken);
  }
}
