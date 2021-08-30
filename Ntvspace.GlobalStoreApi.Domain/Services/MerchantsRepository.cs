using Ntvspace.GlobalStoreApi.Domain.Models;
using Ntvspace.GlobalStoreApi.Domain.Requests;
using Ntvspace.GlobalStoreApi.Web.Domain.Infrastructure;
using Ntvspace.GlobalStoreApi.Web.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Services
{
  /// <summary>
  /// Provides operations to handle merchants requests.
  /// </summary>
  public class MerchantsRepository: Repository<Data.Entities.Merchant>, IMerchantsRepository
  {
        private readonly Data.Context.GlobalStoreDbContext _globalStoreDbContext;
        /// <summary>
        /// Initiates handler.
        /// </summary>
        /// <param name="globalStoreDbContext"></param>
        public MerchantsRepository(Data.Context.GlobalStoreDbContext globalStoreDbContext): base(globalStoreDbContext)
        {
            _globalStoreDbContext = globalStoreDbContext;
        }

        /// <summary>
        /// Retrieves all Merchants
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public IQueryable<Merchant> GetMerchants(CancellationToken cancellationToken)
        {
            var merchants = from m in _globalStoreDbContext.Merchants
                            select new Merchant
                            {
                                Id = m.Id,
                                Name = m.Name,
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
                                Locations = from s in m.Locations
                                            select new Location
                                            {
                                                Id = s.Id,
                                                Name = s.Name,
                                                Description = s.Description,
                                                Image = s.Image,
                                                Website = s.Website,
                                            }
                            };

            return merchants.AsQueryable();
        }

        /// <summary>
        /// Retrieves Locations by merchant id
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="cancelletionToken"></param>
        /// <returns></returns>
        public IQueryable<Location> GetLocations(int merchantId, CancellationToken cancelletionToken)
        {
            var locations = from l in _globalStoreDbContext.Locations
                            where l.MerchantId.Equals(merchantId)
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


        /// <summary>
        /// Creates a new merchants.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancelletionToken"></param>
        /// <returns></returns>
        public async Task<Data.Entities.Merchant> CreateMerchant(MerchantRequest request, CancellationToken cancelletionToken)
        {
            Data.Entities.Merchant merchant = new Data.Entities.Merchant();
            var check = _globalStoreDbContext.Merchants.FirstOrDefault(x => x.Name.Equals(request.Name));

            if (check == null)
            {
                merchant.Name = request.Name;
                merchant.Logo = request.Logo;
                merchant.Website = request.Website;
                merchant.Description = request.Description;
                merchant.MerchantClassificationId = request.MerchantClassificationId;

                _globalStoreDbContext.Add(merchant);
                await _globalStoreDbContext.SaveChangesAsync();
            } else
            {
                merchant = check;
            }

            return merchant;
        }
    }
}
