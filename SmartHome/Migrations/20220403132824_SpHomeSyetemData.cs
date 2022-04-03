using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class SpHomeSyetemData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SpGetHomeSystemData]
                AS
                BEGIN
                  WITH added_row_number AS (SELECT Id, SystemId, Status, ROW_NUMBER() OVER(PARTITION BY SystemId  ORDER BY Id DESC) AS row_number FROM Systems_Status)SELECT * FROM added_row_number WHERE row_number = 1;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
