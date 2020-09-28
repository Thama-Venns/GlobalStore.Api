using Microsoft.EntityFrameworkCore;
using Ntvspace.Data.GlobalStore.Entities;
using Ntvspace.GlobalStore.Data.External;

namespace Ntvspace.Data.GlobalStore.Context
{
  public class GlobalStoreDbContext : DbContext
  {
    public GlobalStoreDbContext(DbContextOptions<GlobalStoreDbContext> options) : base(options) {}

    public DbSet<Store> Stores;
    public DbSet<Product> Products;
    public DbSet<Country> Countries;
    public DbSet<Currency> Currencies;
    public DbSet<City> Cities;
    public DbSet<StoreAddess> Locations;
    public DbSet<ProductCategory> ProductCategories;
    public DbSet<StoreCategory> StoreCategories;
  }
}
