namespace PetFindMeShop.Services.Interfaces
{
    using PetFindMeShop.ViewModels.Home;

    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>> LastestProductAsync();
    }
}
