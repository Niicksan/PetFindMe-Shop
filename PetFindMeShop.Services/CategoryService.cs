namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.Services.Mapping;
    using PetFindMeShop.ViewModels.Category;

    public class CategoryService : ICategoryService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public CategoryService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            bool result = await dbContext
                .Categories
                .AnyAsync(c => c.Name == name);

            return result;
        }

        public async Task<bool> ExistsByOtherNameAsync(int id, string name)
        {
            bool result = await dbContext
                 .Categories
                 .Where(c => c.Id != id && c.Name == name)
                 .AnyAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await dbContext
                 .Categories
                 .Select(c => c.Name)
                 .ToArrayAsync();

            return allNames;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            IEnumerable<CategoryViewModel> allCategories = await dbContext
                 .Categories
                 .AsNoTracking()
                 .To<CategoryViewModel>()
                 .ToArrayAsync();

            return allCategories;
        }

        public async Task<CategoryFormViewModel> GetCategoryForEditByIdAsync(int id)
        {
            Category category = await this.dbContext
               .Categories
               .FirstAsync(c => c.Id == id);

            return new CategoryFormViewModel
            {
                Name = category.Name
            };
        }

        public async Task Create(CategoryFormViewModel model)
        {
            Category category = AutoMapperConfig.MapperInstance.Map<Category>(model);

            await this.dbContext.Categories.AddAsync(category);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Edit(int id, CategoryFormViewModel model)
        {
            Category category = await this.dbContext
                .Categories
                .FirstAsync(c => c.Id == id);

            category.Name = model.Name;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Category categoryToDelete = await this.dbContext
                .Categories
                .FirstAsync(c => c.Id == id);

            this.dbContext.Remove(categoryToDelete);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
