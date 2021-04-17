using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoRental.Migrations
{
    public partial class Moiviestock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Movies");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
