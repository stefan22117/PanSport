using Microsoft.EntityFrameworkCore.Migrations;

namespace PanSport.Migrations
{
    public partial class FifthMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProduct_Products_ProductId",
                table: "SubProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubProduct",
                table: "SubProduct");

            migrationBuilder.RenameTable(
                name: "SubProduct",
                newName: "SubProducts");

            migrationBuilder.RenameIndex(
                name: "IX_SubProduct_ProductId",
                table: "SubProducts",
                newName: "IX_SubProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubProducts",
                table: "SubProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducts_Products_ProductId",
                table: "SubProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProducts_Products_ProductId",
                table: "SubProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubProducts",
                table: "SubProducts");

            migrationBuilder.RenameTable(
                name: "SubProducts",
                newName: "SubProduct");

            migrationBuilder.RenameIndex(
                name: "IX_SubProducts_ProductId",
                table: "SubProduct",
                newName: "IX_SubProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubProduct",
                table: "SubProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubProduct_Products_ProductId",
                table: "SubProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
