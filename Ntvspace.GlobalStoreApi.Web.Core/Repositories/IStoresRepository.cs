using Ntvspace.GlobalStoreApi.Data.Entities;
using Ntvspace.GlobalStoreApi.Web.Core.Infrastructure;

namespace Ntvspace.GlobalStoreApi.Web.Core.Repositories
{
  /// <summary>
  /// Provides operations to manage stores.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IStoresRepository : IRepository<Store>
  {
  }
}
