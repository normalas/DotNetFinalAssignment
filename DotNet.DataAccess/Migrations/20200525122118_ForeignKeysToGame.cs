using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet.DataAccess.Migrations
{
    public partial class ForeignKeysToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Developers_DeveloperCompanyId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publishers_PublisherCompanyId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PublisherCompanyId",
                table: "Games",
                newName: "PublisherId");

            migrationBuilder.RenameColumn(
                name: "DeveloperCompanyId",
                table: "Games",
                newName: "DeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PublisherCompanyId",
                table: "Games",
                newName: "IX_Games_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_DeveloperCompanyId",
                table: "Games",
                newName: "IX_Games_DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Games",
                newName: "PublisherCompanyId");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Games",
                newName: "DeveloperCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                newName: "IX_Games_PublisherCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                newName: "IX_Games_DeveloperCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Developers_DeveloperCompanyId",
                table: "Games",
                column: "DeveloperCompanyId",
                principalTable: "Developers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publishers_PublisherCompanyId",
                table: "Games",
                column: "PublisherCompanyId",
                principalTable: "Publishers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
