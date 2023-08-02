namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Shop;
    using PetFindMeShop.Web.Infrastructure.Extensions;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ShopController : Controller
    {
        private readonly IShopService shopService;
        private readonly IShopManagerService shopManagerService;


        public ShopController(IShopService shopService, IShopManagerService shopManagerService)
        {
            this.shopService = shopService;
            this.shopManagerService = shopManagerService;
        }

        [HttpGet]
        [Route("/manager/shops/create")]
        public async Task<IActionResult> Create()
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            return View();
        }

        [HttpPost]
        [Route("/manager/shops/create")]
        public async Task<IActionResult> Create(ShopFormViewModel model)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int shopId = await shopService.CreateAndReturnShopIdAsync(model);
                await shopManagerService.CreateRelationBetweenShopAndManager(shopId, userId!);

                TempData[SuccessMessage] = "Успешно създаване!";

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно.";

                return RedirectToAction("Error400", "Home");
            }

            return RedirectToAction("MyShops", "ShopManager");
        }

        [HttpGet]
        [Route("/manager/shops/edit/{id?}")]
        public async Task<IActionResult> Edit(int id)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            bool isShopExists = await shopService.ShopExistsByIdAsync(id);

            if (!isShopExists)
            {
                TempData[ErrorMessage] = "Несъществуващ магазин!";

                return RedirectToAction("Error404", "Home");
            }

            try
            {
                ShopFormViewModel formModel = await shopService.GetShopForEditByIdAsync(id);

                return View(formModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно!";

                return RedirectToAction("Error400", "Home");
            }
        }

        [HttpPost]
        [Route("/manager/shops/edit/{id?}")]
        public async Task<IActionResult> Edit(int id, ShopFormViewModel model)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            bool isShopExists = await shopService.ShopExistsByIdAsync(id);

            if (!isShopExists)
            {
                TempData[ErrorMessage] = "Несъществуващ магазин!";

                return RedirectToAction("Error404", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await shopService.Edit(id, model);

                TempData[SuccessMessage] = "Успешно редактиране!";

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно!";

                return RedirectToAction("Error400", "Home");
            }

            return RedirectToAction("MyShops", "ShopManager");
        }

        [HttpGet]
        [Route("/manager/shops/details/{id?}")]
        public async Task<IActionResult> Details(int id)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                TempData[ErrorMessage] = "Не сте мениджър!";

                return RedirectToAction("Error403", "Home");
            }

            bool isShopExists = await shopService.ShopExistsByIdAsync(id);

            if (!isShopExists)
            {
                TempData[ErrorMessage] = "Несъществуващ магазин!";

                return RedirectToAction("Error404", "Home");
            }

            try
            {
                ShopDetailsViewModel shopModel = await shopService.GetShopDetailsByIdAsync(id);

                return View(shopModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно!";

                return RedirectToAction("Error400", "Home");
            }
        }
    }
}
