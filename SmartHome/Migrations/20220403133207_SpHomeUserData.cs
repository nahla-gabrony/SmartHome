using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class SpHomeUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SpGetHomeUsers]
                      @UserId varchar(50)
                    AS
                    BEGIN
                        SELECT Id,FirstName ,UserImageURL FROM HomeUsers where Id =  @UserId ;
                    END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
