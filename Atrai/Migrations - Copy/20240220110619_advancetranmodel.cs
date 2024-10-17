using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class advancetranmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvanceTrasactionTracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: true),
                    OccuringDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Occurence = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceTrasactionTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceTrasactionTracking_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvanceTrasactionTracking_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceTrasactionTracking_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceTrasactionTracking_ComId",
                table: "AdvanceTrasactionTracking",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceTrasactionTracking_LuserId",
                table: "AdvanceTrasactionTracking",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceTrasactionTracking_SalesId",
                table: "AdvanceTrasactionTracking",
                column: "SalesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvanceTrasactionTracking");
        }
    }
}
