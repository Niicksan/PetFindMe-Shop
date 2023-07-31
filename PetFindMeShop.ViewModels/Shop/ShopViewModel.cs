namespace PetFindMeShop.ViewModels.Shop
{
    using System.ComponentModel.DataAnnotations;

    using static PetFindMeShop.Common.EntityValidationConstants.Shop;

    public class ShopViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Име на магазина")]
        [StringLength(ShopNameMaxLength, MinimumLength = ShopNameMinLength, ErrorMessage = "Името трябва да е с дължина поне 2 символа")]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Снимка на магазина")]
        [StringLength(ShopImageNameMaxLength, ErrorMessage = "Качете снимка")]
        public string ShopImageName { get; set; } = null!;
    }
}
