namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.Services.Models;
    using PetFindMeShop.ViewModels.Product;
    using PetFindMeShop.Web.Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ProductController : ErrorController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IShopManagerService shopManagerService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService,
            IShopManagerService shopManagerService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.shopManagerService = shopManagerService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/products/all")]
        public async Task<IActionResult> AllProducts([FromQuery] AllProductsQueryModel queryModel)
        {
            AllProductsFilteredAndPagedServiceModel serviceModel = await productService.AllAsync(queryModel);

            queryModel.Products = serviceModel.Products;
            queryModel.TotalProducts = serviceModel.TotalProductsCount;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();

            return View(queryModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/products/details/{id?}")]
        public async Task<IActionResult> Details(int id)
        {
            bool isProductExists = await productService.ExistsByIdAsync(id);

            if (!isProductExists)
            {
                return NotFoundError();
            }

            try
            {
                ProductDetailsViewModel viewModel = await productService.GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [Route("/manager/shops/{id}/add-product")]
        public async Task<IActionResult> Create(int id)
        {
            string? userId = User.GetId();
            bool isShopOwner = await shopManagerService.ManagerAllowedToAccess(id, userId!);
            bool isAdmin = User.IsAdmin();

            if (!isShopOwner && !isAdmin)
            {
                return ForbiddenError();
            }

            try
            {
                ProductFormViewModel formModel = new ProductFormViewModel()
                {
                    Categories = await categoryService.AllCategoriesAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        [Route("/manager/shops/{id}/add-product")]
        public async Task<IActionResult> Create(int id, ProductFormViewModel formModel)
        {
            string? userId = User.GetId();
            bool isShopOwner = await shopManagerService.ManagerAllowedToAccess(id, userId!);
            bool isAdmin = User.IsAdmin();

            if (!isShopOwner && !isAdmin)
            {
                return ForbiddenError();
            }

            bool categoryExists = await categoryService.ExistsByIdAsync(formModel.CategoryId);
            if (!categoryExists)
            {
                // Adding model error to ModelState automatically makes ModelState Invalid
                ModelState.AddModelError(nameof(formModel.CategoryId), "Изберете валидна категория");
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await categoryService.AllCategoriesAsync();

                return View(formModel);
            }

            try
            {
                await productService.Create(id, formModel);

                TempData[SuccessMessage] = "Успешно създаване!";

                return RedirectToAction("Details", "Shop", new { id });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [Route("/manager/shops/products/edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            bool isProductExists = await productService.ExistsByIdAsync(id);

            if (!isProductExists)
            {
                return NotFoundError();
            }

            string? userId = User.GetId();
            int shopId = await productService.GetProductShopIdAsync(id);
            bool isShopOwner = await shopManagerService.ManagerAllowedToAccess(shopId, userId!);
            bool isAdmin = User.IsAdmin();

            if (!isShopOwner && !isAdmin)
            {
                return ForbiddenError();
            }

            try
            {
                ProductFormViewModel formModel = await productService.GetProductForEditByIdAsync(id);
                formModel.Categories = await categoryService.AllCategoriesAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        [Route("/manager/shops/products/edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel formModel)
        {
            bool isProductExists = await productService.ExistsByIdAsync(id);

            if (!isProductExists)
            {
                return NotFoundError();
            }

            string? userId = User.GetId();
            int shopId = await productService.GetProductShopIdAsync(id);
            bool isShopOwner = await shopManagerService.ManagerAllowedToAccess(shopId, userId!);
            bool isAdmin = User.IsAdmin();

            if (!isShopOwner && !isAdmin)
            {
                return ForbiddenError();
            }

            try
            {
                await productService.Edit(id, formModel);

                TempData[SuccessMessage] = "Успешно редактиране!";

                return RedirectToAction("Details", "Shop", new { id = shopId });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
    }
}
