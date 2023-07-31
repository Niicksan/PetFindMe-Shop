namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Shop;
    using System.Threading.Tasks;

    public class ShopService : IShopService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public ShopService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ShopExistsByIdAsync(int shopId)
        {
            bool result = await dbContext
              .Shops
              .AnyAsync(s => s.Id == shopId);

            return result;
        }

        public async Task<bool> ShopExistsByNameAsync(string shopName)
        {
            bool result = await dbContext
              .Shops
              .AnyAsync(s => s.Name == shopName);

            return result;
        }

        public async Task<ShopFormViewModel> GetShopForEditByIdAsync(int shopId)
        {
            Shop shop = await dbContext
               .Shops
               .FirstAsync(s => s.Id == shopId);

            return new ShopFormViewModel
            {
                Name = shop.Name,
                ShopImageName = shop.ShopImageName,
                Description = shop.Description,
            };
        }

        public Task Create(ShopFormViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int shopId, ShopFormViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
