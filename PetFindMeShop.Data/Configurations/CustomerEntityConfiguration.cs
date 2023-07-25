namespace PetFindMeShop.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
              .Property(c => c.CreatedAt)
              .HasDefaultValueSql("GETDATE()");

            builder
               .Property(c => c.UpdatedAt)
               .HasDefaultValueSql("GETDATE()");

            builder.HasData(GenerateCustomers());
        }

        private Customer[] GenerateCustomers()
        {
            ICollection<Customer> customers = new HashSet<Customer>();

            Customer customer;
            PasswordHasher<Customer> ph;

            // Customer
            customer = new Customer()
            {
                Id = Guid.Parse("98C666AC-9AEE-80C3-5686-08DB7FBB6666"),
                UserName = "customer@abv.bg",
                NormalizedUserName = "CUSTOMER",
                Email = "customer@abv.bg",
                NormalizedEmail = "CUSTOMER@ABV.BG",
                EmailConfirmed = true,
                SecurityStamp = "LUTV3ZFEY6XFBCSJEGW3JIA62BBWBETZ",
                ConcurrencyStamp = "ffc7bb00-b000-4c61-b41b-e34f908c34c1",
                LockoutEnabled = true,
            };

            ph = new PasswordHasher<Customer>();
            customer.PasswordHash = ph.HashPassword(customer, "customer123");

            customers.Add(customer);

            // Manager
            customer = new Customer()
            {
                Id = Guid.Parse("811C2B9D-B754-44EF-783B-08DB7FBC8275"),
                UserName = "manager@abv.bg",
                NormalizedUserName = "MANAGER@ABV.BG",
                Email = "manager@abv.bg",
                NormalizedEmail = "MANAGER@ABV.BG",
                EmailConfirmed = true,
                SecurityStamp = "JZDXAYLLGTFDW2QPGEWCOEMNS2XMOHE5",
                ConcurrencyStamp = "4300bc13-f79a-42fb-abce-a54c520bbac5",
                LockoutEnabled = true,
            };

            ph = new PasswordHasher<Customer>();
            customer.PasswordHash = ph.HashPassword(customer, "manager123");

            customers.Add(customer);

            // Admin
            customer = new Customer()
            {
                Id = Guid.Parse("6DCF663D-7CC9-4249-73FC-08DB7FE046B6"),
                UserName = "admin@petfindmeshop.bg",
                NormalizedUserName = "ADMIN@PETFINDME.BG",
                Email = "admin@petfindmeshop.bg",
                NormalizedEmail = "ADMIN@PETFINDME.BG",
                EmailConfirmed = true,
                SecurityStamp = "KAKHTVIWBHSUI4ESCAVXXEFC2UZ2JX44",
                ConcurrencyStamp = "ab1755fa-4ea8-47e8-aa13-c57fae13a4a9",
                LockoutEnabled = true,
            };

            ph = new PasswordHasher<Customer>();
            customer.PasswordHash = ph.HashPassword(customer, "admin123");

            customers.Add(customer);

            return customers.ToArray();
        }
    }
}
