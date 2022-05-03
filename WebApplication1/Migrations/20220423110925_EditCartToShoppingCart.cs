using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    public partial class EditCartToShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "carts",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_carts_ApplicationUserId",
                table: "carts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_carts_ProductId",
                table: "carts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_AspNetUsers_ApplicationUserId",
                table: "carts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Products_ProductId",
                table: "carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_AspNetUsers_ApplicationUserId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_Products_ProductId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_ApplicationUserId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_ProductId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "carts",
                newName: "Quantity");
        }
    }
}
