using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMasterLCModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommercialTypeId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_CommercialTypeId",
                table: "MasterLC",
                column: "CommercialTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_CommercialType_CommercialTypeId",
                table: "MasterLC",
                column: "CommercialTypeId",
                principalTable: "CommercialType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_CommercialType_CommercialTypeId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_CommercialTypeId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "CommercialTypeId",
                table: "MasterLC");
        }
    }
}
