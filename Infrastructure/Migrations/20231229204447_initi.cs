using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("00045678-1234-5678-1234-567812345671"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("00045678-1234-5678-1234-567812345672"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("00045678-1234-5678-1234-567812345673"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("01223456-1234-5678-1234-567812345674"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("086150ab-2d83-472a-9737-f73d2ef39dc8"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("989a168c-6ef1-4ba0-9429-98631cda24f2"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("c8d5a82e-43b2-4736-9e8a-de1638287980"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("85115885-8e94-473b-b215-8a9f5b8fc67d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("8b9122ca-f1ac-4fb4-9b8e-d2fca04b028b"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("dbaaa587-9d02-4240-8ae3-53287bbfd18a"));

            migrationBuilder.RenameColumn(
                name: "token",
                table: "Users",
                newName: "Token");

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1c6523f0-49dc-47ed-b1d2-f259a10c8992"), "Patrik" },
                    { new Guid("b249b3db-acd8-498c-ba53-c8c5434dde07"), "Björn" },
                    { new Guid("dbf0e21f-c423-463f-bbf6-5f7502a2047d"), "Alfred" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("6403be78-9916-40cd-83a2-6fcab6c04f14"), true, "admin", "admin", null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("1c6523f0-49dc-47ed-b1d2-f259a10c8992"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("b249b3db-acd8-498c-ba53-c8c5434dde07"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("dbf0e21f-c423-463f-bbf6-5f7502a2047d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345674"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6403be78-9916-40cd-83a2-6fcab6c04f14"));

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "token");

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("00045678-1234-5678-1234-567812345671"), true, "TestCatForUnitTests1" },
                    { new Guid("00045678-1234-5678-1234-567812345672"), true, "TestCatForUnitTests2" },
                    { new Guid("00045678-1234-5678-1234-567812345673"), true, "TestCatForUnitTests3" },
                    { new Guid("01223456-1234-5678-1234-567812345674"), true, "TestCatForUnitTests4" },
                    { new Guid("086150ab-2d83-472a-9737-f73d2ef39dc8"), true, "Niklas" },
                    { new Guid("989a168c-6ef1-4ba0-9429-98631cda24f2"), true, "Johan" },
                    { new Guid("c8d5a82e-43b2-4736-9e8a-de1638287980"), false, "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("85115885-8e94-473b-b215-8a9f5b8fc67d"), "Björn" },
                    { new Guid("8b9122ca-f1ac-4fb4-9b8e-d2fca04b028b"), "Patrik" },
                    { new Guid("dbaaa587-9d02-4240-8ae3-53287bbfd18a"), "Alfred" }
                });
        }
    }
}
