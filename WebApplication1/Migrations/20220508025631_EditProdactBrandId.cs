using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    public partial class EditProdactBrandId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Products_Brands_BrandId",
        //        table: "Products",
        //        column: "BrandId",
        //        principalTable: "Brands",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_Brands_BrandId",
            //    table: "Products",
            //    column: "BrandId",
            //    principalTable: "Brands",
            //    principalColumn: "Id");
        }
    }
}
