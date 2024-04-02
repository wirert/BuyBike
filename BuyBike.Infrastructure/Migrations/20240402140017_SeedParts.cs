using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "description", "image_url", "name", "parent_category_id" },
                values: new object[,]
                {
                    { 8, "Lorem ipsum elit. Maiores ,  reici voluptatem quibusdam!", "categories/fork.jpg", "Вилки", 7 },
                    { 9, "Lorem ipsum elit. Maiores ,  reici voluptatem quibusdam!", "categories/gear-shifter.jpg", "Команди", 7 },
                    { 10, "Lorem ipsum elit. Reici voluptatem quibusdam!", "categories/chain.jpg", "Вериги", 7 }
                });

            migrationBuilder.InsertData(
                table: "manufacturers",
                columns: new[] { "id", "is_active", "logo_url", "name" },
                values: new object[,]
                {
                    { new Guid("24be2dc6-7b7b-459a-a665-155b4e9e50dc"), true, "brand-logos/shimano-logo.png", "Shimano" },
                    { new Guid("87ccf053-a35b-48f5-90d4-568a91fc053a"), true, "brand-logos/srsuntour-logo.png", "SR Suntour" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "color", "description", "discount_id", "gender", "image_url", "is_active", "make_id", "name", "price", "specification" },
                values: new object[,]
                {
                    { new Guid("7494afe6-c436-4d4b-b6c4-68ea4ac3c633"), 8, "Black", "Начален клас амортисьорна вилка SR SUNTOUR 26\" за планински велосипеди, съвместима с V-образни спирачки.", 1, null, "parts/forks/SR-26-M3020-P.jpg", true, new Guid("87ccf053-a35b-48f5-90d4-568a91fc053a"), "26 M3020-P", 121m, "[[\"Размер\", \"26 цола\"],[\"Ход\", \"75mm\"], [\"Стержен\", \"1 1/8 инча (28,6mm)\"], [\"Дължина на стержена\", \"255mm\"], [\"Материал\", \" въглеродна стомана, алуминий\"], [\"Тип ос\", \"9mm\"], [\"Тип спирачка\", \"V-образна\"]]" },
                    { new Guid("bae19e01-9923-4de7-bee3-38b713ea68f9"), 9, "Black", "Лява команда, подходяща за планински велосипеди (МТВ). Гладко и леко превключване на скоростите. Вкомплекта е включено жило.", null, null, "shifters/SH-SL-M360-3-L.jpeg", true, new Guid("24be2dc6-7b7b-459a-a665-155b4e9e50dc"), "ACERA SL-M360 3L", 36m, "[[\"Тип на лосчетата\", \"Rapidfire Plus\"],[\"Скорости\", \"3s\"], [\"Индикатор за коростта\", \"да\"], [\"Ергономичен дизайн на лосчето\", \"да\"], [\"Регулатор за жилото\", \"да\"]]" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "in_stock", "is_active", "product_id", "size", "sku" },
                values: new object[] { new Guid("34b132b4-4cb8-4ce9-8478-31ce596c4d48"), 3, true, new Guid("7494afe6-c436-4d4b-b6c4-68ea4ac3c633"), null, "ITM0000014" });

            migrationBuilder.InsertData(
                table: "parts",
                column: "id",
                values: new object[]
                {
                    new Guid("7494afe6-c436-4d4b-b6c4-68ea4ac3c633"),
                    new Guid("bae19e01-9923-4de7-bee3-38b713ea68f9")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: new Guid("34b132b4-4cb8-4ce9-8478-31ce596c4d48"));

            migrationBuilder.DeleteData(
                table: "parts",
                keyColumn: "id",
                keyValue: new Guid("7494afe6-c436-4d4b-b6c4-68ea4ac3c633"));

            migrationBuilder.DeleteData(
                table: "parts",
                keyColumn: "id",
                keyValue: new Guid("bae19e01-9923-4de7-bee3-38b713ea68f9"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("7494afe6-c436-4d4b-b6c4-68ea4ac3c633"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("bae19e01-9923-4de7-bee3-38b713ea68f9"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("24be2dc6-7b7b-459a-a665-155b4e9e50dc"));

            migrationBuilder.DeleteData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("87ccf053-a35b-48f5-90d4-568a91fc053a"));
        }
    }
}
