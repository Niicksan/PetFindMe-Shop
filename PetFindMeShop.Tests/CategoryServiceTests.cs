namespace PetFindMeShop.Tests
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Services;
    using PetFindMeShop.Services.Interfaces;

    using static DatabaseSeeder;

    public class CategoryServiceTests
    {
        private DbContextOptions<PetFindMeShopDbContext> dbOptions;
        private PetFindMeShopDbContext dbContext;

        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<PetFindMeShopDbContext>()
                .UseInMemoryDatabase("PetFindMeShopInMemory")
                .Options;
            this.dbContext = new PetFindMeShopDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task CategoryExistsByIdShouldReturnFalseWhenDoNotExist()
        {
            bool result = await this.categoryService.ExistsByIdAsync(33);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CategoryExistsByIdShouldReturnTrueWhenExists()
        {
            int existingCategoryId = DogBedCategory.Id;

            bool result = await this.categoryService.ExistsByIdAsync(existingCategoryId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ReturnAllCategoryNames()
        {
            IEnumerable<string> categoriesNmaes = new string[] { "Сухи храни за кучета", "Сухи храни за котки", "Легла за куче" };
            int count = categoriesNmaes.Count()
                ;
            var result = await this.categoryService.AllCategoryNamesAsync();

            Assert.That(result, Is.EqualTo(categoriesNmaes));
            Assert.That(result.Count(), Is.EqualTo(count));
        }
    }
}
