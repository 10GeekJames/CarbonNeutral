using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WskApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameGrids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    RowCellData = table.Column<string>(type: "TEXT", nullable: false),
                    CompletedWordCellData = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGrids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RowCells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pigment = table.Column<string>(type: "TEXT", nullable: false),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false),
                    Letter = table.Column<char>(type: "TEXT", nullable: false),
                    IsStartHighlight = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEndHighlight = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCompletedSet = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowCells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    GameDifficulty = table.Column<int>(type: "INTEGER", nullable: false),
                    GameGridId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameGrids_GameGridId",
                        column: x => x.GameGridId,
                        principalTable: "GameGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HiddenWords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Word = table.Column<string>(type: "TEXT", nullable: false),
                    IsFound = table.Column<bool>(type: "INTEGER", nullable: false),
                    GameGridId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiddenWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiddenWords_GameGrids_GameGridId",
                        column: x => x.GameGridId,
                        principalTable: "GameGrids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameGameCategory",
                columns: table => new
                {
                    GameCategoriesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GamesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameCategory", x => new { x.GameCategoriesId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_GameGameCategory_GameCategories_GameCategoriesId",
                        column: x => x.GameCategoriesId,
                        principalTable: "GameCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameCategory_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGameTag",
                columns: table => new
                {
                    GameTagsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GamesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameTag", x => new { x.GameTagsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_GameGameTag_GameTags_GameTagsId",
                        column: x => x.GameTagsId,
                        principalTable: "GameTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameTag_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGameCategory_GamesId",
                table: "GameGameCategory",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameTag_GamesId",
                table: "GameGameTag",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameGridId",
                table: "Games",
                column: "GameGridId");

            migrationBuilder.CreateIndex(
                name: "IX_HiddenWords_GameGridId",
                table: "HiddenWords",
                column: "GameGridId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGameCategory");

            migrationBuilder.DropTable(
                name: "GameGameTag");

            migrationBuilder.DropTable(
                name: "HiddenWords");

            migrationBuilder.DropTable(
                name: "RowCells");

            migrationBuilder.DropTable(
                name: "GameCategories");

            migrationBuilder.DropTable(
                name: "GameTags");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameGrids");
        }
    }
}
