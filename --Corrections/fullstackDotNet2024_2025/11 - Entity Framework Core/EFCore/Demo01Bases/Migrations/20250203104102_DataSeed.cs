using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo01Bases.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "Auteur", "DatePublication", "Description", "Titre" },
                values: new object[] { 1, "Arthur DENNETIERE", new DateTime(2025, 2, 3, 11, 41, 2, 196, DateTimeKind.Local).AddTicks(4309), "La meilleure recette de crêpe connue à ce jour", "La recette des crêpes" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
