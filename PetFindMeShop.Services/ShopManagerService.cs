namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.ShopManager;
    using System.Threading.Tasks;

    public class ShopManagerService : IShopManagerService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public ShopManagerService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ManagerExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
              .ShopManager
              .AnyAsync(m => m.CustomerId.ToString() == userId);

            return result;
        }

        public async Task<bool> ManagerExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
                .ShopManager
                .AnyAsync(m => m.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<string?> GetManagerIdByUserIdAsync(string userId)
        {
            ShopManager? manager = await dbContext
               .ShopManager
               .FirstOrDefaultAsync(m => m.CustomerId.ToString() == userId);
            if (manager == null)
            {
                return null;
            }

            return manager.Id.ToString();
        }

        public async Task Create(string userId, ShopManagerFormModel model)
        {
            ShopManager manager = new ShopManager()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                CustomerId = Guid.Parse(userId)
            };

            await dbContext.ShopManager.AddAsync(manager);
            await dbContext.SaveChangesAsync();
        }
    }
}
