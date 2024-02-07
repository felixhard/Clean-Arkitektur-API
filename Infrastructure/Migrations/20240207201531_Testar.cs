using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Testar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Dog_Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dog_Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authorized = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalUsers",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalUsers", x => x.Key);
                    table.ForeignKey(
                        name: "FK_AnimalUsers_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345671"), "Golden", "Dog", "TestDogForUnitTests1", 20 },
                    { new Guid("12345678-1234-5678-1234-567812345672"), "Golden", "Dog", "TestDogForUnitTests2", 20 },
                    { new Guid("12345678-1234-5678-1234-567812345673"), "Golden", "Dog", "TestDogForUnitTests3", 20 },
                    { new Guid("12345678-1234-5678-1234-567812345674"), "Golden", "Dog", "TestDogForUnitTests4", 20 },
                    { new Guid("4733fba5-b594-4746-bb80-b5e7d0eabbb4"), "Golden", "Dog", "Patrik", 20 },
                    { new Guid("ae81f78e-6614-483a-92ee-7d84b8226391"), "Golden", "Dog", "Alfred", 20 },
                    { new Guid("c2bae476-b05d-451a-ad52-99db30e440f2"), "Golden", "Dog", "Björn", 20 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("ca9fecd4-15ae-49f0-91e3-ce84bae95174"), true, "admin", "admin", null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_AnimalId",
                table: "AnimalUsers",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_UserId",
                table: "AnimalUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalUsers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
