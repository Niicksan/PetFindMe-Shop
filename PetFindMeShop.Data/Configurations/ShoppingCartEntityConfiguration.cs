namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class ShoppingCartEntityConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
             .Property(sc => sc.TotalProductsPrice)
             .HasDefaultValueSql(null);

            builder
              .Property(sc => sc.CreatedAt)
              .HasDefaultValueSql("GETDATE()");

            builder
               .Property(sc => sc.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
