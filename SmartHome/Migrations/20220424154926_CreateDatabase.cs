using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Devices_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Status_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHome_Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HomeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHome_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHome_Logs_HomeUsers_HomeUserId",
                        column: x => x.HomeUserId,
                        principalTable: "HomeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { 1, "Main Systems" },
                    { 2, "Bedroom 1" },
                    { 3, "Bedroom 2" },
                    { 4, "Leaving Room" },
                    { 5, "Dining Room" },
                    { 6, "Storage Room" },
                    { 7, "Office Room" },
                    { 8, "Garage" },
                    { 9, "Garden" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "RoomId" },
                values: new object[,]
                {
                    { 1, "Home Security", 1 },
                    { 22, "AC", 5 },
                    { 23, "Sound", 5 },
                    { 24, "Light", 5 },
                    { 25, "Light", 6 },
                    { 26, "Door", 6 },
                    { 27, "TV", 7 },
                    { 28, "AC", 7 },
                    { 29, "Sound", 7 },
                    { 30, "Light", 7 },
                    { 31, "Door", 7 },
                    { 32, "Garage Security", 8 },
                    { 33, "Garage Door", 8 },
                    { 34, "Left Parking", 8 },
                    { 35, "Right Parking", 8 },
                    { 36, "Garage Light", 8 },
                    { 21, "Light", 4 },
                    { 20, "Sound", 4 },
                    { 19, "AC", 4 },
                    { 18, "TV", 4 },
                    { 2, "Open Door", 1 },
                    { 3, "Fire System", 1 },
                    { 4, "Smoke System", 1 },
                    { 5, "Outdoor Light", 1 },
                    { 6, "Temperature", 1 },
                    { 7, "Humidity", 1 },
                    { 8, "TV", 2 },
                    { 37, "Water Tank", 9 },
                    { 9, "AC", 2 },
                    { 11, "Light", 2 },
                    { 12, "Door", 2 },
                    { 13, "TV", 3 },
                    { 14, "AC", 3 },
                    { 15, "Sound", 3 },
                    { 16, "Light", 3 },
                    { 17, "Door", 3 },
                    { 10, "Sound", 2 },
                    { 38, "Irrigation System", 9 }
                });

            migrationBuilder.InsertData(
                table: "Devices_Status",
                columns: new[] { "Id", "DeviceId", "ModifyDateTime", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 22, 22, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 23, 23, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 24, 24, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 25, 25, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 26, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 27, 27, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 28, 28, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 29, 29, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 30, 30, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 31, 31, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 32, 32, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 33, 33, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 34, 34, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 35, 35, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 36, 36, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 21, 21, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 20, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 19, 19, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 18, 18, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 2, 2, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 3, 3, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 4, 4, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 5, 5, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 6, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 31 },
                    { 7, 7, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 10 },
                    { 8, 8, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 37, 37, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 50 },
                    { 9, 9, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 11, 11, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 12, 12, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 13, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 14, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 15, 15, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 16, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 17, 17, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 10, 10, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 38, 38, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 90 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RoomId",
                table: "Devices",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Status_DeviceId",
                table: "Devices_Status",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeUsers_UserTypeId",
                table: "HomeUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHome_Logs_HomeUserId",
                table: "UserHome_Logs",
                column: "HomeUserId");


            // stored procedure
            var SpUsersData = @"CREATE PROCEDURE [dbo].[SpGetUsersData]
                AS
                BEGIN
                   WITH added_row_number AS (SELECT Id, Status, HomeUserId, ROW_NUMBER() OVER(PARTITION BY HomeUserId  ORDER BY Id DESC) AS row_number FROM UserHome_Logs) SELECT * FROM added_row_number WHERE row_number = 1 and Status = 1;
                END";

            migrationBuilder.Sql(SpUsersData);


            var SpDevicesData = @"CREATE PROCEDURE [dbo].[SpGetHomeDevicesData]
                AS
                BEGIN
                 WITH added_row_number AS (SELECT Id, DeviceId, Status, ROW_NUMBER() OVER(PARTITION BY DeviceId  ORDER BY Id DESC) AS row_number FROM Devices_Status) SELECT * FROM added_row_number WHERE row_number = 1;
                END";

            migrationBuilder.Sql(SpDevicesData);


            var SpHomeUsers = @"CREATE PROCEDURE [dbo].[SpGetHomeUsers]
                      @UserId varchar(50)
                    AS
                    BEGIN
                        SELECT Id,FirstName ,UserImageURL FROM HomeUsers where Id =  @UserId ;
                    END";

            migrationBuilder.Sql(SpHomeUsers);

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Devices_Status");

            migrationBuilder.DropTable(
                name: "UserHome_Logs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "HomeUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users_Types");
        }
    }
}
