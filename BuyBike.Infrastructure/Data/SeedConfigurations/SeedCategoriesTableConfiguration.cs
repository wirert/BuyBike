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
                    Name = "Колела",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Части",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                 new Category()
                {
                    Id = 1,
                    Name = "Mountain",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Road",
                    ParentCategoryId = 6,
                    Description = "Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                new Category()
                {
                    Id = 3,
                    Name = "City",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi  quibusdam!"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Kids",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Electric",
                    ParentCategoryId = 6,
                    Description = "Lorem ipsum elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                ]);
        }
    }
}
