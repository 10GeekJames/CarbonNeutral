using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WskApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameCategories_Games_GameId",
                table: "GameCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTags_Games_GameId",
                table: "GameTags");

            migrationBuilder.DropIndex(
                name: "IX_GameTags_GameId",
                table: "GameTags");

            migrationBuilder.DropIndex(
                name: "IX_GameCategories_GameId",
                table: "GameCategories");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameTags");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameCategories");

            migrationBuilder.CreateTable(
                name: "GameGameCategory",
                columns: table => new
                {
                    GameCategoriesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameCategory", x => new { x.GameCategoriesId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameGameCategory_GameCategories_GameCategoriesId",
                        column: x => x.GameCategoriesId,
                        principalTable: "GameCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameCategory_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGameTag",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameTagsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameTag", x => new { x.GameId, x.GameTagsId });
                    table.ForeignKey(
                        name: "FK_GameGameTag_GameTags_GameTagsId",
                        column: x => x.GameTagsId,
                        principalTable: "GameTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameTag_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGameCategory_GameId",
                table: "GameGameCategory",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameTag_GameTagsId",
                table: "GameGameTag",
                column: "GameTagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGameCategory");

            migrationBuilder.DropTable(
                name: "GameGameTag");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameTags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameTags_GameId",
                table: "GameTags",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_GameId",
                table: "GameCategories",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategories_Games_GameId",
                table: "GameCategories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameTags_Games_GameId",
                table: "GameTags",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
