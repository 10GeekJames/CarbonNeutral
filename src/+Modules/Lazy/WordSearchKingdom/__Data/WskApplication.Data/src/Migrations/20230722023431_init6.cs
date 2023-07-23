using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WskApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RowCells_GameGrids_GameGridId",
                table: "RowCells");

            migrationBuilder.DropIndex(
                name: "IX_RowCells_GameGridId",
                table: "RowCells");

            migrationBuilder.DropColumn(
                name: "GameGridId",
                table: "RowCells");

            migrationBuilder.AddColumn<string>(
                name: "CompletedWordCellsAsString",
                table: "GameGrids",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RowCellDataAsString",
                table: "GameGrids",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedWordCellsAsString",
                table: "GameGrids");

            migrationBuilder.DropColumn(
                name: "RowCellDataAsString",
                table: "GameGrids");

            migrationBuilder.AddColumn<Guid>(
                name: "GameGridId",
                table: "RowCells",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RowCells_GameGridId",
                table: "RowCells",
                column: "GameGridId");

            migrationBuilder.AddForeignKey(
                name: "FK_RowCells_GameGrids_GameGridId",
                table: "RowCells",
                column: "GameGridId",
                principalTable: "GameGrids",
                principalColumn: "Id");
        }
    }
}
