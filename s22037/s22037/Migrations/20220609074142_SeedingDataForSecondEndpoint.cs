using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace s22037.Migrations
{
    public partial class SeedingDataForSecondEndpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Name", "ProductionYear" },
                values: new object[] { -3, "Car3", 2018 });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "IdInspection", "Comment", "IdCar", "IdMechanic", "InspectionDate" },
                values: new object[] { -4, "Yearly Inspection", -3, -1, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ServiceTypeDict_Inspections",
                columns: new[] { "IdInspection", "IdServiceType", "Comments" },
                values: new object[] { -4, -2, null });

            migrationBuilder.InsertData(
                table: "ServiceTypeDict_Inspections",
                columns: new[] { "IdInspection", "IdServiceType", "Comments" },
                values: new object[] { -4, -1, "IfNecessary" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceTypeDict_Inspections",
                keyColumns: new[] { "IdInspection", "IdServiceType" },
                keyValues: new object[] { -4, -2 });

            migrationBuilder.DeleteData(
                table: "ServiceTypeDict_Inspections",
                keyColumns: new[] { "IdInspection", "IdServiceType" },
                keyValues: new object[] { -4, -1 });

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "IdInspection",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: -3);
        }
    }
}
