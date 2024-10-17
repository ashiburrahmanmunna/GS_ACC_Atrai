using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class reportstylevariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "RewardPointValue",
            //    table: "Sales",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "PaymentTypeId",
            //    table: "AccountsDailyTransaction",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Feedback",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FeedbackForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Rating = table.Column<int>(type: "int", nullable: false),
            //        Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsDelete = table.Column<bool>(type: "bit", nullable: false),
            //        ComId = table.Column<int>(type: "int", nullable: false),
            //        LuserId = table.Column<int>(type: "int", nullable: false),
            //        LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Feedback", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Feedback_Company_ComId",
            //            column: x => x.ComId,
            //            principalTable: "Company",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Feedback_UserAccount_LuserId",
            //            column: x => x.LuserId,
            //            principalTable: "UserAccount",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AccountsDailyTransaction_PaymentTypeId",
            //    table: "AccountsDailyTransaction",
            //    column: "PaymentTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Feedback_ComId",
            //    table: "Feedback",
            //    column: "ComId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Feedback_LuserId",
            //    table: "Feedback",
            //    column: "LuserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AccountsDailyTransaction_PaymentType_PaymentTypeId",
            //    table: "AccountsDailyTransaction",
            //    column: "PaymentTypeId",
            //    principalTable: "PaymentType",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_PaymentType_PaymentTypeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_PaymentTypeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "RewardPointValue",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "AccountsDailyTransaction");
        }
    }
}
