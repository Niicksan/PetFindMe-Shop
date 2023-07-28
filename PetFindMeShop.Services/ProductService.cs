namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Home;

    public class ProductService : IProductService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public ProductService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastestProductAsync()
        {
            IEnumerable<IndexViewModel> lastestProducts = await dbContext
                .Products
                .Where(p => p.IsAvailable)
                .OrderByDescending(p => p.CreatedAt)
                .Take(16)
                .Select(p => new IndexViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageName,
                    Price = p.Price
                })
                .ToArrayAsync();

            return lastestProducts;
        }
    }
}
