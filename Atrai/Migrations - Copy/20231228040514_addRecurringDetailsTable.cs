using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addRecurringDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "Purchase",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RecurringDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDays = table.Column<int>(type: "int", nullable: false),
                    Interval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Every_ = table.Column<int>(type: "int", nullable: false),
                    Week_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Month_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Integer_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecurringStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecurringEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    occurences = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringDetails_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringDetails_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecurringDetails_ComId",
                table: "RecurringDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringDetails_LuserId",
                table: "RecurringDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringDetails_PurchaseId",
                table: "RecurringDetails",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringDetails_SalesId",
                table: "RecurringDetails",
                column: "SalesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecurringDetails");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "Purchase");
        }
    }
}
