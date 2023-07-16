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
            migrationBuilder.DropForeignKey(
                name: "FK_GameCategories_GameCategories_GameCategoryId",
                table: "GameCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGameCategory_Games_GameId",
                table: "GameGameCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGameTag_Games_GameId",
                table: "GameGameTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTags_GameTags_GameTagId",
                table: "GameTags");

            migrationBuilder.DropIndex(
                name: "IX_GameTags_GameTagId",
                table: "GameTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameGameTag",
                table: "GameGameTag");

            migrationBuilder.DropIndex(
                name: "IX_GameGameTag_GameTagsId",
                table: "GameGameTag");

            migrationBuilder.DropIndex(
                name: "IX_GameCategories_GameCategoryId",
                table: "GameCategories");

            migrationBuilder.DropColumn(
                name: "GameTagId",
                table: "GameTags");

            migrationBuilder.DropColumn(
                name: "GameCategoryId",
                table: "GameCategories");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameGameTag",
                newName: "GamesId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameGameCategory",
                newName: "GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGameCategory_GameId",
                table: "GameGameCategory",
                newName: "IX_GameGameCategory_GamesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameGameTag",
                table: "GameGameTag",
                columns: new[] { "GameTagsId", "GamesId" });

            migrationBuilder.CreateIndex(
                name: "IX_GameGameTag_GamesId",
                table: "GameGameTag",
                column: "GamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGameCategory_Games_GamesId",
                table: "GameGameCategory",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGameTag_Games_GamesId",
                table: "GameGameTag",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGameCategory_Games_GamesId",
                table: "GameGameCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGameTag_Games_GamesId",
                table: "GameGameTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameGameTag",
                table: "GameGameTag");

            migrationBuilder.DropIndex(
                name: "IX_GameGameTag_GamesId",
                table: "GameGameTag");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameGameTag",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameGameCategory",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGameCategory_GamesId",
                table: "GameGameCategory",
                newName: "IX_GameGameCategory_GameId");

            migrationBuilder.AddColumn<Guid>(
                name: "GameTagId",
                table: "GameTags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameCategoryId",
                table: "GameCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameGameTag",
                table: "GameGameTag",
                columns: new[] { "GameId", "GameTagsId" });

            migrationBuilder.CreateIndex(
                name: "IX_GameTags_GameTagId",
                table: "GameTags",
                column: "GameTagId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameTag_GameTagsId",
                table: "GameGameTag",
                column: "GameTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_GameCategoryId",
                table: "GameCategories",
                column: "GameCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategories_GameCategories_GameCategoryId",
                table: "GameCategories",
                column: "GameCategoryId",
                principalTable: "GameCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGameCategory_Games_GameId",
                table: "GameGameCategory",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGameTag_Games_GameId",
                table: "GameGameTag",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTags_GameTags_GameTagId",
                table: "GameTags",
                column: "GameTagId",
                principalTable: "GameTags",
                principalColumn: "Id");
        }
    }
}
