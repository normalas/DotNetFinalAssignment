using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet.DataAccess.Migrations
{
    public partial class TiredOfModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursToComplete",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "HoursToComplete",
                table: "Games",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
