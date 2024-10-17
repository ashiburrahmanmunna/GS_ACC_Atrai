using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addApprovalStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatusId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatusId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ApprovalStatusId",
                table: "Sales",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ApprovalStatusId",
                table: "Purchase",
                column: "ApprovalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_ApprovalStatus_ApprovalStatusId",
                table: "Purchase",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_ApprovalStatus_ApprovalStatusId",
                table: "Sales",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_ApprovalStatus_ApprovalStatusId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_ApprovalStatus_ApprovalStatusId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "ApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ApprovalStatusId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_ApprovalStatusId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ApprovalStatusId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ApprovalStatusId",
                table: "Purchase");
        }
    }
}
