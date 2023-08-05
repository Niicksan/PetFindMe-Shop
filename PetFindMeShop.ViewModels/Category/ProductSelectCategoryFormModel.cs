namespace PetFindMeShop.ViewModels.Category
{
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;

    public class ProductSelectCategoryFormModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
