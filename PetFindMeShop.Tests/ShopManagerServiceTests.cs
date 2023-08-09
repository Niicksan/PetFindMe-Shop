namespace PetFindMeShop.Tests
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Services;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.ShopManager;

    using static DatabaseSeeder;

    public class ShopManagerServiceTests
    {
        private DbContextOptions<PetFindMeShopDbContext> dbOptions;
        private PetFindMeShopDbContext dbContext;

        private IShopManagerService shopManagerService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<PetFindMeShopDbContext>()
                .UseInMemoryDatabase("PetFindMeShopInMemory")
                .Options;
            this.dbContext = new PetFindMeShopDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.shopManagerService = new ShopManagerService(this.dbContext);
        }

        [Test]
        public async Task ManagerExistsByUserIdShouldReturnTrueWhenExists()
        {
            string existingShopManagerId = ShopManagerUser.Id.ToString();

            bool result = await this.shopManagerService.ManagerExistsByUserIdAsync(existingShopManagerId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ManagerExistsByUserIdShouldReturnFalseWhenDoNotExist()
        {
            string notExistingShopManagerId = CustomerUser.Id.ToString();

            bool result = await this.shopManagerService.ManagerExistsByUserIdAsync(notExistingShopManagerId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ManagerExistsByPhoneNumberShouldReturnTrueWhenExists()
        {
            string existingShopManagerPhoneNumber = ShopManager.PhoneNumber;

            bool result = await this.shopManagerService.ManagerExistsByPhoneNumberAsync(existingShopManagerPhoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ManagerExistsByOtherPhoneNumberhouldReturnTrueWhenExists()
        {
            string shopManagerId = ShopManager.Id.ToString();
            string phoneNumber = "+359888888899";

            bool result = await this.shopManagerService.ManagerExistsByOtherPhoneNumberAsync(shopManagerId, phoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetManagerIdByUserIdAShouldReturnTrue()
        {
            string shopManagerUserId = ShopManagerUser.Id.ToString();
            string shopManagerId = ShopManager.Id.ToString();

            string result = await this.shopManagerService.GetManagerIdByUserIdAsync(shopManagerUserId);

            Assert.AreEqual(shopManagerId, result!);
        }

        [Test]
        public async Task ManagerHasAccesShouldReturnTrue()
        {
            string shopManagerUserId = ShopManagerUser.Id.ToString();
            int shopId = PetShopBg.Id;

            bool result = await this.shopManagerService.ManagerAllowedToAccess(shopId, shopManagerUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ManagerHasAccesShouldReturnFalse()
        {
            string shopManagerUserId = ShopManagerUser.Id.ToString();
            int shopId = PetStoreBg.Id;

            bool result = await this.shopManagerService.ManagerAllowedToAccess(shopId, shopManagerUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetManagerForEditByIdAShouldReturnManager()
        {
            string shopManagerUserId = ShopManagerUser.Id.ToString();
            var manager = ShopManager;

            var model = new ShopManagerFormViewModel()
            {
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                PhoneNumber = manager.PhoneNumber
            };

            var result = await this.shopManagerService.GetManagerForEditByIdAsync(shopManagerUserId);

            result.Should().BeEquivalentTo(model);
        }
    }
}