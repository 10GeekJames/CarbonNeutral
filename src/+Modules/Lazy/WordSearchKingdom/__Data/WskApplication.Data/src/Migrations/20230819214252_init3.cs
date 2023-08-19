using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WskApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGameCategory");

            migrationBuilder.DropTable(
                name: "GameGameTag");

            migrationBuilder.DropTable(
                name: "HiddenWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameTags",
                table: "GameTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameCategories",
                table: "GameCategories");

            migrationBuilder.RenameTable(
                name: "GameTags",
                newName: "GameTag");

            migrationBuilder.RenameTable(
                name: "GameCategories",
                newName: "GameCategory");

            migrationBuilder.AddColumn<string>(
                name: "GameCategoriesData",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "GameCategoryId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameTagId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameTagsData",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HiddenWordsData",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompletedWordsData",
                table: "GameGridInstances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameTag",
                table: "GameTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameCategory",
                table: "GameCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameCategoryId",
                table: "Games",
                column: "GameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTagId",
                table: "Games",
                column: "GameTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameCategory_GameCategoryId",
                table: "Games",
                column: "GameCategoryId",
                principalTable: "GameCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameTag_GameTagId",
                table: "Games",
                column: "GameTagId",
                principalTable: "GameTag",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameCategory_GameCategoryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameTag_GameTagId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameCategoryId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameTagId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameTag",
                table: "GameTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameCategory",
                table: "GameCategory");

            migrationBuilder.DropColumn(
                name: "GameCategoriesData",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameCategoryId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameTagId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameTagsData",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HiddenWordsData",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CompletedWordsData",
                table: "GameGridInstances");

            migrationBuilder.RenameTable(
                name: "GameTag",
                newName: "GameTags");

            migrationBuilder.RenameTable(
                name: "GameCategory",
                newName: "GameCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameTags",
                table: "GameTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameCategories",
                table: "GameCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameGameCategory",
                columns: table => new
                {
                    GameCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    GameTagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "HiddenWords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsFound = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiddenWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiddenWords_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
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
                name: "IX_HiddenWords_GameId",
                table: "HiddenWords",
                column: "GameId");
        }
    }
}
