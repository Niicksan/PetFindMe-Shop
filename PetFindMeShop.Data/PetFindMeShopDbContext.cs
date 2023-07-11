namespace PetFindMeShop.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class PetFindMeShopDbContext : IdentityDbContext
    {
        public PetFindMeShopDbContext(DbContextOptions<PetFindMeShopDbContext> options)
            : base(options)
        {
        }
    }
}