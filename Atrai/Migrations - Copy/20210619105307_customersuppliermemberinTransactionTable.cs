using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class customersuppliermemberinTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_CustomerId",
                table: "AccountsDailyTransaction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_MemberId",
                table: "AccountsDailyTransaction",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_SupplierId",
                table: "AccountsDailyTransaction",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Customer_CustomerId",
                table: "AccountsDailyTransaction",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Member_MemberId",
                table: "AccountsDailyTransaction",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Supplier_SupplierId",
                table: "AccountsDailyTransaction",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Customer_CustomerId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Member_MemberId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Supplier_SupplierId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_CustomerId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_MemberId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_SupplierId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "AccountsDailyTransaction");
        }
    }
}
