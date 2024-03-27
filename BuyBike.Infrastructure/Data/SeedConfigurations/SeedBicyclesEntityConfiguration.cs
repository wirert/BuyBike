namespace BuyBike.Infrastructure.Data.SeedConfigurations
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
                    Price = 3499,
                    Model = "Fathom 1",
                    DiscountId = 1,
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg",
                    Color = "Black"
                },

                new Bicycle()
                {
                    Id = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    Price = 3499,
                    Model = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg",
                    Color = "White"
                },

                new Bicycle()
                {
                    Id = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    Price = 13599,
                    DiscountId = 2,
                    Model = "Epic Expert Morn",
                    MakeId = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "bicycles/mountain/Epic_Expert_Morn_White.jpg",
                    Color = "White",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    Price = 1699,
                    Model = "Touring Pro",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    CategoryId = 3,
                    TyreSize = 28,
                    Gender = Gender.Male,
                    ImageUrl = "bicycles/city/Touring_Pro_28_Silver.jpg",
                    Color = "Silver",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },

                 new Bicycle()
                {
                    Id = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    Price = 3899,
                    Model = "Nulane Pro",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    CategoryId = 3,
                    TyreSize = 28,
                    Gender = Gender.Female,
                    ImageUrl = "bicycles/city/Nulane_Pro_28_Grey.png",
                    Color = "Grey"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    Price = 2399,
                    Model = "Allez E5",
                    MakeId = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                    CategoryId = 2,
                    TyreSize = 28,
                    ImageUrl = "bicycles/road/Allez_E5_28_red.jpg",
                    Color = "Red",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    Price = 14899,
                    DiscountId = 3,
                    Model = "Litening Aero",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    CategoryId = 2,
                    TyreSize = 28,
                    ImageUrl = "bicycles/road/Litening_Aero_28_Blue.jpg",
                    Color = "Blue",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                    Price = 299,
                    DiscountId = 2,
                    Model = "Boxer",
                    MakeId = Guid.Parse("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"),
                    CategoryId = 4,
                    TyreSize = 12,
                    ImageUrl = "bicycles/kids/Boxer_12_blue.jpg",
                    Color = "Blue",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                    Price = 279,
                    DiscountId = 1,
                    Model = "Faro",
                    MakeId = Guid.Parse("fb2ef438-d045-4e5c-8022-d979204b4f29"),
                    CategoryId = 4,
                    TyreSize = 12,
                    ImageUrl = "bicycles/kids/Faro_12_black.jpg",
                    Color = "Black",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
            ];
    }
}
