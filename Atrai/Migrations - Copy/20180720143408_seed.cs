using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (ConfirmPassword,CreateDate, Email,IsDelete,Password, UpdateDate) VALUES ('12345', '02-03-2018', 'admin@Dominatebd.com', 'false', '12345', '02-03-2018')");
            migrationBuilder.Sql("INSERT INTO Customer (Name,Email,Phone, CreateDate, UpdateDate,IsDelete) VALUES ('Walk in Customer', 'customer@gmail.com', '0000000000', '02-03-2018','02-03-2018', 'false')");
            migrationBuilder.Sql("INSERT INTO StoreSetting (Logo,StoreName,Email, Phone, Currency, Address, CreateDate,UpdateDate,IsDelete, web) VALUES ('wwwroot/images/k_logo.png', 'Dominatebd','admin@Dominatebd.com', '0000000000', '$', 'Dhaka, Bangladesh', '02-03-2018','02-03-2018', 'false', 'www.Dominatebd.com')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
