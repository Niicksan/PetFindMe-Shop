namespace PetFindMeShop.Web.Areas.Admin.Services
{
    using PetFindMeShop.Web.Areas.Admin.ViewModels;

    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
