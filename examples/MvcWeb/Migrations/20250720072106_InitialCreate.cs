using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cart_items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cart_items_carts_CartId",
                        column: x => x.CartId,
                        principalTable: "carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_items_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_items_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewComment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "ImageUrl", "MetaDescription", "MetaTitle", "Name" },
                values: new object[,]
                {
                    { 1, "Various electronic gadgets", null, null, null, "Electronics" },
                    { 2, "Home appliances and kitchenware", null, null, null, "Home and Kitchen" },
                    { 3, "Fashion and beauty products", null, null, null, "Fashion and Beauty" },
                    { 4, "Instruments for making music", null, null, null, "Musical Instruments" },
                    { 5, "Art and craft supplies", null, null, null, "Art and Crafts" },
                    { 6, "Products for babies and toddlers", null, null, null, "Baby and Toddler" },
                    { 7, "Bedding and bath essentials", null, null, null, "Bed and Bath" },
                    { 8, "Home decor and furniture", null, null, null, "Decor and Furniture" },
                    { 9, "Health and beauty products", null, null, null, "Health and Beauty" },
                    { 10, "Garden tools and supplies", null, null, null, "Home and Garden" },
                    { 11, "Jewellery and watches", null, null, null, "Jewellery and Watches" },
                    { 12, "Luggage and travel accessories", null, null, null, "Luggage and Travel" },
                    { 13, "Office supplies and stationery", null, null, null, "Office and Stationery" },
                    { 14, "Products for pets", null, null, null, "Pet Products" },
                    { 15, "Sports and outdoor equipment", null, null, null, "Sports and Outdoor" },
                    { 16, "Tools for DIY projects", null, null, null, "Tools and DIY" },
                    { 17, "Toys and games for children", null, null, null, "Toys and Games" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "CategoryId", "Colour", "CreatedAt", "Description", "DiscountedPrice", "ImageUrl", "IsFeatured", "Name", "OnSale", "Price", "ReleaseDate", "Size", "Sku", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Samsung", 1, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A sleek smartphone with a powerful processor.", 4999m, "samsung_a15_blue.jpg", false, "A15 Blue", true, 5999m, new DateOnly(2024, 1, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Dell", 1, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A high-performance laptop with a stunning display.", 18999m, "dell_xps_15.jpg", false, "XPS 15", true, 21999m, new DateOnly(2024, 2, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Sony", 1, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Noise-cancelling wireless headphones.", 3499m, "sony_wh_1000xm4.jpg", false, "WH-1000XM4", true, 3999m, new DateOnly(2024, 3, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Apple", 1, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A versatile tablet with a powerful A14 chip.", 8999m, "ipad_air.jpg", false, "iPad Air", true, 9999m, new DateOnly(2024, 4, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Canon", 1, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A full-frame mirrorless camera for professional photography.", 31999m, "canon_eos_r6.jpg", false, "EOS R6", true, 36999m, new DateOnly(2024, 5, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Philips", 2, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A healthy way to fry food with little to no oil.", 2299m, "philips_air_fryer.jpg", false, "Air Fryer", true, 2799m, new DateOnly(2024, 1, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Dyson", 2, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A powerful cordless vacuum cleaner.", 6999m, "dyson_v11.jpg", false, "V11 Vacuum Cleaner", true, 7999m, new DateOnly(2024, 2, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "KitchenAid", 2, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A versatile mixer for all your baking needs.", 5499m, "kitchenaid_mixer.jpg", false, "Stand Mixer", true, 6999m, new DateOnly(2024, 3, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Nespresso", 2, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A convenient way to make espresso at home.", 2999m, "nespresso_machine.jpg", false, "Coffee Machine", true, 3499m, new DateOnly(2024, 4, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Instant", 2, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A multi-use pressure cooker for quick meals.", 1199m, "instant_pot_duo.jpg", false, "Pot Duo", true, 1599m, new DateOnly(2024, 5, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Chanel", 3, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A timeless fragrance for special occasions.", 1699m, "chanel_no_5.jpg", false, "No. 5 Perfume", true, 1999m, new DateOnly(2024, 1, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Maybelline", 3, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A volumizing mascara for bold lashes.", 129m, "maybelline_mascara.jpg", false, "Mascara", true, 199m, new DateOnly(2024, 2, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Gucci", 3, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A luxury handbag made from fine leather.", 13999m, "gucci_handbag.jpg", false, "Handbag", true, 15999m, new DateOnly(2024, 3, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Ray-Ban", 3, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Classic sunglasses with polarized lenses.", 2499m, "rayban_aviator.jpg", false, "Aviator Sunglasses", true, 2999m, new DateOnly(2024, 4, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "MAC", 3, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A long-lasting lipstick in a range of colors.", 249m, "mac_lipstick.jpg", false, "Lipstick", true, 299m, new DateOnly(2024, 5, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Yamaha", 4, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A high-quality acoustic guitar for all levels.", 4499m, "yamaha_acoustic_guitar.jpg", false, "Acoustic Guitar", true, 4999m, new DateOnly(2024, 1, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Roland", 4, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A digital piano with realistic touch and sound.", 17999m, "roland_digital_piano.jpg", false, "Digital Piano", true, 19999m, new DateOnly(2024, 2, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Fender", 4, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A legendary electric guitar for professionals.", 12999m, "fender_stratocaster.jpg", false, "Stratocaster", true, 17999m, new DateOnly(2024, 3, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Zildjian", 4, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Professional cymbals for drummers.", 4999m, "zildjian_cymbals.jpg", false, "Cymbals", true, 5999m, new DateOnly(2024, 4, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Shure", 4, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A reliable microphone for live performances.", 1499m, "shure_sm58.jpg", false, "SM58 Microphone", true, 1999m, new DateOnly(2024, 5, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Winsor & Newton", 5, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "High-quality watercolor paints for artists.", 799m, "winsor_newton_watercolors.jpg", false, "Watercolors", true, 999m, new DateOnly(2024, 1, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "Faber-Castell", 5, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A set of professional-grade colored pencils.", 499m, "faber_castell_pencils.jpg", false, "Pencils", true, 599m, new DateOnly(2024, 2, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "Cricut", 5, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "A versatile cutting machine for crafting.", 3999m, "cricut_maker.jpg", false, "Maker", true, 4999m, new DateOnly(2024, 3, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "Sennelier", 5, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Richly pigmented oil pastels for artists.", 1599m, "sennelier_oil_pastels.jpg", false, "Oil Pastels", true, 1999m, new DateOnly(2024, 4, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "Canson", 5, null, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "High-quality drawing paper for all mediums.", 429m, "canson_drawing_paper.jpg", false, "Drawing Paper", true, 499m, new DateOnly(2024, 5, 1), null, null, 0, new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_CartId",
                table: "cart_items",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_ProductId",
                table: "cart_items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_OrderId",
                table: "order_items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_ProductId",
                table: "order_items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_OrderId",
                table: "payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_ProductId",
                table: "reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_items");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
