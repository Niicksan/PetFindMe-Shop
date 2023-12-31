﻿namespace PetFindMeShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static PetFindMeShop.Common.EntityValidationConstants.Product;

    [Comment("Order Item")]
    public class OrderItem
    {
        [Comment("Primery key")]
        [Key]
        public int Id { get; set; }

        [Comment("ForeignKey to Product")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("ForeignKey to Order")]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Comment("ForeignKey to Shop")]
        [Required]
        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;

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
