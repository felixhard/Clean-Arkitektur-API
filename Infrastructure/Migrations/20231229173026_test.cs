using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("0b25affc-56f1-431b-90c4-0d677173facf"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("7bd3481a-e6bf-49d6-bfb2-0adfb71eb732"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("99e9e37d-6c1b-4a11-80be-a60ab97add4e"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("aa5e96b7-f1a7-4863-9cae-072b2b74725c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("dd9e7e29-c2ee-48d5-bfea-0ef97b2a87d0"));

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("00045678-1234-5678-1234-567812345671"), true, "TestCatForUnitTests1" },
                    { new Guid("00045678-1234-5678-1234-567812345672"), true, "TestCatForUnitTests2" },
                    { new Guid("00045678-1234-5678-1234-567812345673"), true, "TestCatForUnitTests3" },
                    { new Guid("01223456-1234-5678-1234-567812345674"), true, "TestCatForUnitTests4" },
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

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
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b25affc-56f1-431b-90c4-0d677173facf"), "NewG" },
                    { new Guid("7bd3481a-e6bf-49d6-bfb2-0adfb71eb732"), "OldG" },
                    { new Guid("99e9e37d-6c1b-4a11-80be-a60ab97add4e"), "Patrik" },
                    { new Guid("aa5e96b7-f1a7-4863-9cae-072b2b74725c"), "Alfred" },
                    { new Guid("dd9e7e29-c2ee-48d5-bfea-0ef97b2a87d0"), "Björn" }
                });
        }
    }
}
