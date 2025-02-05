using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exo02EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chambres",
                columns: table => new
                {
                    numero_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statut = table.Column<int>(type: "int", nullable: false),
                    nombre_lits = table.Column<int>(type: "int", nullable: false),
                    tarif = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chambres", x => x.numero_id);
                    table.ForeignKey(
                        name: "FK_Chambres_Hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numero_telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clients_Hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statut = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationChambres",
                columns: table => new
                {
                    chambre_id = table.Column<int>(name: "chambre_id)", type: "int", nullable: false),
                    reservation_id = table.Column<int>(name: "reservation_id)", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationChambres", x => new { x.reservation_id, x.chambre_id });
                    table.ForeignKey(
                        name: "FK_ReservationChambres_Chambres_chambre_id)",
                        column: x => x.chambre_id,
                        principalTable: "Chambres",
                        principalColumn: "numero_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationChambres_Reservations_reservation_id)",
                        column: x => x.reservation_id,
                        principalTable: "Reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chambres_hotel_id",
                table: "Chambres",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_hotel_id",
                table: "Clients",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationChambres_chambre_id)",
                table: "ReservationChambres",
                column: "chambre_id)");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_client_id",
                table: "Reservations",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_hotel_id",
                table: "Reservations",
                column: "hotel_id");
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

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
