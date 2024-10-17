using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class tradeterms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CreditLimit",
                table: "Customer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TradeTermsId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TradeTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeTermCaption = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isInactive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeTerms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TradeTermsId",
                table: "Customer",
                column: "TradeTermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_TradeTerms_TradeTermsId",
                table: "Customer",
                column: "TradeTermsId",
                principalTable: "TradeTerms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_TradeTerms_TradeTermsId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "TradeTerms");

            migrationBuilder.DropIndex(
                name: "IX_Customer_TradeTermsId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TradeTermsId",
                table: "Customer");
        }
    }
}
