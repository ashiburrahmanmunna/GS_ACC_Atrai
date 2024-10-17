using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class userlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLink = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LongString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    WebBrowserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogingInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTransactionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLink = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TransactionStatement = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentReferance = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CommandType = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FromDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FlagValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransactionLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogingInfo");

            migrationBuilder.DropTable(
                name: "UserTransactionLog");
        }
    }
}
