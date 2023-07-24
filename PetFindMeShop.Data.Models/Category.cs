namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static PetFindMeShop.Common.EntityValidationConstants.Category;

    [Comment("Category")]
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Comment("Primery key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the Category")]
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}