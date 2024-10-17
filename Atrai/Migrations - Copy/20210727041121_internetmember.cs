using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class internetmember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SaleCode",
                table: "Sales",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseCode",
                table: "Purchase",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillNo",
                table: "InvoiceBill",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "InvoiceBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "InternetMemberStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberStatusLong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MemberStatusShort = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetMemberStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternetMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastBilledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    ONUMac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionPointAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIdCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberStatusId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternetMember_InternetMemberStatus_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "InternetMemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ComId_SaleCode",
                table: "Sales",
                columns: new[] { "ComId", "SaleCode" },
                unique: true,
                filter: "[SaleCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ComId_PurchaseCode",
                table: "Purchase",
                columns: new[] { "ComId", "PurchaseCode" },
                unique: true,
                filter: "[PurchaseCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceBill_ComId_BillNo",
                table: "InvoiceBill",
                columns: new[] { "ComId", "BillNo" },
                unique: true,
                filter: "[BillNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InternetMember_ComId_UserId",
                table: "InternetMember",
                columns: new[] { "ComId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InternetMember_MemberStatusId",
                table: "InternetMember",
                column: "MemberStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternetMember");

            migrationBuilder.DropTable(
                name: "InternetMemberStatus");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ComId_SaleCode",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_ComId_PurchaseCode",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceBill_ComId_BillNo",
                table: "InvoiceBill");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "InvoiceBill");

            migrationBuilder.AlterColumn<string>(
                name: "SaleCode",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseCode",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillNo",
                table: "InvoiceBill",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
