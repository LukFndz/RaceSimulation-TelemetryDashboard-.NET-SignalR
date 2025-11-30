using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telemetry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelemetrySamples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SpeedKmh = table.Column<float>(type: "REAL", nullable: false),
                    Rpm = table.Column<int>(type: "INTEGER", nullable: false),
                    Gear = table.Column<int>(type: "INTEGER", nullable: false),
                    Throttle = table.Column<float>(type: "REAL", nullable: false),
                    Brake = table.Column<float>(type: "REAL", nullable: false),
                    TireTempFL = table.Column<float>(type: "REAL", nullable: false),
                    TireTempFR = table.Column<float>(type: "REAL", nullable: false),
                    TireTempRL = table.Column<float>(type: "REAL", nullable: false),
                    TireTempRR = table.Column<float>(type: "REAL", nullable: false),
                    FuelRemainingKg = table.Column<float>(type: "REAL", nullable: false),
                    DrsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetrySamples", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelemetrySamples");
        }
    }
}
