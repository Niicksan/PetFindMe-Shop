namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.Shop;

    public interface IShopService
    {
        Task<bool> ShopExistsByIdAsync(int shopId);

        Task<bool> ShopExistsByNameAsync(string shopName);

        Task<ShopFormViewModel> GetShopForEditByIdAsync(int shopId);

        Task<ShopDetailsViewModel> GetShopDetailsByIdAsync(int shopId);

        Task<int> CreateAndReturnShopIdAsync(ShopFormViewModel model);

        Task Edit(int shopId, ShopFormViewModel model);
    }
}
