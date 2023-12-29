using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testing1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("1e3d6759-deef-4a4f-954b-c61d8579ff71"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("2b621148-9f90-4ee7-b9a8-30ee73677cad"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("c40fe003-8034-407b-bbda-4f5692e06826"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("43a1d7d2-117e-424c-a941-89bb90d9dd65"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("811436cc-fa93-4b12-92ec-684e63ea8277"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("eda8c670-fd88-4b31-b48e-19b682757e40"));

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("1e3d6759-deef-4a4f-954b-c61d8579ff71"), true, "Niklas" },
                    { new Guid("2b621148-9f90-4ee7-b9a8-30ee73677cad"), true, "Johan" },
                    { new Guid("c40fe003-8034-407b-bbda-4f5692e06826"), false, "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("43a1d7d2-117e-424c-a941-89bb90d9dd65"), "Björn" },
                    { new Guid("811436cc-fa93-4b12-92ec-684e63ea8277"), "Patrik" },
                    { new Guid("eda8c670-fd88-4b31-b48e-19b682757e40"), "Alfred" }
                });
        }
    }
}
