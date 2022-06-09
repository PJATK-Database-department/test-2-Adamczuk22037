using Microsoft.EntityFrameworkCore.Migrations;

namespace s22037.Migrations
{
    public partial class SeedingServicesEtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "IdServiceType", "Price", "ServiceType" },
                values: new object[,]
                {
                    { -1, 350.49f, "ServiceType1" },
                    { -2, 500f, "ServiceType2" },
                    { -3, 100f, "ServiceType3" },
                    { -4, 235.75f, "ServiceType4" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypeDict_Inspections",
                columns: new[] { "IdInspection", "IdServiceType", "Comments" },
                values: new object[,]
                {
                    { -1, -1, null },
                    { -2, -1, "Comments" },
                    { -3, -2, "YetMoreComments" },
                    { -2, -3, null },
                    { -2, -4, "OtherComments" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceTypeDict_Inspections",
                keyColumns: new[] { "IdInspection", "IdServiceType" },
                keyValues: new object[] { -2, -4 });

            migrationBuilder.DeleteData(
                table: "ServiceTypeDict_Inspections",
                keyColumns: new[] { "IdInspection", "IdServiceType" },
                keyValues: new object[] { -2, -3 });

            migrationBuilder.DeleteData(
                table: "ServiceTypeDict_Inspections",
                keyColumns: new[] { "IdInspection", "IdServiceType" },
                keyValues: new object[] { -3, -2 });

            migrationBuilder.DeleteData(
                table: "ServiceTypeDict_Inspections",
                keyColumns: new[] { "IdInspection", "IdServiceType" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "ServiceTypeDict_Inspections",
                keyColumns: new[] { "IdInspection", "IdServiceType" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "IdServiceType",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "IdServiceType",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "IdServiceType",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "IdServiceType",
                keyValue: -1);
        }
    }
}
