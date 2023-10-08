namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Product;
    using PetFindMeShop.Web.Infrastructure.Extensions;
    using PetFindMeShop.Web.Infrastructure.Filters;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ShoppingCartController : ErrorController
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IShoppingCartItemService shoppingCartItemService;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService,
            IShoppingCartItemService shoppingCartItemService)
        {
            this.shoppingCartService = shoppingCartService;
            this.shoppingCartItemService = shoppingCartItemService;
        }

        public IActionResult MyShoppingCart()
        {
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(ProductExistsValidationFilter))]
        public async Task<IActionResult> AddToCart(int id, ProductBoughtQuantityFormViewModel formModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Невалидно количество!";

                return View("~/Views/Product/Details.cshtml", formModel);
            }

            try
            {
                string? userId = User.GetId();
                bool isUserHasCart = await shoppingCartService.ExistsByUserIdAsync(userId!);

                if (!isUserHasCart)
                {
                    await shoppingCartService.CreateUserShoppingCart(userId!);
                }

                string shoppingCartId = await shoppingCartService.GetCartIdByUserIdAsync(userId!);
                bool isItemAddedToCart = await shoppingCartItemService.ProductAddedToCart(id, shoppingCartId!);

                if (!isItemAddedToCart)
                {
                    await shoppingCartItemService.AddProductToCart(id, shoppingCartId, formModel);

                    TempData[SuccessMessage] = "Продуктът е добавен в количката!";

                    return Redirect(Request.Headers["Referer"].ToString());

                }
                else
                {
                    await shoppingCartItemService.UpdateProductInCart(id, shoppingCartId, formModel);

                    TempData[SuccessMessage] = "Продуктът в количката е обновен!";

                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
    }
}
