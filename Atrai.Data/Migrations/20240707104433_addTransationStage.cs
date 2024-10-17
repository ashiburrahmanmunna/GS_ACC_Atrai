using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTransationStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_ApprovalStatus_ApprovalStatusId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ApprovalStatusId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ApprovalStatusId",
                table: "Sales");

            migrationBuilder.CreateTable(
                name: "TransactionApprovalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: true),
                    SalesId = table.Column<int>(type: "int", nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    DocTypeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionApprovalStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionApprovalStatus_Acc_VoucherMain_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Acc_VoucherMain",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionApprovalStatus_ApprovalStatus_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionApprovalStatus_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionApprovalStatus_DocType_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionApprovalStatus_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionApprovalStatus_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionApprovalStatus_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_ApprovalStatusId",
                table: "TransactionApprovalStatus",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_ComId",
                table: "TransactionApprovalStatus",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_DocTypeId",
                table: "TransactionApprovalStatus",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_LuserId",
                table: "TransactionApprovalStatus",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_PurchaseId",
                table: "TransactionApprovalStatus",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_SalesId",
                table: "TransactionApprovalStatus",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_VoucherId",
                table: "TransactionApprovalStatus",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionApprovalStatus");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatusId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ApprovalStatusId",
                table: "Sales",
                column: "ApprovalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_ApprovalStatus_ApprovalStatusId",
                table: "Sales",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatus",
                principalColumn: "Id");
        }
    }
}
