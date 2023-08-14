namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
               .Property(o => o.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
