namespace BuyBike.Infrastructure.Data.Configuraton
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                        Name = "Giant"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"),
                        Name = "Cross"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                        Name = "Cube"
                    },
                    new Manufacturer()
                    {
                        Id = Guid.Parse("fb2ef438-d045-4e5c-8022-d979204b4f29"),
                        Name = "Head"
                    },
                     new Manufacturer()
                    {
                        Id = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                        Name = "Specialized"
                    }
              ];
    }
}
