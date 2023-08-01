namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.Services.Models;
    using PetFindMeShop.ViewModels.Product;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/products/all")]
        public async Task<IActionResult> AllProducts([FromQuery] AllProductsQueryModel queryModel)
        {
            AllProductsFilteredAndPagedServiceModel serviceModel =
                await productService.AllAsync(queryModel);

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
                TempData[ErrorMessage] = "Несъществуващ продукт";

                return RedirectToAction("Error404", "Home");
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

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Възникна грешка! Моля опитайте отново по-късно!";

            return RedirectToAction("Index", "Home");
        }
    }
}
