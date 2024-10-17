using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedLCNature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LCNature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LCNatureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LCNatureShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LCNature", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LCNature");
        }
    }
}
