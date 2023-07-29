namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Services.Interfaces;

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

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await dbContext
                 .Categories
                 .Select(c => c.Name)
                 .ToArrayAsync();

            return allNames;
        }
    }
}
