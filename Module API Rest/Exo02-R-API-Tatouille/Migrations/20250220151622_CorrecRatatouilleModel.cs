using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exo02_R_API_Tatouille.Migrations
{
    /// <inheritdoc />
    public partial class CorrecRatatouilleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_ratatouille_RatatouilleId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "ingredient");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_RatatouilleId",
                table: "ingredient",
                newName: "IX_ingredient_RatatouilleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_ratatouille_RatatouilleId",
                table: "ingredient",
                column: "RatatouilleId",
                principalTable: "ratatouille",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_ratatouille_RatatouilleId",
                table: "ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient");

            migrationBuilder.RenameTable(
                name: "ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_ingredient_RatatouilleId",
                table: "Ingredients",
                newName: "IX_Ingredients_RatatouilleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_ratatouille_RatatouilleId",
                table: "Ingredients",
                column: "RatatouilleId",
                principalTable: "ratatouille",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
