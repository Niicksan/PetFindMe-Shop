using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFindMeShop.Data.Models;

namespace PetFindMeShop.Data.Configurations
{
    public class ShopsManagersEntityConfiguration : IEntityTypeConfiguration<ShopsManagers>
    {
        public void Configure(EntityTypeBuilder<ShopsManagers> builder)
        {
            builder
               .Property(sm => sm.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

            builder
               .Property(sm => sm.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");

            builder.HasData(this.GenerateShopsManagers());
        }

        private ShopsManagers[] GenerateShopsManagers()
        {
            ICollection<ShopsManagers> shopsManagers = new HashSet<ShopsManagers>();

            ShopsManagers shopManger = new ShopsManagers()
            {
                Id = 1,
                ShopId = 1,
                ShopManagerId = Guid.Parse("98C929AC-9AEE-40C3-5691-08DB7FBB6193"),
            };
            shopsManagers.Add(shopManger);

            return shopsManagers.ToArray();
        }
    }
}
