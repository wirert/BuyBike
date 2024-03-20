using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddValueColumnToAttributeValueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_attribute_values",
                table: "attribute_values");

            migrationBuilder.DropIndex(
                name: "ix_attribute_values_product_id",
                table: "attribute_values");

            migrationBuilder.DropColumn(
                name: "id",
                table: "attribute_values");

            migrationBuilder.AlterTable(
                name: "products_categories",
                comment: "Product category");

            migrationBuilder.AlterTable(
                name: "attribute_values",
                comment: "Optional attribute value table");

            migrationBuilder.AlterColumn<int>(
                name: "product_category_id",
                table: "attributes",
                type: "integer",
                nullable: false,
                comment: "Product category id for current attribute",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "attributes",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                comment: "Attribute name",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Attribute name");

            migrationBuilder.AlterColumn<string>(
                name: "data_type",
                table: "attributes",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                comment: "Product property value type (default: string)",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Product property type (default: string)");

            migrationBuilder.AlterColumn<Guid>(
                name: "product_id",
                table: "attribute_values",
                type: "uuid",
                nullable: false,
                comment: "Attribute product identifier",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "attribute_id",
                table: "attribute_values",
                type: "integer",
                nullable: false,
                comment: "Attribute identifier",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "attribute_values",
                type: "character varying(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                comment: "Attribute actual value");

            migrationBuilder.AddPrimaryKey(
                name: "pk_attribute_values",
                table: "attribute_values",
                columns: new[] { "product_id", "attribute_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_attribute_values",
                table: "attribute_values");

            migrationBuilder.DropColumn(
                name: "value",
                table: "attribute_values");

            migrationBuilder.AlterTable(
                name: "products_categories",
                oldComment: "Product category");

            migrationBuilder.AlterTable(
                name: "attribute_values",
                oldComment: "Optional attribute value table");

            migrationBuilder.AlterColumn<int>(
                name: "product_category_id",
                table: "attributes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Product category id for current attribute");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "attributes",
                type: "text",
                nullable: false,
                comment: "Attribute name",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldComment: "Attribute name");

            migrationBuilder.AlterColumn<string>(
                name: "data_type",
                table: "attributes",
                type: "text",
                nullable: false,
                comment: "Product property type (default: string)",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldComment: "Product property value type (default: string)");

            migrationBuilder.AlterColumn<int>(
                name: "attribute_id",
                table: "attribute_values",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Attribute identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "product_id",
                table: "attribute_values",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Attribute product identifier");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "attribute_values",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_attribute_values",
                table: "attribute_values",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_attribute_values_product_id",
                table: "attribute_values",
                column: "product_id");
        }
    }
}
