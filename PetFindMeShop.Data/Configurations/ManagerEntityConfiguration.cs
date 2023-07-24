namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class ManagerEntityConfiguration : IEntityTypeConfiguration<ShopManager>
    {
        public void Configure(EntityTypeBuilder<ShopManager> builder)
        {
            builder
             .Property(m => m.CreatedAt)
             .HasDefaultValueSql("GETDATE()");

            builder
               .Property(m => m.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");

            builder.HasData(this.GenerateShopManagers());
        }

        private ShopManager[] GenerateShopManagers()
        {
            ICollection<ShopManager> managers = new HashSet<ShopManager>();

            ShopManager manager = new ShopManager()
            {
                Id = Guid.Parse("98C929AC-9AEE-40C3-5691-08DB7FBB6193"),
                FirstName = "Shop",
                LastName = "Manager",
                PhoneNumber = "+359888888888",
                CustomerId = Guid.Parse("811C2B9D-B754-44EF-783B-08DB7FBC8275")
            };
            managers.Add(manager);

            return managers.ToArray();
        }
    }
}
