namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.Services.Mapping;
    using PetFindMeShop.ViewModels.Product;
    using System.Threading.Tasks;

    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public ShoppingCartItemService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductToCart(int productId, string cartId, ProductBoughtQuantityFormViewModel formModel)
        {
            ShoppingCartItem cartItem = AutoMapperConfig.MapperInstance.Map<ShoppingCartItem>(formModel);
            cartItem.ProductId = productId;
            cartItem.ShoppingCartId = Guid.Parse(cartId);

            await this.dbContext.ShoppingCartItems.AddAsync(cartItem);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductInCart(int productId, string cartId, ProductBoughtQuantityFormViewModel formModel)
        {
            ShoppingCartItem cartItemToUpdate = await this.dbContext
                .ShoppingCartItems
                .FirstAsync(sci => sci.ProductId == productId && sci.ShoppingCartId.ToString() == cartId);

            if (cartItemToUpdate != null && cartItemToUpdate.BoughtQuantity != formModel.BoughtQuantity)
            {
                cartItemToUpdate.BoughtQuantity = formModel.BoughtQuantity;
                cartItemToUpdate.UpdatedAt = DateTime.Now;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveProductFromCart(int productId, string cartId)
        {
            ShoppingCartItem cartItemToDelete = await this.dbContext
               .ShoppingCartItems
               .FirstAsync(sci => sci.ProductId == productId && sci.ShoppingCartId.ToString() == cartId);

            if (cartItemToDelete != null)
            {
                this.dbContext.Remove(cartItemToDelete);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
