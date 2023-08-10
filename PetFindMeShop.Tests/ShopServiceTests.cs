namespace PetFindMeShop.Tests
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Services;
    using PetFindMeShop.Services.Interfaces;
    using static DatabaseSeeder;

    public class ShopServiceTests
    {
        private DbContextOptions<PetFindMeShopDbContext> dbOptions;
        private PetFindMeShopDbContext dbContext;

        private IShopService shopService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<PetFindMeShopDbContext>()
                .UseInMemoryDatabase("PetFindMeShopInMemory")
                .Options;
            this.dbContext = new PetFindMeShopDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.shopService = new ShopService(this.dbContext);
        }

        [Test]
        public async Task ShopExistsByIdReturnFalseWhenDoNotExist()
        {
            bool result = await this.shopService.ShopExistsByIdAsync(33);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShopExistsByIdReturnTrueWhenExists()
        {
            var shopId = PetShopBg.Id;

            bool result = await this.shopService.ShopExistsByIdAsync(shopId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ShopExistsByNameReturnFalseWhenDoNotExist()
        {
            bool result = await this.shopService.ShopExistsByNameAsync("PetShop");

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShopExistsByNameReturnTrueWhenExists()
        {
            var shopName = PetShopBg.Name;

            bool result = await this.shopService.ShopExistsByNameAsync(shopName);

            Assert.IsTrue(result);
        }
    }
}
