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

            builder.HasData(this.GenerateProducts());
        }

        private Product[] GenerateProducts()
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;

            // Products
            product = new Product()
            {
                Id = 1,
                Title = "Advance Dog VET DIETS HYPOALLERGENIC 2.5кг",
                ImageName = "https://www.petshop.bg/media/t46s-4/183.webp",
                Description =
                    "Advance Veterinary Diets Hypoallergenic е диетична храна за кучета с алергичен дерматит и " +
                    "гастрит или пък с непоносимости към определени храни. В състава на храната се влагат само внимателно " +
                    "подбрани източници на протеини и въглехидрати, което я прави много добре поносима. Advance Veterinary " +
                    "Diets Hypoallergenic може да подпомогне оздравителния процес при последващи заболявания като лимфангиектазия " +
                    "или възпаление на червата. Като източник на протеини е използван хидролизиран соев протеин. Той няма антигенен " +
                    "потенциал и съответно няма как да отключи алергична реакция. Изключително високата смилаемост на тази храна е " +
                    "фактор с основно значение при терапията на ентеропатии и стомашно-чревни смущения.",
                Price = 16.50m,
                AvailableQuantity = 1000,
                CategoryId = 3,
                ShopId = 1
            };
            products.Add(product);

            product = new Product()
            {
                Id = 2,
                Title = "Natural TRAINER Cat Hairball Chicken 1.5 кг – с пиле",
                ImageName = "https://www.petshop.bg/media/t46s-4/436.webp",
                Description =
                    "Вашата котка е предразположена към образуване на топки косми? Специфична храна може да бъде " +
                    "полезна за този проблем. Natural Trainer Hairball with Chicken е разработена за тази цел, нейната " +
                    "адаптирана формула с високо съдържание на фибри може да помогне за намаляване на образуването на топки " +
                    "косми в стомаха и естествено елиминиране на погълнатите косми.\r\n\r\nТази суха храна за котки е " +
                    "формулирана със специфични компоненти от естествен произход, за да осигури пълноценна и балансирана диета. " +
                    "Освен това Natural Trainer Hairball с пиле се откроява с контролираното си минерално съдържание, което, " +
                    "заедно с корен от цикория и екстракт от червена боровинка, помага за поддържане на правилното функциониране " +
                    "на пикочните пътища през целия живот на котката. Съставът също подкрепя здравето на кожата и блясъка на козината, " +
                    "благодарение на есенциалните мастни киселини, биотин и цинк. Natural Trainer Hairball с пиле е разработена за " +
                    "възрастни котки, над една година.",
                Price = 23.50m,
                AvailableQuantity = 1000,
                CategoryId = 9,
                ShopId = 1
            };
            products.Add(product);

            product = new Product()
            {
                Id = 3,
                Title = "Легло кучета с лапичка",
                ImageName = "https://s13emagst.akamaized.net/products/28760/28759268/images/res_15a701aad0f1906034a15c9bf3423014.jpg?width=450&height=450&hash=6252F38AE44582D99492052092FAA02F",
                Description = "Меко двулицево легълце, със зимна страна от пухкава имитация на овча вълна и лятна страна " +
                "от гладка найлонова тъкан с правоъгълна форма, нисък борд, може да се пере, подходящо за кучета",
                Price = 43.44m,
                AvailableQuantity = 1000,
                CategoryId = 6,
                ShopId = 1
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
