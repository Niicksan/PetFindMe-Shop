namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static PetFindMeShop.Common.EntityValidationConstants.Order;

    [Comment("Order")]
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Comment("Primery key")]
        [Key]
        public Guid Id { get; set; }

        [Comment("ForeignKey to Customer")]
        [Required]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [Comment("ForeignKey to Shop")]
        [Required]
        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;

        [Comment("Customer's Full Name")]
        [Required]
        [MinLength(FullNameMinLength)]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Comment("Customer's City for delivery")]
        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        [Comment("Customer's Address for delivery")]
        [Required]
        [MinLength(AddressMinLength)]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Comment("Customer's Phone")]
        [Required]
        [StringLength(PhoneNumberLength, MinimumLength = PhoneNumberLength)]
        public string Phone { get; set; } = null!;

        [Comment("Total number of ordered")]
        [Required]
        [Range(1, 100)]
        public int OrderedProducts { get; set; }

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}