namespace PetFindMeShop.ViewModels.Category
{
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static PetFindMeShop.Common.EntityValidationConstants.Category;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Име на категория")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Името трябва да е с дължина поне 2 символа")]
        public string Name { get; set; } = null!;
    }
}
