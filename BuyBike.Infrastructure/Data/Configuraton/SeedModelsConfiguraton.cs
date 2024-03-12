namespace BuyBike.Infrastructure.Data.Configuraton
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;
    using Entities.Enumerations;

    internal class SeedModelsAndBicyclesConfiguraton : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasData(CreateModels());
        }

        private Model[] CreateModels() =>
            [
                new Model()
                {
                    Id = Guid.Parse("e0e61bd9-f6e9-4338-9671-65aff5e32224"),
                    Name = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    Type = BikeType.Mountain,
                    TyreSize = 29,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg",
                    Color = "Black"
                },
                new Model()
                {
                    Id = Guid.Parse("4ae30432-6417-4c8b-ad3c-6643177c3a00"),
                    Name = "Fathom 1",
                    MakeId = Guid.Parse("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                    Type = BikeType.Mountain,
                    TyreSize = 29,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg",
                    Color = "White"
                },
                new Model()
                {
                    Id = Guid.Parse("778a39ee-879b-49e1-a76f-87e5b039204c"),
                    Name = "Epic Expert Morn",
                    MakeId = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                    Type = BikeType.Mountain,
                    TyreSize = 29,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_29_specialized_epic_expert_morn_dknvy.jpg",
                    Color = "White",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Model()
                {
                    Id = Guid.Parse("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"),
                    Name = "Kathmandu XLR",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    Type = BikeType.City,
                    TyreSize = 28,
                    Gender = Gender.Male,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg",
                    Color = "Grey",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Model()
                {
                    Id = Guid.Parse("cf155129-97cd-4957-8251-0790f4252cd8"),
                    Name = "Nulane Pro",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    Type = BikeType.City,
                    TyreSize = 28,
                    Gender = Gender.Female,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_nulane_pro_gry_blk_tr.jpg",
                    Color = "Grey"
                },
                new Model()
                {
                    Id = Guid.Parse("3fa408ee-f3d4-4de0-8ef8-34f2db15be8e"),
                    Name = "Allez E5",
                    MakeId = Guid.Parse("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                    Type = BikeType.Road,
                    TyreSize = 28,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_specialized_allez_e5_disc_mrn_sil.jpg",
                    Color = "Red",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Model()
                {
                    Id = Guid.Parse("a9401b93-3c58-470d-b48e-6bfb5731c4c0"),
                    Name = "Litening Aero",
                    MakeId = Guid.Parse("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                    Type = BikeType.Road,
                    TyreSize = 28,
                    ImageUrl = "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_litening_aero_c68x_pro_crbn.jpg",
                    Color = "Black",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Model()
                {
                    Id = Guid.Parse("265da868-5b3a-46c1-b098-57af4170151e"),
                    Name = "Boxer",
                    MakeId = Guid.Parse("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"),
                    Type = BikeType.Kids,
                    TyreSize = 12,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/CROSS/12-cross-boxer-alloy-boy-1276x1276.jpg",
                    Color = "Blue",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
                new Model()
                {
                    Id = Guid.Parse("88d6ba12-8d54-4191-a2a2-01d0a5f24f07"),
                    Name = "Faro",
                    MakeId = Guid.Parse("fb2ef438-d045-4e5c-8022-d979204b4f29"),
                    Type = BikeType.Kids,
                    TyreSize = 12,
                    ImageUrl = "https://www.velozona.bg/image/cache/catalog/HEAD-2019/HEAD-Faro-12-black-1276x1276.jpg",
                    Color = "Black",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!"
                },
            ];
    }
}
