using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TptMappingStrategyForProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bicycles",
                table: "Bicycles");

            migrationBuilder.DropColumn(
                name: "in_stock",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "in_stock",
                table: "Bicycles");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Bicycles");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Bicycles");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "parts");

            migrationBuilder.RenameTable(
                name: "Bicycles",
                newName: "bicycles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parts",
                table: "parts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bicycles",
                table: "bicycles",
                column: "id");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product primary key"),
                    price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Product price"),
                    in_stock = table.Column<int>(type: "integer", nullable: false, comment: "Bicycle count in stock"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                },
                comment: "Shop product model");

            migrationBuilder.AddForeignKey(
                name: "fk_bicycles_products_id",
                table: "bicycles",
                column: "id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_products_products_product_id",
                table: "order_products",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_parts_products_id",
                table: "parts",
                column: "id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bicycles_products_id",
                table: "bicycles");

            migrationBuilder.DropForeignKey(
                name: "fk_order_products_products_product_id",
                table: "order_products");

            migrationBuilder.DropForeignKey(
                name: "fk_parts_products_id",
                table: "parts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parts",
                table: "parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bicycles",
                table: "bicycles");

            migrationBuilder.RenameTable(
                name: "parts",
                newName: "Parts");

            migrationBuilder.RenameTable(
                name: "bicycles",
                newName: "Bicycles");

            migrationBuilder.AddColumn<int>(
                name: "in_stock",
                table: "Parts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Bicycle count in stock");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Parts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete boolean property");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Parts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                comment: "Product price");

            migrationBuilder.AddColumn<int>(
                name: "in_stock",
                table: "Bicycles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Bicycle count in stock");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Bicycles",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete boolean property");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Bicycles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                comment: "Product price");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bicycles",
                table: "Bicycles",
                column: "id");
        }
    }
}
