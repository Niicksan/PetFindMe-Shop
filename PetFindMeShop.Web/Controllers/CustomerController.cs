namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Product;
    using PetFindMeShop.Web.Infrastructure.Extensions;

    [Authorize]
    public class CustomerController : ErrorController
    {
        private IProductService productService;

        public CustomerController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("/liked-products")]
        public async Task<IActionResult> LikedProducts()
        {
            try
            {
                string? userId = User.GetId();

                IEnumerable<LikedProductViewModel> viewmodel = await productService.GetLikedProducts(userId!);

                return View(viewmodel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
    }
}
