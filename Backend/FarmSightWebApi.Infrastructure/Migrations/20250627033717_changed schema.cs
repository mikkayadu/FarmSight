using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmSightWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confidence",
                table: "Yield_Forecasts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Message_Logs");

            migrationBuilder.DropColumn(
                name: "IsDynamic",
                table: "CropCalendars");

            migrationBuilder.DropColumn(
                name: "CropType",
                table: "Benchmark_Snapshots");

            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "Benchmark_Snapshots");

            migrationBuilder.RenameColumn(
                name: "MarketTip",
                table: "Yield_Forecasts",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "ExpectedYield",
                table: "Yield_Forecasts",
                newName: "PredictedYieldTons");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Yield_Forecasts",
                newName: "PredictedHarvestDate");

            migrationBuilder.RenameColumn(
                name: "WeatherNotes",
                table: "CropCalendars",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "SowingDate",
                table: "CropCalendars",
                newName: "PlantingDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Benchmark_Snapshots",
                newName: "SnapshotDate");

            migrationBuilder.AddColumn<string>(
                name: "CropType",
                table: "Yield_Forecasts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CropType",
                table: "CropCalendars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "GeneratedAt",
                table: "CropCalendars",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "FieldId",
                table: "Benchmark_Snapshots",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Benchmark_Snapshots_FieldId",
                table: "Benchmark_Snapshots",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benchmark_Snapshots_Fields_FieldId",
                table: "Benchmark_Snapshots",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benchmark_Snapshots_Fields_FieldId",
                table: "Benchmark_Snapshots");

            migrationBuilder.DropIndex(
                name: "IX_Benchmark_Snapshots_FieldId",
                table: "Benchmark_Snapshots");

            migrationBuilder.DropColumn(
                name: "CropType",
                table: "Yield_Forecasts");

            migrationBuilder.DropColumn(
                name: "CropType",
                table: "CropCalendars");

            migrationBuilder.DropColumn(
                name: "GeneratedAt",
                table: "CropCalendars");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "Benchmark_Snapshots");

            migrationBuilder.RenameColumn(
                name: "PredictedYieldTons",
                table: "Yield_Forecasts",
                newName: "ExpectedYield");

            migrationBuilder.RenameColumn(
                name: "PredictedHarvestDate",
                table: "Yield_Forecasts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Yield_Forecasts",
                newName: "MarketTip");

            migrationBuilder.RenameColumn(
                name: "PlantingDate",
                table: "CropCalendars",
                newName: "SowingDate");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "CropCalendars",
                newName: "WeatherNotes");

            migrationBuilder.RenameColumn(
                name: "SnapshotDate",
                table: "Benchmark_Snapshots",
                newName: "Date");

            migrationBuilder.AddColumn<float>(
                name: "Confidence",
                table: "Yield_Forecasts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Message_Logs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDynamic",
                table: "CropCalendars",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CropType",
                table: "Benchmark_Snapshots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegionCode",
                table: "Benchmark_Snapshots",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
