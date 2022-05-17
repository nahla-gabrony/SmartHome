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
                    UserImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeUsers", x => x.Id);
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
                name: "HomeUser_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HomeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeUser_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeUser_Status_HomeUsers_HomeUserId",
                        column: x => x.HomeUserId,
                        principalTable: "HomeUsers",
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
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04ff9086-8225-424a-8620-ef1a58ae853c", "83e57d03-6311-4247-acbf-7339051fed15", "Dashboard Admin", "DASHBOARD ADMIN" },
                    { "60f49c54-5108-4bc1-963c-2534383a8401", "02150d6d-25c1-42ee-831b-f14c9407bc11", "Control Users", "CONTROL USERS" },
                    { "e3108378-4aa3-4bd0-87f7-854c67b723ec", "f5107123-ba80-4c6f-b83a-45b8e054cd26", "Main Systems", "MAIN SYSTEMS" },
                    { "2a602357-9e35-4ed2-bfbc-3b0f5e12711f", "f7f96646-7fd2-43be-9303-e6dc5e3bbabf", "Bedroom One", "BEDROOM ONE" },
                    { "864bf846-c768-490c-93be-e1fcdd4170dd", "0a16edc0-69ac-4468-bdaa-85be632b5d1c", "Bedroom Two", "BEDROOM TWO" },
                    { "133543c4-a29b-451a-b523-73e01dc6eabf", "50be69ca-f7b8-4664-9160-0e0e976e5c54", "Bedroom Three", "BEDROOM THREE" },
                    { "7c86824a-0b7c-48a6-894e-646c67fe8af3", "9c2fc070-0ca5-436f-b74d-99d83fcc4154", "Living Room", "LIVING ROOM" },
                    { "c7d70bff-ad21-4875-adc2-cb48eed8f9b2", "cb71a660-136c-4e67-ad0c-6ca9db65b45a", "Dining Room", "DINING ROOM" },
                    { "9edf75c5-f2cd-401e-8137-de7cd73f0348", "5f453357-7dcd-4449-86b7-24a5f6a01121", "Storage Room", "STORAGE ROOM" },
                    { "02f51724-f598-4c82-8735-79c890c60f2a", "c2410240-662c-4146-a96f-2c753379cbca", "Office Room", "OFFICE ROOM" },
                    { "2c824d27-18b2-4e5d-8d74-ae82ff7615ca", "91ba3e9d-eb9d-4c80-9c14-253cd1f8c088", "Garage", "GARAGE" },
                    { "5c3734dc-ec07-40ae-8da1-d0d134bd1cf5", "7f22cca4-0246-4886-a775-d67392f59654", "Garden", "GARDEN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[,]
                {
                    { "984c0481-ae7e-4845-96d1-8da01f96f878", 0, "91cf969e-2358-48cb-a227-da7e2a86cb54", "mai_ali@gmail.com", true, "Mai", "Ali", false, null, "MAI_ALI@GMAIL.COM", "MAI_ALI@GMAIL.COM", "AQAAAAEAACcQAAAAEGgvDb8jSB93ClOHHQ+nC4l4Vc7kdeKs643TiqilX/2yTWYpvv3C+zJaqMFjGFzx2Q==", "01068289043", false, "f640f386-03b0-4ce1-bb54-4f68b09f6a99", false, "../images/profile/4.png", "mai_ali@gmail.com" },
                    { "4878fbf1-18ae-4b64-a34b-c60c0d825a9c", 0, "a0f0083e-6fb7-448a-8f65-9a60cb5b536d", "mohamed_ali@gmail.com", true, "Mohamed", "Ali", false, null, "MOHAMED_ALI@GMAIL.COM", "MOHAMED_ALI@GMAIL.COM", "AQAAAAEAACcQAAAAEFgVcFn3tdPSOO38kukRnUK0qLaYzh93Dyl8EJ9CCUzXuMwu+VjwpjS4I3YMyJuj2Q==", "01068289043", false, "487f00d6-2009-43ad-91ce-7e8df8ac9d4e", false, "../images/profile/3.png", "mohamed_ali@gmail.com" },
                    { "a47e6b88-2629-4d08-b4e3-f44aa61b455d", 0, "d4b12f6e-4348-41cc-a653-4a84c3114485", "ahmed_ibrahim@yahoo.com", true, "Ahmed", "Ibrahim", false, null, "AHMED_IBRAHIM@YAHOO.COM", "AHMED_IBRAHIM@YAHOO.COM", "AQAAAAEAACcQAAAAEFaA5ZLU4o1i+BuslzenuRFHtCn4fdCAMZ41yYPBewwup3fvCgwi7TTgzAppJSzT8w==", "01068289043", false, "0231fbaa-70d9-4d7a-b349-085e0fb40260", false, "../images/profile/5.png", "ahmed_ibrahim@yahoo.com" },
                    { "84a7cf74-1232-41cb-af9c-952593cd7089", 0, "90d625e3-e70e-4b3c-b9eb-7a03e83f2aaf", "ali_ahmed@gmail.com", true, "Ali", "Ahmed", false, null, "ALI_AHMED@GMAIL.COM", "ALI_AHMED@GMAIL.COM", "AQAAAAEAACcQAAAAEJgHQKa8ILz/d4c2h9F0eBq1RCC6N/0q5FaMoWOsc/txaY64AhhH5y0yhdL5xphIJg==", "01017080058", false, "f3935b08-af74-4712-985b-c9c10166bee7", false, "../images/profile/1.png", "Ali_Ahmed@gmail.com" },
                    { "117368c9-da90-417b-815a-55a3891c9672", 0, "c4cc5eec-38b5-464d-9a18-3479b40c5b21", "mona_mohamed@yahoo.com", true, "Mona", "Mohamed", false, null, "MONA_MOHAMED@YAHOO.COM", "MONA_MOHAMED@YAHOO.COM", "AQAAAAEAACcQAAAAEJJTCsMOPRgi8Zj+SKy1Cir3boKi0aoB8oWJaT5mQy9z/KWLgtZpc7dMXmF2zvphxg==", "01017180069", false, "1fe3e1d7-c86e-4fe9-a383-6221f901fc19", false, "../images/profile/2.png", "mona_mohamed@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "HomeUsers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber", "UserImageURL" },
                values: new object[,]
                {
                    { 1, "In Home", "ali_ahmed@gmail.com", "Ali", "Ahmed", "01017080058", "../images/profile/1.png" },
                    { 2, "In Home", "mona_mohamed@yahoo.com", "Mona", "Mohamed", "01017180069", "../images/profile/2.png" },
                    { 3, "In Home", "mohamed_ali@gmail.com", "Mohamed", "Ali", "01017189052", "../images/profile/3.png" },
                    { 4, "In Home", "mai_ali@gmail.com", "Mai", "Ali", "01069189080", "../images/profile/4.png" },
                    { 5, "In Home", "ahmed_ibrahim@yahoo.com", "Ahmed", "Ibrahim", "01068289043", "../images/profile/5.png" },
                    { 6, "90 Ain-shams - Cairo,Egypt", "marwa_saad@gmail.com", "Marwa", "Saad", "01268468933", "../images/profile/6.png" },
                    { 7, "50 Ain-shams - Cairo,Egypt", "mona_Kamel@gmail.com", "Nada", "Helmy", "01168237594", "../images/profile/7.png" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { 8, "Office Room" },
                    { 7, "Storage Room" },
                    { 6, "Dining Room" },
                    { 5, "Leaving Room" },
                    { 1, "Main Systems" },
                    { 3, "Bedroom 2" },
                    { 2, "Bedroom 1" },
                    { 9, "Garage" },
                    { 4, "Bedroom 3" },
                    { 10, "Garden" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "04ff9086-8225-424a-8620-ef1a58ae853c", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "c7d70bff-ad21-4875-adc2-cb48eed8f9b2", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "9edf75c5-f2cd-401e-8137-de7cd73f0348", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "2c824d27-18b2-4e5d-8d74-ae82ff7615ca", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "5c3734dc-ec07-40ae-8da1-d0d134bd1cf5", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "e3108378-4aa3-4bd0-87f7-854c67b723ec", "4878fbf1-18ae-4b64-a34b-c60c0d825a9c" },
                    { "864bf846-c768-490c-93be-e1fcdd4170dd", "4878fbf1-18ae-4b64-a34b-c60c0d825a9c" },
                    { "7c86824a-0b7c-48a6-894e-646c67fe8af3", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "c7d70bff-ad21-4875-adc2-cb48eed8f9b2", "4878fbf1-18ae-4b64-a34b-c60c0d825a9c" },
                    { "864bf846-c768-490c-93be-e1fcdd4170dd", "984c0481-ae7e-4845-96d1-8da01f96f878" },
                    { "e3108378-4aa3-4bd0-87f7-854c67b723ec", "a47e6b88-2629-4d08-b4e3-f44aa61b455d" },
                    { "133543c4-a29b-451a-b523-73e01dc6eabf", "a47e6b88-2629-4d08-b4e3-f44aa61b455d" },
                    { "c7d70bff-ad21-4875-adc2-cb48eed8f9b2", "a47e6b88-2629-4d08-b4e3-f44aa61b455d" },
                    { "2c824d27-18b2-4e5d-8d74-ae82ff7615ca", "a47e6b88-2629-4d08-b4e3-f44aa61b455d" },
                    { "5c3734dc-ec07-40ae-8da1-d0d134bd1cf5", "a47e6b88-2629-4d08-b4e3-f44aa61b455d" },
                    { "e3108378-4aa3-4bd0-87f7-854c67b723ec", "984c0481-ae7e-4845-96d1-8da01f96f878" },
                    { "133543c4-a29b-451a-b523-73e01dc6eabf", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "c7d70bff-ad21-4875-adc2-cb48eed8f9b2", "984c0481-ae7e-4845-96d1-8da01f96f878" },
                    { "2a602357-9e35-4ed2-bfbc-3b0f5e12711f", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "864bf846-c768-490c-93be-e1fcdd4170dd", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "60f49c54-5108-4bc1-963c-2534383a8401", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "e3108378-4aa3-4bd0-87f7-854c67b723ec", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "864bf846-c768-490c-93be-e1fcdd4170dd", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "133543c4-a29b-451a-b523-73e01dc6eabf", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "7c86824a-0b7c-48a6-894e-646c67fe8af3", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "c7d70bff-ad21-4875-adc2-cb48eed8f9b2", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "2a602357-9e35-4ed2-bfbc-3b0f5e12711f", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "02f51724-f598-4c82-8735-79c890c60f2a", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "2c824d27-18b2-4e5d-8d74-ae82ff7615ca", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "5c3734dc-ec07-40ae-8da1-d0d134bd1cf5", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "04ff9086-8225-424a-8620-ef1a58ae853c", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "60f49c54-5108-4bc1-963c-2534383a8401", "117368c9-da90-417b-815a-55a3891c9672" },
                    { "9edf75c5-f2cd-401e-8137-de7cd73f0348", "84a7cf74-1232-41cb-af9c-952593cd7089" },
                    { "e3108378-4aa3-4bd0-87f7-854c67b723ec", "117368c9-da90-417b-815a-55a3891c9672" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "RoomId" },
                values: new object[,]
                {
                    { 29, "Light", 6 },
                    { 28, "Sound", 6 },
                    { 27, "AC", 5 },
                    { 26, "Light", 5 },
                    { 23, "TV", 5 },
                    { 24, "Door", 5 },
                    { 22, "Ac", 4 },
                    { 30, "AC", 6 }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "RoomId" },
                values: new object[,]
                {
                    { 21, "Light", 4 },
                    { 25, "Sound", 5 },
                    { 31, "Light", 7 },
                    { 39, "Left Parking", 9 },
                    { 33, "TV", 8 },
                    { 34, "Door", 8 },
                    { 35, "Sound", 8 },
                    { 36, "Light", 8 },
                    { 37, "AC", 8 },
                    { 38, "Garage Security", 9 },
                    { 40, "Right Parking", 9 },
                    { 41, "Garage Door", 9 },
                    { 42, "Garage Light", 9 },
                    { 20, "Sound", 4 },
                    { 32, "Door", 7 },
                    { 19, "Door", 4 },
                    { 2, "Home Door", 1 },
                    { 17, "AC", 3 },
                    { 1, "Home Security", 1 },
                    { 43, "Water Tank", 10 },
                    { 3, "Fire System", 1 },
                    { 4, "Smoke System", 1 },
                    { 18, "TV", 4 },
                    { 6, "Temperature", 1 },
                    { 7, "Humidity", 1 },
                    { 8, "TV", 2 },
                    { 5, "Outdoor Light", 1 },
                    { 10, "Sound", 2 },
                    { 11, "Light", 2 },
                    { 12, "AC", 2 },
                    { 13, "TV", 3 },
                    { 14, "Door", 3 },
                    { 15, "Sound", 3 },
                    { 16, "Light", 3 },
                    { 9, "Door", 2 },
                    { 44, "Irrigation System", 10 }
                });

            migrationBuilder.InsertData(
                table: "HomeUser_Status",
                columns: new[] { "Id", "HomeUserId", "Status", "StatusDateTime" },
                values: new object[,]
                {
                    { 7, 7, true, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified) },
                    { 6, 6, false, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified) },
                    { 5, 5, false, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified) },
                    { 4, 4, false, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified) },
                    { 3, 3, true, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified) },
                    { 2, 2, true, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HomeUser_Status",
                columns: new[] { "Id", "HomeUserId", "Status", "StatusDateTime" },
                values: new object[] { 1, 1, true, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Devices_Status",
                columns: new[] { "Id", "DeviceId", "ModifyDateTime", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 23, 23, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 24, 24, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 25, 25, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 70 },
                    { 26, 26, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 80 },
                    { 27, 27, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 25 },
                    { 28, 28, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 20 },
                    { 29, 29, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 90 },
                    { 30, 30, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 20 },
                    { 31, 31, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 22, 22, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 18 },
                    { 32, 32, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 34, 34, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 35, 35, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 10 },
                    { 36, 36, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 15 },
                    { 37, 37, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 20 },
                    { 38, 38, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 39, 39, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 40, 40, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 41, 41, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 42, 42, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 33, 33, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 43, 43, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 50 },
                    { 21, 21, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 25 },
                    { 19, 19, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 2, 2, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 3, 3, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 4, 4, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 5, 5, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 6, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 31 },
                    { 7, 7, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 10 },
                    { 8, 8, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 20, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 20 },
                    { 9, 9, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 44, 44, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 90 },
                    { 11, 11, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 90 },
                    { 12, 12, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 22 },
                    { 13, 13, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 14, 14, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 15, 15, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 40 },
                    { 16, 16, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 50 },
                    { 17, 17, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 20 }
                });

            migrationBuilder.InsertData(
                table: "Devices_Status",
                columns: new[] { "Id", "DeviceId", "ModifyDateTime", "Status" },
                values: new object[,]
                {
                    { 18, 18, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 10, 10, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 50 }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "DeviceId", "IsRead", "NotificationBody", "NotificationDate", "NotificationHeader", "Status" },
                values: new object[,]
                {
                    { 3, 4, true, "There is no Smoke in House", new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), "Smoke System", false },
                    { 2, 3, true, "There is no Fire in House", new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), "Fire System", false },
                    { 1, 1, true, "The House is Safe Now", new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), "Home Security", false },
                    { 4, 32, true, "The Garage is Safe Now", new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), "Garage Security", false }
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
                name: "IX_HomeUser_Status_HomeUserId",
                table: "HomeUser_Status",
                column: "HomeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_DeviceId",
                table: "Notification",
                column: "DeviceId");
            // stored procedure
            var SpUsersData = @"CREATE PROCEDURE [dbo].[SpGetUsersData]
                AS
                BEGIN
                   WITH added_row_number AS (SELECT Id, Status, HomeUserId, ROW_NUMBER() OVER(PARTITION BY HomeUserId  ORDER BY Id DESC) AS row_number FROM HomeUser_Status) SELECT * FROM added_row_number WHERE row_number = 1 and Status = 1;
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

            var SpNotification = @"CREATE PROCEDURE [dbo].[SpGetNotifications]
                    AS
                    BEGIN
                        SELECT * from [Notification] WHERE IsRead = 'False' ;
                    END";

            migrationBuilder.Sql(SpNotification);
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
                name: "HomeUser_Status");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HomeUsers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
