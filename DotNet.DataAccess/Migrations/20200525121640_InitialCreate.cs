using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeveloperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameTitle = table.Column<string>(nullable: true),
                    GameSubtitle = table.Column<string>(nullable: true),
                    GameSeries = table.Column<string>(nullable: true),
                    BoxArtImage = table.Column<string>(nullable: true),
                    DeveloperCompanyId = table.Column<int>(nullable: true),
                    PublisherCompanyId = table.Column<int>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    EstimatedTtc = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Developers_DeveloperCompanyId",
                        column: x => x.DeveloperCompanyId,
                        principalTable: "Developers",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherCompanyId",
                        column: x => x.PublisherCompanyId,
                        principalTable: "Publishers",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterName = table.Column<string>(nullable: true),
                    ActorId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    DeveloperId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => new { x.GameId, x.PublisherId, x.DeveloperId, x.CharacterId, x.ActorId });
                    table.UniqueConstraint("AK_VideoGames_ActorId_CharacterId_DeveloperId_GameId_PublisherId", x => new { x.ActorId, x.CharacterId, x.DeveloperId, x.GameId, x.PublisherId });
                    table.ForeignKey(
                        name: "FK_VideoGames_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGames_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGames_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGames_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActorId",
                table: "Characters",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameId",
                table: "Characters",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperCompanyId",
                table: "Games",
                column: "DeveloperCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherCompanyId",
                table: "Games",
                column: "PublisherCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_CharacterId",
                table: "VideoGames",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_DeveloperId",
                table: "VideoGames",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGames");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
