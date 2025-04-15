using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo02RelationsRepository.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Nom", "Url" },
                values: new object[,]
                {
                    { 1, "JohnnyHalliday115", "http://www.johnnyhalliday115.skyblog.com" },
                    { 2, "Koreus", "http://www.koreus.com" },
                    { 3, "Toto", "http://www.toto.com" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Contenu", "DatePublication", "Titre" },
                values: new object[,]
                {
                    { 1, 1, "Trop triste :'(", new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7854), "Johnny est mort." },
                    { 2, 2, "Le chat il tombe là", new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7895), "Trop mdr xd la vidéo OLALALA" },
                    { 3, 2, "Le chien il tombe là", new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7897), "Trop mdr xd la vidéo 2" },
                    { 4, 3, "Moi non plus la porte était fermée ^^", new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7898), "Tu connais la blague de toto aux toilettes ?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
