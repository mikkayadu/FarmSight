using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmSightWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benchmark_Snapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionCode = table.Column<string>(type: "text", nullable: false),
                    CropType = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvgNDVI = table.Column<float>(type: "real", nullable: false),
                    AvgMoisture = table.Column<float>(type: "real", nullable: false),
                    FieldCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benchmark_Snapshots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FarmerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CropType = table.Column<string>(type: "text", nullable: false),
                    Lat1 = table.Column<double>(type: "double precision", nullable: false),
                    Lng1 = table.Column<double>(type: "double precision", nullable: false),
                    Lat2 = table.Column<double>(type: "double precision", nullable: false),
                    Lng2 = table.Column<double>(type: "double precision", nullable: false),
                    Lat3 = table.Column<double>(type: "double precision", nullable: false),
                    Lng3 = table.Column<double>(type: "double precision", nullable: false),
                    Lat4 = table.Column<double>(type: "double precision", nullable: false),
                    Lng4 = table.Column<double>(type: "double precision", nullable: false),
                    CenterLat = table.Column<double>(type: "double precision", nullable: false),
                    CenterLng = table.Column<double>(type: "double precision", nullable: false),
                    AreaHa = table.Column<double>(type: "double precision", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    AlertLevel = table.Column<int>(type: "integer", nullable: false),
                    Medium = table.Column<int>(type: "integer", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropCalendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    SowingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDynamic = table.Column<bool>(type: "boolean", nullable: false),
                    WeatherNotes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropCalendars_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EOData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NDVI = table.Column<float>(type: "real", nullable: false),
                    SoilMoisture = table.Column<float>(type: "real", nullable: false),
                    Rainfall = table.Column<float>(type: "real", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    DroughtIndex = table.Column<float>(type: "real", nullable: false),
                    FloodRisk = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EOData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EOData_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message_Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FarmerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Medium = table.Column<int>(type: "integer", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Logs_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_Logs_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Yield_Forecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ForecastDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpectedYield = table.Column<float>(type: "real", nullable: false),
                    Confidence = table.Column<float>(type: "real", nullable: false),
                    MarketTip = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yield_Forecasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yield_Forecasts_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_FieldId",
                table: "Alerts",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CropCalendars_FieldId",
                table: "CropCalendars",
                column: "FieldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EOData_FieldId",
                table: "EOData",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FarmerId",
                table: "Fields",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Logs_FarmerId",
                table: "Message_Logs",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Logs_FieldId",
                table: "Message_Logs",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Yield_Forecasts_FieldId",
                table: "Yield_Forecasts",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Benchmark_Snapshots");

            migrationBuilder.DropTable(
                name: "CropCalendars");

            migrationBuilder.DropTable(
                name: "EOData");

            migrationBuilder.DropTable(
                name: "Message_Logs");

            migrationBuilder.DropTable(
                name: "Yield_Forecasts");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
