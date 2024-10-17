using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class walletcheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RechargeAmount",
                table: "CreditBalance");

            migrationBuilder.DropColumn(
                name: "SMSPurchaseRate",
                table: "CreditBalance");

            migrationBuilder.RenameColumn(
                name: "UsedAmount",
                table: "CreditBalance",
                newName: "PurchaseRate");

            migrationBuilder.RenameColumn(
                name: "SMSUsedQuantity",
                table: "CreditBalance",
                newName: "UsedQuantity");

            migrationBuilder.RenameColumn(
                name: "SMSPurchaseQuantity",
                table: "CreditBalance",
                newName: "PurchaseQuantity");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "CreditBalance",
                newName: "ActivationDate");

            migrationBuilder.AddColumn<int>(
                name: "SoftwarePackageId",
                table: "CreditBalance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RechargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wallet_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditBalance_SoftwarePackageId",
                table: "CreditBalance",
                column: "SoftwarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_ComId",
                table: "Wallet",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_LuserId",
                table: "Wallet",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditBalance_SoftwarePackage_SoftwarePackageId",
                table: "CreditBalance",
                column: "SoftwarePackageId",
                principalTable: "SoftwarePackage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditBalance_SoftwarePackage_SoftwarePackageId",
                table: "CreditBalance");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_CreditBalance_SoftwarePackageId",
                table: "CreditBalance");

            migrationBuilder.DropColumn(
                name: "SoftwarePackageId",
                table: "CreditBalance");

            migrationBuilder.RenameColumn(
                name: "UsedQuantity",
                table: "CreditBalance",
                newName: "SMSUsedQuantity");

            migrationBuilder.RenameColumn(
                name: "PurchaseRate",
                table: "CreditBalance",
                newName: "UsedAmount");

            migrationBuilder.RenameColumn(
                name: "PurchaseQuantity",
                table: "CreditBalance",
                newName: "SMSPurchaseQuantity");

            migrationBuilder.RenameColumn(
                name: "ActivationDate",
                table: "CreditBalance",
                newName: "PurchaseDate");

            migrationBuilder.AddColumn<decimal>(
                name: "RechargeAmount",
                table: "CreditBalance",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SMSPurchaseRate",
                table: "CreditBalance",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
