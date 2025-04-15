using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExoCaisseEnregistreuse.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    QteEnStock = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Alimentaire" },
                    { 2, "Vêtements" },
                    { 3, "Bricolage et jardinage" }
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "CategorieId", "Description", "ImagePath", "Nom", "Prix", "QteEnStock" },
                values: new object[,]
                {
                    { 1, 1, "Pour faire de la chantilly bien entendu", "/images/cd0317d6-962a-4a51-9aed-52ee018cd754-placeholder.png", "Cartouches N2O", 10.99m, 45 },
                    { 2, 1, "Le goût des choses simples", "/images/cd0317d6-962a-4a51-9aed-52ee018cd754-placeholder.png", "Saucisses Herta", 3.5m, 48 },
                    { 3, 2, "Composition : 93% Polyester, 7% élasthanne", "/images/cd0317d6-962a-4a51-9aed-52ee018cd754-placeholder.png", "Chaussettes RC Lens", 2.25m, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieId",
                table: "Produits",
                column: "CategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
