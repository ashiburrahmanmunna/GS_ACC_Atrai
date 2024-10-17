using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateMasterLCModelRemovingIsTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTransaction",
                table: "COM_MasterLC_Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTransaction",
                table: "COM_MasterLC_Details",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
