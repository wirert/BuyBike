namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    internal class SeedPartsTableConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasData(
                [
                new Part(){
                    Id = Guid.Parse("7494afe6-c436-4d4b-b6c4-68ea4ac3c633"),
                    Price = 121,
                    Name = "26 M3020-P",
                    DiscountId = 1,
                    MakeId = Guid.Parse("87ccf053-a35b-48f5-90d4-568a91fc053a"),
                    CategoryId = 8,
                    ImageUrl = "parts/forks/SR-26-M3020-P.jpg",
                    Color = "Black",                    
                    Specification = "[[\"Размер\", \"26 цола\"],[\"Ход\", \"75mm\"], [\"Стержен\", \"1 1/8 инча (28,6mm)\"], [\"Дължина на стержена\", \"255mm\"], [\"Материал\", \" въглеродна стомана, алуминий\"], [\"Тип ос\", \"9mm\"], [\"Тип спирачка\", \"V-образна\"]]",
                    Description = "Начален клас амортисьорна вилка SR SUNTOUR 26\" за планински велосипеди, съвместима с V-образни спирачки."
                },
                new Part(){
                    Id = Guid.Parse("bae19e01-9923-4de7-bee3-38b713ea68f9"),
                    Price = 36,
                    Name = "ACERA SL-M360 3L",
                    MakeId = Guid.Parse("24be2dc6-7b7b-459a-a665-155b4e9e50dc"),
                    CategoryId = 9,
                    ImageUrl = "shifters/SH-SL-M360-3-L.jpeg",
                    Color = "Black",
                    Specification = "[[\"Тип на лосчетата\", \"Rapidfire Plus\"],[\"Скорости\", \"3s\"], [\"Индикатор за коростта\", \"да\"], [\"Ергономичен дизайн на лосчето\", \"да\"], [\"Регулатор за жилото\", \"да\"]]",
                    Description = "Лява команда, подходяща за планински велосипеди (МТВ). Гладко и леко превключване на скоростите. Вкомплекта е включено жило."
                }

                ]);
        }
    }
}
