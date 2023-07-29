namespace PetFindMeShop.Services.Models
{
    using PetFindMeShop.ViewModels.Product;

    public class AllProductsFilteredAndPagedServiceModel
    {
        public AllProductsFilteredAndPagedServiceModel()
        {
            Products = new HashSet<ProductViewModel>();
        }

        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
