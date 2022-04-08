using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class SpHomeDevicesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SpGetHomeDevicesData]
                AS
                BEGIN
                 WITH added_row_number AS (SELECT Id, DeviceId, Status, ROW_NUMBER() OVER(PARTITION BY DeviceId  ORDER BY Id DESC) AS row_number FROM Devices_Status) SELECT * FROM added_row_number WHERE row_number = 1;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
