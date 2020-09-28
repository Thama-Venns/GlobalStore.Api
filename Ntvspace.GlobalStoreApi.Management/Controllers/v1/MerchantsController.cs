using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Ntvspace.GlobalStoreApi.Management.Models.v1;
using Ntvspace.GlobalStoreApi.Web.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ntvspace.GlobalStoreApi.Management.Controllers.v1
{
  /// <summary>
  /// Provides operations to manage merchants.
  /// </summary>
  public class MerchantsController : ODataController
  {
    private readonly IMerchantsRepository _merchantsRepository;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    /// <param name="merchantsRepository"></param>
    public MerchantsController(IMerchantsRepository merchantsRepository)
    {
      _merchantsRepository = merchantsRepository;
    }

    /// <summary>
    /// Provides operations to retrieve merchants.
    /// </summary>
    /// <returns></returns>
    [EnableQuery]
    public IActionResult Get()
    {
      var merchants = Query();
      return Ok(merchants);
    }

    /// <summary>
    /// Retrieves a single merchant with specified id.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [EnableQuery]
    public SingleResult Get(int key)
    {
      var merchants = Query().Where(x => x.Id.Equals(key));
      return SingleResult.Create(merchants);
    }

    /// <summary>
    /// Creates a new merchant.
    /// </summary>
    /// <param name="model">Merchant Request</param>
    /// <returns></returns>
    public IActionResult Post([FromBody] Merchant model)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest();
      }

      var exits = Query().Any(x => x.Name.Equals(model.Name));

      if(exits)
      {
        return BadRequest("A merchant with this name is already registered");
      }

      var address = model.Addresses.FirstOrDefault();
      Data.Entities.Merchant merchant = new Data.Entities.Merchant
      {
        Name = model.Name,
        Logo = model.Logo,
        Website = model.Website,
        Addresses = new List<Data.Entities.Address>
        {
          new Data.Entities.Address
          {
            AddressLine = address.AddressLine,
            AddressLine2 = address.AddressLine2,
            Latitude = address.Latitude,
            Longitude = address.Longitude,
            ZipCode = address.ZipCode,
            AddressType = new Data.Entities.AddressType { Id = 1 }
          }
        },
      };

      _merchantsRepository.Add(merchant);
      _merchantsRepository.SaveChanges();

      return Ok(merchant.Id);
    }

    private IQueryable<Merchant> Query()
    {
      var merchants = from m in _merchantsRepository.GetAll()
                      select new Merchant
                      {
                        Id = m.Id,
                        Name =m.Name,
                        Description = m.Description,
                        Logo = m.Logo,
                        Website = m.Website,
                        MerchantClassification = m.MerchantClassification.Name,
                        Addresses = from a in m.Addresses
                                    select new Address
                                    {
                                      Id = a.Id,
                                      AddressLine = a.AddressLine,
                                      AddressLine2 = a.AddressLine2,
                                      ZipCode = a.ZipCode,
                                      Latitude = a.Latitude,
                                      Longitude = a.Longitude
                                    },
                        Stores = from s in m.Stores
                                 select new Store
                                 {
                                   Id = s.Id,
                                   Name = s.Name,
                                   Description = s.Description,
                                   Image = s.Image,
                                   Website = s.Website
                                 }
                      };

      return merchants.AsQueryable();
    }
  }
}
