namespace PetFindMeShop.Data.Configurations.SeedDbConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class SeedManagersEntityConfiguration : IEntityTypeConfiguration<ShopManager>
    {
        public void Configure(EntityTypeBuilder<ShopManager> builder)
        {
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
