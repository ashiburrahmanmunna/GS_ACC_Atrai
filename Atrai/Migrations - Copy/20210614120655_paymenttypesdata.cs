using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class paymenttypesdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('=N/A=','=N/A=' , getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('CASH','CASH', getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('BANK','BANK', getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('CT','CT', getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('BKASH','BKASH', getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('TT','TT', getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('LC','LC', getdate(), getdate(),0,1,1)");

            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('INTER PROJECT','INTER PROJECT', getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('PRICE ADJUSTMENT','PRICE ADJUSTMENT', getdate(), getdate(),0,1,1)");
            migrationBuilder.Sql("INSERT INTO PaymentType(TypeName , TypeShortName , CreateDate , UpdateDate , isDelete , ComId , LuserId) Values('OTHER','OTHER', getdate(), getdate(),0,1,1)");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
