using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLogoUrlToManufacturers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "products",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                comment: "Model Image URL",
                oldClrType: typeof(string),
                oldType: "character varying(2048)",
                oldMaxLength: 2048,
                oldComment: "Model Image URL");

            migrationBuilder.AddColumn<string>(
                name: "logo_url",
                table: "manufacturers",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                comment: "Manufacturer logo URL");

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                column: "model",
                value: "Touring Pro");

            migrationBuilder.UpdateData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"),
                column: "logo_url",
                value: "brand-logos/specialized.png");

            migrationBuilder.UpdateData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"),
                column: "logo_url",
                value: "brand-logos/cube.png");

            migrationBuilder.UpdateData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"),
                column: "logo_url",
                value: "brand-logos/giant.png");

            migrationBuilder.UpdateData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"),
                column: "logo_url",
                value: "brand-logos/cross.jpg");

            migrationBuilder.UpdateData(
                table: "manufacturers",
                keyColumn: "id",
                keyValue: new Guid("fb2ef438-d045-4e5c-8022-d979204b4f29"),
                column: "logo_url",
                value: "brand-logos/head.png");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                columns: new[] { "color", "image_url", "price" },
                values: new object[] { "Blue", "bicycles/road/Litening_Aero_28_Blue.jpg", 14899m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                column: "image_url",
                value: "bicycles/city/Nulane_Pro_28_Grey.png");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                column: "image_url",
                value: "bicycles/mountain/Epic_Expert_Morn_White.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                column: "image_url",
                value: "bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                column: "image_url",
                value: "bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                column: "image_url",
                value: "bicycles/kids/Faro_12_black.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                columns: new[] { "color", "image_url", "price" },
                values: new object[] { "Silver", "bicycles/city/Touring_Pro_28_Silver.jpg", 1699m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                column: "image_url",
                value: "bicycles/kids/Boxer_12_blue.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                column: "image_url",
                value: "bicycles/road/Allez_E5_28_red.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo_url",
                table: "manufacturers");

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "products",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: false,
                comment: "Model Image URL",
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024,
                oldComment: "Model Image URL");

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                column: "model",
                value: "Kathmandu XLR");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                columns: new[] { "color", "image_url", "price" },
                values: new object[] { "Black", "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_litening_aero_c68x_pro_crbn.jpg", 9199m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                column: "image_url",
                value: "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_nulane_pro_gry_blk_tr.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                column: "image_url",
                value: "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_29_specialized_epic_expert_morn_dknvy.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                column: "image_url",
                value: "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                column: "image_url",
                value: "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                column: "image_url",
                value: "https://www.velozona.bg/image/cache/catalog/HEAD-2019/HEAD-Faro-12-black-1276x1276.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                columns: new[] { "color", "image_url", "price" },
                values: new object[] { "Grey", "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg", 3899m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                column: "image_url",
                value: "https://www.velozona.bg/image/cache/catalog/CROSS/12-cross-boxer-alloy-boy-1276x1276.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                column: "image_url",
                value: "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_specialized_allez_e5_disc_mrn_sil.jpg");
        }
    }
}
