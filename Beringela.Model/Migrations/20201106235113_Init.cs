using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beringela.Models.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TemperatureC = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { "2485397e-5a03-4fab-8df8-526a5b15f7b9", new DateTime(2020, 11, 7, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(810), "Warm", 20 },
                    { "ede8d5cc-72e0-44c2-adca-cb810f161596", new DateTime(2020, 11, 8, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4181), "Balmy", 21 },
                    { "4e017299-0191-4527-b2f7-1c4134a8412e", new DateTime(2020, 11, 9, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4315), "Chilly", 26 },
                    { "0586bbe0-4ba6-4bec-9ba1-e3834479b7ed", new DateTime(2020, 11, 10, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4323), "Chilly", 13 },
                    { "b36e107a-e474-48b7-9bfa-6762c6f1361b", new DateTime(2020, 11, 11, 0, 51, 13, 246, DateTimeKind.Local).AddTicks(4327), "Bracing", 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
