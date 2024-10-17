using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingTemporaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COM_MasterLC_Details_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SL = table.Column<int>(type: "int", nullable: true),
                    ExportPONo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StyleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HSCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fabrication = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OrderQty = table.Column<float>(type: "real", nullable: false),
                    Factor = table.Column<float>(type: "real", nullable: false),
                    QtyInPcs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContractNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CatNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DestinationPO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Kimball = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_MasterLC_Details_Temp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_MasterLC_Details_Temp_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COM_MasterLC_Details_Temp_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLC_Details_Temp_ComId",
                table: "COM_MasterLC_Details_Temp",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLC_Details_Temp_LuserId",
                table: "COM_MasterLC_Details_Temp",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COM_MasterLC_Details_Temp");
        }
    }
}
