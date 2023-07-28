namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Services.Interfaces;
    using System.Threading.Tasks;

    public class ManagerService : IManagerService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public ManagerService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgentExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
              .ShopManager
              .AnyAsync(m => m.CustomerId.ToString() == userId);

            return result;
        }
    }
}
