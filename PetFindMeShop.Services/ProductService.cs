namespace PetFindMeShop.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFindMeShop.Data;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.Services.Mapping;
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
                .Where(p => p.DeletedAt == null)
                .OrderByDescending(p => p.CreatedAt)
                .Take(6)
                .To<ProductViewModel>()
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
                    .Where(p => p.Category.Name == queryModel.Category)
                    .Where(p => p.DeletedAt == null);
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
                .To<ProductViewModel>()
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
                 .AnyAsync(p => p.Id == productId);

            return result;
        }

        public async Task<int> GetProductShopIdAsync(int productId)
        {
            Product product = await dbContext
               .Products
               .FirstAsync(p => p.Id == productId);

            return product.ShopId;
        }

        public async Task<ProductDetailsViewModel> GetDetailsByIdAsync(int productId, string userId)
        {
            Product product = await dbContext
                .Products
                .Include(p => p.Category)
                .Include(p => p.Shop)
                .FirstAsync(p => p.Id == productId);

            bool isLiked = await this.ProductAlreadyAddedToCustomerLikedCollection(userId!, productId);

            return new ProductDetailsViewModel
            {
                Id = product.Id,
                Title = product.Title,
                ImageName = product.ImageName,
                Price = product.Price,
                Category = product.Category.Name,
                ShopProviderName = product.Shop.Name,
                IsAvailable = product.IsAvailable,
                Status = product.IsAvailable ? "В наличност" : "Изчерпан",
                IsLiked = isLiked ? true : false,
                IsDeleted = product.DeletedAt != null ? true : false,
                Description = product.Description,
            };
        }

        public async Task<ProductFormViewModel> GetProductForEditByIdAsync(int productId)
        {
            Product product = await dbContext
                .Products
                .FirstAsync(s => s.Id == productId);

            return new ProductFormViewModel
            {
                Title = product.Title,
                ImageName = product.ImageName,
                CategoryId = product.CategoryId,
                AvailableQuantity = product.AvailableQuantity,
                Price = product.Price,
                Description = product.Description
            };
        }

        public async Task<bool> ProductAlreadyArchived(int productId)
        {
            bool result = await dbContext
                 .Products
                 .Where(p => p.DeletedAt != null)
                 .AnyAsync(p => p.Id == productId);

            return result;
        }

        public async Task Create(int shopId, ProductFormViewModel formModel)
        {
            Product product = AutoMapperConfig.MapperInstance.Map<Product>(formModel);
            product.ShopId = shopId;

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task Edit(int productId, ProductFormViewModel formModel)
        {
            Product product = await dbContext
                .Products
                .FirstAsync(p => p.Id == productId);

            product.Title = formModel.Title;
            product.ImageName = formModel.ImageName;
            product.CategoryId = formModel.CategoryId;
            product.AvailableQuantity = formModel.AvailableQuantity;
            product.Price = formModel.Price;
            product.Description = formModel.Description;
            product.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();
        }

        public async Task Archive(int productId)
        {
            Product productToDelete = await dbContext
                .Products
                .FirstAsync(p => p.Id == productId);

            productToDelete.IsAvailable = false;
            productToDelete.DeletedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();
        }

        public async Task Activate(int productId)
        {
            Product productToDelete = await dbContext
                .Products
                .FirstAsync(p => p.Id == productId);

            productToDelete.IsAvailable = true;
            productToDelete.DeletedAt = null;

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ProductAlreadyAddedToCustomerLikedCollection(string userId, int productId)
        {
            bool result = await dbContext
                 .LikedProducts
                 .AnyAsync(lp => lp.CustomerId.ToString() == userId && lp.ProductId == productId);

            return result;
        }

        public async Task AddProductToLikedCollectionAsync(string userId, int productId)
        {
            bool alreadyAdded = await this.ProductAlreadyAddedToCustomerLikedCollection(userId, productId);

            if (alreadyAdded == false)
            {
                var userBook = new LikedProducts
                {
                    CustomerId = Guid.Parse(userId),
                    ProductId = productId
                };

                await dbContext.LikedProducts.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveProductFromLikedCollectionAsync(string userId, int productId)
        {
            var likedProduct = await dbContext.LikedProducts
                    .FirstOrDefaultAsync(lp => lp.CustomerId.ToString() == userId && lp.ProductId == productId);

            if (likedProduct != null)
            {
                dbContext.LikedProducts.Remove(likedProduct);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LikedProductViewModel>> GetLikedProducts(string userId)
        {
            return await dbContext.LikedProducts
                .Where(lp => lp.CustomerId.ToString() == userId)
                .Select(p => new LikedProductViewModel
                {
                    Id = p.Product.Id,
                    Title = p.Product.Title,
                    ImageName = p.Product.ImageName,
                    IsAvailable = p.Product.IsAvailable,
                    Price = p.Product.Price,
                    Status = p.Product.IsAvailable ? "В наличност" : "Изчерпан",
                    IsLiked = true,
                    IsDeleted = p.Product.DeletedAt != null ? true : false,
                }).ToListAsync();
        }
    }
}
