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
        }
    }
}
