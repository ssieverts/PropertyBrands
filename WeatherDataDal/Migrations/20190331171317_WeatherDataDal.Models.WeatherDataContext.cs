using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherDataDal.Migrations
{
    public partial class WeatherDataDalModelsWeatherDataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    RefId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Base = table.Column<string>(nullable: true),
                    Visibility = table.Column<long>(nullable: false),
                    Dt = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cod = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.RefId);
                });

            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    RefId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    WeatherDataRefId = table.Column<Guid>(nullable: false),
                    All = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_Clouds_WeatherData_WeatherDataRefId",
                        column: x => x.WeatherDataRefId,
                        principalTable: "WeatherData",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    RefId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    WeatherDataRefId = table.Column<Guid>(nullable: false),
                    Lon = table.Column<double>(nullable: false),
                    Lat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_Coord_WeatherData_WeatherDataRefId",
                        column: x => x.WeatherDataRefId,
                        principalTable: "WeatherData",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    RefId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    WeatherDataRefId = table.Column<Guid>(nullable: false),
                    Temp = table.Column<double>(nullable: false),
                    Pressure = table.Column<long>(nullable: false),
                    Humidity = table.Column<long>(nullable: false),
                    TempMin = table.Column<double>(nullable: false),
                    TempMax = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_Main_WeatherData_WeatherDataRefId",
                        column: x => x.WeatherDataRefId,
                        principalTable: "WeatherData",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    RefId = table.Column<Guid>(nullable: false),
                    WeatherDataRefId = table.Column<Guid>(nullable: false),
                    Type = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Message = table.Column<double>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Sunrise = table.Column<long>(nullable: false),
                    Sunset = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_Sys_WeatherData_WeatherDataRefId",
                        column: x => x.WeatherDataRefId,
                        principalTable: "WeatherData",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    RefId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    WeatherDataRefId = table.Column<Guid>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Main = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_Weather_WeatherData_WeatherDataRefId",
                        column: x => x.WeatherDataRefId,
                        principalTable: "WeatherData",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    RefId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    WeatherDataRefId = table.Column<Guid>(nullable: false),
                    Speed = table.Column<double>(nullable: false),
                    Deg = table.Column<long>(nullable: false),
                    Gust = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_Wind_WeatherData_WeatherDataRefId",
                        column: x => x.WeatherDataRefId,
                        principalTable: "WeatherData",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clouds_WeatherDataRefId",
                table: "Clouds",
                column: "WeatherDataRefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coord_WeatherDataRefId",
                table: "Coord",
                column: "WeatherDataRefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Main_WeatherDataRefId",
                table: "Main",
                column: "WeatherDataRefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_WeatherDataRefId",
                table: "Sys",
                column: "WeatherDataRefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WeatherDataRefId",
                table: "Weather",
                column: "WeatherDataRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Wind_WeatherDataRefId",
                table: "Wind",
                column: "WeatherDataRefId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coord");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Wind");

            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
