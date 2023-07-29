namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Home;
    using PetFindMeShop.ViewModels.Product;

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


        public async Task<bool> ExistsByIdAsync(int productId)
        {
            bool result = await dbContext
                 .Products
                 .Where(p => p.IsAvailable)
                 .AnyAsync(p => p.Id == productId);

            return result;
        }

        public async Task<ProductDetailsViewModel> GetDetailsByIdAsync(int productId)
        {
            Product product = await dbContext
                .Products
                .Include(p => p.Category)
                .Include(p => p.Shop)
                .FirstAsync(p => p.Id == productId);

            return new ProductDetailsViewModel
            {
                Id = product.Id,
                Title = product.Title,
                Image = product.ImageName,
                Price = product.Price,
                Category = product.Category.Name,
                ShopProviderName = product.Shop.Name,
                Status = product.IsAvailable ? "В наличност" : "Изчерпан",
                Description = product.Description,
            };
        }
    }
}
