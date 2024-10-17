using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class isTermsCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTermsCondition",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SalesTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    TermsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TermsDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TermsSLNo = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesTerms_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTerms_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTerms_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerms_ComId",
                table: "SalesTerms",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerms_LuserId",
                table: "SalesTerms",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerms_SalesId",
                table: "SalesTerms",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesTerms");

            migrationBuilder.DropColumn(
                name: "IsTermsCondition",
                table: "StoreSetting");
        }
    }
}
