namespace PetFindMeShop.ViewModels.Product
{
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageName { get; set; } = null!;

        public decimal? Price { get; set; }
    }
}
