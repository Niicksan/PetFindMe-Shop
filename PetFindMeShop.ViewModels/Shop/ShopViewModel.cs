namespace PetFindMeShop.ViewModels.Shop
{
    using AutoMapper;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static PetFindMeShop.Common.EntityValidationConstants.Shop;

    public class ShopViewModel : IMapFrom<ShopsManagers>, IHaveCustomMappings
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ShopsManagers, ShopViewModel>()
                .ForMember(f => f.Id, opt =>
                    opt.MapFrom(t => t.Shop.Id))
                .ForMember(f => f.Name, opt =>
                    opt.MapFrom(t => t.Shop.Name))
                .ForMember(f => f.ShopImageName,
                    opt => opt.MapFrom(t => t.Shop.ShopImageName));
        }
    }
}
