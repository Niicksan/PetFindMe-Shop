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

            return View(indexViewModel.ToList());
        }

        [Route("/error-400")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error400()
        {
            return View("Error400");
        }

        [Route("Home/Error/401")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error401()
        {
            return View("Error401");
        }

        [Route("/error-403")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error403()
        {
            return View("Error403");
        }

        [Route("/error-404")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error404()
        {
            return View("Error404");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}