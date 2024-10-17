using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PaymentMethodmodelCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CardNickName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NameOnCard = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsDebitCredit = table.Column<bool>(type: "bit", nullable: false),
                    IsPayPal = table.Column<bool>(type: "bit", nullable: false),
                    StoreSettingId = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_StoreSetting_StoreSettingId",
                        column: x => x.StoreSettingId,
                        principalTable: "StoreSetting",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentMethod_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_ComId",
                table: "PaymentMethod",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_CountryId",
                table: "PaymentMethod",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_LuserId",
                table: "PaymentMethod",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_StoreSettingId",
                table: "PaymentMethod",
                column: "StoreSettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethod");
        }
    }
}
