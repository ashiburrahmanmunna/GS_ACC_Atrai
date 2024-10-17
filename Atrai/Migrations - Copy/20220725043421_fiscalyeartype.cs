using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class fiscalyeartype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccounts",
                table: "BusinessType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDealerBasedOrganization",
                table: "BusinessType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMarcel",
                table: "BusinessType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWalton",
                table: "BusinessType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FiscalYearType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FYName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FYStartDate = table.Column<int>(type: "int", nullable: true),
                    FYStartMonth = table.Column<int>(type: "int", nullable: true),
                    FYEndDate = table.Column<int>(type: "int", nullable: true),
                    FYEndMonth = table.Column<int>(type: "int", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYearType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiscalYearType");

            migrationBuilder.DropColumn(
                name: "IsAccounts",
                table: "BusinessType");

            migrationBuilder.DropColumn(
                name: "IsDealerBasedOrganization",
                table: "BusinessType");

            migrationBuilder.DropColumn(
                name: "IsMarcel",
                table: "BusinessType");

            migrationBuilder.DropColumn(
                name: "IsWalton",
                table: "BusinessType");
        }
    }
}
