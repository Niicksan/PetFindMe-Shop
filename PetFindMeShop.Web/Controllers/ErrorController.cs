namespace PetFindMeShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationMessagesConstants;

    public class ErrorController : Controller
    {
        public IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Възникна грешка! Моля опитайте отново по-късно.";

            return RedirectToAction("Error400", "Home");
        }

        public IActionResult ForbiddenError()
        {
            TempData[ErrorMessage] = "Не сте мениджър!";

            return RedirectToAction("Error403", "Home");
        }

        public IActionResult NotFoundError()
        {
            TempData[ErrorMessage] = "Несъществуващ продукт";

            return RedirectToAction("Error404", "Home");
        }
    }
}
