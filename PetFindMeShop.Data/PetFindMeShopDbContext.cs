namespace PetFindMeShop.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data.Models;

    public class PetFindMeShopDbContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        public PetFindMeShopDbContext(DbContextOptions<PetFindMeShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<ShopManager> ShopManager { get; set; } = null!;

        public DbSet<Shop> Shops { get; set; } = null!;

        public DbSet<ShopsManagers> ShopsManagers { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}