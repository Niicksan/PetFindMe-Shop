namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class ShopEntityConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
               .Property(s => s.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
