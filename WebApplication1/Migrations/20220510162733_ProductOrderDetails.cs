using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    public partial class ProductOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderDetials_OrderDetailsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderDetailsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "Products");


            migrationBuilder.CreateTable(
                name: "Product_OrderDetails",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_OrderDetails", x => new { x.ProductId, x.OrderDetailsId });
                    table.ForeignKey(
                        name: "FK_Product_OrderDetails_OrderDetials_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderDetails_OrderDetailsId",
                table: "Product_OrderDetails",
                column: "OrderDetailsId");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "Product_OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderDetailsId",
                table: "Products",
                column: "OrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderDetials_OrderDetailsId",
                table: "Products",
                column: "OrderDetailsId",
                principalTable: "OrderDetials",
                principalColumn: "Id");
        }
    }
}
