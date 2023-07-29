using Microsoft.AspNetCore.Mvc;
using PetFindMeShop.Services.Interfaces;
using PetFindMeShop.ViewModels.Product;

namespace PetFindMeShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductViewModel> indexViewModel =
                await productService.LastestProductAsync();

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            else if (statusCode == 403)
            {
                return View("Error403");
            }
            else if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
    }
}