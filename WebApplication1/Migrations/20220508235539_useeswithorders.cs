using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    public partial class useeswithorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                 CREATE VIEW View_UsersWithorder AS
             SELECT [OrderHeaders]. [Id]
      ,[OrderHeaders].[FirstName]
      ,[OrderHeaders].[LastName]
      ,[OrderDateTime]
      ,[OrderHeaders].[PhoneNumber]
      ,[OrderHeaders].[Address]
      ,[Note]
      ,[BillingAddress]
      ,p.Method,C.Name As CouponName,C.Percentage ,C.ValidFrom,C.ValidTo
  FROM [EcommerceM].[dbo].[OrderHeaders]
  inner join AspNetUsers ANU on ANU.Id= [OrderHeaders].ApplicationUserId
  inner join OrderDetials OD on Od.OrderHeaderId=[OrderHeaders].Id 
  inner join Payments P on P.Id=OD.PaymentId
  inner join Coupons C on C.Id=OD.CouponId";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW View_UsersWithorder");

        }
    }
}
