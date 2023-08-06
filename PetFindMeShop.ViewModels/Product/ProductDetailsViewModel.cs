namespace PetFindMeShop.ViewModels.Product
{
    public class ProductDetailsViewModel : LikedProductViewModel
    {
        public string ShopProviderName { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
