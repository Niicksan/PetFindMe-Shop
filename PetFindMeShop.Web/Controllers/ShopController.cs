namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Shop;
    using PetFindMeShop.Web.Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ShopController : ErrorController
    {
        private readonly IShopService shopService;
        private readonly IShopManagerService shopManagerService;


        public ShopController(IShopService shopService, IShopManagerService shopManagerService)
        {
            this.shopService = shopService;
            this.shopManagerService = shopManagerService;
        }

        [HttpGet]
        [Route("/manager/shops/details/{id?}")]
        public async Task<IActionResult> Details(int id)
        {
            string? userId = User.GetId();
            bool isAdmin = User.IsAdmin();
            bool isShopOwner = await shopManagerService.ManagerAllowedToAccess(id, userId!);

            if (!isShopOwner && !isAdmin)
            {
                return ForbiddenError();
            }

            bool isShopExists = await shopService.ShopExistsByIdAsync(id);

            if (!isShopExists)
            {
                return NotFoundError();
            }

            try
            {
                ShopDetailsViewModel shopModel = await shopService.GetShopDetailsByIdAsync(id);

                return View(shopModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [Route("/manager/shops/create")]
        public async Task<IActionResult> Create()
        {
            string? userId = User.GetId();
            bool isAdmin = User.IsAdmin();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager && !isAdmin)
            {
                return ForbiddenError();
            }

            return View();
        }

        [HttpPost]
        [Route("/manager/shops/create")]
        public async Task<IActionResult> Create(ShopFormViewModel model)
        {
            string? userId = User.GetId();
            bool isAdmin = User.IsAdmin();
            bool isShopManager = await shopManagerService.ManagerExistsByUserIdAsync(userId!);

            if (!isShopManager && !isAdmin)
            {
                return ForbiddenError();
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

                return RedirectToAction("MyShops", "ShopManager");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [Route("/manager/shops/edit/{id?}")]
        public async Task<IActionResult> Edit(int id)
        {
            string? userId = User.GetId();
            bool isAdmin = User.IsAdmin();
            bool isShopOwner = await shopManagerService.ManagerAllowedToAccess(id, userId!);

            if (!isShopOwner && !isAdmin)
            {
                return ForbiddenError();
            }

            bool isShopExists = await shopService.ShopExistsByIdAsync(id);

            if (!isShopExists)
            {
                return NotFoundError();
            }

            try
            {
                ShopFormViewModel formModel = await shopService.GetShopForEditByIdAsync(id);

                ViewData["id"] = id;

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        [Route("/manager/shops/edit/{id?}")]
        public async Task<IActionResult> Edit(int id, ShopFormViewModel model)
        {
            string? userId = User.GetId();
            bool isAdmin = User.IsAdmin();
            bool isShopOwner = await shopManagerService.ManagerAllowedToAccess(id, userId!);

            if (!isShopOwner && !isAdmin)
            {
                return ForbiddenError();
            }

            bool isShopExists = await shopService.ShopExistsByIdAsync(id);

            if (!isShopExists)
            {
                return NotFoundError();
            }

            if (!ModelState.IsValid)
            {
                ViewData["id"] = id;

                return View(model);
            }

            try
            {
                await shopService.Edit(id, model);

                TempData[SuccessMessage] = "Успешно редактиране!";

                return RedirectToAction("MyShops", "ShopManager");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
    }
}
