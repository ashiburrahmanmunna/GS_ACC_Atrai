using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class acc_vouchermain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_FiscalHalfYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HyearName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HyearNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aid = table.Column<int>(type: "int", nullable: false),
                    FYId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalHalfYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalHalfYear_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalHalfYear_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_FiscalMonth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningdtFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingdtTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FYId = table.Column<int>(type: "int", nullable: false),
                    HYearId = table.Column<int>(type: "int", nullable: false),
                    QtrId = table.Column<int>(type: "int", nullable: false),
                    isLocked = table.Column<bool>(type: "bit", nullable: false),
                    isLockedStore = table.Column<bool>(type: "bit", nullable: false),
                    isLockedAccounts = table.Column<bool>(type: "bit", nullable: false),
                    isLockedAttendance = table.Column<bool>(type: "bit", nullable: false),
                    isLockedSalary = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalMonth_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalMonth_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_FiscalQtr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtrNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aid = table.Column<int>(type: "int", nullable: false),
                    FYId = table.Column<int>(type: "int", nullable: false),
                    HYearId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalQtr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalQtr_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalQtr_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_FiscalYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FYName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FYNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isWorking = table.Column<bool>(type: "bit", nullable: false),
                    isRunning = table.Column<bool>(type: "bit", nullable: false),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    isLocked = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalYear_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalYear_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherNoCreatedType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNoCreatedTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherNoCreatedTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherNoCreatedType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherTypeNameShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherTypeClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherTypeButtonClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DeptBangla = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Slno = table.Column<short>(type: "smallint", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Department_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_Department_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrdUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PrdUnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrdUnitShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    isPrdUnit = table.Column<bool>(type: "bit", nullable: false),
                    PrdUnitBanglaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrdUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrdUnit_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrdUnit_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherTranGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTranGroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherTranGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherNoPrefix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTypeId = table.Column<int>(type: "int", nullable: false),
                    VoucherShortPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: false),
                    isVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherNoPrefix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherNoPrefix_Acc_VoucherType_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "Acc_VoucherType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SectNameB = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    Slno = table.Column<int>(type: "int", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Section_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_Section_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_Section_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSerialId = table.Column<int>(type: "int", nullable: false),
                    YearlyVoucherTypeWiseSerial = table.Column<int>(type: "int", nullable: true),
                    VoucherNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoucherInputDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrdUnitId = table.Column<int>(type: "int", nullable: true),
                    VoucherDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuserIdCheck = table.Column<int>(type: "int", nullable: true),
                    LuserIdApprove = table.Column<int>(type: "int", nullable: true),
                    isAutoEntry = table.Column<bool>(type: "bit", nullable: false),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    VAmount = table.Column<double>(type: "float", nullable: false),
                    vAmountInWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    ConvRate = table.Column<double>(type: "float", nullable: false),
                    vAmountLocal = table.Column<double>(type: "float", nullable: false),
                    Referance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferanceTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferanceThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCash = table.Column<bool>(type: "bit", nullable: false),
                    VoucherTypeId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryIdLocal = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: true),
                    VoucherTranGroupList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherTranGroupId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherMain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_Acc_FiscalMonth_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_Acc_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_Acc_VoucherType_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "Acc_VoucherType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_Country_CountryIdLocal",
                        column: x => x.CountryIdLocal,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_PrdUnit_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_VoucherTranGroup_VoucherTranGroupId",
                        column: x => x.VoucherTranGroupId,
                        principalTable: "VoucherTranGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cat_SubSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSectName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SubSectNameB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    Slno = table.Column<short>(type: "smallint", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_SubSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_SubSection_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_SubSection_Cat_Section_SectId",
                        column: x => x.SectId,
                        principalTable: "Cat_Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_SubSection_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_SubSection_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    SRowNo = table.Column<int>(type: "int", nullable: false),
                    ccId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyForeignId = table.Column<int>(type: "int", nullable: false),
                    TKDebit = table.Column<double>(type: "float", nullable: false),
                    TKCredit = table.Column<double>(type: "float", nullable: false),
                    TKDebitLocal = table.Column<double>(type: "float", nullable: false),
                    TKCreditLocal = table.Column<double>(type: "float", nullable: false),
                    CurrencyRate = table.Column<double>(type: "float", nullable: false),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    SLNo = table.Column<int>(type: "int", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    VoucherTranGroupIdRow = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_Acc_VoucherMain_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Acc_VoucherMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_Country_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_Country_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_VoucherTranGroup_VoucherTranGroupIdRow",
                        column: x => x.VoucherTranGroupIdRow,
                        principalTable: "VoucherTranGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherTranGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTranGroupId = table.Column<int>(type: "int", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherTranGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTranGroup_Acc_VoucherMain_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Acc_VoucherMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTranGroup_VoucherTranGroup_VoucherTranGroupId",
                        column: x => x.VoucherTranGroupId,
                        principalTable: "VoucherTranGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSubCheckno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowNoChk = table.Column<int>(type: "int", nullable: false),
                    SRowNo = table.Column<int>(type: "int", nullable: true),
                    ChkNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtChk = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtChkTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isClear = table.Column<bool>(type: "bit", nullable: false),
                    dtChkClear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    VoucherSubId = table.Column<int>(type: "int", nullable: true),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    LuserIdCheck = table.Column<int>(type: "int", nullable: true),
                    LuserIdApprove = table.Column<int>(type: "int", nullable: true),
                    isManualEntry = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSubCheckno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubCheckno_Acc_VoucherSub_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "Acc_VoucherSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubCheckno_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSubSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSubId = table.Column<int>(type: "int", nullable: false),
                    RowNoSSec = table.Column<int>(type: "int", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    SRowNo = table.Column<int>(type: "int", nullable: false),
                    SubSectId = table.Column<int>(type: "int", nullable: false),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SubSectionId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSubSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubSection_Acc_VoucherSub_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "Acc_VoucherSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubSection_Cat_SubSection_SubSectionId",
                        column: x => x.SubSectionId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalHalfYear_ComId",
                table: "Acc_FiscalHalfYear",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalHalfYear_LuserId",
                table: "Acc_FiscalHalfYear",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalMonth_ComId",
                table: "Acc_FiscalMonth",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalMonth_LuserId",
                table: "Acc_FiscalMonth",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalQtr_ComId",
                table: "Acc_FiscalQtr",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalQtr_LuserId",
                table: "Acc_FiscalQtr",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalYear_ComId",
                table: "Acc_FiscalYear",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalYear_LuserId",
                table: "Acc_FiscalYear",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_ComId",
                table: "Acc_VoucherMain",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_CountryId",
                table: "Acc_VoucherMain",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_CountryIdLocal",
                table: "Acc_VoucherMain",
                column: "CountryIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_FiscalMonthId",
                table: "Acc_VoucherMain",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_FiscalYearId",
                table: "Acc_VoucherMain",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_LuserId",
                table: "Acc_VoucherMain",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PrdUnitId",
                table: "Acc_VoucherMain",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_VoucherTranGroupId",
                table: "Acc_VoucherMain",
                column: "VoucherTranGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_VoucherTypeId",
                table: "Acc_VoucherMain",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherNoPrefix_VoucherTypeId",
                table: "Acc_VoucherNoPrefix",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_AccId",
                table: "Acc_VoucherSub",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_ComId",
                table: "Acc_VoucherSub",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_CurrencyForeignId",
                table: "Acc_VoucherSub",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_CurrencyId",
                table: "Acc_VoucherSub",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_CustomerId",
                table: "Acc_VoucherSub",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_EmpId",
                table: "Acc_VoucherSub",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_LuserId",
                table: "Acc_VoucherSub",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_SupplierId",
                table: "Acc_VoucherSub",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_VoucherId",
                table: "Acc_VoucherSub",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_VoucherTranGroupIdRow",
                table: "Acc_VoucherSub",
                column: "VoucherTranGroupIdRow");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubCheckno_AccId",
                table: "Acc_VoucherSubCheckno",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubCheckno_VoucherSubId",
                table: "Acc_VoucherSubCheckno",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSection_SubSectionId",
                table: "Acc_VoucherSubSection",
                column: "SubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSection_VoucherSubId",
                table: "Acc_VoucherSubSection",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTranGroup_VoucherId",
                table: "Acc_VoucherTranGroup",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTranGroup_VoucherTranGroupId",
                table: "Acc_VoucherTranGroup",
                column: "VoucherTranGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Department_ComId",
                table: "Cat_Department",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Department_LuserId",
                table: "Cat_Department",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Section_ComId",
                table: "Cat_Section",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Section_DeptId",
                table: "Cat_Section",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Section_LuserId",
                table: "Cat_Section",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SubSection_ComId",
                table: "Cat_SubSection",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SubSection_DeptId",
                table: "Cat_SubSection",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SubSection_LuserId",
                table: "Cat_SubSection",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SubSection_SectId",
                table: "Cat_SubSection",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_PrdUnit_ComId",
                table: "PrdUnit",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PrdUnit_LuserId",
                table: "PrdUnit",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_FiscalHalfYear");

            migrationBuilder.DropTable(
                name: "Acc_FiscalQtr");

            migrationBuilder.DropTable(
                name: "Acc_VoucherNoCreatedType");

            migrationBuilder.DropTable(
                name: "Acc_VoucherNoPrefix");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSubCheckno");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSubSection");

            migrationBuilder.DropTable(
                name: "Acc_VoucherTranGroup");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSub");

            migrationBuilder.DropTable(
                name: "Cat_SubSection");

            migrationBuilder.DropTable(
                name: "Acc_VoucherMain");

            migrationBuilder.DropTable(
                name: "Cat_Section");

            migrationBuilder.DropTable(
                name: "Acc_FiscalMonth");

            migrationBuilder.DropTable(
                name: "Acc_FiscalYear");

            migrationBuilder.DropTable(
                name: "Acc_VoucherType");

            migrationBuilder.DropTable(
                name: "PrdUnit");

            migrationBuilder.DropTable(
                name: "VoucherTranGroup");

            migrationBuilder.DropTable(
                name: "Cat_Department");
        }
    }
}
