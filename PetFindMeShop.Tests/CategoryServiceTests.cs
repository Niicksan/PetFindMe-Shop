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
            IEnumerable<string> categoriesNmaes = new string[] { "Купи и диспенсъри за храна и вода", "Гребени и четки", "Сухи храни за кучета" };
            int count = 18;
            var result = await this.categoryService.AllCategoryNamesAsync();

            Assert.That(result.First(), Is.EqualTo(categoriesNmaes.First()));
            Assert.That(result.Skip(1).Take(1), Is.EqualTo(categoriesNmaes.Skip(1).Take(1)));
            Assert.That(result.Count(), Is.EqualTo(count));
        }
    }
}
