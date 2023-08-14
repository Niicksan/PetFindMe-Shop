namespace PetFindMeShop.Tests
{
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;

    public static class DatabaseSeeder
    {
        public static Customer? CustomerUser;
        public static Customer? ShopManagerUser;
        public static Customer? NikShopManagerUser;
        public static ShopManager? ShopManager;
        public static ShopManager? NikShopManager;
        public static Shop? PetShopBg;
        public static Shop? PetStoreBg;
        public static ShopsManagers? PetShopBgShopManager;
        public static ShopsManagers? PetStoreBgShopManager;
        public static Category? DogFoodCategory;
        public static Category? CatFoodCategory;
        public static Category? DogBedCategory;
        public static Product? DogFood;
        public static Product? CatFood;
        public static Product? DogBed;
        public static LikedProduct? DogFoodLikedProduct;

        public static void SeedDatabase(PetFindMeShopDbContext dbContext)
        {
            // Customers
            CustomerUser = new Customer()
            {
                Id = Guid.Parse("98C666AC-9AEE-80C3-5686-09DB7FBB6556"),
                UserName = "customer@abv.bg",
                NormalizedUserName = "CUSTOMER@ABV.BG",
                Email = "customer@abv.bg",
                NormalizedEmail = "CUSTOMER@ABV.BG",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                LockoutEnabled = true,
                TwoFactorEnabled = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            ShopManagerUser = new Customer()
            {
                Id = Guid.Parse("811C2B9D-B754-44EF-383B-04DB6FBC8275"),
                UserName = "manager@abv.bg",
                NormalizedUserName = "CMANAGER@ABV.BG",
                Email = "manager@abv.bg",
                NormalizedEmail = "MANAGER@ABV.BG",
                EmailConfirmed = true,
                PasswordHash = "8d962eef6efad3c22a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "4300bc13-f79a-42fb-abce-a54c520bbac5",
                SecurityStamp = "ZDXAYLLGTFDW2QPGEWCOEMNS2XMOHE5",
                LockoutEnabled = true,
                TwoFactorEnabled = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            NikShopManagerUser = new Customer()
            {
                Id = Guid.Parse("80035A5C-CBC1-4BCC-8B29-CF0114A8184A"),
                UserName = "nik@abv.bg",
                NormalizedUserName = "NIK@ABV.BG",
                Email = "nik@abv.bg",
                NormalizedEmail = "NIK@ABV.BG",
                EmailConfirmed = true,
                PasswordHash = "8d962eef6efad3c22a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "IJ64D2ADOMVJ6AKR7536UNTCYMMQHD6R",
                SecurityStamp = "f37e0804-a305-4831-ac82-cd23ad830eb9",
                LockoutEnabled = true,
                TwoFactorEnabled = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            // Managers
            ShopManager = new ShopManager()
            {
                Id = Guid.Parse("98C929AC-9AEE-40C3-5691-08BB4FBB6193"),
                FirstName = "Shop",
                LastName = "Manager",
                PhoneNumber = "+359888888888",
                Customer = ShopManagerUser,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            NikShopManager = new ShopManager()
            {
                Id = Guid.Parse("94CD29DC-9AEE-40C2-1491-08DB7FBB6193"),
                FirstName = "Nik",
                LastName = "Koev",
                PhoneNumber = "+359888888899",
                Customer = NikShopManagerUser,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            // Shops
            PetShopBg = new Shop()
            {
                Id = 1,
                Name = "PetShop.BG",
                ShopImageName = "https://www.petshop.bg/media/t46s-10/1603.webp",
                Description = "Нашата мисия е да предоставим на родителите на кучета и котки всичко необходимо, за да."
            };

            PetStoreBg = new Shop()
            {
                Id = 2,
                Name = "PetStoreBG",
                ShopImageName = "https://img.freepik.com/premium-vector/pet-shop-building-with-products-equipments-inside-store_281368-396.jpg?w=1380",
                Description = "Нашата мисия е да предоставим на родителите на кучета и котки всичко необходимо, за да."
            };

            // ShopsManagers
            PetShopBgShopManager = new ShopsManagers()
            {
                Id = 1,
                ShopId = 1,
                ShopManagerId = Guid.Parse("98C929AC-9AEE-40C3-5691-08BB4FBB6193"),
            };

            PetStoreBgShopManager = new ShopsManagers()
            {
                Id = 2,
                ShopId = 2,
                ShopManagerId = Guid.Parse("94CD29DC-9AEE-40C2-1491-08DB7FBB6193"),
            };

            // Categories
            DogFoodCategory = new Category()
            {
                Id = 1,
                Name = "Сухи храни за кучета"
            };

            CatFoodCategory = new Category()
            {
                Id = 2,
                Name = "Сухи храни за котки"
            };

            DogBedCategory = new Category()
            {
                Id = 3,
                Name = "Легла за куче"
            };

            // Products
            DogFood = new Product()
            {
                Id = 1,
                Title = "Advance Dog VET DIETS HYPOALLERGENIC 2.5кг",
                ImageName = "https://www.petshop.bg/media/t46s-4/183.webp",
                Description = "Advance Veterinary Diets Hypoallergenic е диетична храна за кучета с алергичен дерматит.",
                Price = 16.50m,
                IsAvailable = true,
                AvailableQuantity = 1000,
                CategoryId = 1,
                ShopId = 1,
                DeletedAt = null
            };

            CatFood = new Product()
            {
                Id = 2,
                Title = "Natural TRAINER Cat Hairball Chicken 1.5 кг – с пиле",
                ImageName = "https://www.petshop.bg/media/t46s-4/436.webp",
                Description = "Вашата котка е предразположена към образуване на топки косми? Специфична храна може да бъде.",
                Price = 23.50m,
                IsAvailable = true,
                AvailableQuantity = 1000,
                CategoryId = 2,
                ShopId = 1,
                DeletedAt = null
            };

            DogBed = new Product()
            {
                Id = 3,
                Title = "Легло за кучета с лапичка",
                ImageName = "https://s13emagst.akamaized.net/products/28760/28759268/images/res_15a701aad0f1906034a15c9bf3423014.jpg?width=450&height=450&hash=6252F38AE44582D99492052092FAA02F",
                Description = "Меко двулицево легълце, със зимна страна от пухкава имитация на овча вълна и лятна страна.",
                Price = 43.44m,
                IsAvailable = true,
                AvailableQuantity = 1000,
                CategoryId = 3,
                ShopId = 2,
                DeletedAt = DateTime.Parse("2023-08-02 22:51:03.2598126")
            };

            // Add Liked Product
            DogFoodLikedProduct = new LikedProduct()
            {
                Id = 1,
                ProductId = 1,
                CustomerId = Guid.Parse("98C666AC-9AEE-80C3-5686-09DB7FBB6556")
            };

            // Add Customers
            dbContext.Customers.Add(CustomerUser);
            dbContext.Customers.Add(ShopManagerUser);
            dbContext.Customers.Add(NikShopManagerUser);

            // Add Managers
            dbContext.ShopManagers.Add(ShopManager);
            dbContext.ShopManagers.Add(NikShopManager);

            // Add Shops
            dbContext.Shops.Add(PetShopBg);
            dbContext.Shops.Add(PetStoreBg);

            // Add ShopsManagers
            dbContext.ShopsManagers.Add(PetShopBgShopManager);
            dbContext.ShopsManagers.Add(PetStoreBgShopManager);

            // Add Categories
            dbContext.Categories.Add(DogFoodCategory);
            dbContext.Categories.Add(CatFoodCategory);
            dbContext.Categories.Add(DogBedCategory);

            // Add Products
            dbContext.Products.Add(DogFood);
            dbContext.Products.Add(CatFood);
            dbContext.Products.Add(DogBed);

            // Add Liked Product
            dbContext.LikedProducts.Add(DogFoodLikedProduct);

            dbContext.SaveChanges();
        }
    }
}
