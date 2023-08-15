namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using System.Threading.Tasks;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public ShoppingCartService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsByUserIdAsync(string userId)
        {
            return await dbContext
               .ShoppingCarts
               .AnyAsync(sc => sc.CustomerId.ToString() == userId);
        }

        public async Task<string?> GetCartIdByUserIdAsync(string userId)
        {
            ShoppingCart shoppingCart = await dbContext
              .ShoppingCarts
              .FirstAsync(sc => sc.CustomerId.ToString() == userId);

            return shoppingCart.Id.ToString();
        }

        public async Task CreateUserShoppingCart(string userId)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                CustomerId = Guid.Parse(userId),
            };

            await dbContext.ShoppingCarts.AddAsync(shoppingCart);
            await dbContext.SaveChangesAsync();
        }
    }
}
