namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
   

    internal class SeedAttributeTableConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Entities.Attribute> builder)
        {
            builder.HasData(
                [
                    new Attribute()
                    {
                        Id = 1,
                        Name = "TyreSize",
                        DataType = "double",
                        ProductTypeId = 1,
                    },
                     new Attribute()
                    {
                        Id = 2,
                        Name = "Material",
                        ProductTypeId = 1,
                    },
                     new Attribute()
                    {
                        Id = 3,
                        Name = "Brakes",
                        ProductTypeId = 1,
                    },
                     new Attribute()
                    {
                        Id = 4,
                        Name = "Suspention",
                        ProductTypeId = 1,
                    },
                     new Attribute()
                    {
                        Id = 5,
                        Name = "Style",
                        ProductTypeId = 1,
                    },
                ]);
        }
    }
}
