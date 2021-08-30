using Ntvspace.GlobalStoreApi.Data.Context;
using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Web.Domain.Infrastructure;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Services
{
  public class LocationsRepositoryService: ILocationsRepository
  {
        private GlobalStoreDbContext _globalStoreDbContext;
        public LocationsRepositoryService(GlobalStoreDbContext globalStoreDbContext)
        {
            _globalStoreDbContext = globalStoreDbContext;
        }

        public IQueryable<Location> GetAllLocations()
        {
            var locations = from l in _globalStoreDbContext.Locations
                            select new Location
                            {
                                Id = l.Id,
                                Name = l.Name,
                                Image = l.Image,
                                Website = l.Website,
                                Description = l.Description,
                                Address = new Address
                                {
                                    Id = l.Address.Id,
                                    AddressLine = l.Address.AddressLine,
                                    AddressLine2 = l.Address.AddressLine2,
                                    Latitude = l.Address.Latitude,
                                    Longitude = l.Address.Longitude,
                                    ZipCode = l.Address.ZipCode,
                                    AddressType = l.Address.AddressType.Name,
                                },
                                Merchant = new Merchant
                                {
                                    Id = l.Merchant.Id,
                                    Name = l.Merchant.Name,
                                    Description = l.Merchant.Description,
                                    MerchantClassification = l.Merchant.MerchantClassification.Name,
                                    Logo = l.Merchant.Logo,
                                    Website = l.Merchant.Website
                                }
                            }; ;

            return locations;
        }

        public IQueryable<Location> GetLocationById(int locationId)
        {
            var location = GetAllLocations().Where(x => x.Id.Equals(locationId));
            return location;
        }

        public IQueryable<Location> GetMerchantLocations(int merchantId)
        {
            var locations = GetAllLocations().Where(x => x.Merchant.Id.Equals(merchantId));
            return locations;
        }
    }
}
