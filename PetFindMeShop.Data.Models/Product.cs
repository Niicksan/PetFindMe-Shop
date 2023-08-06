namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static PetFindMeShop.Common.EntityValidationConstants.Product;

    [Comment("Product")]
    public class Product
    {
        [Comment("Primery key")]
        [Key]
        public int Id { get; set; }

        [Comment("Title of the product")]
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Image name of the product")]
        [Required]
        [MaxLength(ImageNameMaxLength)]
        public string ImageName { get; set; } = null!;

        [Comment("Description of the product")]
        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Price of the product")]
        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Comment("Quantity of the product")]
        [Required]
        [Range(QuantityMinValue, QuantityMaxValue)]
        public int AvailableQuantity { get; set; }

        [Comment("Is the product in stock")]
        [Required]
        public bool IsAvailable { get; set; }

        [Comment("ForeignKey to Category")]
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        [Comment("ForeignKey to Shop")]
        [Required]
        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public virtual Shop Shop { get; set; } = null!;

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }

        [Comment("Date and time of deletion")]
        public DateTime? DeletedAt { get; set; } = null;
    }
}