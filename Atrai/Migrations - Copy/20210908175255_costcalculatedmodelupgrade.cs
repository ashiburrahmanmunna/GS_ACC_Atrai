using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class costcalculatedmodelupgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Damage_DamageModelId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "DamageModelId",
                table: "CostCalculated",
                newName: "DamageId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_DamageModelId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_DamageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Damage_DamageId",
                table: "CostCalculated",
                column: "DamageId",
                principalTable: "Damage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Damage_DamageId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "DamageId",
                table: "CostCalculated",
                newName: "DamageModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_DamageId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_DamageModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Damage_DamageModelId",
                table: "CostCalculated",
                column: "DamageModelId",
                principalTable: "Damage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
