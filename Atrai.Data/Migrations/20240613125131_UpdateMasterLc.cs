using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMasterLc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PIDate",
                table: "MasterLC",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PINo",
                table: "MasterLC",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PIDate",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "PINo",
                table: "MasterLC");
        }
    }
}
