using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ItemTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_products_products_product_id",
                table: "order_products");

            migrationBuilder.DropForeignKey(
                name: "fk_products_products_categories_category_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_products",
                table: "order_products");

            migrationBuilder.DropIndex(
                name: "ix_order_products_product_id",
                table: "order_products");

            migrationBuilder.DeleteData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"));

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
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"));

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

            migrationBuilder.DropColumn(
                name: "in_stock",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "order_products");

            migrationBuilder.DropColumn(
                name: "size",
                table: "bicycles");

            migrationBuilder.AlterTable(
                name: "order_products",
                comment: "Connecting table between orders and items",
                oldComment: "Connecting table between orders and products");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Product category identifier",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "Product category identifier");

            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "order_products",
                type: "integer",
                nullable: false,
                comment: "Item quantity",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Product quantity");

            migrationBuilder.AddColumn<Guid>(
                name: "item_id",
                table: "order_products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Ordered item id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_products",
                table: "order_products",
                columns: new[] { "order_id", "item_id" });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Item identifier"),
                    sku = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "Product item number (SKU)"),
                    in_stock = table.Column<int>(type: "integer", nullable: false, comment: "Product items in stock"),
                    size = table.Column<int>(type: "integer", nullable: true, comment: "Item size (enumeration"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete property"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Item's product identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Product item for sale");

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "in_stock", "is_active", "product_id", "size", "sku" },
                values: new object[,]
                {
                    { new Guid("05fa52be-4af7-4923-8e35-9e337d1f7939"), 22, true, new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"), 5, "ITM0000012" },
                    { new Guid("2f14708a-9fd7-498a-ab57-e207cb92bb02"), 5, true, new Guid("78804049-030f-4373-be3c-dfb4df261846"), 2, "ITM0000003" },
                    { new Guid("5ed9dbe5-9b52-472c-8701-5bb4e47bfc88"), 10, true, new Guid("78804049-030f-4373-be3c-dfb4df261846"), 4, "ITM0000002" },
                    { new Guid("62af2302-bbfc-48fe-80d2-273db4b3918b"), 5, true, new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"), 1, "ITM0000009" },
                    { new Guid("69d4c6ac-225e-4280-99fb-58869eae5333"), 33, true, new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"), 3, "ITM0000005" },
                    { new Guid("899fc2be-85af-46c9-b1ca-c1bb256fdacf"), 9, true, new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"), 2, "ITM0000004" },
                    { new Guid("8e6b5a05-304d-4d4d-a1f9-bbd2e5d92809"), 20, true, new Guid("78804049-030f-4373-be3c-dfb4df261846"), 3, "ITM0000001" },
                    { new Guid("9a3c3435-f141-44d2-a7b5-2d408edb5b17"), 7, true, new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"), 3, "ITM0000011" },
                    { new Guid("a1b1b140-9a70-4bb9-8286-b46f8bdc41f3"), 17, true, new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"), 5, "ITM0000013" },
                    { new Guid("d99f6519-e62d-4653-a950-2ef8f896608d"), 12, true, new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"), 3, "ITM0000006" },
                    { new Guid("e3ff3a7f-96ac-487c-888d-311bf73018e2"), 14, true, new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"), 3, "ITM0000010" },
                    { new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"), 0, true, new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"), 4, "ITM0000008" },
                    { new Guid("ff30f42a-ec1d-42cd-a3b4-7b5658221d01"), 18, true, new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"), 3, "ITM0000007" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_products_item_id",
                table: "order_products",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_product_id",
                table: "items",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_order_products_items_item_id",
                table: "order_products",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "products_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_products_items_item_id",
                table: "order_products");

            migrationBuilder.DropForeignKey(
                name: "fk_products_products_categories_category_id",
                table: "products");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_products",
                table: "order_products");

            migrationBuilder.DropIndex(
                name: "ix_order_products_item_id",
                table: "order_products");

            migrationBuilder.DropColumn(
                name: "item_id",
                table: "order_products");

            migrationBuilder.AlterTable(
                name: "order_products",
                comment: "Connecting table between orders and products",
                oldComment: "Connecting table between orders and items");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "products",
                type: "integer",
                nullable: true,
                comment: "Product category identifier",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Product category identifier");

            migrationBuilder.AddColumn<int>(
                name: "in_stock",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Bicycle count in stock");

            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "order_products",
                type: "integer",
                nullable: false,
                comment: "Product quantity",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Item quantity");

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                table: "order_products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Product id");

            migrationBuilder.AddColumn<int>(
                name: "size",
                table: "bicycles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Bicycle frame size (enumeration)");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_products",
                table: "order_products",
                columns: new[] { "order_id", "product_id" });

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                column: "size",
                value: 3);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                column: "size",
                value: 1);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                column: "size",
                value: 3);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                column: "size",
                value: 2);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                column: "size",
                value: 3);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                column: "size",
                value: 5);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                column: "size",
                value: 3);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                column: "size",
                value: 5);

            migrationBuilder.UpdateData(
                table: "bicycles",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                column: "size",
                value: 3);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                column: "in_stock",
                value: 7);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                column: "in_stock",
                value: 5);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                column: "in_stock",
                value: 12);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                column: "in_stock",
                value: 9);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                column: "in_stock",
                value: 20);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                column: "in_stock",
                value: 17);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                column: "in_stock",
                value: 18);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                column: "in_stock",
                value: 22);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                column: "in_stock",
                value: 14);

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "color", "description", "gender", "image_url", "in_stock", "is_active", "make_id", "price" },
                values: new object[,]
                {
                    { new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"), 1, "White", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2021/MY21FATHOM_29_1_ColorADesertSage-1000x1000.jpg", 33, true, new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), 3499m },
                    { new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"), 1, "Black", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg", 10, true, new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), 3499m },
                    { new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"), 1, "Black", null, null, "https://www.velozona.bg/image/cache/catalog/GIANT-2022/MY21FATHOM_29_1_ColorBBlack_Charcoal-1000x1000.jpg", 5, true, new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), 3499m },
                    { new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"), 3, "Grey", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 1, "https://www.bikecenter.bg/media/catalog/product/cache/1/image/85e4522595efc69f496374d01ef2bf13/_/2/_28_cube_kathmandu_slx_sil_blk.jpg", 0, true, new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), 3899m }
                });

            migrationBuilder.InsertData(
                table: "bicycles",
                columns: new[] { "id", "model", "size", "tyre_size" },
                values: new object[,]
                {
                    { new Guid("122b4402-a081-4bcb-aeb4-face1ca35afe"), "Fathom 1", 3, 29.0 },
                    { new Guid("e31d06f0-ba78-40de-8cae-039844229fbe"), "Fathom 1", 4, 29.0 },
                    { new Guid("e877e2a4-5a84-41d4-acfc-443a350b1506"), "Fathom 1", 2, 29.0 },
                    { new Guid("f1c54893-bdc1-4b37-baad-db033b2d359b"), "Kathmandu XLR", 4, 28.0 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_products_product_id",
                table: "order_products",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_order_products_products_product_id",
                table: "order_products",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "products_categories",
                principalColumn: "id");
        }
    }
}
