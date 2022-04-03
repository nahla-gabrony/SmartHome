using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class spUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SpGetUsers]
                AS
                BEGIN
                   WITH added_row_number AS (SELECT Id, Status, HomeUserId, ROW_NUMBER() OVER(PARTITION BY HomeUserId  ORDER BY Id DESC) AS row_number FROM Users_Logs) SELECT * FROM added_row_number WHERE row_number = 1 and Status = 1;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
