namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.Home;
    using PetFindMeShop.ViewModels.Product;

    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>> LastestProductAsync();

        Task<bool> ExistsByIdAsync(int productId);

        Task<ProductDetailsViewModel> GetDetailsByIdAsync(int productId);
    }
}
