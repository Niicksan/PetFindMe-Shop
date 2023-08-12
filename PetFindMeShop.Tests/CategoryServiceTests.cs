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

        [Test, Order(1)]
        public async Task CategoryExistsByIdShouldReturnFalseWhenDoNotExist()
        {
            bool result = await this.categoryService.ExistsByIdAsync(33);

            Assert.IsFalse(result);
        }

        [Test, Order(2)]
        public async Task CategoryExistsByIdShouldReturnTrueWhenExists()
        {
            int existingCategoryId = DogBedCategory.Id;

            bool result = await this.categoryService.ExistsByIdAsync(existingCategoryId);

            Assert.IsTrue(result);
        }

        [Test, Order(3)]
        public async Task CategoryExistsByNameShouldReturnFalseWhenDoNotExist()
        {
            bool result = await this.categoryService.ExistsByNameAsync("New Category");

            Assert.IsFalse(result);
        }

        [Test, Order(4)]
        public async Task CategoryExistsByNameShouldReturnTrueWhenExists()
        {
            string categoryName = DogBedCategory.Name;

            bool result = await this.categoryService.ExistsByNameAsync(categoryName);

            Assert.IsTrue(result);
        }

        [Test, Order(5)]
        public async Task CategoryExistsByOtherNameShouldReturnFalseWhenDoNotExist()
        {
            var dogBedCategory = DogBedCategory;

            bool result = await this.categoryService.ExistsByOtherNameAsync(dogBedCategory.Id, "New Category");

            Assert.IsFalse(result);
        }

        [Test, Order(6)]
        public async Task CategoryExistsByOtherNameShoulsReturnTrueWhenExists()
        {
            var dogfoodCategory = DogFoodCategory;
            var dogBedCategory = DogBedCategory;

            bool result = await this.categoryService.ExistsByOtherNameAsync(dogfoodCategory.Id, dogBedCategory.Name);

            Assert.IsTrue(result);
        }

        [Test, Order(7)]
        public async Task EdditingCurrentCategoryShouldBePossible()
        {
            var dogBedCategory = DogBedCategory;

            bool result = await this.categoryService.ExistsByOtherNameAsync(dogBedCategory.Id, dogBedCategory.Name);

            Assert.IsFalse(result);
        }

        [Test, Order(8)]
        public async Task ReturnAllCategoryNames()
        {
            IEnumerable<string> categoriesNmaes = new string[] { "Сухи храни за кучета", "Сухи храни за котки", "Легла за куче" };
            int count = categoriesNmaes.Count()
                ;
            var result = await this.categoryService.AllCategoryNamesAsync();

            Assert.That(result, Is.EqualTo(categoriesNmaes));
            Assert.That(result.Count(), Is.EqualTo(count));
        }

        [Test, Order(9)]
        public async Task DeleteCategory()
        {
            var dogBedCategory = DogBedCategory;

            await this.categoryService.Delete(dogBedCategory.Id);

            bool isExistsById = await this.categoryService.ExistsByIdAsync(dogBedCategory.Id);
            bool isExistsByName = await this.categoryService.ExistsByNameAsync(dogBedCategory.Name);

            Assert.IsFalse(isExistsById);
            Assert.IsFalse(isExistsByName);
        }
    }
}
