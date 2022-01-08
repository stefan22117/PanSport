using Microsoft.EntityFrameworkCore.Migrations;

namespace PanSport.Migrations
{
    public partial class OrderPaused : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paused",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paused",
                table: "Orders");
        }
    }
}
