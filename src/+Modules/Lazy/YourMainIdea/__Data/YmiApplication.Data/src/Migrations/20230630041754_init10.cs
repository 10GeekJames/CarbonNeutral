using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YmiApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_FirstName",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_LastName",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_MiddleName",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_NameSuffix",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_FirstName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Name_LastName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Name_MiddleName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Name_NameSuffix",
                table: "Authors");
        }
    }
}
