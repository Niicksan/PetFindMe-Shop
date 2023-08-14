namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class ShoppingCartItemEntityConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder
              .Property(sci => sci.CreatedAt)
              .HasDefaultValueSql("GETDATE()");

            builder
               .Property(sci => sci.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
