using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveRoomApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiveRoomSessionCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoomSessionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveRoomSessionGrids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    RowCellData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedWordCellData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoomSessionGrids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveRoomSessionTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoomSessionTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RowCells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pigment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Letter = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    IsStartHighlight = table.Column<bool>(type: "bit", nullable: false),
                    IsEndHighlight = table.Column<bool>(type: "bit", nullable: false),
                    IsCompletedSet = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowCells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveRoomSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnownUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LiveRoomSessionDifficulty = table.Column<int>(type: "int", nullable: false),
                    LiveRoomSessionGridId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoomSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveRoomSessions_LiveRoomSessionGrids_LiveRoomSessionGridId",
                        column: x => x.LiveRoomSessionGridId,
                        principalTable: "LiveRoomSessionGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HiddenWords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFound = table.Column<bool>(type: "bit", nullable: false),
                    LiveRoomSessionGridId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiddenWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiddenWords_LiveRoomSessionGrids_LiveRoomSessionGridId",
                        column: x => x.LiveRoomSessionGridId,
                        principalTable: "LiveRoomSessionGrids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LiveRoomSessionLiveRoomSessionCategory",
                columns: table => new
                {
                    LiveRoomSessionCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveRoomSessionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoomSessionLiveRoomSessionCategory", x => new { x.LiveRoomSessionCategoriesId, x.LiveRoomSessionsId });
                    table.ForeignKey(
                        name: "FK_LiveRoomSessionLiveRoomSessionCategory_LiveRoomSessionCategories_LiveRoomSessionCategoriesId",
                        column: x => x.LiveRoomSessionCategoriesId,
                        principalTable: "LiveRoomSessionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiveRoomSessionLiveRoomSessionCategory_LiveRoomSessions_LiveRoomSessionsId",
                        column: x => x.LiveRoomSessionsId,
                        principalTable: "LiveRoomSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiveRoomSessionLiveRoomSessionTag",
                columns: table => new
                {
                    LiveRoomSessionTagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveRoomSessionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoomSessionLiveRoomSessionTag", x => new { x.LiveRoomSessionTagsId, x.LiveRoomSessionsId });
                    table.ForeignKey(
                        name: "FK_LiveRoomSessionLiveRoomSessionTag_LiveRoomSessionTags_LiveRoomSessionTagsId",
                        column: x => x.LiveRoomSessionTagsId,
                        principalTable: "LiveRoomSessionTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiveRoomSessionLiveRoomSessionTag_LiveRoomSessions_LiveRoomSessionsId",
                        column: x => x.LiveRoomSessionsId,
                        principalTable: "LiveRoomSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiveRoomSessionLiveRoomSessionCategory_LiveRoomSessionsId",
                table: "LiveRoomSessionLiveRoomSessionCategory",
                column: "LiveRoomSessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveRoomSessionLiveRoomSessionTag_LiveRoomSessionsId",
                table: "LiveRoomSessionLiveRoomSessionTag",
                column: "LiveRoomSessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveRoomSessions_LiveRoomSessionGridId",
                table: "LiveRoomSessions",
                column: "LiveRoomSessionGridId");

            migrationBuilder.CreateIndex(
                name: "IX_HiddenWords_LiveRoomSessionGridId",
                table: "HiddenWords",
                column: "LiveRoomSessionGridId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiveRoomSessionLiveRoomSessionCategory");

            migrationBuilder.DropTable(
                name: "LiveRoomSessionLiveRoomSessionTag");

            migrationBuilder.DropTable(
                name: "HiddenWords");

            migrationBuilder.DropTable(
                name: "RowCells");

            migrationBuilder.DropTable(
                name: "LiveRoomSessionCategories");

            migrationBuilder.DropTable(
                name: "LiveRoomSessionTags");

            migrationBuilder.DropTable(
                name: "LiveRoomSessions");

            migrationBuilder.DropTable(
                name: "LiveRoomSessionGrids");
        }
    }
}
