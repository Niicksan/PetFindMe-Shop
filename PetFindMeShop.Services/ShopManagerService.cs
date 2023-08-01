namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.Services.Mapping;
    using PetFindMeShop.ViewModels.Shop;
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

        public async Task<bool> ManagerExistsByOtherPhoneNumberAsync(string userId, string phoneNumber)
        {
            bool result = await dbContext
                 .ShopManager
                 .Where(m => m.CustomerId.ToString() != userId.ToString() && m.PhoneNumber == phoneNumber)
                 .AnyAsync();

            return result;
        }

        public async Task<ShopManagerFormViewModel> GetManagerForEditByIdAsync(string userId)
        {
            ShopManager manager = await dbContext
                .ShopManager
                .FirstAsync(m => m.CustomerId.ToString() == userId);

            return new ShopManagerFormViewModel
            {
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                PhoneNumber = manager.PhoneNumber,
            };
        }

        public async Task<IEnumerable<ShopViewModel>> GetAllManagerShopsByManagerIdAsync(string userId)
        {
            return await dbContext.ShopsManagers
                .Where(sm => sm.ShopManagerId.ToString() == userId)
                .To<ShopViewModel>()
                .ToListAsync();
        }

        public async Task Create(string userId, ShopManagerFormViewModel model)
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

        public async Task Edit(string userId, ShopManagerFormViewModel model)
        {
            ShopManager manager = await dbContext
                .ShopManager
                .FirstAsync(m => m.CustomerId.ToString() == userId);

            manager.FirstName = model.FirstName;
            manager.LastName = model.LastName;
            manager.PhoneNumber = model.PhoneNumber;
            manager.UpdatedAt = DateTime.Now;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
