using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "discount_id",
                table: "products",
                type: "integer",
                nullable: true,
                comment: "Product discount id");

            migrationBuilder.CreateTable(
                name: "discount",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Discount identifier")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "Discount name"),
                    desc = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "Discount description (optional)"),
                    discount_percent = table.Column<int>(type: "integer", nullable: false, comment: "Discount value - percentage"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_discount", x => x.id);
                },
                comment: "Prodict discount");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("78804049-030f-4373-be3c-dfb4df261846"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                column: "discount_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                column: "discount_id",
                value: null);

            migrationBuilder.CreateIndex(
                name: "ix_products_discount_id",
                table: "products",
                column: "discount_id");

            migrationBuilder.AddForeignKey(
                name: "fk_products_discount_discount_id",
                table: "products",
                column: "discount_id",
                principalTable: "discount",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_discount_discount_id",
                table: "products");

            migrationBuilder.DropTable(
                name: "discount");

            migrationBuilder.DropIndex(
                name: "ix_products_discount_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "discount_id",
                table: "products");
        }
    }
}
