namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.Services.Models;
    using PetFindMeShop.ViewModels.Product;

    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> LastestProductAsync();

        Task<AllProductsFilteredAndPagedServiceModel> AllAsync(AllProductsQueryModel queryModel);

        Task<bool> ExistsByIdAsync(int productId);

        Task<ProductDetailsViewModel> GetDetailsByIdAsync(int productId);
    }
}
