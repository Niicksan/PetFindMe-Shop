namespace PetFindMeShop.ViewModels.Product
{
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;
    using PetFindMeShop.ViewModels.Category;
    using System.ComponentModel.DataAnnotations;
    using static PetFindMeShop.Common.EntityValidationConstants.Product;

    public class ProductFormViewModel : IMapTo<Product>
    {
        public ProductFormViewModel()
        {
            Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [Display(Name = "Име на продукт")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Името трябва да е с дължина поне 5 символа")]
        public string Title { get; set; } = null!;

        [Required]
        [Display(Name = "Снимка на продукт")]
        [StringLength(ImageNameMaxLength, ErrorMessage = "Моля качете снимка")]
        public string ImageName { get; set; } = null!;

        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Налично количество")]
        [Range(QuantityMinValue, QuantityMaxValue, ErrorMessage = "Моля въведете количество")]
        public int AvailableQuantity { get; set; }

        [Required]
        [Display(Name = "Цена на продукта")]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = "Моля въведете валидна цена")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Описанието на продукта")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Описанието трябва да е с дължина поне 10 символа")]
        public string Description { get; set; } = null!;

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
