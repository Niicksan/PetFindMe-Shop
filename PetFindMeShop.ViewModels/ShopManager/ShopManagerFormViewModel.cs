namespace PetFindMeShop.ViewModels.ShopManager
{
    using AutoMapper;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using static PetFindMeShop.Common.EntityValidationConstants.ShopManager;

    public class ShopManagerFormViewModel : IMapTo<ShopManager>, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Вашето име")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = "Името трябва да е с дължина поне 2 символа")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Вашата фамилия")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = "Фамилията трябва да е с дължина поне 2 символа")]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "Вашият телефон")]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength, ErrorMessage = "Телефома трябва да е с дължина между 10 и 12 цифри")]
        public string PhoneNumber { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ShopManagerFormViewModel, ShopManager>()
                .ForMember(sm => sm.CustomerId, opt => opt.Ignore());
        }
    }
}
