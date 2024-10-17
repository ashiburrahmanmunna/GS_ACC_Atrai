using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class issuemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssueModelId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issue_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    SerialItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueItems_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueItems_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueBatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueItemId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseBatchId = table.Column<int>(type: "int", nullable: false),
                    BatchSerialNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueBatchItems_IssueItems_IssueItemId",
                        column: x => x.IssueItemId,
                        principalTable: "IssueItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueBatchItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueBatchItems_PurchaseBatchItems_PurchaseBatchId",
                        column: x => x.PurchaseBatchId,
                        principalTable: "PurchaseBatchItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_IssueModelId",
                table: "CostCalculated",
                column: "IssueModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_ComId_IssueCode",
                table: "Issue",
                columns: new[] { "ComId", "IssueCode" },
                unique: true,
                filter: "[IssueCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_InternetUserId",
                table: "Issue",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBatchItems_IssueItemId",
                table: "IssueBatchItems",
                column: "IssueItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBatchItems_ProductId",
                table: "IssueBatchItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBatchItems_PurchaseBatchId",
                table: "IssueBatchItems",
                column: "PurchaseBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueItems_IssueId",
                table: "IssueItems",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueItems_ProductId",
                table: "IssueItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueItems_WarehouseId",
                table: "IssueItems",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Issue_IssueModelId",
                table: "CostCalculated",
                column: "IssueModelId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Issue_IssueModelId",
                table: "CostCalculated");

            migrationBuilder.DropTable(
                name: "IssueBatchItems");

            migrationBuilder.DropTable(
                name: "IssueItems");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_IssueModelId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "IssueModelId",
                table: "CostCalculated");
        }
    }
}
