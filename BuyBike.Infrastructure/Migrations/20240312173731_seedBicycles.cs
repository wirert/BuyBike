using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedBicycles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "bicycles");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "models",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                comment: "Bicycle model color (optional)");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "models",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true,
                comment: "Bicycle model description (optional");

            migrationBuilder.InsertData(
                table: "manufacturers",
                columns: new[] { "id", "is_active", "name" },
                values: new object[,]
                {
                    { new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"), true, "Specialized" },
                    { new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), true, "Cube" },
                    { new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), true, "Giant" },
                    { new Guid("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"), true, "Cross" },
                    { new Guid("fb2ef438-d045-4e5c-8022-d979204b4f29"), true, "Head" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "in_stock", "is_active", "price" },
                values: new object[,]
                {
                    { new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"), 7, true, 9199m },
                    { new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"), 33, true, 3499m },
                    { new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"), 5, true, 3899m },
                    { new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"), 12, true, 13599m },
                    { new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"), 9, true, 3499m },
                    { new Guid("78804049-030f-4373-be3c-dfb4df261846"), 20, true, 3499m },
                    { new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"), 17, true, 279m },
                    { new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"), 18, true, 3899m },
                    { new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"), 22, true, 299m },
                    { new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"), 14, true, 2399m },
                    { new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"), 10, true, 3499m },
                    { new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"), 5, true, 3499m },
                    { new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"), 0, true, 3899m }
                });

            migrationBuilder.InsertData(
                table: "models",
                columns: new[] { "id", "color", "description", "gender", "image_url", "is_active", "make_id", "name", "type", "tyre_size" },
                values: new object[,]
                {
                    { new Guid("265da868-5b3a-46c1-b098-57af4170151e"), "Blue", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 0, "https://www.velozona.bg/image/cache/catalog/CROSS/12-cross-boxer-alloy-boy-1276x1276.jpg", true, new Guid("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"), "Boxer", 3, 12.0 },
                    { new Guid("3fa408ee-f3d4-4de0-8ef8-34f2db15be8e"), "Red", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 0, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_specialized_allez_e5_disc_mrn_sil.jpg", true, new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"), "Allez E5", 1, 28.0 },
                    { new Guid("4ae30432-6417-4c8b-ad3c-6643177c3a00"), "White", null, 0, "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg", true, new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), "Fathom 1", 0, 29.0 },
                    { new Guid("778a39ee-879b-49e1-a76f-87e5b039204c"), "White", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 0, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_29_specialized_epic_expert_morn_dknvy.jpg", true, new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"), "Epic Expert Morn", 0, 29.0 },
                    { new Guid("88d6ba12-8d54-4191-a2a2-01d0a5f24f07"), "Black", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 0, "https://www.velozona.bg/image/cache/catalog/HEAD-2019/HEAD-Faro-12-black-1276x1276.jpg", true, new Guid("fb2ef438-d045-4e5c-8022-d979204b4f29"), "Faro", 3, 12.0 },
                    { new Guid("a9401b93-3c58-470d-b48e-6bfb5731c4c0"), "Black", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 0, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_litening_aero_c68x_pro_crbn.jpg", true, new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), "Litening Aero", 1, 28.0 },
                    { new Guid("cf155129-97cd-4957-8251-0790f4252cd8"), "Grey", null, 2, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_nulane_pro_gry_blk_tr.jpg", true, new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), "Nulane Pro", 2, 28.0 },
                    { new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"), "Black", null, 0, "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg", true, new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), "Fathom 1", 0, 29.0 },
                    { new Guid("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"), "Grey", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 1, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg", true, new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), "Kathmandu XLR", 2, 28.0 }
                });

            migrationBuilder.InsertData(
                table: "bicycles",
                columns: new[] { "id", "model_id", "size" },
                values: new object[,]
                {
                    { new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"), new Guid("a9401b93-3c58-470d-b48e-6bfb5731c4c0"), 3 },
                    { new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"), new Guid("4ae30432-6417-4c8b-ad3c-6643177c3a00"), 3 },
                    { new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"), new Guid("cf155129-97cd-4957-8251-0790f4252cd8"), 1 },
                    { new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"), new Guid("778a39ee-879b-49e1-a76f-87e5b039204c"), 3 },
                    { new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"), new Guid("4ae30432-6417-4c8b-ad3c-6643177c3a00"), 2 },
                    { new Guid("78804049-030f-4373-be3c-dfb4df261846"), new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"), 3 },
                    { new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"), new Guid("88d6ba12-8d54-4191-a2a2-01d0a5f24f07"), 5 },
                    { new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"), new Guid("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"), 3 },
                    { new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"), new Guid("265da868-5b3a-46c1-b098-57af4170151e"), 5 },
                    { new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"), new Guid("3fa408ee-f3d4-4de0-8ef8-34f2db15be8e"), 3 },
                    { new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"), new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"), 4 },
                    { new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"), new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"), 2 },
                    { new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"), new Guid("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"), 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"));

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("265da868-5b3a-46c1-b098-57af4170151e"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("3fa408ee-f3d4-4de0-8ef8-34f2db15be8e"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("4ae30432-6417-4c8b-ad3c-6643177c3a00"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("778a39ee-879b-49e1-a76f-87e5b039204c"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("88d6ba12-8d54-4191-a2a2-01d0a5f24f07"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("a9401b93-3c58-470d-b48e-6bfb5731c4c0"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("cf155129-97cd-4957-8251-0790f4252cd8"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"));

            migrationBuilder.DeleteData(
                table: "models",
                keyColumn: "id",
                keyValue: new Guid("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"));

            migrationBuilder.DeleteData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"));

            migrationBuilder.DeleteData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"));

            migrationBuilder.DeleteData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"));

            migrationBuilder.DeleteData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"));

            migrationBuilder.DeleteData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("fb2ef438-d045-4e5c-8022-d979204b4f29"));

            migrationBuilder.DropColumn(
                name: "color",
                table: "models");

            migrationBuilder.DropColumn(
                name: "description",
                table: "models");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "bicycles",
                type: "text",
                nullable: true,
                comment: "Bicycle color (optional)");
        }
    }
}
