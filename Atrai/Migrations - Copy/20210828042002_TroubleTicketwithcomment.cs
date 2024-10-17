using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class TroubleTicketwithcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.CreateTable(
                name: "ActivationTicket",
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
                    table.PrimaryKey("PK_ActivationTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivationTicket_InternetPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "InternetPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TroubleTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    InternetComplainId = table.Column<int>(type: "int", nullable: true),
                    DiagonosisBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DiagnosisReportId = table.Column<int>(type: "int", nullable: true),
                    SupportBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroubleTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TroubleTicket_DiagnosisReport_DiagnosisReportId",
                        column: x => x.DiagnosisReportId,
                        principalTable: "DiagnosisReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TroubleTicket_InternetComplain_InternetComplainId",
                        column: x => x.InternetComplainId,
                        principalTable: "InternetComplain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TroubleTicket_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TroubleTicketComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TroubleTicketModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroubleTicketComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TroubleTicketComment_TroubleTicket_TroubleTicketModelId",
                        column: x => x.TroubleTicketModelId,
                        principalTable: "TroubleTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivationTicket_PackageId",
                table: "ActivationTicket",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicket_DiagnosisReportId",
                table: "TroubleTicket",
                column: "DiagnosisReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicket_InternetComplainId",
                table: "TroubleTicket",
                column: "InternetComplainId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicket_InternetUserId",
                table: "TroubleTicket",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicketComment_TroubleTicketModelId",
                table: "TroubleTicketComment",
                column: "TroubleTicketModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationTicket");

            migrationBuilder.DropTable(
                name: "TroubleTicketComment");

            migrationBuilder.DropTable(
                name: "TroubleTicket");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activatedby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AreaZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FusionTeamAssaign = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    MRC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ONUFrom = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    OTC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PromiseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROUTERFrom = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ReferanceBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PackageId",
                table: "Ticket",
                column: "PackageId");
        }
    }
}
