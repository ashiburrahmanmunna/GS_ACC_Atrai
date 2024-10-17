using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class smsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendSMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CommandType = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TextLength = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendSMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SendSMS_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SendSMS_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMSBalance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SMSPurchaseQuantity = table.Column<int>(type: "int", nullable: false),
                    SMSPurchaseRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSBalance_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SMSBalance_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SendSMS_ComId",
                table: "SendSMS",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SendSMS_LuserId",
                table: "SendSMS",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSBalance_ComId",
                table: "SMSBalance",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSBalance_LuserId",
                table: "SMSBalance",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendSMS");

            migrationBuilder.DropTable(
                name: "SMSBalance");
        }
    }
}
