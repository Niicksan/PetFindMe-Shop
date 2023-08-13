namespace PetFindMeShop.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data.Models;
    using System.Reflection;

    public class PetFindMeShopDbContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public PetFindMeShopDbContext(DbContextOptions<PetFindMeShopDbContext> options, bool seed = true)
            : base(options)
        {
            //if (Database.IsRelational())
            //{
            //    Database.Migrate();
            //}
            //else
            //{
            //    Database.EnsureCreated();
            //}

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
            if (this.seedDb)
            {
                Assembly configAssembly = Assembly.GetAssembly(typeof(PetFindMeShopDbContext)) ??
                                      Assembly.GetExecutingAssembly();
                modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}