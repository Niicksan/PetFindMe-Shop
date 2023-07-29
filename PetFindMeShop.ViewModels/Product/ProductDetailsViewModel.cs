namespace PetFindMeShop.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Image { get; set; } = null!;

        public decimal Price { get; set; }

        public string ShopProviderName { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
