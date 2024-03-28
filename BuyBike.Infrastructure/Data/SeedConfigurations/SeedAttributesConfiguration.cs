﻿namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using BuyBike.Infrastructure.Data.Entities;

    internal class SeedAttributesConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasData(
                [
                    new Attribute()
                    {
                        Id = 1,
                       Name = "TyreSize",
                       DataType  = "double",
                       ProductTypeId = 6,
                    },
                    new Attribute()
                    {
                        Id = 2,
                       Name = "Material",
                       ProductTypeId = 6,
                    },
                    new Attribute()
                    {
                        Id = 3,
                       Name = "Brakes",
                       ProductTypeId = 6,
                    },
                     new Attribute()
                    {
                        Id = 4,
                       Name = "Suspention",
                       ProductTypeId = 6,
                    },
                    new Attribute()
                    {
                        Id = 5,
                       Name = "Style",
                       ProductTypeId = 6,
                    },
                ]);
        }
    }
}
