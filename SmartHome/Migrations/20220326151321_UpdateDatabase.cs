using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Users_Types_UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DeviceDeviceStatus");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Jobs_Type");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Users_Types");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserTypeName",
                table: "Users_Types",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeUserId",
                table: "Users_Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Home_Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeUsers_Users_Types_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "Users_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Systems_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Systems_Status_Home_Systems_SystemId",
                        column: x => x.SystemId,
                        principalTable: "Home_Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Logs_HomeUserId",
                table: "Users_Logs",
                column: "HomeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Status_DeviceId",
                table: "Devices_Status",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeUsers_UserTypeId",
                table: "HomeUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_Status_SystemId",
                table: "Systems_Status",
                column: "SystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Status_Devices_DeviceId",
                table: "Devices_Status",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Logs_HomeUsers_HomeUserId",
                table: "Users_Logs",
                column: "HomeUserId",
                principalTable: "HomeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Status_Devices_DeviceId",
                table: "Devices_Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Logs_HomeUsers_HomeUserId",
                table: "Users_Logs");

            migrationBuilder.DropTable(
                name: "HomeUsers");

            migrationBuilder.DropTable(
                name: "Systems_Status");

            migrationBuilder.DropTable(
                name: "Home_Systems");

            migrationBuilder.DropIndex(
                name: "IX_Users_Logs_HomeUserId",
                table: "Users_Logs");

            migrationBuilder.DropIndex(
                name: "IX_Devices_Status_DeviceId",
                table: "Devices_Status");

            migrationBuilder.DropColumn(
                name: "UserTypeName",
                table: "Users_Types");

            migrationBuilder.DropColumn(
                name: "HomeUserId",
                table: "Users_Logs");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Users_Types",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeviceDeviceStatus",
                columns: table => new
                {
                    DevicesId = table.Column<int>(type: "int", nullable: false),
                    DevicesStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDeviceStatus", x => new { x.DevicesId, x.DevicesStatusId });
                    table.ForeignKey(
                        name: "FK_DeviceDeviceStatus_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDeviceStatus_Devices_Status_DevicesStatusId",
                        column: x => x.DevicesStatusId,
                        principalTable: "Devices_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_Type_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "Jobs_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDeviceStatus_DevicesStatusId",
                table: "DeviceDeviceStatus",
                column: "DevicesStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTypeId",
                table: "Employees",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Users_Types_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId",
                principalTable: "Users_Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
