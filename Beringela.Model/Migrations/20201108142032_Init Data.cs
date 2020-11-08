using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beringela.Models.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "0586bbe0-4ba6-4bec-9ba1-e3834479b7ed");

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "2485397e-5a03-4fab-8df8-526a5b15f7b9",
                columns: new[] { "Date", "TemperatureC" },
                values: new object[] { new DateTime(2020, 11, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), 26 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "4e017299-0191-4527-b2f7-1c4134a8412e",
                columns: new[] { "Date", "TemperatureC" },
                values: new object[] { new DateTime(2020, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), 18 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "b36e107a-e474-48b7-9bfa-6762c6f1361b",
                column: "Date",
                value: new DateTime(2020, 11, 9, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "ede8d5cc-72e0-44c2-adca-cb810f161596",
                columns: new[] { "Date", "Summary" },
                values: new object[] { new DateTime(2020, 11, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "Warm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "2485397e-5a03-4fab-8df8-526a5b15f7b9",
                columns: new[] { "Date", "TemperatureC" },
                values: new object[] { new DateTime(2020, 11, 7, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(810), 20 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "4e017299-0191-4527-b2f7-1c4134a8412e",
                columns: new[] { "Date", "TemperatureC" },
                values: new object[] { new DateTime(2020, 11, 9, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4315), 26 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "b36e107a-e474-48b7-9bfa-6762c6f1361b",
                column: "Date",
                value: new DateTime(2020, 11, 11, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: "ede8d5cc-72e0-44c2-adca-cb810f161596",
                columns: new[] { "Date", "Summary" },
                values: new object[] { new DateTime(2020, 11, 8, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4181), "Balmy" });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { "0586bbe0-4ba6-4bec-9ba1-e3834479b7ed", new DateTime(2020, 11, 10, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4323), "Chilly", 13 });
        }
    }
}
