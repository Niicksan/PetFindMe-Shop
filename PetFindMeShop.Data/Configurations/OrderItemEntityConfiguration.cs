namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    internal class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
              .Property(oi => oi.CreatedAt)
              .HasDefaultValueSql("GETDATE()");

            builder
               .Property(oi => oi.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
