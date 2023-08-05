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
    public class ShopManagerController : ErrorController
    {
        private readonly IShopManagerService shopManagerService;

        public ShopManagerController(IShopManagerService shopManagerService)
        {
            this.shopManagerService = shopManagerService;
        }

        [HttpGet]
        [Route("/manager/create")]
        public async Task<IActionResult> Create()
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (isShopManager)
            {
                TempData[ErrorMessage] = "Вече сте мениджър!";

                return RedirectToAction("MyShops");
            }

            return View();
        }

        [HttpPost]
        [Route("/manager/create")]
        public async Task<IActionResult> Create(ShopManagerFormViewModel model)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (isShopManager)
            {
                TempData[ErrorMessage] = "Вече сте мениджър!";

                return RedirectToAction("MyShops");
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

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [Route("/manager/edit")]
        public async Task<IActionResult> Edit()
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                return ForbiddenError();
            }

            try
            {
                ShopManagerFormViewModel formModel = await shopManagerService.GetManagerForEditByIdAsync(userId!);

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        [Route("/manager/edit")]
        public async Task<IActionResult> Edit(ShopManagerFormViewModel model)
        {
            string? userId = User.GetId();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager)
            {
                return ForbiddenError();
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

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [Route("/manager/shops")]
        public async Task<IActionResult> MyShops()
        {
            string? userId = User.GetId();
            bool isAdmin = User.IsAdmin();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager && !isAdmin)
            {
                return ForbiddenError();
            }

            try
            {
                string? managerId = await shopManagerService.GetManagerIdByUserIdAsync(userId!);

                IEnumerable<ShopViewModel> viewmodel = await shopManagerService.GetAllManagerShopsByManagerIdAsync(managerId!);

                return View(viewmodel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
    }
}
