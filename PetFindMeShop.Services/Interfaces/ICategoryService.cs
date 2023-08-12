namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.Category;

    public interface ICategoryService
    {
        Task<bool> ExistsByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);

        Task<bool> ExistsByOtherNameAsync(int id, string name);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();

        Task<CategoryFormViewModel> GetCategoryForEditByIdAsync(int id);

        Task Create(CategoryFormViewModel model);

        Task Edit(int id, CategoryFormViewModel model);

        Task Delete(int id);
    }
}
