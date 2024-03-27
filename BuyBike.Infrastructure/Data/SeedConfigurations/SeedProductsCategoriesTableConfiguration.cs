namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SeedProductsCategoriesTableConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                [
                     new ProductCategory()
                {
                    Id = 1,
                    Name = "Mountain",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                new ProductCategory()
                {
                    Id = 2,
                    Name = "Road",
                    Description = "Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                new ProductCategory()
                {
                    Id = 3,
                    Name = "City",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi  quibusdam!"
                },
                new ProductCategory()
                {
                    Id = 4,
                    Name = "Kids",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                new ProductCategory()
                {
                    Id = 5,
                    Name = "Electric",
                    Description = "Lorem ipsum elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!"
                },
                ]);
        }
    }
}
