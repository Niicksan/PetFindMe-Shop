using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFindMeShop.Data.Models;

namespace PetFindMeShop.Data.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(p => p.IsAvailable)
                .HasDefaultValue(true);

            builder
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
               .Property(p => p.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");

            builder
               .Property(p => p.DeletedAt)
               .HasDefaultValueSql(null);
        }
    }
}
