using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedModelsAndAddAttributeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bicycles_models_model_id",
                table: "bicycles");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropIndex(
                name: "ix_bicycles_model_id",
                table: "bicycles");

            migrationBuilder.DropColumn(
                name: "model_id",
                table: "bicycles");

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "products",
                type: "integer",
                nullable: true,
                comment: "Product category identifier");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "products",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                comment: "Product color (optional)");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "products",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true,
                comment: "Product description (optional");

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "products",
                type: "integer",
                nullable: true,
                comment: "Gender (optional)");

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "products",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                comment: "Model Image URL");

            migrationBuilder.AddColumn<Guid>(
                name: "make_id",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Product manufacturer id");

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "bicycles",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                comment: "Bicycle model name");

            migrationBuilder.AddColumn<double>(
                name: "tyre_size",
                table: "bicycles",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "Tyre size");

            migrationBuilder.CreateTable(
                name: "products_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true, comment: "Product description (optional")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Attribute Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Attribute name"),
                    data_type = table.Column<string>(type: "text", nullable: false, comment: "Product property type (default: string)"),
                    product_category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attributes", x => x.id);
                    table.ForeignKey(
                        name: "fk_attributes_products_categories_product_category_id",
                        column: x => x.product_category_id,
                        principalTable: "products_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "EAV pattern attribute model");

            migrationBuilder.CreateTable(
                name: "attribute_values",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    attribute_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attribute_values", x => x.id);
                    table.ForeignKey(
                        name: "fk_attribute_values_attributes_attribute_id",
                        column: x => x.attribute_id,
                        principalTable: "attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_attribute_values_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Litening Aero", 28.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Fathom 1", 29.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Nulane Pro", 28.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Epic Expert Morn", 29.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Fathom 1", 29.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Fathom 1", 29.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Faro", 12.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Kathmandu XLR", 28.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Boxer", 12.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Allez E5", 28.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Fathom 1", 29.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Fathom 1", 29.0 });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"),
                columns: new[] { "model", "tyre_size" },
                values: new object[] { "Kathmandu XLR", 28.0 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 2, "Black", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", null, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_litening_aero_c68x_pro_crbn.jpg", new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 1, "White", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg", new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 3, "Grey", null, 2, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_nulane_pro_gry_blk_tr.jpg", new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 1, "White", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", null, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_29_specialized_epic_expert_morn_dknvy.jpg", new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 1, "White", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg", new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 1, "Black", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg", new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 4, "Black", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", null, "https://www.velozona.bg/image/cache/catalog/HEAD-2019/HEAD-Faro-12-black-1276x1276.jpg", new Guid("fb2ef438-d045-4e5c-8022-d979204b4f29") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 3, "Grey", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 1, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg", new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 4, "Blue", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", null, "https://www.velozona.bg/image/cache/catalog/CROSS/12-cross-boxer-alloy-boy-1276x1276.jpg", new Guid("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 2, "Red", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", null, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_specialized_allez_e5_disc_mrn_sil.jpg", new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 1, "Black", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg", new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 1, "Black", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg", new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9") });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"),
                columns: new[] { "category_id", "color", "description", "gender", "image_url", "make_id" },
                values: new object[] { 3, "Grey", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 1, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg", new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87") });

            migrationBuilder.InsertData(
                table: "products_categories",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "Mountain" },
                    { 2, "Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "Road" },
                    { 3, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi  quibusdam!", "City" },
                    { 4, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "Kids" },
                    { 5, "Lorem ipsum elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "Electric" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_make_id",
                table: "products",
                column: "make_id");

            migrationBuilder.CreateIndex(
                name: "ix_bicycles_model",
                table: "bicycles",
                column: "model");

            migrationBuilder.CreateIndex(
                name: "ix_attribute_values_attribute_id",
                table: "attribute_values",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "ix_attribute_values_product_id",
                table: "attribute_values",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_attributes_product_category_id",
                table: "attributes",
                column: "product_category_id");

            migrationBuilder.AddForeignKey(
                name: "fk_products_manufacturers_make_id",
                table: "products",
                column: "make_id",
                principalTable: "manufacturers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "products_categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_manufacturers_make_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_products_products_categories_category_id",
                table: "products");

            migrationBuilder.DropTable(
                name: "attribute_values");

            migrationBuilder.DropTable(
                name: "attributes");

            migrationBuilder.DropTable(
                name: "products_categories");

            migrationBuilder.DropIndex(
                name: "ix_products_category_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_products_make_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_bicycles_model",
                table: "bicycles");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "color",
                table: "products");

            migrationBuilder.DropColumn(
                name: "description",
                table: "products");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "products");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "products");

            migrationBuilder.DropColumn(
                name: "make_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "model",
                table: "bicycles");

            migrationBuilder.DropColumn(
                name: "tyre_size",
                table: "bicycles");

            migrationBuilder.AddColumn<Guid>(
                name: "model_id",
                table: "bicycles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Bicycle model Id");

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Model primary key"),
                    make_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Model manufacturer id"),
                    color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "Bicycle model color (optional)"),
                    description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true, comment: "Bicycle model description (optional"),
                    gender = table.Column<int>(type: "integer", nullable: false, comment: "Gender (Undefined by default)"),
                    image_url = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false, comment: "Model Image URL"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property"),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false, comment: "Bicycle model name"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "Bicycle model Type (Enumeration)"),
                    tyre_size = table.Column<double>(type: "double precision", nullable: false, comment: "Tyre size")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_models", x => x.id);
                    table.ForeignKey(
                        name: "fk_models_manufacturers_make_id",
                        column: x => x.make_id,
                        principalTable: "manufacturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Bicycle model");

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                column: "model_id",
                value: new Guid("a9401b93-3c58-470d-b48e-6bfb5731c4c0"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"),
                column: "model_id",
                value: new Guid("4ae30432-6417-4c8b-ad3c-6643177c3a00"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                column: "model_id",
                value: new Guid("cf155129-97cd-4957-8251-0790f4252cd8"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                column: "model_id",
                value: new Guid("778a39ee-879b-49e1-a76f-87e5b039204c"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                column: "model_id",
                value: new Guid("4ae30432-6417-4c8b-ad3c-6643177c3a00"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                column: "model_id",
                value: new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                column: "model_id",
                value: new Guid("88d6ba12-8d54-4191-a2a2-01d0a5f24f07"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                column: "model_id",
                value: new Guid("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                column: "model_id",
                value: new Guid("265da868-5b3a-46c1-b098-57af4170151e"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                column: "model_id",
                value: new Guid("3fa408ee-f3d4-4de0-8ef8-34f2db15be8e"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"),
                column: "model_id",
                value: new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"),
                column: "model_id",
                value: new Guid("e0e61bd9-f6e9-4338-9671-65aff5e32224"));

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"),
                column: "model_id",
                value: new Guid("e2a5ce77-eb7c-4809-a45a-dc9ced72921f"));

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

            migrationBuilder.CreateIndex(
                name: "ix_bicycles_model_id",
                table: "bicycles",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "ix_models_make_id",
                table: "models",
                column: "make_id");

            migrationBuilder.CreateIndex(
                name: "ix_models_type",
                table: "models",
                column: "type");

            migrationBuilder.AddForeignKey(
                name: "fk_bicycles_models_model_id",
                table: "bicycles",
                column: "model_id",
                principalTable: "models",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
