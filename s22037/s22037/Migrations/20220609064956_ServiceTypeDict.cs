using Microsoft.EntityFrameworkCore.Migrations;

namespace s22037.Migrations
{
    public partial class ServiceTypeDict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_Cars_IdCar",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_Mechanics_IdMechanic",
                table: "Inspection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inspection",
                table: "Inspection");

            migrationBuilder.RenameTable(
                name: "Inspection",
                newName: "Inspections");

            migrationBuilder.RenameIndex(
                name: "IX_Inspection_IdMechanic",
                table: "Inspections",
                newName: "IX_Inspections_IdMechanic");

            migrationBuilder.RenameIndex(
                name: "IX_Inspection_IdCar",
                table: "Inspections",
                newName: "IX_Inspections_IdCar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inspections",
                table: "Inspections",
                column: "IdInspection");

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.IdServiceType);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Cars_IdCar",
                table: "Inspections",
                column: "IdCar",
                principalTable: "Cars",
                principalColumn: "IdCar",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Mechanics_IdMechanic",
                table: "Inspections",
                column: "IdMechanic",
                principalTable: "Mechanics",
                principalColumn: "IdMechanic",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Cars_IdCar",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Mechanics_IdMechanic",
                table: "Inspections");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inspections",
                table: "Inspections");

            migrationBuilder.RenameTable(
                name: "Inspections",
                newName: "Inspection");

            migrationBuilder.RenameIndex(
                name: "IX_Inspections_IdMechanic",
                table: "Inspection",
                newName: "IX_Inspection_IdMechanic");

            migrationBuilder.RenameIndex(
                name: "IX_Inspections_IdCar",
                table: "Inspection",
                newName: "IX_Inspection_IdCar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inspection",
                table: "Inspection",
                column: "IdInspection");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_Cars_IdCar",
                table: "Inspection",
                column: "IdCar",
                principalTable: "Cars",
                principalColumn: "IdCar",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_Mechanics_IdMechanic",
                table: "Inspection",
                column: "IdMechanic",
                principalTable: "Mechanics",
                principalColumn: "IdMechanic",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
