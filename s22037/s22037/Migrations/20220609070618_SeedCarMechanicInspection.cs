using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace s22037.Migrations
{
    public partial class SeedCarMechanicInspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Name", "ProductionYear" },
                values: new object[] { -1, "Car1", 1998 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "Name", "ProductionYear" },
                values: new object[] { -2, "Car2", 2011 });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "IdMechanic", "FirstName", "LastName" },
                values: new object[] { -1, "Fname1", "Lname1" });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "IdInspection", "Comment", "IdCar", "IdMechanic", "InspectionDate" },
                values: new object[] { -1, null, -1, -1, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "IdInspection", "Comment", "IdCar", "IdMechanic", "InspectionDate" },
                values: new object[] { -2, "Post Accident", -1, -1, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "IdInspection", "Comment", "IdCar", "IdMechanic", "InspectionDate" },
                values: new object[] { -3, null, -2, -1, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "IdInspection",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "IdInspection",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "IdInspection",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "IdCar",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "IdMechanic",
                keyValue: -1);
        }
    }
}
