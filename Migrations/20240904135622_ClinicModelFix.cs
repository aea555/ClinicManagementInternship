using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagementInternship.Migrations
{
    /// <inheritdoc />
    public partial class ClinicModelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "BreakEndTime",
                table: "Clinics",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "BreakStartTime",
                table: "Clinics",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "CloseTime",
                table: "Clinics",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OpenTime",
                table: "Clinics",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakEndTime",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "BreakStartTime",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "Clinics");
        }
    }
}
