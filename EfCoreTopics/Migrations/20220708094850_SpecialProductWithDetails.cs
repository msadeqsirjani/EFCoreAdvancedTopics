using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTopics.Migrations
{
    public partial class SpecialProductWithDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SpecialProductSequence",
                startValue: 10L,
                incrementBy: 5);

            migrationBuilder.CreateTable(
                name: "SpecialProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisteredDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialProductPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialProductPrices_SpecialProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "SpecialProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialProductPrices_ProductId",
                table: "SpecialProductPrices",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialProductPrices");

            migrationBuilder.DropTable(
                name: "SpecialProducts");

            migrationBuilder.DropSequence(
                name: "SpecialProductSequence");
        }
    }
}
