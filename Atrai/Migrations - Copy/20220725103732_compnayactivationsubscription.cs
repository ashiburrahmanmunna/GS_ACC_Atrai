using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class compnayactivationsubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalYearTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubscriptionActivationCompany",
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
                    SubscriptionTypeId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionActivationCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionActivationCompany_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriptionActivationCompany_SubscriptionType_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_FiscalYearTypeId",
                table: "StoreSetting",
                column: "FiscalYearTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionActivationCompany_ComId",
                table: "SubscriptionActivationCompany",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionActivationCompany_SubscriptionTypeId",
                table: "SubscriptionActivationCompany",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_FiscalYearType_FiscalYearTypeId",
                table: "StoreSetting",
                column: "FiscalYearTypeId",
                principalTable: "FiscalYearType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_FiscalYearType_FiscalYearTypeId",
                table: "StoreSetting");

            migrationBuilder.DropTable(
                name: "SubscriptionActivationCompany");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_FiscalYearTypeId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "FiscalYearTypeId",
                table: "StoreSetting");
        }
    }
}
