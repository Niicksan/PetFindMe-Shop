namespace PetFindMeShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using PetFindMeShop.Services.Interfaces;
    using PetFindMeShop.ViewModels.Category;

    using static PetFindMeShop.Common.GeneralApplicationConstants;
    using static PetFindMeShop.Common.NotificationMessagesConstants;

    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryService categoryService;
        private readonly IMemoryCache memoryCache;

        public CategoryController(ICategoryService categoryService, IMemoryCache memoryCache)
        {
            this.categoryService = categoryService;
            this.memoryCache = memoryCache;
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryViewModel> categories =
                this.memoryCache.Get<IEnumerable<CategoryViewModel>>(CategoriesCacheKey);

            if (categories == null)
            {
                categories = await this.categoryService.AllCategoriesAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan
                        .FromMinutes(CategoriesCacheDurationMinutes));

                this.memoryCache.Set(CategoriesCacheKey, categories, cacheOptions);
            }

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryFormViewModel model)
        {
            bool isCategoryNameExists = await categoryService.ExistsByNameAsync(model.Name);

            if (isCategoryNameExists)
            {
                ModelState.AddModelError(nameof(model.Name), "Категорията вече съществува!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await categoryService.Create(model);

                TempData[SuccessMessage] = "Успешно добавена категория!";

                this.memoryCache.Remove(CategoriesCacheKey);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool isCategoryExists = await categoryService.ExistsByIdAsync(id);

            if (!isCategoryExists)
            {
                TempData[SuccessMessage] = "Несъществуваща категория!";

                return RedirectToAction("All");
            }

            try
            {
                CategoryFormViewModel formModel = await categoryService.GetCategoryForEditByIdAsync(id);

                ViewData["id"] = id;

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryFormViewModel model)
        {
            bool isCategoryExists = await categoryService.ExistsByIdAsync(id);

            if (!isCategoryExists)
            {
                TempData[SuccessMessage] = "Несъществуваща категория!";

                return RedirectToAction("All");
            }

            bool isCategoryNameExists = await categoryService.ExistsByOtherNameAsync(id, model.Name);

            if (isCategoryNameExists)
            {
                ModelState.AddModelError(nameof(model.Name), "Категорията вече съществува!");

                ViewData["id"] = id;
            }

            if (!ModelState.IsValid)
            {
                ViewData["id"] = id;

                return View(model);
            }

            try
            {
                await categoryService.Edit(id, model);

                TempData[SuccessMessage] = "Успешно редактиване!";

                this.memoryCache.Remove(CategoriesCacheKey);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool isCategoryExists = await categoryService.ExistsByIdAsync(id);

            if (!isCategoryExists)
            {
                TempData[SuccessMessage] = "Несъществуваща категория!";

                return RedirectToAction("All");
            }

            try
            {
                await categoryService.Delete(id);

                TempData[SuccessMessage] = "Категорията беше успешно изтрита!";

                this.memoryCache.Remove(CategoriesCacheKey);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        public IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно.";

            return RedirectToAction("Error400", "Home");
        }
    }
}
