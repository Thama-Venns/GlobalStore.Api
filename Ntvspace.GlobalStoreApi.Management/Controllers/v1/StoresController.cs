//using Microsoft.AspNet.OData;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Ntvspace.GlobalStoreApi.Management.Models.v1;
//using Ntvspace.GlobalStoreApi.Management.Models.v1.Request;
//using Ntvspace.GlobalStoreApi.Web.Core.Authorization;
//using Ntvspace.GlobalStoreApi.Web.Core.Repositories;
//using Swashbuckle.AspNetCore.Annotations;
//using System.Linq;

//namespace Ntvspace.GlobalStoreApi.Management.Controllers.v1
//{
//  /// <summary>
//  /// Provides operations to manage stores.
//  /// </summary>
//  [ApiVersion("1.0")]
//  [SwaggerTag("Provides operations to manage stores.")]
//  [Authorize(Policy = Policy.UsecurePolicy)]

//  public class StoresController : ODataController
//  {
//    private readonly IStoresRepository _storesRepository;

//    /// <summary>
//    /// Initializes the controller.
//    /// </summary>
//    /// <param name="storesRepository"></param>
//    public StoresController(IStoresRepository storesRepository)
//    {
//      _storesRepository = storesRepository;
//    }

//    /// <summary>
//    /// Retrieves a list of store details
//    /// </summary>
//    /// <returns></returns>
//    [EnableQuery]
//    public IQueryable<Store> Get()
//    {
//      var stores = ModelQuery();
//      return stores;
//    }

//    /// <summary>
//    /// Rereieves a store's details
//    /// </summary>
//    /// <param name="key">storeID</param>
//    /// <returns></returns>
//    [EnableQuery]
//    public SingleResult<Store> Get(int key)
//    {
//      var store = ModelQuery().Where(x => x.Id.Equals(key));
//      return SingleResult.Create(store);
//    }

//    /// <summary>
//    /// Creates a new store.
//    /// </summary>
//    /// <param name="model"></param>
//    /// <returns></returns>
//    public IActionResult Post([FromBody]StoreRequest model)
//    {
//      if(!ModelState.IsValid)
//      {
//        return BadRequest();
//      }

//      var newStore = new Data.Entities.Store
//      {
//        Name = model.Name,
//        Website = model.Website,
//        Description = model.Description,

//        Address = new Data.Entities.Address
//        {
//          AddressLine = model.AddressLine,
//          AddressLine2 = model.AddressLine2,
//          Latitude = -model.Latitude,
//          Longitude = model.Longitude,
//          AddressTypeId = model.AddressTypeId,
//          ZipCode = model.ZipCode,
//          City = new Data.Entities.City
//          {
//            Name = model.City,
//            Province = new Data.Entities.Province
//            {
//              Name = model.Province,
//              CountryId = 23
//            }
//          }
//        },
//        Merchant = new Data.Entities.Merchant
//        {
//          Name = model.Merchant,
//          Description = model.MerchantDescription,
//          Website = model.CompanyWebsite,
//          MerchantClassificationId = model.MerchantClassificationId
//        }
//      };

//      _storesRepository.Add(newStore);
//      _storesRepository.SaveChanges();

//      return Ok(newStore.Id);
//    }

//    private IQueryable<Store> ModelQuery()
//    {
//      var stores = from s in DbQuery()
//                   select new Store
//                   {
//                     Id = s.Id,
//                     Name = s.Name,
//                     Image = s.Image,
//                     Website = s.Website,
//                     Description = s.Description,
//                     Address = new Address
//                     {
//                       Id = s.Address.Id,
//                       AddressLine = s.Address.AddressLine,
//                       AddressLine2 = s.Address.AddressLine2,
//                       Latitude = s.Address.Latitude,
//                       Longitude = s.Address.Longitude,
//                       ZipCode = s.Address.ZipCode,
//                       AddressType = s.Address.AddressType.Name,
//                     },
//                     Merchant = new Merchant
//                     {
//                       Id = s.Merchant.Id,
//                       Name = s.Merchant.Name,
//                       Description = s.Merchant.Description,
//                       MerchantClassification = s.Merchant.MerchantClassification.Name,
//                       Logo = s.Merchant.Logo,
//                       Website = s.Merchant.Website
//                     }
//                   };

//      return stores;
//    }

//    private IQueryable<Data.Entities.Store> DbQuery() 
//    {
//      return _storesRepository.GetAll().AsQueryable().AsNoTracking();
//    }
//  }
//}
