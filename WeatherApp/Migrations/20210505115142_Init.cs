using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dailies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinTemperaure = table.Column<int>(type: "int", nullable: false),
                    MaxTemperature = table.Column<int>(type: "int", nullable: false),
                    Situation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindSpeed = table.Column<int>(type: "int", nullable: false),
                    SunriseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SunetTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LastUpdatedAt = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hourlies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    WindSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hourlies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyCities",
                columns: table => new
                {
                    DailyId = table.Column<int>(type: "int", nullable: false),
                    CityyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyCities", x => new { x.DailyId, x.CityyId });
                    table.ForeignKey(
                        name: "FK_DailyCities_Cities_CityyId",
                        column: x => x.CityyId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyCities_Dailies_DailyId",
                        column: x => x.DailyId,
                        principalTable: "Dailies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourlyCities",
                columns: table => new
                {
                    HourlyId = table.Column<int>(type: "int", nullable: false),
                    CityyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyCities", x => new { x.HourlyId, x.CityyId });
                    table.ForeignKey(
                        name: "FK_HourlyCities_Cities_CityyId",
                        column: x => x.CityyId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourlyCities_Hourlies_HourlyId",
                        column: x => x.HourlyId,
                        principalTable: "Hourlies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyCities_CityyId",
                table: "DailyCities",
                column: "CityyId");

            migrationBuilder.CreateIndex(
                name: "IX_HourlyCities_CityyId",
                table: "HourlyCities",
                column: "CityyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyCities");

            migrationBuilder.DropTable(
                name: "HourlyCities");

            migrationBuilder.DropTable(
                name: "Dailies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Hourlies");
        }
    }
}
