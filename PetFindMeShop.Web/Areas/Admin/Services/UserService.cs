namespace PetFindMeShop.Web.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Web.Areas.Admin.ViewModels;

    public class UserService : IUserService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public UserService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Customers
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                })
                .ToListAsync();

            foreach (UserViewModel user in allUsers)
            {
                ShopManager? manager = this.dbContext
                    .ShopManager
                    .FirstOrDefault(m => m.CustomerId.ToString() == user.Id);

                if (manager != null)
                {
                    user.PhoneNumber = manager.PhoneNumber;
                    user.FullName = $"{manager.FirstName} {manager.LastName}";
                    user.isManager = true;
                }
            }

            return allUsers;
        }
    }
}
