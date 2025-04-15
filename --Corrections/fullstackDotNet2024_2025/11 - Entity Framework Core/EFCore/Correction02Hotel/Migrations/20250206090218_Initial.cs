using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Correction02Hotel.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chambres",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    NombreLits = table.Column<int>(type: "int", nullable: false),
                    Tarif = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chambres", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatutReservation = table.Column<int>(type: "int", nullable: false),
                    ClientIdentifiant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientIdentifiant",
                        column: x => x.ClientIdentifiant,
                        principalTable: "Clients",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationChambres",
                columns: table => new
                {
                    ChambreNumero = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationChambres", x => new { x.ChambreNumero, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ReservationChambres_Chambres_ChambreNumero",
                        column: x => x.ChambreNumero,
                        principalTable: "Chambres",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationChambres_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chambres",
                columns: new[] { "Numero", "NombreLits", "Statut", "Tarif" },
                values: new object[,]
                {
                    { 1, 2, 0, 100.50m },
                    { 2, 4, 2, 400.50m }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Identifiant", "Nom", "Prenom", "Telephone" },
                values: new object[,]
                {
                    { 1, "Mairesse", "Guillaume", "0607080910" },
                    { 2, "Dieudonné", "Antoine", "0607080911" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationChambres_ReservationId",
                table: "ReservationChambres",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientIdentifiant",
                table: "Reservations",
                column: "ClientIdentifiant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationChambres");

            migrationBuilder.DropTable(
                name: "Chambres");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
