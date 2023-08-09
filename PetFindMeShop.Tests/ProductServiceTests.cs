namespace PetFindMeShop.Tests
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Services;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Product;
    using static DatabaseSeeder;

    public class ProductServiceTests
    {
        private DbContextOptions<PetFindMeShopDbContext> dbOptions;
        private PetFindMeShopDbContext dbContext;

        private IProductService productService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<PetFindMeShopDbContext>()
                .UseInMemoryDatabase("PetFindMeShopInMemory")
                .Options;
            this.dbContext = new PetFindMeShopDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.productService = new ProductService(this.dbContext);
        }

        [Test]
        public async Task ProductExistsByIdShouldReturnFalseWhenDoNotExist()
        {
            bool result = await this.productService.ExistsByIdAsync(33);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ProductExistsByIdShouldReturnTrueWhenExists()
        {
            int existingProductId = DogFood.Id;

            bool result = await this.productService.ExistsByIdAsync(existingProductId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetProductShopIdShouldReturnTheShopId()
        {
            int existingProductId = DogFood.Id;

            int result = await this.productService.GetProductShopIdAsync(existingProductId);

            Assert.That(result, Is.EqualTo(existingProductId));
        }

        [Test]
        public async Task GetProducDetailsByIShouldReturnProductViewModel()
        {
            var customerUser = CustomerUser;
            var dogFoodProduct = DogFood;

            var expected = new ProductDetailsViewModel
            {
                Id = 10,
                Title = "Advance Dog VET DIETS HYPOALLERGENIC 2.5кг",
                ImageName = "https://www.petshop.bg/media/t46s-4/183.webp",
                Description = "Advance Veterinary Diets Hypoallergenic е диетична храна за кучета с алергичен дерматит.",
                Price = 16.50m,
                IsAvailable = true,
                Category = "Сухи храни за кучета",
                ShopProviderName = "PetShop.BG",
                Status = "В наличност",
                IsLiked = false,
                IsDeleted = false,
            };

            var result = await this.productService.GetDetailsByIdAsync(dogFoodProduct.Id, CustomerUser.Id.ToString());

            result.Should().BeEquivalentTo(dogFoodProduct, options =>
                options
                    .Excluding(p => p.AvailableQuantity)
                    .Excluding(p => p.Category)
                    .Excluding(p => p.CategoryId)
                    .Excluding(p => p.Shop)
                    .Excluding(p => p.ShopId)
                    .Excluding(p => p.CreatedAt)
                    .Excluding(p => p.UpdatedAt)
                    .Excluding(p => p.DeletedAt)
                );
        }

        [Test]
        public async Task GetProductForEditByIShouldReturnProductViewModel()
        {
            var dogFoodProduct = DogFood;

            var result = await this.productService.GetProductForEditByIdAsync(dogFoodProduct.Id);

            result.Should().BeEquivalentTo(dogFoodProduct, options =>
                options
                    .Excluding(p => p.Id)
                    .Excluding(p => p.Category)
                    .Excluding(p => p.IsAvailable)
                    .Excluding(p => p.Shop)
                    .Excluding(p => p.ShopId)
                    .Excluding(p => p.CreatedAt)
                    .Excluding(p => p.UpdatedAt)
                    .Excluding(p => p.DeletedAt)
                );
        }

        [Test]
        public async Task ProductAlreadyArchivedShouldReturnFalse()
        {
            int productId = DogFood.Id;

            bool result = await this.productService.ProductAlreadyArchived(productId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ProductAlreadyArchivedShouldReturnTrue()
        {
            int productId = DogBed.Id;

            bool result = await this.productService.ProductAlreadyArchived(productId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ProductAlreadyLikedShouldReturnTrue()
        {
            int productId = DogFood.Id;
            string customerId = CustomerUser.Id.ToString();

            bool result = await this.productService.ProductAlreadyAddedToCustomerLikedCollection(customerId, productId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ProductAlreadyLikedShouldReturnFalse()
        {
            int productId = DogBed.Id;
            string customerId = CustomerUser.Id.ToString();

            bool result = await this.productService.ProductAlreadyAddedToCustomerLikedCollection(customerId, productId);

            Assert.IsFalse(result);
        }
    }
}