using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class testRouter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestRouterOnuTracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PrdDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MacSerial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    WithdrawnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GivenBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WithdrawnBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRouterOnuTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRouterOnuTracking_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRouterOnuTracking_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestRouterOnuTracking_InternetUserId",
                table: "TestRouterOnuTracking",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRouterOnuTracking_ProductId",
                table: "TestRouterOnuTracking",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestRouterOnuTracking");
        }
    }
}
