namespace PetFindMeShop.ViewModels.Shop
{
    using PetFindMeShop.ViewModels.Product;

    public class ShopDetailsViewModel : ShopFormViewModel
    {
        public IEnumerable<ProductViewModel>? Products { get; set; }
    }
}
