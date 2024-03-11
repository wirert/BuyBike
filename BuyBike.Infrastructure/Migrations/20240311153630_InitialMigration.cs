using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuyBike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "User First name"),
                    last_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "User Last name"),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Manufacturer primary key"),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "Manufacturer name"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_manufacturers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product primary key"),
                    price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Product price"),
                    in_stock = table.Column<int>(type: "integer", nullable: false, comment: "Bicycle count in stock"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property"),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Part name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.id);
                },
                comment: "Bicycle parts");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Order identifier"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Order user identifier"),
                    order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Order time"),
                    address = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false, comment: "Order shipping street address"),
                    zip_code = table.Column<int>(type: "integer", nullable: true, comment: "Order shipping zip code"),
                    city = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false, comment: "Order delivery city"),
                    country = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false, comment: "Order delivery country")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User products order");

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Model primary key"),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false, comment: "Bicycle model name"),
                    make_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Model manufacturer id"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "Bicycle model Type (Enumeration)"),
                    image_url = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false, comment: "Model Image URL"),
                    gender = table.Column<int>(type: "integer", nullable: false, comment: "Gender (Undefined by default)"),
                    tyre_size = table.Column<double>(type: "double precision", nullable: false, comment: "Tyre size"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property")
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

            migrationBuilder.CreateTable(
                name: "order_products",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product id"),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Order id"),
                    quantity = table.Column<int>(type: "integer", nullable: false, comment: "Product quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_products", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "fk_order_products_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Connecting table between orders and products");

            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product primary key"),
                    price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Product price"),
                    in_stock = table.Column<int>(type: "integer", nullable: false, comment: "Bicycle count in stock"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property"),
                    model_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Bicycle model Id"),
                    size = table.Column<int>(type: "integer", nullable: false, comment: "Bicycle frame size (enumeration)"),
                    color = table.Column<string>(type: "text", nullable: true, comment: "Bicycle color (optional)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.id);
                    table.ForeignKey(
                        name: "fk_bicycles_models_model_id",
                        column: x => x.model_id,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Bicycle");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_bicycles_model_id",
                table: "Bicycles",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "ix_models_make_id",
                table: "models",
                column: "make_id");

            migrationBuilder.CreateIndex(
                name: "ix_models_type",
                table: "models",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "ix_order_products_product_id",
                table: "order_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "order_products");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
