using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class DyDashboardColumnRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDateValue",
                table: "DyDashBoard");

            migrationBuilder.DropColumn(
                name: "ToDateValue",
                table: "DyDashBoard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FromDateValue",
                table: "DyDashBoard",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDateValue",
                table: "DyDashBoard",
                type: "datetime2",
                nullable: true);
        }
    }
}
