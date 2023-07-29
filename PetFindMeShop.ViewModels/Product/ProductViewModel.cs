namespace PetFindMeShop.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal? Price { get; set; }
    }
}
