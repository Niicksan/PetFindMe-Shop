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

            builder.HasData(this.GenerateShops());
        }

        private Shop[] GenerateShops()
        {
            ICollection<Shop> shops = new HashSet<Shop>();

            Shop shop = new Shop()
            {
                Id = 1,
                Name = "NikPetShop",
                ShopImageName = "https://www.petshop.bg/media/t46s-10/1603.webp",
                Description = "Very cool Pet Shop",
            };
            shops.Add(shop);

            return shops.ToArray();
        }
    }
}
