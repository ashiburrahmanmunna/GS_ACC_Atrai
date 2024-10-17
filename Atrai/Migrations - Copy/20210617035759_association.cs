using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class association : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketNameEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketNameBng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floors = table.Column<int>(type: "int", nullable: true),
                    FirstFloor = table.Column<int>(type: "int", nullable: true),
                    SecoundFloor = table.Column<int>(type: "int", nullable: true),
                    ThirdFloor = table.Column<int>(type: "int", nullable: true),
                    FourthFloor = table.Column<int>(type: "int", nullable: true),
                    FifthFloor = table.Column<int>(type: "int", nullable: true),
                    TotalShop = table.Column<int>(type: "int", nullable: true),
                    ClosedShop = table.Column<int>(type: "int", nullable: true),
                    ActiveMember = table.Column<int>(type: "int", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresidentImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PresidentImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresidentFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretaryImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SecretaryImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretaryFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberStatusLong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MemberStatusShort = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketId = table.Column<int>(type: "int", nullable: true),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopWebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ShopImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberAccessId = table.Column<int>(type: "int", nullable: false),
                    MembersNameEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembersNameBng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersNameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersNameBng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopNameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopNameBng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixedAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberHomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    MemberImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MemberImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerShipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposerMemberNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupporterMemberNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketId = table.Column<int>(type: "int", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    MemberStatusId = table.Column<int>(type: "int", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    isRecommended = table.Column<bool>(type: "bit", nullable: false),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_MemberStatus_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "MemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_MarketId",
                table: "Member",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_MemberStatusId",
                table: "Member",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ShopId",
                table: "Member",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_MarketId",
                table: "Shop",
                column: "MarketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "MemberStatus");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Market");
        }
    }
}
