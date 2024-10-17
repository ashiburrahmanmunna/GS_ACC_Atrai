using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Atrai.Migrations
{
    public partial class newmodeladdedanddebitcreditConvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AccountsDailyTransaction_AccountHead_AccountId",
            //    table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountPayTypeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AssetLiabilityAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_AccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "AccountsDailyTransactionDetails");

            migrationBuilder.RenameColumn(
                name: "AssetLiabilityAccountId",
                table: "AccountsDailyTransaction",
                newName: "SalarySheetId");

            migrationBuilder.RenameColumn(
                name: "AccountPayTypeId",
                table: "AccountsDailyTransaction",
                newName: "ProductItemId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AccountsDailyTransaction",
                newName: "ComingFrom");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_AssetLiabilityAccountId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_SalarySheetId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_AccountPayTypeId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_ProductItemId");

            //migrationBuilder.AddColumn<string>(
            //    name: "StatusRemarks",
            //    table: "Supplier",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "DocTypeId",
            //    table: "Status",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "StatusUpdateDate",
            //    table: "Sales",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<string>(
            //    name: "StatusUpdatedBy",
            //    table: "Sales",
            //    type: "nvarchar(100)",
            //    maxLength: 100,
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "StatusId",
            //    table: "Purchase",
            //    type: "int",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryItemId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditAccountId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DebitAccountId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionQuantity",
                table: "AccountsDailyTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionRate",
                table: "AccountsDailyTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Cat_EmployeeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeTypeBangla = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Slno = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_SalaryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slno = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_SalaryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_WeekSegment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slno = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_WeekSegment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryMonthFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryMonthTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryTypeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    WeekSegmentId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    SalaryMasterRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Master_Cat_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Cat_Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Master_Cat_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "Cat_EmployeeType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Master_Cat_SalaryType_SalaryTypeId",
                        column: x => x.SalaryTypeId,
                        principalTable: "Cat_SalaryType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Master_Cat_WeekSegment_WeekSegmentId",
                        column: x => x.WeekSegmentId,
                        principalTable: "Cat_WeekSegment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Master_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryMasterId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    GS = table.Column<float>(type: "real", nullable: false),
                    BS = table.Column<float>(type: "real", nullable: false),
                    Allowance = table.Column<float>(type: "real", nullable: false),
                    TotalDay = table.Column<float>(type: "real", nullable: false),
                    OtherAddition = table.Column<float>(type: "real", nullable: false),
                    AbsentDay = table.Column<float>(type: "real", nullable: false),
                    AbsentDeduction = table.Column<float>(type: "real", nullable: false),
                    OtherDeduction = table.Column<float>(type: "real", nullable: false),
                    AdvanceDeduction = table.Column<float>(type: "real", nullable: false),
                    LoanDeduction = table.Column<float>(type: "real", nullable: false),
                    NetAmount = table.Column<float>(type: "real", nullable: false),
                    HourProductionCount = table.Column<float>(type: "real", nullable: false),
                    SalaryDetailsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Details_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Details_EmployeeSalary_Master_SalaryMasterId",
                        column: x => x.SalaryMasterId,
                        principalTable: "EmployeeSalary_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Status_DocTypeId",
            //    table: "Status",
            //    column: "DocTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Purchase_StatusId",
            //    table: "Purchase",
            //    column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_CategoryItemId",
                table: "AccountsDailyTransaction",
                column: "CategoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_CreditAccountId",
                table: "AccountsDailyTransaction",
                column: "CreditAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_DebitAccountId",
                table: "AccountsDailyTransaction",
                column: "DebitAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Details_ComId",
                table: "EmployeeSalary_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Details_EmployeeId",
                table: "EmployeeSalary_Details",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Details_LuserId",
                table: "EmployeeSalary_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Details_SalaryMasterId",
                table: "EmployeeSalary_Details",
                column: "SalaryMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Master_ComId",
                table: "EmployeeSalary_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Master_DepartmentId",
                table: "EmployeeSalary_Master",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Master_EmployeeTypeId",
                table: "EmployeeSalary_Master",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Master_LuserId",
                table: "EmployeeSalary_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Master_SalaryTypeId",
                table: "EmployeeSalary_Master",
                column: "SalaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Master_WarehouseId",
                table: "EmployeeSalary_Master",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_Master_WeekSegmentId",
                table: "EmployeeSalary_Master",
                column: "WeekSegmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_CreditAccountId",
                table: "AccountsDailyTransaction",
                column: "CreditAccountId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_DebitAccountId",
                table: "AccountsDailyTransaction",
                column: "DebitAccountId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Category_CategoryItemId",
                table: "AccountsDailyTransaction",
                column: "CategoryItemId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_EmployeeSalary_Master_SalarySheetId",
                table: "AccountsDailyTransaction",
                column: "SalarySheetId",
                principalTable: "EmployeeSalary_Master",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Product_ProductItemId",
                table: "AccountsDailyTransaction",
                column: "ProductItemId",
                principalTable: "Product",
                principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Purchase_Status_StatusId",
            //    table: "Purchase",
            //    column: "StatusId",
            //    principalTable: "Status",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Status_DocType_DocTypeId",
            //    table: "Status",
            //    column: "DocTypeId",
            //    principalTable: "DocType",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_CreditAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_DebitAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Category_CategoryItemId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_EmployeeSalary_Master_SalarySheetId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Product_ProductItemId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Status_StatusId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_DocType_DocTypeId",
                table: "Status");

            migrationBuilder.DropTable(
                name: "EmployeeSalary_Details");

            migrationBuilder.DropTable(
                name: "EmployeeSalary_Master");

            migrationBuilder.DropTable(
                name: "Cat_EmployeeType");

            migrationBuilder.DropTable(
                name: "Cat_SalaryType");

            migrationBuilder.DropTable(
                name: "Cat_WeekSegment");

            migrationBuilder.DropIndex(
                name: "IX_Status_DocTypeId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_StatusId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_CategoryItemId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_CreditAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_DebitAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "StatusRemarks",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "StatusUpdateDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "StatusUpdatedBy",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CategoryItemId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "CreditAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "DebitAccountId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "TransactionQuantity",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "TransactionRate",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "SalarySheetId",
                table: "AccountsDailyTransaction",
                newName: "AssetLiabilityAccountId");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "AccountsDailyTransaction",
                newName: "AccountPayTypeId");

            migrationBuilder.RenameColumn(
                name: "ComingFrom",
                table: "AccountsDailyTransaction",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_SalarySheetId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_AssetLiabilityAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDailyTransaction_ProductItemId",
                table: "AccountsDailyTransaction",
                newName: "IX_AccountsDailyTransaction_AccountPayTypeId");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "AccountsDailyTransactionDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_AccountId",
                table: "AccountsDailyTransaction",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountId",
                table: "AccountsDailyTransaction",
                column: "AccountId",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AccountPayTypeId",
                table: "AccountsDailyTransaction",
                column: "AccountPayTypeId",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_AccountHead_AssetLiabilityAccountId",
                table: "AccountsDailyTransaction",
                column: "AssetLiabilityAccountId",
                principalTable: "AccountHead",
                principalColumn: "Id");
        }
    }
}
