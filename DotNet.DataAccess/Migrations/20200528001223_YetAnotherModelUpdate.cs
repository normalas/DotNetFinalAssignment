using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet.DataAccess.Migrations
{
    public partial class YetAnotherModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VideoGames_DeveloperId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_CharacterId",
                table: "VideoGames",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_DeveloperId",
                table: "VideoGames",
                column: "DeveloperId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_GameId",
                table: "VideoGames",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames",
                column: "PublisherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VideoGames_CharacterId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_DeveloperId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_GameId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_DeveloperId",
                table: "VideoGames",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames",
                column: "PublisherId");
        }
    }
}
