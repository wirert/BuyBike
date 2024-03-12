namespace BuyBike.Infrastructure.Data.Configuraton
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;
    using Entities.Enumerations;

    internal class SeedBicyclesEntityConfiguration : IEntityTypeConfiguration<Bicycle>
    {
        public void Configure(EntityTypeBuilder<Bicycle> builder)
        {
            builder.HasData(CreateBicycles());
        }

        private Bicycle[] CreateBicycles() => 
            [
                new Bicycle()
                {
                    Id = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                    ModelId = Guid.Parse("e0e61bd9-f6e9-4338-9671-65aff5e32224"),
                    InStock = 20,
                    Price = 3499,
                    Size = BikeSize.L
                },
                new Bicycle()
                {
                    Id = Guid.Parse("e31d06f0-ba78-40de-8cae-039844229fbe"),
                    ModelId = Guid.Parse("e0e61bd9-f6e9-4338-9671-65aff5e32224"),
                    InStock = 10,
                    Price = 3499,
                    Size = BikeSize.XL
                },
                new Bicycle()
                {
                    Id = Guid.Parse("e877e2a4-5a84-41d4-acfc-443a350b1506"),
                    ModelId = Guid.Parse("e0e61bd9-f6e9-4338-9671-65aff5e32224"),
                    InStock = 5,
                    Price = 3499,
                    Size = BikeSize.M
                },
                new Bicycle()
                {
                    Id = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    ModelId = Guid.Parse("4ae30432-6417-4c8b-ad3c-6643177c3a00"),
                    InStock = 9,
                    Price = 3499,
                    Size = BikeSize.M
                },
                new Bicycle()
                {
                    Id = Guid.Parse("122b4402-a081-4bcb-aeb4-face1ca35afe"),
                    ModelId = Guid.Parse("4ae30432-6417-4c8b-ad3c-6643177c3a00"),
                    InStock = 33,
                    Price = 3499,
                    Size = BikeSize.L
                },
                new Bicycle()
                {
                    Id = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    ModelId = Guid.Parse("778a39ee-879b-49e1-a76f-87e5b039204c"),
                    InStock = 12,
                    Price = 13599,
                    Size = BikeSize.L
                },
                new Bicycle()
                {
                    Id = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    ModelId = Guid.Parse("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"),
                    InStock = 18,
                    Price = 3899,
                    Size = BikeSize.L
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("f1c54893-bdc1-4b37-baad-db033b2d359b"),
                    ModelId = Guid.Parse("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"),
                    InStock = 0,
                    Price = 3899,
                    Size = BikeSize.XL
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    ModelId = Guid.Parse("cf155129-97cd-4957-8251-0790f4252cd8"),
                    InStock = 5,
                    Price = 3899,
                    Size = BikeSize.S
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    ModelId = Guid.Parse("3fa408ee-f3d4-4de0-8ef8-34f2db15be8e"),
                    InStock = 14,
                    Price = 2399,
                    Size = BikeSize.L
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    ModelId = Guid.Parse("a9401b93-3c58-470d-b48e-6bfb5731c4c0"),
                    InStock = 7,
                    Price = 9199,
                    Size = BikeSize.L
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                    ModelId = Guid.Parse("265da868-5b3a-46c1-b098-57af4170151e"),
                    InStock = 22,
                    Price = 299,
                    Size = BikeSize.Kids
                },
                new Bicycle()
                {
                    Id = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                    ModelId = Guid.Parse("88d6ba12-8d54-4191-a2a2-01d0a5f24f07"),
                    InStock = 17,
                    Price = 279,
                    Size = BikeSize.Kids
                },
            ];
    }
}
