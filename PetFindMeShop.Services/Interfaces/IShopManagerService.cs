namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.ShopManager;

    public interface IShopManagerService
    {
        Task<bool> ManagerExistsByUserIdAsync(string userId);

        Task<bool> ManagerExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> ManagerExistsByOtherPhoneNumberAsync(string userId, string phoneNumber);

        Task<string?> GetManagerIdByUserIdAsync(string userId);

        Task<ShopManagerFormModel> GetManagerForEditByIdAsync(string userId);

        Task Create(string userId, ShopManagerFormModel model);

        Task Edit(string userId, ShopManagerFormModel model);

    }
}
