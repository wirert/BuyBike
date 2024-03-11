using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressFromAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "city",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "zip_code",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "AspNetUsers",
                type: "character varying(80)",
                maxLength: 80,
                nullable: true,
                comment: "User Address");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "AspNetUsers",
                type: "character varying(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "AspNetUsers",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "zip_code",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                comment: "User Zip Code");
        }
    }
}
