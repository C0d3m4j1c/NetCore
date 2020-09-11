using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.DataAccess.Migrations
{
    public partial class ProjectTypesSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "ProductTypeName" },
                values: new object[] { 1, "Type1" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "ProductTypeName" },
                values: new object[] { 2, "Type2" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "ProductTypeName" },
                values: new object[] { 3, "Type3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
