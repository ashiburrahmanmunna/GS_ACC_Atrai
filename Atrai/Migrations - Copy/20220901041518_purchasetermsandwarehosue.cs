using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class purchasetermsandwarehosue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Warehouse_WarehouseIdMain",
                table: "Purchase");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseIdMain",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVatSales",
                table: "Purchase",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PurchaseTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    TermsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TermsDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TermsSLNo = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseTerms_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PurchaseTerms_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTerms_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTerms_ComId",
                table: "PurchaseTerms",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTerms_LuserId",
                table: "PurchaseTerms",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTerms_PurchaseId",
                table: "PurchaseTerms",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Warehouse_WarehouseIdMain",
                table: "Purchase",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Warehouse_WarehouseIdMain",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "PurchaseTerms");

            migrationBuilder.DropColumn(
                name: "IsVatSales",
                table: "Purchase");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseIdMain",
                table: "Purchase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Warehouse_WarehouseIdMain",
                table: "Purchase",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }
    }
}
