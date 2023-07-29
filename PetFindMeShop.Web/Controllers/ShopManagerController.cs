namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.ShopManager;
    using PetFindMeShop.Web.Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ShopManagerController : Controller
    {
        private readonly IShopManagerService shopManagerService;

        public ShopManagerController(IShopManagerService shopManagerService)
        {
            this.shopManagerService = shopManagerService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);
            if (isShopManager)
            {
                TempData[ErrorMessage] = "Вече сте мениджър!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopManagerFormModel model)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (isShopManager)
            {
                TempData[ErrorMessage] = "Вече сте мениджър!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await shopManagerService.ManagerExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Мениджър с този телефон вече съществува!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await shopManagerService.Create(userId!, model);
                TempData[SuccessMessage] = "Успешно създаване!";

            }
            catch (Exception)
            {
                TempData[ErrorMessage] =
                    "Възникна грешка! Моля опитайте отново по-късно.";

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
