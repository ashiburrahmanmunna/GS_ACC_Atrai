using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportCI_Container",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescId = table.Column<int>(type: "int", nullable: true),
                    ContainerId = table.Column<int>(type: "int", nullable: true),
                    PKG = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    NetWeight = table.Column<double>(type: "float", nullable: true),
                    GrossWeight = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportCI_Container", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportCI_Container_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportCI_Container_Container_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Container",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportCI_Container_ItemDescription_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDescription",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportCI_Container_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ImportCI_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CICode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PortOfLoadingId = table.Column<int>(type: "int", nullable: true),
                    PortOfDischargeId = table.Column<int>(type: "int", nullable: true),
                    CIDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommercialCompanyID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportCI_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportCI_Master_CommercialCompanies_CommercialCompanyID",
                        column: x => x.CommercialCompanyID,
                        principalTable: "CommercialCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportCI_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportCI_Master_PortOfDischarge_PortOfDischargeId",
                        column: x => x.PortOfDischargeId,
                        principalTable: "PortOfDischarge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportCI_Master_PortOfLoading_PortOfLoadingId",
                        column: x => x.PortOfLoadingId,
                        principalTable: "PortOfLoading",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportCI_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ImportCI_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportCIMasterId = table.Column<int>(type: "int", nullable: true),
                    ItemDescId = table.Column<int>(type: "int", nullable: true),
                    HSCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PKG = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
                    NetWeight = table.Column<double>(type: "float", nullable: true),
                    GrossWeight = table.Column<double>(type: "float", nullable: true),
                    CBM = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportCI_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportCI_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportCI_Details_ImportCI_Master_ImportCIMasterId",
                        column: x => x.ImportCIMasterId,
                        principalTable: "ImportCI_Master",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportCI_Details_ItemDescription_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDescription",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportCI_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Container_ComId",
                table: "ImportCI_Container",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Container_ContainerId",
                table: "ImportCI_Container",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Container_ItemDescId",
                table: "ImportCI_Container",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Container_LuserId",
                table: "ImportCI_Container",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Details_ComId",
                table: "ImportCI_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Details_ImportCIMasterId",
                table: "ImportCI_Details",
                column: "ImportCIMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Details_ItemDescId",
                table: "ImportCI_Details",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Details_LuserId",
                table: "ImportCI_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_ComId",
                table: "ImportCI_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_CommercialCompanyID",
                table: "ImportCI_Master",
                column: "CommercialCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_LuserId",
                table: "ImportCI_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_PortOfDischargeId",
                table: "ImportCI_Master",
                column: "PortOfDischargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_PortOfLoadingId",
                table: "ImportCI_Master",
                column: "PortOfLoadingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportCI_Container");

            migrationBuilder.DropTable(
                name: "ImportCI_Details");

            migrationBuilder.DropTable(
                name: "ImportCI_Master");
        }
    }
}
