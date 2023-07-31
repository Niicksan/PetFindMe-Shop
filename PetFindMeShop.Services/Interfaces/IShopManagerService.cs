namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.ShopManager;

    public interface IShopManagerService
    {
        Task<bool> ManagerExistsByUserIdAsync(string userId);

        Task<bool> ManagerExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> ManagerExistsByOtherPhoneNumberAsync(string userId, string phoneNumber);

        Task<string?> GetManagerIdByUserIdAsync(string userId);

        Task<ShopManagerFormViewModel> GetManagerForEditByIdAsync(string userId);

        Task Create(string userId, ShopManagerFormViewModel model);

        Task Edit(string userId, ShopManagerFormViewModel model);

    }
}
