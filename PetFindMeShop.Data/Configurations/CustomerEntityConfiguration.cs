namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
              .Property(c => c.CreatedAt)
              .HasDefaultValueSql("GETDATE()");

            builder
               .Property(c => c.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
