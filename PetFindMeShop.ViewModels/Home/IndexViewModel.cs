namespace PetFindMeShop.ViewModels.Home
{
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;

    public class IndexViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal? Price { get; set; }
    }
}
