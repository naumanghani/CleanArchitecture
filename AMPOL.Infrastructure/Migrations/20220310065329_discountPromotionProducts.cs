using Microsoft.EntityFrameworkCore.Migrations;

namespace AMPOL.Infrastructure.Migrations
{
    public partial class discountPromotionProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = $@"Insert into DiscountPromotionProduct (DiscountPromotionsDiscountPromotionId, ProductsProductId)
                                                       Values ('DP001', 'PRD02');
                         Insert into DiscountPromotionProduct (DiscountPromotionsDiscountPromotionId, ProductsProductId)
                                                       Values ('DP002', 'PRD02');
                        ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = $@"Delete From DiscountPromotionProduct 
                                Where DiscountPromotionsDiscountPromotionId = 'DP001' and ProductsProductId = 'PRD02' and
                                and   DiscountPromotionsDiscountPromotionId = 'DP002' and ProductsProductId = 'PRD02'";
            migrationBuilder.Sql(sql);

        }
    }
}
