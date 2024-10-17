using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class packageactivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageActivation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityDay = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActiveFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrxId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActiveYesNo = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageActivation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageActivation_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageActivation_PackageActivation_PackageId",
                        column: x => x.PackageId,
                        principalTable: "PackageActivation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackageActivation_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageActivation_ComId_InvoiceNo",
                table: "PackageActivation",
                columns: new[] { "ComId", "InvoiceNo" },
                unique: true,
                filter: "[InvoiceNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PackageActivation_LuserId",
                table: "PackageActivation",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageActivation_PackageId",
                table: "PackageActivation",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageActivation");
        }
    }
}
