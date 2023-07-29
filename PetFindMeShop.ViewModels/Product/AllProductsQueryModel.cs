using PetFindMeShop.ViewModels.Product.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetFindMeShop.ViewModels.Product
{
    using static Common.GeneralApplicationConstants;

    public class AllProductsQueryModel
    {
        public AllProductsQueryModel()
        {
            CurrentPage = DefaultPage;
            ProductsPerPage = EntitiesPerPage;

            Categories = new HashSet<string>();
            Products = new HashSet<ProductViewModel>();
        }

        [Display(Name = "Категория")]
        public string? Category { get; set; }

        [Display(Name = "Потърси продукт")]
        public string? SearchString { get; set; }

        [Display(Name = "Подреди по")]
        public ProductSorting ProductSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Продукти")]
        public int ProductsPerPage { get; set; }

        public int TotalProducts { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

    }
}