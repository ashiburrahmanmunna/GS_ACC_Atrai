using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class subscriptiontype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionTypeId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubscriptionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SubscriptionRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityDay = table.Column<int>(type: "int", nullable: false),
                    SubscriptionAmount = table.Column<float>(type: "real", nullable: false),
                    ValidationRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessTypeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionType_BusinessType_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionActivation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityDay = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActiveFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionTypeId = table.Column<int>(type: "int", nullable: true),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionActivation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionActivation_SubscriptionType_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscriptionActivation_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_SubscriptionTypeId",
                table: "Company",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionActivation_LuserId",
                table: "SubscriptionActivation",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionActivation_SubscriptionTypeId",
                table: "SubscriptionActivation",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionType_BusinessTypeId",
                table: "SubscriptionType",
                column: "BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_SubscriptionType_SubscriptionTypeId",
                table: "Company",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_SubscriptionType_SubscriptionTypeId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "SubscriptionActivation");

            migrationBuilder.DropTable(
                name: "SubscriptionType");

            migrationBuilder.DropIndex(
                name: "IX_Company_SubscriptionTypeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeId",
                table: "Company");
        }
    }
}
