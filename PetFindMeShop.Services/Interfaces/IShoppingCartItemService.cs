namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.Product;

    public interface IShoppingCartItemService
    {
        Task<bool> ProductAddedToCart(int productId, string cartId);

        Task AddProductToCart(int productId, string cartId, ProductBoughtQuantityFormViewModel formModel);

        Task UpdateProductInCart(int productId, string cartId, ProductBoughtQuantityFormViewModel formModel);

        Task RemoveProductFromCart(int productId, string cartId);
    }
}
