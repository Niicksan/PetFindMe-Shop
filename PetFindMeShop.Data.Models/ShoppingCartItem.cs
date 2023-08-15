namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static PetFindMeShop.Common.EntityValidationConstants.Product;

    [Comment("Shopping Cart Item")]
    public class ShoppingCartItem
    {
        public ShoppingCartItem()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Primery key")]
        [Key]
        public Guid Id { get; set; }

        [Comment("ForeignKey to Product")]
        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("ForeignKey to Shopping Cart")]
        [Required]
        public Guid ShoppingCartId { get; set; }

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart ShoppingCart { get; set; } = null!;

        [Comment("Bought Quantity of the Product")]
        [Required]
        [Range(typeof(decimal), OnSiteQuantityMinValue, OnSiteQuantityMaxValue)]
        public int BoughtQuantity { get; set; }

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }
    }
}
