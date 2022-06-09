using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace s22037.Migrations
{
    public partial class AddedInspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    IdInspection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdMechanic = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.IdInspection);
                    table.ForeignKey(
                        name: "FK_Inspection_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Restrict); //On purpose as not to destroy seeding data.
                    table.ForeignKey(
                        name: "FK_Inspection_Mechanics_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "Mechanics",
                        principalColumn: "IdMechanic",
                        onDelete: ReferentialAction.Restrict); //May change whenever, just convenience now.
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdCar",
                table: "Inspection",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdMechanic",
                table: "Inspection",
                column: "IdMechanic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspection");
        }
    }
}
