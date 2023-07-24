namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Shopping Cart")]
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Id = Guid.NewGuid();
            this.ShoppingCardItems = new HashSet<ShoppingCartItem>();
        }

        [Comment("Primery key")]
        [Key]
        public Guid Id { get; set; }

        [Comment("ForeignKey to Customer")]
        [Required]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [Comment("Total Products Price")]
        public int TotalProductsPrice { get; set; }

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCardItems { get; set; }
    }
}
