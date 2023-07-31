namespace PetFindMeShop.ViewModels.Shop
{
    using System.ComponentModel.DataAnnotations;

    using static PetFindMeShop.Common.EntityValidationConstants.Shop;

    public class ShopFormViewModel : ShopViewModel
    {
        [Required]
        [Display(Name = "Описание на магазина")]
        [StringLength(ShopDescriptionMaxLength, MinimumLength = ShopDescriptionMinLength, ErrorMessage = "Описанието трябва да е с дължина поне 10 символа")]
        public string Description { get; set; } = null!;
    }
}
