using Ntvspace.GlobalStoreApi.Domain.Models;
using System.Linq;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Repositories
{
  /// <summary>
  /// Provides operations to manage stores.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface ILocationsRepository
  {
        IQueryable<Location> GetAllLocations();
        IQueryable<Location> GetMerchantLocations(int merchantId);
        IQueryable<Location> GetLocationById(int locationId);
    }
}
