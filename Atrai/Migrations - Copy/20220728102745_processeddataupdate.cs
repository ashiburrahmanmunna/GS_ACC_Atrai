using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class processeddataupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbTn",
                table: "HR_ProcessedData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EOTAmt",
                table: "HR_ProcessedData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "OTAmt",
                table: "HR_ProcessedData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "PStatus",
                table: "HR_ProcessedData",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PTimeIn",
                table: "HR_ProcessedData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PTimeOut",
                table: "HR_ProcessedData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ROTAmt",
                table: "HR_ProcessedData",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbTn",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "EOTAmt",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "OTAmt",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "PStatus",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "PTimeIn",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "PTimeOut",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "ROTAmt",
                table: "HR_ProcessedData");
        }
    }
}
