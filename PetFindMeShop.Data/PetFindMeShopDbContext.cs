namespace PetFindMeShop.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data.Configurations;
    using PetFindMeShop.Data.Configurations.SeedDbConfigurations;
    using PetFindMeShop.Data.Models;

    public class PetFindMeShopDbContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public PetFindMeShopDbContext(DbContextOptions<PetFindMeShopDbContext> options, bool seed = true)
            : base(options)
        {
            this.seedDb = seed;
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<ShopManager> ShopManager { get; set; } = null!;

        public DbSet<Shop> Shops { get; set; } = null!;

        public DbSet<ShopsManagers> ShopsManagers { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<LikedProducts> LikedProducts { get; set; } = null!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShopEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShopsManagersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

            if (this.seedDb)
            {
                modelBuilder.ApplyConfiguration(new SeedCategoriesEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedCustomersEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedManagersEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedShopsEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedShopsManagersEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedProductsEntityConfiguration());
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}