using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class ModifyDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Logs_AspNetUsers_UserId",
                table: "Users_Logs");

            migrationBuilder.DropIndex(
                name: "IX_Users_Logs_UserId",
                table: "Users_Logs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users_Logs");

            migrationBuilder.AlterColumn<string>(
                name: "UserTypeName",
                table: "Users_Types",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserTypeName",
                table: "Users_Types",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Users_Logs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Logs_UserId",
                table: "Users_Logs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Logs_AspNetUsers_UserId",
                table: "Users_Logs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
