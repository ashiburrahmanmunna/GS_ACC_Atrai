using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class paymenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTypeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPaymentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    AccId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPaymentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_PaymentTypeModel_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentModel_AccId",
                table: "SalesPaymentModel",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentModel_PaymentTypeId",
                table: "SalesPaymentModel",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentModel_SalesId",
                table: "SalesPaymentModel",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesPaymentModel");

            migrationBuilder.DropTable(
                name: "PaymentTypeModel");
        }
    }
}
