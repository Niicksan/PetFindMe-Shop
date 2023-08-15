namespace PetFindMeShop.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<bool> ExistsByUserIdAsync(string userId);

        Task<string?> GetCartIdByUserIdAsync(string userId);

        Task CreateUserShoppingCart(string userId);
    }
}
