namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using System;
    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BuyBike.Infrastructure.Data.Entities;

    internal class SeedManufacturersEntityConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasData(CreateManufacturers());
        }

        private Manufacturer[] CreateManufacturers()
            => [
                    new Manufacturer()
                    {
                        Id = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                        Name = "Giant",
                        LogoUrl = "brand-logos/giant.png"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"),
                        Name = "Cross",
                        LogoUrl = "brand-logos/cross.jpg"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                        Name = "Cube",
                        LogoUrl = "brand-logos/cube.png"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("fb2ef438-d045-4e5c-8022-d979204b4f29"),
                        Name = "Head",
                        LogoUrl = "brand-logos/head.png"
                    },
                     new Manufacturer()
                    {
                        Id = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                        Name = "Specialized",
                        LogoUrl = "brand-logos/specialized.png"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("87ccf053-a35b-48f5-90d4-568a91fc053a"),
                        Name = "SR Suntour",
                        LogoUrl = "brand-logos/srsuntour-logo.png"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("24be2dc6-7b7b-459a-a665-155b4e9e50dc"),
                        Name = "Shimano",
                        LogoUrl = "brand-logos/shimano-logo.png"
                    }
              ];
    }
}
