namespace PetFindMeShop.Data.Configurations.SeedDbConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFindMeShop.Data.Models;

    public class SeedCategoriesEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            // All
            category = new Category()
            {
                Id = 1,
                Name = "Купи и диспенсъри за храна и вода"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Гребени и четки"
            };
            categories.Add(category);

            // Dogs
            category = new Category()
            {
                Id = 3,
                Name = "Сухи храни за кучета"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Консервирани храни за кучета"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Нашийници, нагръдници, поводи"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Легла за куче"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 7,
                Name = "Играчки за кучета"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 8,
                Name = "Шампоани за кучета"
            };
            categories.Add(category);

            // Cats
            category = new Category()
            {
                Id = 9,
                Name = "Сухи храни за котки"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 10,
                Name = "Консервирани храни за котки"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 11,
                Name = "Транспортни клетки"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 12,
                Name = "Катерушки и легла"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 13,
                Name = "Котешки тоалетни и консумативи"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 14,
                Name = "Играчки за катки"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 15,
                Name = "Шампоани за котки"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
