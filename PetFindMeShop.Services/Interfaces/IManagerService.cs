namespace PetFindMeShop.Services.Interfaces
{
    public interface IManagerService
    {
        Task<bool> AgentExistsByUserIdAsync(string userId);
    }
}
