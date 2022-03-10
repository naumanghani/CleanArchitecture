using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMPOL.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountPromotions",
                columns: table => new
                {
                    DiscountPromotionId = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "Decimal(18,2)", nullable: false, defaultValue: 0m),
                    PromotionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountPromotions", x => x.DiscountPromotionId);
                });

            migrationBuilder.CreateTable(
                name: "PointsPromotions",
                columns: table => new
                {
                    PointsPromotionId = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    PointsPerDollar = table.Column<decimal>(type: "Decimal(18,2)", nullable: false, defaultValue: 0m),
                    PromotionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsPromotions", x => x.PointsPromotionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "Decimal(18,2)", nullable: false, defaultValue: 0m),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "DiscountPromotionProduct",
                columns: table => new
                {
                    DiscountPromotionsDiscountPromotionId = table.Column<string>(type: "char(10)", nullable: false),
                    ProductsProductId = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountPromotionProduct", x => new { x.DiscountPromotionsDiscountPromotionId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_DiscountPromotionProduct_DiscountPromotions_DiscountPromotionsDiscountPromotionId",
                        column: x => x.DiscountPromotionsDiscountPromotionId,
                        principalTable: "DiscountPromotions",
                        principalColumn: "DiscountPromotionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountPromotionProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiscountPromotions",
                columns: new[] { "DiscountPromotionId", "DiscountPercent", "EndDate", "PromotionName", "StartDate" },
                values: new object[,]
                {
                    { "DP001", 20m, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fuel Discount Promo", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "DP002", 15m, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Happy Promo", new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PointsPromotions",
                columns: new[] { "PointsPromotionId", "Category", "EndDate", "PointsPerDollar", "PromotionName", "StartDate" },
                values: new object[,]
                {
                    { "PP001", 0, new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, "New Year Promo", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PP002", 1, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, "New Year Promo", new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PP003", 2, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, "Shop Promo", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { "PRD01", 1, "Vortex 95", 1.2m },
                    { "PRD02", 1, "Vortex 98", 1.3m },
                    { "PRD03", 1, "Diesel", 1.1m },
                    { "PRD04", 2, "Twix 55g", 2.3m },
                    { "PRD05", 2, "Mars 72g", 5.1m },
                    { "PRD06", 2, "SNICKERS 72G ", 3.4m },
                    { "PRD07", 2, "Bounty 3 63g", 6.9m },
                    { "PRD08", 2, "Snickers 50g", 4m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPromotionProduct_ProductsProductId",
                table: "DiscountPromotionProduct",
                column: "ProductsProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountPromotionProduct");

            migrationBuilder.DropTable(
                name: "PointsPromotions");

            migrationBuilder.DropTable(
                name: "DiscountPromotions");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
