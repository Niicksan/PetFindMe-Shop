namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Product;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AllProducts()
        {
            //AllHousesFilteredAndPagedServiceModel serviceModel =
            //    await houseService.AllAsync(queryModel);

            //queryModel.Houses = serviceModel.Houses;
            //queryModel.TotalHouses = serviceModel.TotalHousesCount;
            //queryModel.Categories = await categoryService.AllCategoryNamesAsync();

            //return View(queryModel);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "Несъществуващ продукт";

                return RedirectToRoute("AllProducts");
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
