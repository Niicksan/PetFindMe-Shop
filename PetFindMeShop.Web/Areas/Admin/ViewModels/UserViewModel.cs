namespace PetFindMeShop.Web.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        public bool isManager { get; set; } = false;
    }
}
