namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.Services.Models;
    using PetFindMeShop.ViewModels.Product;

    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> LastestProductAsync();

        Task<AllProductsFilteredAndPagedServiceModel> AllAsync(AllProductsQueryModel queryModel);

        Task<bool> ExistsByIdAsync(int productId);

        Task<int> GetProductShopIdAsync(int productId);

        Task<ProductDetailsViewModel> GetDetailsByIdAsync(int productId, string userId);

        Task<ProductFormViewModel> GetProductForEditByIdAsync(int productId);

        Task<bool> ProductAlreadyArchived(int productId);

        Task Create(int shopId, ProductFormViewModel formModel);

        Task Edit(int productId, ProductFormViewModel formModel);

        Task Archive(int productId);

        Task Activate(int productId);

        Task<bool> ProductAlreadyAddedToCustomerLikedCollection(string userId, int productId);

        Task AddProductToLikedCollectionAsync(string userId, int productId);

        Task RemoveProductFromLikedCollectionAsync(string userId, int productId);

        Task<IEnumerable<LikedProductViewModel>> GetLikedProducts(string userId);
    }
}
