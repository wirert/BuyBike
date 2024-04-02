namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SeedCategoriesTableConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                [
                 new Category()
                {
                    Id = 6,
                    Name = "Велосипеди",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/bicycle-unsplash.jpg"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Части",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/Parts-Explained.jpg"
                },
                 new Category()
                {
                    Id = 1,
                    Name = "Планински",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/mountain-unsplash.jpg"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Шосейни",
                    ParentCategoryId = 6,
                    Description = "Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/road-unsplash.jpg"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Градски",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi  quibusdam!",
                    ImageUrl = "categories/city-unsplash.jpg"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Детски",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/kids-unsplash.jpg"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Електрически",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/ebikes-unsplash.jpg"
                },

                new Category()
                {
                    Id = 8,
                    Name = "Вилки",
                    ParentCategoryId = 7,
                    Description = "Lorem ipsum elit. Maiores ,  reici voluptatem quibusdam!",
                    ImageUrl = "categories/fork.jpg"
                },
                 new Category()
                {
                    Id = 9,
                    Name = "Команди",
                    ParentCategoryId = 7,
                    Description = "Lorem ipsum elit. Maiores ,  reici voluptatem quibusdam!",
                    ImageUrl = "categories/gear-shifter.jpg"
                },
                new Category()
                {
                    Id = 10,
                    Name = "Вериги",
                    ParentCategoryId = 7,
                    Description = "Lorem ipsum elit. Reici voluptatem quibusdam!",
                    ImageUrl = "categories/chain.jpg"
                },

                ]);

        }
    }
}
