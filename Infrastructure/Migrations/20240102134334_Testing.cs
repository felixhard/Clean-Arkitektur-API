using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("0177349a-869c-473f-802c-f46d31e4f3b2"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("630d8d0b-8043-41a7-9fed-ce6ac51f0196"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("70c52e5c-12dd-4473-b305-cadaeae077b6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("974e8700-4e39-453c-8a5d-3b6f72d17cf4"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a65942b7-f95c-418d-8304-85a1b65db937"), "Alfred" },
                    { new Guid("a84e9cd2-9e18-4932-b7d0-d48915f2212d"), "Björn" },
                    { new Guid("f08ca3c6-2d64-4715-b86d-59233bf4d3eb"), "Patrik" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[] { new Guid("f5afe315-e3c2-4db1-872a-4e04cd136ccb"), true, "admin", "admin", null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("a65942b7-f95c-418d-8304-85a1b65db937"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("a84e9cd2-9e18-4932-b7d0-d48915f2212d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("f08ca3c6-2d64-4715-b86d-59233bf4d3eb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5afe315-e3c2-4db1-872a-4e04cd136ccb"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0177349a-869c-473f-802c-f46d31e4f3b2"), "Alfred" },
                    { new Guid("630d8d0b-8043-41a7-9fed-ce6ac51f0196"), "Patrik" },
                    { new Guid("70c52e5c-12dd-4473-b305-cadaeae077b6"), "Björn" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[] { new Guid("974e8700-4e39-453c-8a5d-3b6f72d17cf4"), true, "admin", "admin", null, "admin" });
        }
    }
}
