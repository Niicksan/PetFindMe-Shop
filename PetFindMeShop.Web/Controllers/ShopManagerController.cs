namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Shop;
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
        public async Task<IActionResult> Create(ShopManagerFormViewModel model)
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
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно.";

                return RedirectToAction("Error400", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            try
            {
                ShopManagerFormViewModel formModel = await shopManagerService.GetManagerForEditByIdAsync(userId!);

                return View(formModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно.";

                return RedirectToAction("Error400", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShopManagerFormViewModel model)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            bool isPhoneNumberTaken = await shopManagerService.ManagerExistsByOtherPhoneNumberAsync(userId!, model.PhoneNumber);

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
                await shopManagerService.Edit(userId!, model);

                TempData[SuccessMessage] = "Успешно редактиране!";

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно.";

                return RedirectToAction("Error400", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("/manager/shops")]
        public async Task<IActionResult> MyShops()
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            try
            {
                string? managerId = await shopManagerService.GetManagerIdByUserIdAsync(userId!);

                IEnumerable<ShopViewModel> viewmodel = await shopManagerService.GetAllManagerShopsByManagerIdAsync(managerId!);

                return View(viewmodel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно.";

                return RedirectToAction("Error400", "Home");
            }
        }
    }
}
