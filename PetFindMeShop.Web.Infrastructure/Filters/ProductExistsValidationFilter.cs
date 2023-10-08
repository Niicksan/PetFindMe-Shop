using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetFindMeShop.Services.Interfaces;

namespace PetFindMeShop.Web.Infrastructure.Filters
{
    public class ProductExistsValidationFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public ProductExistsValidationFilter(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            var id = int.Parse((string)filterContext.RouteData.Values["id"]);

            bool isProductExists = await productService.ExistsByIdAsync(id);

            if (!isProductExists)
            {
                filterContext.Result = new RedirectToActionResult("AllProducts", "Product", null);
                return;
            }

            await next();
        }
    }
}
