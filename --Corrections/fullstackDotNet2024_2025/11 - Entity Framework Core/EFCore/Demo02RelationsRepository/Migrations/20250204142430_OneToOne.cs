using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo02RelationsRepository.Migrations
{
    /// <inheritdoc />
    public partial class OneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogHeaders_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 24, 30, 233, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 24, 30, 233, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 24, 30, 233, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 24, 30, 233, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.CreateIndex(
                name: "IX_BlogHeaders_BlogId",
                table: "BlogHeaders",
                column: "BlogId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogHeaders");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatePublication",
                value: new DateTime(2025, 2, 4, 15, 0, 38, 201, DateTimeKind.Local).AddTicks(7898));
        }
    }
}
