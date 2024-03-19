namespace BuyBike.Infrastructure.Data.Configuratons
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
                    InStock = 20,
                    Price = 3499,
                    Size = BikeSize.L,
                    Model = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg",
                    Color = "Black"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("e31d06f0-ba78-40de-8cae-039844229fbe"),
                    InStock = 10,
                    Price = 3499,
                    Size = BikeSize.XL,
                    Model = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg",
                    Color = "Black"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("e877e2a4-5a84-41d4-acfc-443a350b1506"),
                    InStock = 5,
                    Price = 3499,
                    Size = BikeSize.M,
                    Model = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg",
                    Color = "Black"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    InStock = 9,
                    Price = 3499,
                    Size = BikeSize.M,
                    Model = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg",
                    Color = "White"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("122b4402-a081-4bcb-aeb4-face1ca35afe"),
                    InStock = 33,
                    Price = 3499,
                    Size = BikeSize.L,
                    Model = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg",
                    Color = "White"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    InStock = 12,
                    Price = 13599,
                    Size = BikeSize.L,
                    Model = "Epic Expert Morn",
                    MakeId = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                    CategoryId = 1,
                    TyreSize = 29,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_29_specialized_epic_expert_morn_dknvy.jpg",
                    Color = "White",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    InStock = 18,
                    Price = 3899,
                    Size = BikeSize.L,
                    Model = "Kathmandu XLR",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    CategoryId = 3,
                    TyreSize = 28,
                    Gender = Gender.Male,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg",
                    Color = "Grey",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("f1c54893-bdc1-4b37-baad-db033b2d359b"),
                    InStock = 0,
                    Price = 3899,
                    Size = BikeSize.XL,
                     Model = "Kathmandu XLR",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    CategoryId = 3,
                    TyreSize = 28,
                    Gender = Gender.Male,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg",
                    Color = "Grey",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    InStock = 5,
                    Price = 3899,
                    Size = BikeSize.S,
                    Model = "Nulane Pro",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    CategoryId = 3,
                    TyreSize = 28,
                    Gender = Gender.Female,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_nulane_pro_gry_blk_tr.jpg",
                    Color = "Grey"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    InStock = 14,
                    Price = 2399,
                    Size = BikeSize.L,
                    Model = "Allez E5",
                    MakeId = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                    CategoryId = 2,
                    TyreSize = 28,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_specialized_allez_e5_disc_mrn_sil.jpg",
                    Color = "Red",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    InStock = 7,
                    Price = 9199,
                    Size = BikeSize.L,
                    Model = "Litening Aero",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    CategoryId = 2,
                    TyreSize = 28,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_litening_aero_c68x_pro_crbn.jpg",
                    Color = "Black",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                 new Bicycle()
                {
                    Id = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                    InStock = 22,
                    Price = 299,
                    Size = BikeSize.Kids,
                    Model = "Boxer",
                    MakeId = Guid.Parse("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"),
                    CategoryId = 4,
                    TyreSize = 12,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/CROSS/12-cross-boxer-alloy-boy-1276x1276.jpg",
                    Color = "Blue",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Bicycle()
                {
                    Id = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                    InStock = 17,
                    Price = 279,
                    Size = BikeSize.Kids,
                    Model = "Faro",
                    MakeId = Guid.Parse("fb2ef438-d045-4e5c-8022-d979204b4f29"),
                    CategoryId = 4,
                    TyreSize = 12,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/HEAD-2019/HEAD-Faro-12-black-1276x1276.jpg",
                    Color = "Black",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
            ];
    }
}
