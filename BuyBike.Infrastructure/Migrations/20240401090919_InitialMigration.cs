using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Category identifier")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "Category name"),
                    description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true, comment: "Category description (optional"),
                    image_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    parent_category_id = table.Column<int>(type: "integer", nullable: true, comment: "Product parent category (If any) - self referencing foreign key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_categories_parent_category_id",
                        column: x => x.parent_category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                },
                comment: "Product category");

            migrationBuilder.CreateTable(
                name: "discounts",
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
                    table.PrimaryKey("pk_discounts", x => x.id);
                },
                comment: "Prodict discount");

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Manufacturer primary key"),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "Manufacturer name"),
                    logo_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false, comment: "Manufacturer logo URL"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_manufacturers", x => x.id);
                });

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
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product primary key"),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false, comment: "Product name"),
                    category_id = table.Column<int>(type: "integer", nullable: false, comment: "Product category identifier"),
                    price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Product price"),
                    discount_id = table.Column<int>(type: "integer", nullable: true, comment: "Product discount id"),
                    image_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false, comment: "Model Image URL"),
                    make_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product manufacturer id"),
                    color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "Product color (optional)"),
                    gender = table.Column<int>(type: "integer", nullable: true, comment: "Gender (optional)"),
                    description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true, comment: "Product description (optional"),
                    specification = table.Column<string>(type: "jsonb", nullable: true, comment: "Product specification"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Soft delete boolean property")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_products_discounts_discount_id",
                        column: x => x.discount_id,
                        principalTable: "discounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_products_manufacturers_make_id",
                        column: x => x.make_id,
                        principalTable: "manufacturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Shop product model");

            migrationBuilder.CreateTable(
                name: "bicycles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product primary key"),
                    tyre_size = table.Column<double>(type: "double precision", nullable: false, comment: "Tyre size"),
                    material = table.Column<int>(type: "integer", nullable: false, comment: "Frame's material"),
                    brakes = table.Column<int>(type: "integer", nullable: false, comment: "Brakes type"),
                    suspention = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "Suspention type"),
                    style = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true, comment: "Bicycle riding style")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bicycles", x => x.id);
                    table.ForeignKey(
                        name: "fk_bicycles_products_id",
                        column: x => x.id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Bicycle");

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

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product primary key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.id);
                    table.ForeignKey(
                        name: "fk_parts_products_id",
                        column: x => x.id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Bicycle parts");

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    item_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ordered item id"),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Order id"),
                    quantity = table.Column<int>(type: "integer", nullable: false, comment: "Item quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_items", x => new { x.order_id, x.item_id });
                    table.ForeignKey(
                        name: "fk_order_items_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Connecting table between orders and items");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "description", "image_url", "name", "parent_category_id" },
                values: new object[,]
                {
                    { 6, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "categories/bicycle-unsplash.jpg", "Велосипеди", null },
                    { 7, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "categories/Parts-Explained.jpg", "Части", null }
                });

            migrationBuilder.InsertData(
                table: "discounts",
                columns: new[] { "id", "desc", "discount_percent", "is_active", "name" },
                values: new object[,]
                {
                    { 1, null, 10, true, "10" },
                    { 2, null, 20, true, "20" },
                    { 3, null, 40, true, "40" }
                });

            migrationBuilder.InsertData(
                table: "manufacturers",
                columns: new[] { "id", "is_active", "logo_url", "name" },
                values: new object[,]
                {
                    { new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"), true, "brand-logos/specialized.png", "Specialized" },
                    { new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), true, "brand-logos/cube.png", "Cube" },
                    { new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), true, "brand-logos/giant.png", "Giant" },
                    { new Guid("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"), true, "brand-logos/cross.jpg", "Cross" },
                    { new Guid("fb2ef438-d045-4e5c-8022-d979204b4f29"), true, "brand-logos/head.png", "Head" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "description", "image_url", "name", "parent_category_id" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "categories/mountain-unsplash.jpg", "Планински", 6 },
                    { 2, "Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "categories/road-unsplash.jpg", "Шосейни", 6 },
                    { 3, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi  quibusdam!", "categories/city-unsplash.jpg", "Градски", 6 },
                    { 4, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "categories/kids-unsplash.jpg", "Детски", 6 },
                    { 5, "Lorem ipsum elit. Maiores , fugit atque quod quasi saepe sed nulla reici voluptatem quibusdam!", "categories/ebikes-unsplash.jpg", "Електрически", 6 }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "color", "description", "discount_id", "gender", "image_url", "is_active", "make_id", "name", "price", "specification" },
                values: new object[,]
                {
                    { new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"), 2, "Blue", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 3, null, "bicycles/road/Litening_Aero_28_Blue.jpg", true, new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), "Litening Aero", 14899m, "[[\"Рамка\", \"S-Works FACT 12m Carbon, Progressive XC Race Geometry, Rider-First Engineered™, threaded BB, 12x148mm rear spacing, internal cable routing, 100mm of travel\"], [\"Вилка\", \"RockShox SID SL ULTIMATE BRAIN, Top-Adjust Brain damper, Debon Air, 15x110mm, 44mm offset, 100mm Travel\"], [\"Заден дерайльор\", \"SRAM XX1 Eagle AXS\"], [\"Команди\", \"SRAM Eagle AXS Rocker Paddle\"], [\"Касета\", \"Sram XG-1299, 12-Speed, 10-52t\"], [\"Курбели\", \"Quarq XX1 Powermeter, DUB, 170/175mm, 34t\"], [\"Кормило\", \"S-Works Carbon XC Mini Rise, 6-degree upsweep, 8-degree backsweep, 10mm rise, 760mm, 31.8mm\"]]" },
                    { new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"), 3, "Grey", null, null, 1, "bicycles/city/Nulane_Pro_28_Grey.png", true, new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), "Nulane Pro", 3899m, null },
                    { new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"), 1, "White", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 2, null, "bicycles/mountain/Epic_Expert_Morn_White.jpg", true, new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"), "Epic Expert Morn", 13599m, null },
                    { new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"), 1, "White", null, null, null, "bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg", true, new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), "Fathom 1", 3499m, "[[\"Рамка\", \"S-Works FACT 12m Carbon, Progressive XC Race Geometry, Rider-First Engineered™, threaded BB, 12x148mm rear spacing, internal cable routing, 100mm of travel\"], [\"Вилка\", \"RockShox SID SL ULTIMATE BRAIN, Top-Adjust Brain damper, Debon Air, 15x110mm, 44mm offset, 100mm Travel\"], [\"Заден дерайльор\", \"SRAM XX1 Eagle AXS\"], [\"Команди\", \"SRAM Eagle AXS Rocker Paddle\"], [\"Касета\", \"Sram XG-1299, 12-Speed, 10-52t\"], [\"Курбели\", \"Quarq XX1 Powermeter, DUB, 170/175mm, 34t\"], [\"Кормило\", \"S-Works Carbon XC Mini Rise, 6-degree upsweep, 8-degree backsweep, 10mm rise, 760mm, 31.8mm\"]]" },
                    { new Guid("78804049-030f-4373-be3c-dfb4df261846"), 1, "Black", null, 1, null, "bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg", true, new Guid("69ec3905-081e-433b-a8ec-5baef5cbf0e9"), "Fathom 1", 3499m, "[[\"Рамка\", \"S-Works FACT 12m Carbon, Progressive XC Race Geometry, Rider-First Engineered™, threaded BB, 12x148mm rear spacing, internal cable routing, 100mm of travel\"], [\"Вилка\", \"RockShox SID SL ULTIMATE BRAIN, Top-Adjust Brain damper, Debon Air, 15x110mm, 44mm offset, 100mm Travel\"], [\"Заден дерайльор\", \"SRAM XX1 Eagle AXS\"], [\"Команди\", \"SRAM Eagle AXS Rocker Paddle\"], [\"Касета\", \"Sram XG-1299, 12-Speed, 10-52t\"], [\"Курбели\", \"Quarq XX1 Powermeter, DUB, 170/175mm, 34t\"], [\"Кормило\", \"S-Works Carbon XC Mini Rise, 6-degree upsweep, 8-degree backsweep, 10mm rise, 760mm, 31.8mm\"]]" },
                    { new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"), 4, "Black", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 1, null, "bicycles/kids/Faro_12_black.jpg", true, new Guid("fb2ef438-d045-4e5c-8022-d979204b4f29"), "Faro", 279m, "[[\"Рамка\", \"лека алуминиева\"], [\"Седалка\", \"регулируема седалка от 350 мм до 400 мм\"], [\"Кормило\", \"регулируемо във височина от 490мм до 540мм, дължина - 400мм, диаметър - 22,2мм\"], [\"Спирачка\", \"V\"], [\"Тегло\", \"4.4 кг\"]]" },
                    { new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"), 3, "Silver", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", null, 0, "bicycles/city/Touring_Pro_28_Silver.jpg", true, new Guid("62bc8c33-2658-4720-ad78-2bb6ba71ee87"), "Touring Pro", 1699m, "[[\"Рамка\", \"Carbon, Progressive XC Race Geometry, Rider-First Engineered™, threaded BB, 12x148mm rear spacing, internal cable routing, 100mm of travel\"], [\"Вилка\", \"RockShox SID SL ULTIMATE BRAIN, Top-Adjust Brain damper, Debon Air, 15x110mm, 44mm offset, 100mm Travel\"], [\"Заден дерайльор\", \"SRAM XX1 Eagle AXS\"], [\"Команди\", \"SRAM Eagle AXS Rocker Paddle\"], [\"Касета\", \"Sram XG-1299, 12-Speed, 10-52t\"], [\"Курбели\", \"Quarq XX1 Powermeter, DUB, 170/175mm, 34t\"], [\"Кормило\", \"S-Works Carbon XC Mini Rise, 6-degree upsweep, 760mm, 31.8mm\"]]" },
                    { new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"), 4, "Blue", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", 2, null, "bicycles/kids/Boxer_12_blue.jpg", true, new Guid("d40d9dfe-8f24-4bce-8414-b1dbdd3a2df5"), "Boxer", 299m, "[[\"Рамка\", \"лека алуминиева\"], [\"Седалка\", \"регулируема седалка от 350 мм до 400 мм\"], [\"Кормило\", \"регулируемо във височина от 490мм до 540мм, дължина - 400мм, диаметър - 22,2мм\"], [\"Спирачка\", \"V\"], [\"Тегло\", \"4.4 кг\"]]" },
                    { new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"), 2, "Red", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum deserunt voluptas, voluptate laborum quo ipsa ut accusantium beatae autem libero nam nobis maiores adipisci incidunt ad veniam tempora asperiores iure!", null, null, "bicycles/road/Allez_E5_28_red.jpg", true, new Guid("2a63178e-c137-4f76-8bb0-fb2a741c540b"), "Allez E5", 2399m, "[[\"Рамка\", \"S-Works FACT 12m Carbon, Progressive XC Race Geometry, Rider-First Engineered™, threaded BB, 12x148mm rear spacing, internal cable routing, 100mm of travel\"], [\"Вилка\", \"RockShox SID SL ULTIMATE BRAIN, Top-Adjust Brain damper, Debon Air, 15x110mm, 44mm offset, 100mm Travel\"], [\"Заден дерайльор\", \"SRAM XX1 Eagle AXS\"], [\"Команди\", \"SRAM Eagle AXS Rocker Paddle\"], [\"Касета\", \"Sram XG-1299, 12-Speed, 10-52t\"], [\"Курбели\", \"Quarq XX1 Powermeter, DUB, 170/175mm, 34t\"], [\"Кормило\", \"S-Works Carbon XC Mini Rise, 6-degree upsweep, 8-degree backsweep, 10mm rise, 760mm, 31.8mm\"]]" }
                });

            migrationBuilder.InsertData(
                table: "bicycles",
                columns: new[] { "id", "brakes", "material", "style", "suspention", "tyre_size" },
                values: new object[,]
                {
                    { new Guid("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"), 0, 1, "Шосе", "Амортисьорна вилка", 28.0 },
                    { new Guid("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"), 1, 0, "Treking", "Твърда вилка", 28.0 },
                    { new Guid("6f88c752-2b55-4380-8287-0e85a569abd5"), 0, 1, "DOWNHILL", "Пълно окачване", 29.0 },
                    { new Guid("751f85bf-9f3a-443d-a66f-1ad719e50b4e"), 0, 0, "Крос кънтри / XC", "Амортисьорна вилка", 29.0 },
                    { new Guid("78804049-030f-4373-be3c-dfb4df261846"), 0, 0, "Крос кънтри / XC", "Амортисьорна вилка", 29.0 },
                    { new Guid("b46a5b25-1e35-4006-b862-71b8b0f7e816"), 1, 2, null, "Твърда вилка", 12.0 },
                    { new Guid("c77e1e5a-86eb-4356-86c1-c6868494df85"), 1, 0, "City / Градски", "Твърда вилка", 28.0 },
                    { new Guid("c8a565f6-eb03-44b1-bed9-68dcdbff914e"), 0, 0, null, "Амортисьорна вилка", 12.0 },
                    { new Guid("dd32437b-1dfb-4a4d-bca4-43b1294a925e"), 1, 0, "Gravel Bike", "Амортисьорна вилка", 28.0 }
                });

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
                name: "ix_categories_parent_category_id",
                table: "categories",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_product_id",
                table: "items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_item_id",
                table: "order_items",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_discount_id",
                table: "products",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_make_id",
                table: "products",
                column: "make_id");
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
                name: "bicycles");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "manufacturers");
        }
    }
}
