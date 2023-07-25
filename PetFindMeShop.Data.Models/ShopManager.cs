namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static PetFindMeShop.Common.EntityValidationConstants.ShopManager;

    [Comment("ShopManager")]
    public class ShopManager
    {
        public ShopManager()
        {
            this.Id = Guid.NewGuid();
            this.Shops = new HashSet<ShopsManagers>();
        }

        [Comment("Primery key")]
        [Key]
        public Guid Id { get; set; }

        [Comment("ShopManager FirstName")]
        [Required]
        [MinLength(FirstNameMinLength)]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Comment("ShopManager LastName")]
        [Required]
        [MinLength(LastNameMinLength)]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Comment("ShopManager PhoneNumber")]
        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        [Comment("ForeignKey to Customer")]
        [Required]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ShopsManagers> Shops { get; set; }
    }
}
