using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpCaisseEnregistreuse.Migrations
{
    /// <inheritdoc />
    public partial class addpath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProduitPath",
                table: "Produits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduitPath",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProduitPath",
                table: "Produits");
        }
    }
}
