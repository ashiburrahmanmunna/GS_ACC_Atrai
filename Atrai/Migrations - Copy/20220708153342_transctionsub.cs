using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class transctionsub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsDailyTransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    NetAmount = table.Column<float>(type: "real", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsDailyTransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsDailyTransactionDetails_AccountsDailyTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "AccountsDailyTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsDailyTransactionDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsDailyTransactionDetails_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountsDailyTransactionDetails_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountsDailyTransactionDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransactionDetails_ComId",
                table: "AccountsDailyTransactionDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransactionDetails_LuserId",
                table: "AccountsDailyTransactionDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransactionDetails_PurchaseId",
                table: "AccountsDailyTransactionDetails",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransactionDetails_SalesId",
                table: "AccountsDailyTransactionDetails",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransactionDetails_TransactionId",
                table: "AccountsDailyTransactionDetails",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsDailyTransactionDetails");
        }
    }
}
