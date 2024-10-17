using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class emloyeinfochanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyListId",
                table: "IntegrationSettingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "IntegrationSettingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "IntegrationSettingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationSettingDetails_CompanyListId",
                table: "IntegrationSettingDetails",
                column: "CompanyListId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationSettingDetails_LuserId",
                table: "IntegrationSettingDetails",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntegrationSettingDetails_Company_CompanyListId",
                table: "IntegrationSettingDetails",
                column: "CompanyListId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntegrationSettingDetails_UserAccount_LuserId",
                table: "IntegrationSettingDetails",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntegrationSettingDetails_Company_CompanyListId",
                table: "IntegrationSettingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IntegrationSettingDetails_UserAccount_LuserId",
                table: "IntegrationSettingDetails");

            migrationBuilder.DropIndex(
                name: "IX_IntegrationSettingDetails_CompanyListId",
                table: "IntegrationSettingDetails");

            migrationBuilder.DropIndex(
                name: "IX_IntegrationSettingDetails_LuserId",
                table: "IntegrationSettingDetails");

            migrationBuilder.DropColumn(
                name: "CompanyListId",
                table: "IntegrationSettingDetails");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "IntegrationSettingDetails");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "IntegrationSettingDetails");
        }
    }
}
