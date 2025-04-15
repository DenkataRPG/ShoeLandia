using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeLandia.Data.Models;

namespace ShoeLandia.Data.Seeder
{
    public class CategoriesSeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasData(GenerateCategories());

        }

        private List<Category> GenerateCategories()
        {
            List<Category> categories = new List<Category>();

            Category category1 = new Category()
            {
                Id = 1,
                IsDeleted = false,
                Name = "Men",

            };
            categories.Add(category1);

            Category category2 = new Category()
            {
                Id = 2,
                IsDeleted = false,
                Name = "Women",

            };
            categories.Add(category2);

            Category category3 = new Category()
            {
                Id = 3,
                IsDeleted = false,
                Name = "Kids",

            };
            categories.Add(category3);

            Category category4 = new Category()
            {
                Id = 4,
                IsDeleted = false,
                Name = "Discount",

            };
            categories.Add(category4);

            return categories;
        }

    }
}
