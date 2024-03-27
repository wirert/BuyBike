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

    internal class SeedDiscountsConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasData(
                [
                new Discount()
                {
                    Id = 1,
                    Name = "10",
                    DiscountPercent = 10,
                },
                new Discount()
                {
                    Id = 2,
                    Name = "20",
                    DiscountPercent = 20,
                },
                new Discount()
                {
                    Id = 3,
                    Name = "40",
                    DiscountPercent = 40,
                },
                ]);
        }
    }
}
