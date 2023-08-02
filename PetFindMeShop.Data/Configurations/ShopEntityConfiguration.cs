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
                Name = "PetShop.BG",
                ShopImageName = "https://www.petshop.bg/media/t46s-10/1603.webp",
                Description =
                    "Нашата мисия е да предоставим на родителите на кучета и котки всичко необходимо, за да " +
                    "гарантират дълъг и щастлив живот на домашния си любимец. Обичаме да говорим за домашни любимци от всякакъв " +
                    "вид и се вълнуваме още повече, когато доведете косматия си член на семейството в магазина, за да се срещне с " +
                    "нас! Ние непрекъснато проучваме и научаваме нови продукти, които могат да направят живота на нашите домашни " +
                    "любимци по-добър. Нашата цел е да осигурим чист магазин, подходящ за домашни любимци, който разполага с всичко, " +
                    "от което се нуждае вашето куче или котка. Въпреки че нашият магазин не е много голям, ние предлагаме изживяване, " +
                    "което е бързо, приятелско, местно и по-евтино от магазините за домашни любимци „PetShop.BG“."
            };
            shops.Add(shop);

            return shops.ToArray();
        }
    }
}
