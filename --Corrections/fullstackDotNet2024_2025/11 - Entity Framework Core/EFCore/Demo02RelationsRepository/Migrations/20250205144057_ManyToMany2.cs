using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo02RelationsRepository.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => new { x.TagId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_BlogTags_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublication",
                value: new DateTime(2025, 2, 5, 15, 40, 57, 483, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublication",
                value: new DateTime(2025, 2, 5, 15, 40, 57, 483, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePublication",
                value: new DateTime(2025, 2, 5, 15, 40, 57, 483, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatePublication",
                value: new DateTime(2025, 2, 5, 15, 40, 57, 483, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_BlogId",
                table: "BlogTags",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "Tags");

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
        }
    }
}
