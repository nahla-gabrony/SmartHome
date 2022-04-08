using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHome.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 32, "Garage Light", 8 },
                    { 31, "Right Parking", 8 },
                    { 30, "Left Parking", 8 },
                    { 29, "Garage Door", 8 },
                    { 28, "Garage Security", 8 },
                    { 27, "Light", 7 },
                    { 26, "Sound", 7 },
                    { 25, "AC", 7 },
                    { 24, "TV", 7 },
                    { 23, "Light", 6 },
                    { 22, "Light", 5 },
                    { 21, "Sound", 5 },
                    { 20, "AC", 5 },
                    { 19, "Light", 4 },
                    { 18, "Sound", 4 },
                    { 17, "AC", 4 },
                    { 16, "TV", 4 },
                    { 2, "Open Door", 1 },
                    { 3, "Fire System", 1 },
                    { 4, "Smoke System", 1 },
                    { 5, "Outdoor Light", 1 },
                    { 6, "Temperature", 1 },
                    { 7, "Humidity", 1 },
                    { 33, "Water Tank", 9 },
                    { 8, "TV", 2 },
                    { 10, "Sound", 2 },
                    { 11, "Light", 2 },
                    { 12, "TV", 3 },
                    { 13, "AC", 3 },
                    { 14, "Sound", 3 },
                    { 15, "Light", 3 },
                    { 9, "AC", 2 },
                    { 34, "Irrigation System", 9 }
                });

            migrationBuilder.InsertData(
                table: "Devices_Status",
                columns: new[] { "Id", "DeviceId", "ModifyDateTime", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 32, 32, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 31, 31, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 30, 30, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 29, 29, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 28, 28, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 27, 27, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 26, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 25, 25, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 24, 24, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 23, 23, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 22, 22, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 21, 21, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 20, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 19, 19, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 18, 18, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 17, 17, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 16, 16, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 2, 2, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 3, 3, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 4, 4, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 5, 5, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 6, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 31 },
                    { 7, 7, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 10 },
                    { 33, 32, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 50 },
                    { 8, 8, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 10, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 11, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 12, 12, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 13, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 14, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 15, 15, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 1 },
                    { 9, 9, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 0 },
                    { 34, 32, new DateTime(2022, 3, 2, 12, 10, 50, 0, DateTimeKind.Unspecified), 90 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Devices_Status",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
