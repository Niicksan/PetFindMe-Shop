namespace PetFindMeShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Comment("Customer")]
    public class Customer : IdentityUser<Guid>
    {
        public Customer()
        {
            this.Id = Guid.NewGuid();
            this.LikedProducts = new HashSet<LikedProducts>();
            this.BoughtProducts = new HashSet<Order>();
        }

        [Comment("Date and time of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Date and time of updation")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<LikedProducts> LikedProducts { get; set; }

        public virtual ICollection<Order> BoughtProducts { get; set; }
    }
}
