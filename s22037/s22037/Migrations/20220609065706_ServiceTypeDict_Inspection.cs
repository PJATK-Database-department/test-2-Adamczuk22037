using Microsoft.EntityFrameworkCore.Migrations;

namespace s22037.Migrations
{
    public partial class ServiceTypeDict_Inspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceTypeDict_Inspections",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false),
                    IdInspection = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDict_Inspections", x => new { x.IdServiceType, x.IdInspection });
                    table.ForeignKey(
                        name: "FK_ServiceTypeDict_Inspections_Inspections_IdInspection",
                        column: x => x.IdInspection,
                        principalTable: "Inspections",
                        principalColumn: "IdInspection",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTypeDict_Inspections_ServiceTypes_IdServiceType",
                        column: x => x.IdServiceType,
                        principalTable: "ServiceTypes",
                        principalColumn: "IdServiceType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeDict_Inspections_IdInspection",
                table: "ServiceTypeDict_Inspections",
                column: "IdInspection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTypeDict_Inspections");
        }
    }
}
