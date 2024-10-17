using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class AccountHeadSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountHead_SystemX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    AccName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NumericNumber = table.Column<int>(type: "int", nullable: true),
                    AccCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isSystem = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    AccountCategoryId = table.Column<int>(type: "int", nullable: true),
                    isInactive = table.Column<bool>(type: "bit", nullable: false),
                    IsItemDepExp = table.Column<bool>(type: "bit", nullable: false),
                    IsItemAccmulateddDep = table.Column<bool>(type: "bit", nullable: false),
                    OpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccumulatedDepId = table.Column<int>(type: "int", nullable: true),
                    DepExpenseId = table.Column<int>(type: "int", nullable: true),
                    DepreciationRate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHead_SystemX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountHead_SystemX_AccountCategory_AccountCategoryId",
                        column: x => x.AccountCategoryId,
                        principalTable: "AccountCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountHead_SystemX_AccountHead_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AccountHead",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_SystemX_AccountCategoryId",
                table: "AccountHead_SystemX",
                column: "AccountCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_SystemX_ParentId",
                table: "AccountHead_SystemX",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHead_SystemX");
        }
    }
}
