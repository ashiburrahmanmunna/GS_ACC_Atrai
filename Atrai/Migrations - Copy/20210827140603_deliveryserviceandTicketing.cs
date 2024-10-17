using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class deliveryserviceandTicketing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryServiceDistance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DistanceDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FigureForCalculation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryServiceDistance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryServiceTiming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimingName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TimingDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FigureForCalculation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryServiceTiming", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryServiceWeight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WeightDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FigureForCalculation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryServiceWeight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternetComplain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetComplain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AreaZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PromiseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MRC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ONUFrom = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ROUTERFrom = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ReferanceBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FusionTeamAssaign = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Activatedby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_InternetPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "InternetPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PickupPoint = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    WeightId = table.Column<int>(type: "int", nullable: true),
                    DistanceId = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    DeliveryClientPhoneNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeliveryClientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeliveryClientAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PreferableDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryTimingId = table.Column<int>(type: "int", nullable: true),
                    BilledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillAmount = table.Column<float>(type: "real", nullable: false),
                    ReceivedAmount = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    isPost = table.Column<bool>(type: "bit", nullable: false),
                    isSystem = table.Column<bool>(type: "bit", nullable: false),
                    InWords = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryService_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryService_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryService_DeliveryServiceDistance_DistanceId",
                        column: x => x.DistanceId,
                        principalTable: "DeliveryServiceDistance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryService_DeliveryServiceTiming_DeliveryTimingId",
                        column: x => x.DeliveryTimingId,
                        principalTable: "DeliveryServiceTiming",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryService_DeliveryServiceWeight_WeightId",
                        column: x => x.WeightId,
                        principalTable: "DeliveryServiceWeight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryService_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_CategoryId",
                table: "DeliveryService",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_ComId_BillNo",
                table: "DeliveryService",
                columns: new[] { "ComId", "BillNo" },
                unique: true,
                filter: "[BillNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_CustomerId",
                table: "DeliveryService",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_DeliveryTimingId",
                table: "DeliveryService",
                column: "DeliveryTimingId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_DistanceId",
                table: "DeliveryService",
                column: "DistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_PaymentTypeId",
                table: "DeliveryService",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_WeightId",
                table: "DeliveryService",
                column: "WeightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PackageId",
                table: "Ticket",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryService");

            migrationBuilder.DropTable(
                name: "DiagnosisReport");

            migrationBuilder.DropTable(
                name: "InternetComplain");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "DeliveryServiceDistance");

            migrationBuilder.DropTable(
                name: "DeliveryServiceTiming");

            migrationBuilder.DropTable(
                name: "DeliveryServiceWeight");
        }
    }
}
