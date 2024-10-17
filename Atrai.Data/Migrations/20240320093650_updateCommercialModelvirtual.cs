using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateCommercialModelvirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_UserAccount_UserAccountListId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_IntegrationSettingDetails_Company_CompanyListId",
                table: "IntegrationSettingDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyListId",
                table: "IntegrationSettingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountListId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_UserAccount_UserAccountListId",
                table: "HR_Emp_Increment",
                column: "UserAccountListId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntegrationSettingDetails_Company_CompanyListId",
                table: "IntegrationSettingDetails",
                column: "CompanyListId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_UserAccount_UserAccountListId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_IntegrationSettingDetails_Company_CompanyListId",
                table: "IntegrationSettingDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyListId",
                table: "IntegrationSettingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountListId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_UserAccount_UserAccountListId",
                table: "HR_Emp_Increment",
                column: "UserAccountListId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IntegrationSettingDetails_Company_CompanyListId",
                table: "IntegrationSettingDetails",
                column: "CompanyListId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
