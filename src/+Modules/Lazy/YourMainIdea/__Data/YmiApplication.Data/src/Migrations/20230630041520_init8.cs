using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YmiApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street2",
                table: "Libraries",
                newName: "MailingAddress_Street2");

            migrationBuilder.RenameColumn(
                name: "Address_Street1",
                table: "Libraries",
                newName: "MailingAddress_Street1");

            migrationBuilder.RenameColumn(
                name: "Address_StateProvince",
                table: "Libraries",
                newName: "MailingAddress_StateProvince");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Libraries",
                newName: "MailingAddress_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Libraries",
                newName: "MailingAddress_Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Libraries",
                newName: "MailingAddress_City");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryEmail_Description",
                table: "Libraries",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PrimaryEmail_PhoneNumber",
                table: "Libraries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryEmail_Type",
                table: "Libraries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryPhone_Description",
                table: "Libraries",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PrimaryPhone_PhoneNumber",
                table: "Libraries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryPhone_Type",
                table: "Libraries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryEmail_Description",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "PrimaryEmail_PhoneNumber",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "PrimaryEmail_Type",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "PrimaryPhone_Description",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "PrimaryPhone_PhoneNumber",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "PrimaryPhone_Type",
                table: "Libraries");

            migrationBuilder.RenameColumn(
                name: "MailingAddress_Street2",
                table: "Libraries",
                newName: "Address_Street2");

            migrationBuilder.RenameColumn(
                name: "MailingAddress_Street1",
                table: "Libraries",
                newName: "Address_Street1");

            migrationBuilder.RenameColumn(
                name: "MailingAddress_StateProvince",
                table: "Libraries",
                newName: "Address_StateProvince");

            migrationBuilder.RenameColumn(
                name: "MailingAddress_PostalCode",
                table: "Libraries",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "MailingAddress_Country",
                table: "Libraries",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "MailingAddress_City",
                table: "Libraries",
                newName: "Address_City");
        }
    }
}
