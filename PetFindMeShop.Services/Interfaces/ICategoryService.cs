namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.Category;

    public interface ICategoryService
    {
        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<IEnumerable<ProductSelectCategoryFormModel>> AllCategoriesAsync();
    }
}
