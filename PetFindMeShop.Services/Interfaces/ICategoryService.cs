namespace PetFindMeShop.Services.Interfaces
{
    public interface ICategoryService
    {
        //Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
