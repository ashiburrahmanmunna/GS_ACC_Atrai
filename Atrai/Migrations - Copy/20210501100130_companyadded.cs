using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class companyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecoundaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    comEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    comWeb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ContPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContDesig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
