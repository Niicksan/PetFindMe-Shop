namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static PetFindMeShop.Common.EntityValidationConstants.Shop;

    [Comment("Shop")]
    public class Shop
    {
        public Shop()
        {
            this.ShopManagers = new HashSet<ShopsManagers>();
            this.ShopProducts = new HashSet<Product>();
            this.Orders = new HashSet<Order>();
        }

        [Comment("Primery key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the Shop")]
        [Required]
        [MinLength(ShopNameMinLength)]
        [MaxLength(ShopNameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Shop image name")]
        [Required]
        [MaxLength(ShopImageNameMaxLength)]
        public string ShopImageName { get; set; }

        [Comment("Description of the shop")]
        [Required]
        [MinLength(ShopDescriptionMinLength)]
        [MaxLength(ShopDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ShopsManagers> ShopManagers { get; set; }

        public virtual ICollection<Product> ShopProducts { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}