namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.Services.Models;
    using PetFindMeShop.ViewModels.Product;
    using PetFindMeShop.ViewModels.Product.Enums;

    public class ProductService : IProductService
    {
        private readonly PetFindMeShopDbContext dbContext;

        public ProductService(PetFindMeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductViewModel>> LastestProductAsync()
        {
            IEnumerable<ProductViewModel> lastestProducts = await dbContext
                .Products
                .Where(p => p.IsAvailable)
                .OrderByDescending(p => p.CreatedAt)
                .Take(16)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageName,
                    Price = p.Price
                })
                .ToArrayAsync();

            return lastestProducts;
        }

        public async Task<AllProductsFilteredAndPagedServiceModel> AllAsync(AllProductsQueryModel queryModel)
        {
            IQueryable<Product> productsQuery = dbContext
                .Products
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                productsQuery = productsQuery
                    .Where(h => h.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                productsQuery = productsQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                                EF.Functions.Like(h.Description, wildCard));
            }

            productsQuery = queryModel.ProductSorting switch
            {
                ProductSorting.Newest => productsQuery
                    .OrderByDescending(p => p.CreatedAt),
                ProductSorting.Oldest => productsQuery
                    .OrderBy(p => p.CreatedAt),
                ProductSorting.PriceAscending => productsQuery
                    .OrderBy(p => p.Price),
                ProductSorting.PriceDescending => productsQuery
                    .OrderByDescending(h => h.Price)
            };

            IEnumerable<ProductViewModel> allProducts = await productsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ProductsPerPage)
                .Take(queryModel.ProductsPerPage)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageName,
                    Price = p.Price
                })
                .ToArrayAsync();
            int totalproducts = productsQuery.Count();

            return new AllProductsFilteredAndPagedServiceModel()
            {
                TotalProductsCount = totalproducts,
                Products = allProducts
            };
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
