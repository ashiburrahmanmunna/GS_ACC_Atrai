using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class hrempsalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LocationNameB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LocationNameShort = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LocationNameShortB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Location_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Location_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Salary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    LId1 = table.Column<int>(type: "int", nullable: true),
                    LId2 = table.Column<int>(type: "int", nullable: true),
                    LId3 = table.Column<int>(type: "int", nullable: true),
                    BId = table.Column<int>(type: "int", nullable: true),
                    PFLId = table.Column<int>(type: "int", nullable: true),
                    WelfareLId = table.Column<int>(type: "int", nullable: true),
                    MCLId = table.Column<int>(type: "int", nullable: true),
                    HBLId = table.Column<int>(type: "int", nullable: true),
                    HBLId2 = table.Column<int>(type: "int", nullable: true),
                    HBLId3 = table.Column<int>(type: "int", nullable: true),
                    PFLLId = table.Column<int>(type: "int", nullable: true),
                    PFLLId2 = table.Column<int>(type: "int", nullable: true),
                    PFLLId3 = table.Column<int>(type: "int", nullable: true),
                    GLId = table.Column<int>(type: "int", nullable: true),
                    BasicSalary = table.Column<float>(type: "real", nullable: false),
                    IsBS = table.Column<bool>(type: "bit", nullable: false),
                    HouseRent = table.Column<float>(type: "real", nullable: true),
                    IsHr = table.Column<bool>(type: "bit", nullable: false),
                    MadicalAllow = table.Column<float>(type: "real", nullable: true),
                    IsMa = table.Column<bool>(type: "bit", nullable: false),
                    FoodAllow = table.Column<float>(type: "real", nullable: true),
                    IsFa = table.Column<bool>(type: "bit", nullable: false),
                    HRExpensesOther = table.Column<float>(type: "real", nullable: true),
                    IsHRExpensesOther = table.Column<bool>(type: "bit", nullable: false),
                    ConveyanceAllow = table.Column<float>(type: "real", nullable: true),
                    IsConvAllow = table.Column<bool>(type: "bit", nullable: false),
                    DearnessAllow = table.Column<float>(type: "real", nullable: true),
                    IsDearAllow = table.Column<bool>(type: "bit", nullable: false),
                    GasAllow = table.Column<float>(type: "real", nullable: true),
                    IsGasAllow = table.Column<bool>(type: "bit", nullable: false),
                    PersonalPay = table.Column<float>(type: "real", nullable: true),
                    IsPersonalPay = table.Column<bool>(type: "bit", nullable: false),
                    ArrearBasic = table.Column<float>(type: "real", nullable: true),
                    IsArrearBasic = table.Column<bool>(type: "bit", nullable: false),
                    ArrearBonus = table.Column<float>(type: "real", nullable: true),
                    IsArrearBonus = table.Column<bool>(type: "bit", nullable: false),
                    WashingAllow = table.Column<float>(type: "real", nullable: true),
                    IsWashingAllow = table.Column<bool>(type: "bit", nullable: false),
                    SiftAllow = table.Column<float>(type: "real", nullable: true),
                    IsSiftAllow = table.Column<bool>(type: "bit", nullable: false),
                    ChargeAllow = table.Column<float>(type: "real", nullable: true),
                    IsChargAllow = table.Column<bool>(type: "bit", nullable: false),
                    MiscAdd = table.Column<float>(type: "real", nullable: true),
                    IsMiscAdd = table.Column<bool>(type: "bit", nullable: false),
                    ContainSub = table.Column<float>(type: "real", nullable: true),
                    IsContainSub = table.Column<bool>(type: "bit", nullable: false),
                    ComPfCount = table.Column<float>(type: "real", nullable: true),
                    IsComPfcount = table.Column<bool>(type: "bit", nullable: false),
                    EduAllow = table.Column<float>(type: "real", nullable: true),
                    IsEduAllow = table.Column<bool>(type: "bit", nullable: false),
                    TiffinAllow = table.Column<float>(type: "real", nullable: true),
                    IsTiffinAllow = table.Column<bool>(type: "bit", nullable: false),
                    CanteenAllow = table.Column<float>(type: "real", nullable: true),
                    IsCanteenAllow = table.Column<bool>(type: "bit", nullable: false),
                    AttAllow = table.Column<float>(type: "real", nullable: true),
                    IsAttAllow = table.Column<bool>(type: "bit", nullable: false),
                    FestivalBonus = table.Column<float>(type: "real", nullable: true),
                    IsFestivalBonus = table.Column<bool>(type: "bit", nullable: false),
                    RiskAllow = table.Column<float>(type: "real", nullable: true),
                    IsRiskAllow = table.Column<bool>(type: "bit", nullable: false),
                    NightAllow = table.Column<float>(type: "real", nullable: true),
                    IsNightAllow = table.Column<bool>(type: "bit", nullable: false),
                    MobileAllow = table.Column<float>(type: "real", nullable: true),
                    IsMobileAllow = table.Column<bool>(type: "bit", nullable: false),
                    Pf = table.Column<float>(type: "real", nullable: true),
                    IsPf = table.Column<bool>(type: "bit", nullable: false),
                    PfAdd = table.Column<float>(type: "real", nullable: true),
                    IsPfAdd = table.Column<bool>(type: "bit", nullable: false),
                    HrExp = table.Column<float>(type: "real", nullable: true),
                    IsHrexp = table.Column<bool>(type: "bit", nullable: false),
                    FesBonusDed = table.Column<float>(type: "real", nullable: true),
                    IsFesBonus = table.Column<bool>(type: "bit", nullable: false),
                    Transportcharge = table.Column<float>(type: "real", nullable: true),
                    IsTrncharge = table.Column<bool>(type: "bit", nullable: false),
                    TeliphoneCharge = table.Column<float>(type: "real", nullable: true),
                    IsTelcharge = table.Column<bool>(type: "bit", nullable: false),
                    GasChargeOther = table.Column<float>(type: "real", nullable: true),
                    IsGasChargeOther = table.Column<bool>(type: "bit", nullable: false),
                    ElectricChargeOther = table.Column<float>(type: "real", nullable: true),
                    IsElectricChargeOther = table.Column<bool>(type: "bit", nullable: false),
                    WaterChargeOther = table.Column<float>(type: "real", nullable: true),
                    IsWaterChargeOther = table.Column<bool>(type: "bit", nullable: false),
                    TAExpense = table.Column<float>(type: "real", nullable: true),
                    IsTAExp = table.Column<bool>(type: "bit", nullable: false),
                    SalaryAdv = table.Column<float>(type: "real", nullable: true),
                    IsSalaryAdv = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseAdv = table.Column<float>(type: "real", nullable: true),
                    IsPurchaseAdv = table.Column<bool>(type: "bit", nullable: false),
                    McloanDed = table.Column<float>(type: "real", nullable: true),
                    IsMcloan = table.Column<bool>(type: "bit", nullable: false),
                    HbloanDed = table.Column<float>(type: "real", nullable: true),
                    IsHbloan = table.Column<bool>(type: "bit", nullable: false),
                    PfloannDed = table.Column<float>(type: "real", nullable: true),
                    IsPfloann = table.Column<bool>(type: "bit", nullable: false),
                    WfloanLocal = table.Column<float>(type: "real", nullable: true),
                    IsWfloanLocal = table.Column<bool>(type: "bit", nullable: false),
                    WfloanOther = table.Column<float>(type: "real", nullable: true),
                    IsWfloanOther = table.Column<bool>(type: "bit", nullable: false),
                    WpfloanDed = table.Column<float>(type: "real", nullable: true),
                    IsWpfloanDed = table.Column<bool>(type: "bit", nullable: false),
                    MaterialLoanDed = table.Column<float>(type: "real", nullable: true),
                    IsMaterialLoan = table.Column<bool>(type: "bit", nullable: false),
                    MiscDed = table.Column<float>(type: "real", nullable: true),
                    IsMiscDed = table.Column<bool>(type: "bit", nullable: false),
                    AdvAgainstExp = table.Column<float>(type: "real", nullable: true),
                    IsAdvAgainstExp = table.Column<bool>(type: "bit", nullable: false),
                    AdvFacility = table.Column<float>(type: "real", nullable: true),
                    IsAdvFacility = table.Column<bool>(type: "bit", nullable: false),
                    ElectricCharge = table.Column<float>(type: "real", nullable: true),
                    IsElectricCharge = table.Column<bool>(type: "bit", nullable: false),
                    Gascharge = table.Column<float>(type: "real", nullable: true),
                    IsGascharge = table.Column<bool>(type: "bit", nullable: false),
                    HazScheme = table.Column<float>(type: "real", nullable: true),
                    IsHazScheme = table.Column<bool>(type: "bit", nullable: false),
                    Donation = table.Column<float>(type: "real", nullable: true),
                    IsDonation = table.Column<bool>(type: "bit", nullable: false),
                    Dishantenna = table.Column<float>(type: "real", nullable: true),
                    IsDishantenna = table.Column<bool>(type: "bit", nullable: false),
                    RevenueStamp = table.Column<float>(type: "real", nullable: true),
                    IsRevenueStamp = table.Column<bool>(type: "bit", nullable: false),
                    OwaSub = table.Column<float>(type: "real", nullable: true),
                    IsOwaSub = table.Column<bool>(type: "bit", nullable: false),
                    DedIncBns = table.Column<float>(type: "real", nullable: true),
                    IsDedIncBns = table.Column<bool>(type: "bit", nullable: false),
                    DapEmpClub = table.Column<float>(type: "real", nullable: true),
                    IsDapEmpClub = table.Column<bool>(type: "bit", nullable: false),
                    Moktab = table.Column<float>(type: "real", nullable: true),
                    IsMoktab = table.Column<bool>(type: "bit", nullable: false),
                    ChemicalForum = table.Column<float>(type: "real", nullable: true),
                    IsChemicalForum = table.Column<bool>(type: "bit", nullable: false),
                    DiplomaassoDed = table.Column<float>(type: "real", nullable: true),
                    IsDiplomaassoDed = table.Column<bool>(type: "bit", nullable: false),
                    EnggassoDed = table.Column<float>(type: "real", nullable: true),
                    IsEnggassoDed = table.Column<bool>(type: "bit", nullable: false),
                    Wfsub = table.Column<float>(type: "real", nullable: true),
                    IsWfsub = table.Column<bool>(type: "bit", nullable: false),
                    EduAlloDed = table.Column<float>(type: "real", nullable: true),
                    IsEduAlloDed = table.Column<bool>(type: "bit", nullable: false),
                    PurChange = table.Column<float>(type: "real", nullable: true),
                    IsPurChange = table.Column<bool>(type: "bit", nullable: false),
                    IncomeTax = table.Column<float>(type: "real", nullable: true),
                    IsIncomeTax = table.Column<bool>(type: "bit", nullable: false),
                    ArrearInTaxDed = table.Column<float>(type: "real", nullable: true),
                    IsArrearInTaxDed = table.Column<bool>(type: "bit", nullable: false),
                    OffWlfareAsso = table.Column<float>(type: "real", nullable: true),
                    IsOffWlfareAsso = table.Column<bool>(type: "bit", nullable: false),
                    OfficeclubDed = table.Column<float>(type: "real", nullable: true),
                    IsOfficeclubDed = table.Column<bool>(type: "bit", nullable: false),
                    IncBonusDed = table.Column<float>(type: "real", nullable: true),
                    IsIncBonusDed = table.Column<bool>(type: "bit", nullable: false),
                    Watercharge = table.Column<float>(type: "real", nullable: true),
                    IsWatercharge = table.Column<bool>(type: "bit", nullable: false),
                    ChemicalAsso = table.Column<float>(type: "real", nullable: true),
                    IsChemicalAsso = table.Column<bool>(type: "bit", nullable: false),
                    AdvInTaxDed = table.Column<float>(type: "real", nullable: true),
                    IsAdvInTaxDed = table.Column<bool>(type: "bit", nullable: false),
                    ConvAllowDed = table.Column<float>(type: "real", nullable: true),
                    IsConvAllowDed = table.Column<bool>(type: "bit", nullable: false),
                    DedIncBonusOf = table.Column<float>(type: "real", nullable: true),
                    IsDedIncBonusOf = table.Column<bool>(type: "bit", nullable: false),
                    UnionSubDed = table.Column<float>(type: "real", nullable: true),
                    IsUnionSubDed = table.Column<bool>(type: "bit", nullable: false),
                    EmpClubDed = table.Column<float>(type: "real", nullable: true),
                    IsEmpClubDed = table.Column<bool>(type: "bit", nullable: false),
                    MedicalExp = table.Column<float>(type: "real", nullable: true),
                    IsMedicalExp = table.Column<bool>(type: "bit", nullable: false),
                    WagesaAdv = table.Column<float>(type: "real", nullable: true),
                    IsWagesaAdv = table.Column<bool>(type: "bit", nullable: false),
                    MedicalLoanDed = table.Column<float>(type: "real", nullable: true),
                    IsMedicalLoanDed = table.Column<bool>(type: "bit", nullable: false),
                    AdvWagesDed = table.Column<float>(type: "real", nullable: true),
                    IsAdvWagesDed = table.Column<bool>(type: "bit", nullable: false),
                    WFL = table.Column<float>(type: "real", nullable: true),
                    IsWFL = table.Column<bool>(type: "bit", nullable: false),
                    CheForum = table.Column<float>(type: "real", nullable: true),
                    IsCheForum = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_GLId",
                        column: x => x.GLId,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_HBLId",
                        column: x => x.HBLId,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_HBLId2",
                        column: x => x.HBLId2,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_HBLId3",
                        column: x => x.HBLId3,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                        column: x => x.LId1,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_LId2",
                        column: x => x.LId2,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_LId3",
                        column: x => x.LId3,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_MCLId",
                        column: x => x.MCLId,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_PFLId",
                        column: x => x.PFLId,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_PFLLId",
                        column: x => x.PFLLId,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_PFLLId2",
                        column: x => x.PFLLId2,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_PFLLId3",
                        column: x => x.PFLLId3,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_WelfareLId",
                        column: x => x.WelfareLId,
                        principalTable: "Cat_Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Location_ComId",
                table: "Cat_Location",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Location_LuserId",
                table: "Cat_Location",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_BId",
                table: "HR_Emp_Salary",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_ComId",
                table: "HR_Emp_Salary",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_EmpId",
                table: "HR_Emp_Salary",
                column: "EmpId",
                unique: true,
                filter: "[EmpId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_GLId",
                table: "HR_Emp_Salary",
                column: "GLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_HBLId",
                table: "HR_Emp_Salary",
                column: "HBLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_HBLId2",
                table: "HR_Emp_Salary",
                column: "HBLId2");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_HBLId3",
                table: "HR_Emp_Salary",
                column: "HBLId3");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_LId1",
                table: "HR_Emp_Salary",
                column: "LId1");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_LId2",
                table: "HR_Emp_Salary",
                column: "LId2");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_LId3",
                table: "HR_Emp_Salary",
                column: "LId3");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_LuserId",
                table: "HR_Emp_Salary",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_MCLId",
                table: "HR_Emp_Salary",
                column: "MCLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLId",
                table: "HR_Emp_Salary",
                column: "PFLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLLId",
                table: "HR_Emp_Salary",
                column: "PFLLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLLId2",
                table: "HR_Emp_Salary",
                column: "PFLLId2");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLLId3",
                table: "HR_Emp_Salary",
                column: "PFLLId3");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_WelfareLId",
                table: "HR_Emp_Salary",
                column: "WelfareLId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_Salary");

            migrationBuilder.DropTable(
                name: "Cat_Location");
        }
    }
}
