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
        }
    }
}
