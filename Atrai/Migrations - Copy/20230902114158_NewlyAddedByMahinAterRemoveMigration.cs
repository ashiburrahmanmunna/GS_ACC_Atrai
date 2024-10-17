using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class NewlyAddedByMahinAterRemoveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTermsId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermitNo",
                table: "Purchase",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseFilePath",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "AccountsDailyTransactionDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fillingfrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOfTaxPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agency_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agency_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MasterSalesTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSalesTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterSalesTax_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterSalesTax_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DueInFixedDays = table.Column<int>(type: "int", nullable: true),
                    DueByDayOfMonth = table.Column<int>(type: "int", nullable: true),
                    DueNextMonthWithinDays = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTerms_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTerms_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItemsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    IsBillable = table.Column<bool>(type: "bit", nullable: false),
                    IsTax = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PurchaseModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItemsCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_Purchase_PurchaseModelId",
                        column: x => x.PurchaseModelId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseItemsCategory_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SalesTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    SalesTaxMasterId = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<float>(type: "real", nullable: true),
                    CustomRateTotal = table.Column<float>(type: "real", nullable: true),
                    IsSingleTax = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesTax_Agency_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesTax_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTax_MasterSalesTax_SalesTaxMasterId",
                        column: x => x.SalesTaxMasterId,
                        principalTable: "MasterSalesTax",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesTax_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_CustomerId",
                table: "PurchaseItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PaymentTermsId",
                table: "Purchase",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_ComId",
                table: "Agency",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_LuserId",
                table: "Agency",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSalesTax_ComId",
                table: "MasterSalesTax",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSalesTax_LuserId",
                table: "MasterSalesTax",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTerms_ComId",
                table: "PaymentTerms",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTerms_LuserId",
                table: "PaymentTerms",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_AccId",
                table: "PurchaseItemsCategory",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_ComId",
                table: "PurchaseItemsCategory",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_CustomerId",
                table: "PurchaseItemsCategory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_LuserId",
                table: "PurchaseItemsCategory",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItemsCategory_PurchaseModelId",
                table: "PurchaseItemsCategory",
                column: "PurchaseModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_AgentId",
                table: "SalesTax",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_ComId",
                table: "SalesTax",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_LuserId",
                table: "SalesTax",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_SalesTaxMasterId",
                table: "SalesTax",
                column: "SalesTaxMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_PaymentTerms_PaymentTermsId",
                table: "Purchase",
                column: "PaymentTermsId",
                principalTable: "PaymentTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Customer_CustomerId",
                table: "PurchaseItems",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_PaymentTerms_PaymentTermsId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Customer_CustomerId",
                table: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "PaymentTerms");

            migrationBuilder.DropTable(
                name: "PurchaseItemsCategory");

            migrationBuilder.DropTable(
                name: "SalesTax");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "MasterSalesTax");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_CustomerId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_PaymentTermsId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PermitNo",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PurchaseFilePath",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "AccountsDailyTransactionDetails");
        }
    }
}
