using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class durationtimeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "SoftwarePackage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DurationTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurationName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DayMonthYear = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isInactive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurationTime", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwarePackage_DurationId",
                table: "SoftwarePackage",
                column: "DurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwarePackage_DurationTime_DurationId",
                table: "SoftwarePackage",
                column: "DurationId",
                principalTable: "DurationTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwarePackage_DurationTime_DurationId",
                table: "SoftwarePackage");

            migrationBuilder.DropTable(
                name: "DurationTime");

            migrationBuilder.DropIndex(
                name: "IX_SoftwarePackage_DurationId",
                table: "SoftwarePackage");

            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "SoftwarePackage");
        }
    }
}
