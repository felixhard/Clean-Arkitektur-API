using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authorized = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b25affc-56f1-431b-90c4-0d677173facf"), "NewG" },
                    { new Guid("12345678-1234-5678-1234-567812345671"), "TestDogForUnitTests1" },
                    { new Guid("12345678-1234-5678-1234-567812345672"), "TestDogForUnitTests2" },
                    { new Guid("12345678-1234-5678-1234-567812345673"), "TestDogForUnitTests3" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), "TestDogForUnitTests4" },
                    { new Guid("7bd3481a-e6bf-49d6-bfb2-0adfb71eb732"), "OldG" },
                    { new Guid("99e9e37d-6c1b-4a11-80be-a60ab97add4e"), "Patrik" },
                    { new Guid("aa5e96b7-f1a7-4863-9cae-072b2b74725c"), "Alfred" },
                    { new Guid("dd9e7e29-c2ee-48d5-bfea-0ef97b2a87d0"), "Björn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
