using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetFindMeShop.Web.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        public IActionResult MyShoppingCart()
        {
            return View();
        }
    }
}
