using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class todoproductledger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextFollowDate",
                table: "InvoiceBill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductLedger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PrdDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TeamType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Referance = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReceivedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLedger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLedger_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLedger_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StaffComment = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AssaignFusionTeam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDo_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedger_InternetUserId",
                table: "ProductLedger",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedger_ProductId",
                table: "ProductLedger",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_InternetUserId",
                table: "ToDo",
                column: "InternetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLedger");

            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropColumn(
                name: "NextFollowDate",
                table: "InvoiceBill");
        }
    }
}
