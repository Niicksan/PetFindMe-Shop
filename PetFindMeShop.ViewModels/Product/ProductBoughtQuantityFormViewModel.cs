namespace PetFindMeShop.ViewModels.Product
{
    using AutoMapper;
    using PetFindMeShop.Data.Models;
    using PetFindMeShop.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static PetFindMeShop.Common.EntityValidationConstants.Product;

    public class ProductBoughtQuantityFormViewModel : IMapTo<ShoppingCartItem>, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Количество")]
        [Range(typeof(decimal), OnSiteQuantityMinValue, OnSiteQuantityMaxValue)]
        public int BoughtQuantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                 .CreateMap<ProductBoughtQuantityFormViewModel, ShoppingCartItem>()
                 .ForMember(sci => sci.ProductId, opt => opt.Ignore())
                 .ForMember(sci => sci.ShoppingCartId, opt => opt.Ignore());
        }
    }
}
