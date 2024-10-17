using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class emloyeeattupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InTime",
                table: "EmployeeAttendance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OutTime",
                table: "EmployeeAttendance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PunchDate",
                table: "EmployeeAttendance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EmployeeAttendance",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InTime",
                table: "EmployeeAttendance");

            migrationBuilder.DropColumn(
                name: "OutTime",
                table: "EmployeeAttendance");

            migrationBuilder.DropColumn(
                name: "PunchDate",
                table: "EmployeeAttendance");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmployeeAttendance");
        }
    }
}
