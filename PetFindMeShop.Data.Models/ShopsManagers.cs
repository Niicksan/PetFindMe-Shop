namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Shops Manager")]
    public class ShopsManagers
    {
        [Comment("Primery key")]
        [Key]
        public int Id { get; set; }

        [Comment("ForeignKey to Shop")]
        [Required]
        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;

        [Comment("ForeignKey to ShopManager")]
        [Required]
        public Guid ShopManagerId { get; set; }

        [ForeignKey(nameof(ShopManagerId))]
        public ShopManager ShopManager { get; set; } = null!;

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }
    }
}
