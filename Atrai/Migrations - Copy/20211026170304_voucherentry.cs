using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class voucherentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherNoCreatedTypeId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isChequeDetails",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiCurrency",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiDebitCredit",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVoucherDistributionEntry",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBankItem",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCashItem",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChkRef",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsItemAccmulateddDep",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsItemDepExp",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isItemConsumed",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isItemInventory",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Acc_VoucherTranGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "Acc_VoucherTranGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "Acc_VoucherTranGroup",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IntegrationSettingMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntegrationSettingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IntegrationTableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IntegrationRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainSLNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoucherTypeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationSettingMain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationSettingMain_Acc_VoucherType_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "Acc_VoucherType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntegrationSettingMain_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegrationSettingMain_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollIntegration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: true),
                    TKDebitLocal = table.Column<double>(type: "float", nullable: false),
                    TKCreditLocal = table.Column<double>(type: "float", nullable: false),
                    SLNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PayrollIntegration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollIntegration_Acc_FiscalMonth_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollIntegration_Acc_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollIntegration_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollIntegration_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollIntegration_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessLock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LockType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessLock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessLock_Acc_FiscalMonth_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessLock_Acc_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessLock_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessLock_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationSettingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntegrationSettingMainId = table.Column<int>(type: "int", nullable: false),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    SelectColumnNameOne = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ConditionCount = table.Column<int>(type: "int", nullable: false),
                    ColNameOne = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    colNameOneValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColNameTwo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    colNameTwoValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColNameThree = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    colNameThreeValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColNameFour = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    colNameFourValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    SelectStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhereCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColNameOneGroupBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColNameTwoGroupBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColNameThreeGroupBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColNameFourGroupBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupByCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsSubtract = table.Column<bool>(type: "bit", nullable: false),
                    IsDebit = table.Column<bool>(type: "bit", nullable: false),
                    IsCredit = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationSettingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationSettingDetails_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegrationSettingDetails_IntegrationSettingMain_IntegrationSettingMainId",
                        column: x => x.IntegrationSettingMainId,
                        principalTable: "IntegrationSettingMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_VoucherNoCreatedTypeId",
                table: "Company",
                column: "VoucherNoCreatedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTranGroup_ComId",
                table: "Acc_VoucherTranGroup",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTranGroup_LuserId",
                table: "Acc_VoucherTranGroup",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationSettingDetails_AccId",
                table: "IntegrationSettingDetails",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationSettingDetails_IntegrationSettingMainId",
                table: "IntegrationSettingDetails",
                column: "IntegrationSettingMainId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationSettingMain_ComId",
                table: "IntegrationSettingMain",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationSettingMain_LuserId",
                table: "IntegrationSettingMain",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationSettingMain_VoucherTypeId",
                table: "IntegrationSettingMain",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollIntegration_AccId",
                table: "PayrollIntegration",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollIntegration_ComId",
                table: "PayrollIntegration",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollIntegration_FiscalMonthId",
                table: "PayrollIntegration",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollIntegration_FiscalYearId",
                table: "PayrollIntegration",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollIntegration_LuserId",
                table: "PayrollIntegration",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLock_ComId",
                table: "ProcessLock",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLock_FiscalMonthId",
                table: "ProcessLock",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLock_FiscalYearId",
                table: "ProcessLock",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLock_LuserId",
                table: "ProcessLock",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherTranGroup_Company_ComId",
                table: "Acc_VoucherTranGroup",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherTranGroup_UserAccount_LuserId",
                table: "Acc_VoucherTranGroup",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Acc_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Company",
                column: "VoucherNoCreatedTypeId",
                principalTable: "Acc_VoucherNoCreatedType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherTranGroup_Company_ComId",
                table: "Acc_VoucherTranGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherTranGroup_UserAccount_LuserId",
                table: "Acc_VoucherTranGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Acc_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "IntegrationSettingDetails");

            migrationBuilder.DropTable(
                name: "PayrollIntegration");

            migrationBuilder.DropTable(
                name: "ProcessLock");

            migrationBuilder.DropTable(
                name: "IntegrationSettingMain");

            migrationBuilder.DropIndex(
                name: "IX_Company_VoucherNoCreatedTypeId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherTranGroup_ComId",
                table: "Acc_VoucherTranGroup");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherTranGroup_LuserId",
                table: "Acc_VoucherTranGroup");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "VoucherNoCreatedTypeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isChequeDetails",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isMultiCurrency",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isMultiDebitCredit",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isVoucherDistributionEntry",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsBankItem",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "IsCashItem",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "IsChkRef",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "IsItemAccmulateddDep",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "IsItemDepExp",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "isItemConsumed",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "isItemInventory",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Acc_VoucherTranGroup");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "Acc_VoucherTranGroup");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "Acc_VoucherTranGroup");
        }
    }
}
