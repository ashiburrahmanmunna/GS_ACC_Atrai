using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class agencysalestaxmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesTax");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "MasterSalesTax");
        }
    }
}
