using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exo02EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ReservationChambre_changing_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationChambres_Chambres_chambre_id)",
                table: "ReservationChambres");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationChambres_Reservations_reservation_id)",
                table: "ReservationChambres");

            migrationBuilder.RenameColumn(
                name: "chambre_id)",
                table: "ReservationChambres",
                newName: "chambre_id");

            migrationBuilder.RenameColumn(
                name: "reservation_id)",
                table: "ReservationChambres",
                newName: "reservation_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationChambres_chambre_id)",
                table: "ReservationChambres",
                newName: "IX_ReservationChambres_chambre_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationChambres_Chambres_chambre_id",
                table: "ReservationChambres",
                column: "chambre_id",
                principalTable: "Chambres",
                principalColumn: "numero_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationChambres_Reservations_reservation_id",
                table: "ReservationChambres",
                column: "reservation_id",
                principalTable: "Reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationChambres_Chambres_chambre_id",
                table: "ReservationChambres");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationChambres_Reservations_reservation_id",
                table: "ReservationChambres");

            migrationBuilder.RenameColumn(
                name: "chambre_id",
                table: "ReservationChambres",
                newName: "chambre_id)");

            migrationBuilder.RenameColumn(
                name: "reservation_id",
                table: "ReservationChambres",
                newName: "reservation_id)");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationChambres_chambre_id",
                table: "ReservationChambres",
                newName: "IX_ReservationChambres_chambre_id)");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationChambres_Chambres_chambre_id)",
                table: "ReservationChambres",
                column: "chambre_id)",
                principalTable: "Chambres",
                principalColumn: "numero_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationChambres_Reservations_reservation_id)",
                table: "ReservationChambres",
                column: "reservation_id)",
                principalTable: "Reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
