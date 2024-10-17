using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedLienBankAndBankAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LienBankId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccountNo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    CommercialCompaniesId = table.Column<int>(type: "int", nullable: true),
                    OpeningBankId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountNo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountNo_Commercial_CommercialCompaniesId",
                        column: x => x.CommercialCompaniesId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccountNo_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BankAccountNo_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LienBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LienBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LienBankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LienBank_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LienBank_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LienBank_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_LienBankId",
                table: "MasterLC",
                column: "LienBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNo_ComId",
                table: "BankAccountNo",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNo_CommercialCompaniesId",
                table: "BankAccountNo",
                column: "CommercialCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNo_LuserId",
                table: "BankAccountNo",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_LienBank_ComId",
                table: "LienBank",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_LienBank_CountryId",
                table: "LienBank",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LienBank_LuserId",
                table: "LienBank",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC");

            migrationBuilder.DropTable(
                name: "BankAccountNo");

            migrationBuilder.DropTable(
                name: "LienBank");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_LienBankId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "LienBankId",
                table: "MasterLC");
        }
    }
}
