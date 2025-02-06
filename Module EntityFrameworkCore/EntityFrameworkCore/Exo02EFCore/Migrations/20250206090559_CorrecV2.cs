using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exo02EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CorrecV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "id", "hotel_id", "nom", "numero_telephone", "prenom" },
                values: new object[] { 2, null, "Ratata", "01544884", "Max" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
