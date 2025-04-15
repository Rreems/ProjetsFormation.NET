using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Correction01Personnage.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pseudo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    heath_points = table.Column<int>(type: "int", nullable: false),
                    max_heath_points = table.Column<int>(type: "int", nullable: false),
                    armor = table.Column<int>(type: "int", nullable: false),
                    damages = table.Column<int>(type: "int", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kills = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "character");
        }
    }
}
