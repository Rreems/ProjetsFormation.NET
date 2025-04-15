using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactWithDtos.Migrations
{
    /// <inheritdoc />
    public partial class NamingNormalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "contacts");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "contacts",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "contacts",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "contacts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "contacts",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "contacts",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "contacts",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "contacts",
                newName: "birth_date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "Contacts");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Contacts",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Contacts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Contacts",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Contacts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Contacts",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Contacts",
                newName: "BirthDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");
        }
    }
}
