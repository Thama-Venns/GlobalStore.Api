using Microsoft.EntityFrameworkCore;
using Ntvspace.GlobalStoreApi.Data.Entities;

namespace Ntvspace.GlobalStoreApi.Data.Context
{
  public class GlobalStoreDbContext : DbContext
  {
    public GlobalStoreDbContext(DbContextOptions<GlobalStoreDbContext> options) : base(options) {}

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<AddressType> AddressTypes { get; set; }
    public DbSet<Border> Borders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Creditor> Creditors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pricing> Pricing { get; set; }
    public DbSet<CountryBorder> CountryBorders { get; set; }
    public DbSet<CountryCurrency> CountryCurrencies { get; set; }
    public DbSet<CountryTimeZone> CountryTimeZones { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<TimeZone> TimeZones { get; set; }
    public DbSet<MerchantClassification> CompanyClassifications { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
      modelBuilder.Entity<CountryTimeZone>().HasKey(k => new { k.CountryId, k.TimeZoneId});
      modelBuilder.Entity<CountryCurrency>().HasKey(k => new { k.CountryId, k.CurrencyId });
      modelBuilder.Entity<CountryBorder>().HasKey(k => new { k.CountryId, k.BorderId });
      modelBuilder.Entity<ProductCategory>().HasKey(k => new { k.CategoryId, k.ProductId });
      modelBuilder.Entity<Pricing>().HasKey(k => new { k.ProductId, k.CurrencyId });

      modelBuilder.Entity<TimeZone>().HasIndex(i => i.TimeZoneUtc).IsUnique(true);
      modelBuilder.Entity<Currency>().HasIndex(i => i.Name).IsUnique(true);
      modelBuilder.Entity<Border>().HasIndex(i => i.Name).IsUnique(true);
    }
  }
}
