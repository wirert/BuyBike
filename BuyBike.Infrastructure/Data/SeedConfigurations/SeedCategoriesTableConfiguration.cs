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
                    Id = 1,
                    Name = "Планински",
                    TypeId = 1,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/mountain-unsplash.jpg"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Шосейни",
                    TypeId = 1,
                    Description = "Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/road-unsplash.jpg"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Градски",
                    TypeId = 1,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi  quibusdam!",
                    ImageUrl = "categories/city-unsplash.jpg"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Детски",
                    TypeId = 1,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/kids-unsplash.jpg"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Електрически",
                    TypeId = 1,
                    Description = "Lorem ipsum elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!",
                    ImageUrl = "categories/ebikes-unsplash.jpg"
                },

                new Category()
                {
                    Id = 8,
                    Name = "Вилки",
                    TypeId = 2,
                    Description = "Lorem ipsum elit. Maiores ,  reici voluptatem quibusdam!",
                    ImageUrl = "categories/fork.jpg"
                },
                 new Category()
                {
                    Id = 9,
                    Name = "Команди",
                    TypeId = 2,
                    Description = "Lorem ipsum elit. Maiores ,  reici voluptatem quibusdam!",
                    ImageUrl = "categories/gear-shifter.jpg"
                },
                new Category()
                {
                    Id = 10,
                    Name = "Вериги",
                    TypeId = 2,
                    Description = "Lorem ipsum elit. Reici voluptatem quibusdam!",
                    ImageUrl = "categories/chain.jpg"
                },

                ]);

        }
    }
}
